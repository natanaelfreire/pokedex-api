using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokedexApi.DTOs;
using PokedexApi.Integrations.PokeApi;
using PokedexApi.Interfaces;
using PokedexApi.Models.DatabaseModels;

namespace PokedexApi.Services
{
    public class MestrePokemonService : IMestrePokemonService
    {
        private readonly Context _context;
        private readonly IPokemonService _pokemonService;

        public MestrePokemonService(Context context, IPokemonService pokemonService)
        {
            _context = context;
            _pokemonService = pokemonService;
        }

        public MestreDTO ConvertToDTO(Mestre item)
        {
            return new MestreDTO {
                Id = item.Id,
                Cpf = item.Cpf,
                Idade = item.Idade,
                Nome = item.Nome,
            };
        }

        public async Task ValidaInput(InputMestreDTO dto) 
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new Exception("Preencha corretamente o campo 'Nome'");
            else
            {
                var qtdRepetidos = await _context.Mestre.Where(x => x.Nome == dto.Nome && x.Id != dto.Id).CountAsync();

                if (qtdRepetidos > 0)
                    throw new Exception("Já existe um registro com esse mesmo nome");
            }

            if (dto.Idade <= 0)
                throw new Exception("Idade deve ser maior que zero");
        }

        public async Task<bool> CreateAsync(InputMestreDTO dto)
        {
            await ValidaInput(dto);

            var mestre = new Mestre();

            mestre.Nome = dto.Nome;
            mestre.Idade =  dto.Idade.Value;
            mestre.Cpf = dto.Cpf;

            _context.Mestre.Add(mestre);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var mestre = await GetByIdAsync(id);
            _context.Mestre.Remove(mestre);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Mestre> GetByIdAsync(int id)
        {
            var mestre = await _context.Mestre.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (mestre == null)
                throw new Exception("Item não encontrado.");

            return mestre;
        }

        public async Task<MestreDTO> GetItemAsync(int id)
        {
            var item = await GetByIdAsync(id);

            return ConvertToDTO(item);
        }

        public async Task<List<MestreDTO>> ListAsync()
        {
            var lista = await _context.Mestre.ToListAsync();

            return lista.Select(x => ConvertToDTO(x)).ToList();
        }

        public async Task<int> UpdateAsync(InputMestreDTO dto)
        {
            await ValidaInput(dto);

            var mestre = await GetByIdAsync(dto.Id.Value);

            mestre.Nome = dto.Nome;
            mestre.Idade = dto.Idade.Value;
            mestre.Cpf = dto.Cpf;

            return mestre.Id;
        }

        public async Task<bool> CapturaPokemon(int id, string pokemonName)
        {
            pokemonName = pokemonName.Trim();
            pokemonName = pokemonName.ToLower();
            int idPokemon;
            var pokemon = await _pokemonService.GetByNameAsync(pokemonName);

            if (pokemon == null)
            {
                var integracaoPokemon = await PokeApiIntegration.GetPokemonName(pokemonName);

                if (integracaoPokemon != null)
                {
                    pokemon = await _pokemonService.CreateAsync(new InputPokemonDTO {
                    Base64 = integracaoPokemon.Base64,
                    Evolucoes = integracaoPokemon.Evolucoes,
                    IntegracaoId = integracaoPokemon.Id,
                    Nome = integracaoPokemon.Nome,
                    PontosAtaque = integracaoPokemon.PontosAtaque,
                    PontosDefesa = integracaoPokemon.PontosDefesa,
                    PontosVida = integracaoPokemon.PontosVida,
                    Tipos = integracaoPokemon.Tipos,
                },
                    verifica: false);

                    idPokemon = pokemon.Id;
                }
                else
                    throw new Exception("Pokemon não encontrado");                
            }
            else
                idPokemon = pokemon.Id;

            var mestrePokemon = new MestrePokemons {
                MestreId = id,
                PokemonId = idPokemon
            };

            _context.MestrePokemons.Add(mestrePokemon);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}