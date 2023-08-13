using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokedexApi.DTOs;
using PokedexApi.Integrations.PokeApi;
using PokedexApi.Interfaces;
using PokedexApi.Models.DatabaseModels;

namespace PokedexApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly Context _context;

        private const int MAX_NUMBER_IDS_OF_POKEMONS = 1010;

        public PokemonService(Context context)
        {
            _context = context;
        }

        public PokemonDTO ConvertToDTO(Pokemon item)
        {
            return new PokemonDTO {
                Id = item.Id,
                IntegracaoId = item.IntegracaoId,
                Nome = item.Nome,
                Base64 = item.Base64,
                PontosAtaque = item.PontosAtaque,
                PontosDefesa = item.PontosDefesa,
                PontosVida = item.PontosVida,
                Evolucoes = JsonSerializer.Deserialize<List<string>>(item.Evolucoes),
                Tipos = JsonSerializer.Deserialize<List<string>>(item.Tipos)
            };
        }

        public async Task<Pokemon> CreateAsync(InputPokemonDTO dto, bool verifica = true)
        {
            if (verifica) 
            {
                var jaExiste = await _context.Pokemon.Where(x => x.IntegracaoId == dto.IntegracaoId).FirstOrDefaultAsync();

                if (jaExiste != null) return jaExiste;
            }            

            var pokemon = new Pokemon {
                IntegracaoId = dto.IntegracaoId.Value,
                Base64 = dto.Base64,
                Evolucoes = JsonSerializer.Serialize(dto.Evolucoes),
                Tipos = JsonSerializer.Serialize(dto.Tipos),
                Nome = dto.Nome,
                PontosAtaque = dto.PontosAtaque.Value,
                PontosDefesa = dto.PontosDefesa.Value,
                PontosVida = dto.PontosVida.Value
            };

            _context.Pokemon.Add(pokemon);

            await _context.SaveChangesAsync();

            return pokemon;
        }

        public async Task<Pokemon> GetByNameAsync(string nome)
        {
            nome = nome.Trim();
            nome = nome.ToLower();
            
            var pokemon = await _context.Pokemon.Where(x => x.Nome == nome).FirstOrDefaultAsync();

            return pokemon;
        }

        public async Task<PokemonDTO> GetItemAsync(string nome)
        {
            nome = nome.Trim();
            nome = nome.ToLower();
            
            var pokemon = await GetByNameAsync(nome);

            if (pokemon == null)
            {
                var integracaoPokemon = await PokeApiIntegration.GetPokemonName(nome);

                pokemon = await CreateAsync(new InputPokemonDTO {
                    Base64 = integracaoPokemon.Base64,
                    IntegracaoId = integracaoPokemon.Id,
                    Nome = integracaoPokemon.Nome,
                    PontosAtaque = integracaoPokemon.PontosAtaque,
                    PontosDefesa = integracaoPokemon.PontosDefesa,
                    PontosVida = integracaoPokemon.PontosVida,
                    Evolucoes = integracaoPokemon.Evolucoes,
                    Tipos = integracaoPokemon.Tipos,
                },
                    verifica: false);
            }

            return ConvertToDTO(pokemon);
        }

        public async Task<List<PokemonDTO>> GetPokemonsByMestreId(int mestreId)
        {
            var lista = await _context.MestrePokemons
                                    .Include(x => x.Pokemon)
                                    .Where(x => x.MestreId == mestreId)
                                    .Select(x => x.Pokemon)
                                    .ToListAsync();

            return lista.Select(x => ConvertToDTO(x)).ToList();                                
        }

        public async Task<List<PokemonDTO>> GetRandomPokemons(int qtd)
        {
            Random r = new Random();
            var randomIds = new List<int>();
            int i = 0;

            while (i < qtd)
            {
                int randomInt = r.Next(1, MAX_NUMBER_IDS_OF_POKEMONS);

                if (!randomIds.Contains(randomInt))
                {
                    randomIds.Add(randomInt);
                    i++;
                }
            }

            List<Pokemon> lista = await _context.Pokemon
                                    .Where(x => randomIds.Contains(x.IntegracaoId))
                                    .ToListAsync();

            var pokemonsSalvosIds = lista
                                    .Select(x => x.IntegracaoId)
                                    .ToList();

            foreach (var id in randomIds.Where(x => !pokemonsSalvosIds.Contains(x)).ToList())
            {
                var integracaoPokemon = await PokeApiIntegration.GetPokemonById(id);

                var pokemon = await CreateAsync(new InputPokemonDTO {
                    Base64 = integracaoPokemon.Base64,
                    IntegracaoId = integracaoPokemon.Id,
                    Nome = integracaoPokemon.Nome,
                    PontosAtaque = integracaoPokemon.PontosAtaque,
                    PontosDefesa = integracaoPokemon.PontosDefesa,
                    PontosVida = integracaoPokemon.PontosVida,
                    Evolucoes = integracaoPokemon.Evolucoes,
                    Tipos = integracaoPokemon.Tipos,
                },
                    verifica: false);

                lista.Add(pokemon);
            }

            return lista.Select(x => ConvertToDTO(x)).ToList();
        }
    }
}