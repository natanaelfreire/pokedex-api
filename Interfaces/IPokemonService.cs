using PokedexApi.DTOs;
using PokedexApi.Models.DatabaseModels;

namespace PokedexApi.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonDTO> GetItemAsync(string nome);
        Task<Pokemon> GetByNameAsync(string nome);
        Task<Pokemon> CreateAsync(InputPokemonDTO dto, bool verifica = true);
        Task<List<PokemonDTO>> GetRandomPokemons(int qtd);
        Task<List<PokemonDTO>> GetPokemonsByMestreId(int mestreId);
    }
}