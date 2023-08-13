using PokedexApi.DTOs;
using PokedexApi.Models.DatabaseModels;

namespace PokedexApi.Interfaces
{
    public interface IMestrePokemonService
    {
        Task<bool> CreateAsync(InputMestreDTO dto);
        Task<int> UpdateAsync(InputMestreDTO dto);
        Task<bool> DeleteByIdAsync(int id);
        Task<List<MestreDTO>> ListAsync();
        Task<MestreDTO> GetItemAsync(int id);
        Task<Mestre> GetByIdAsync(int id);
        Task<bool> CapturaPokemon(int id, string pokemonName);
    }
}