using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PokedexApi.Integrations.PokeApi.Models;
using PokedexApi.Models.DatabaseModels;
using PokedexApi.Utils;

namespace PokedexApi.Integrations.PokeApi
{
    public static class PokeApiIntegration
    {
        private const string BASE_URL = "https://pokeapi.co/api/v2/";

        private static List<string> PokemonEvolutions(Chain chain, List<string> evolutions = null)
        {
            if (evolutions == null)
                evolutions = new List<string>();

            evolutions.Add(chain.species.name);

            if (chain.evolves_to != null && chain.evolves_to.Count > 0)
            {
                foreach (var item in chain.evolves_to)
                    PokemonEvolutions(item, evolutions);
            }                

            return evolutions;
        }

        public static async Task<ResponsePokemonModel> GetPokemonById(int id)
        {
            var url = BASE_URL + $"pokemon/{id}";
            var pokemon = await HttpRequestUtils.Get<PokemonModel>(url);

            ResponsePokemonModel resp = new();

            resp.Id = pokemon.id;
            resp.Nome = pokemon.name;
            resp.Tipos = pokemon.types.Select(x => x.type.name).ToList();
            resp.PontosVida = pokemon.stats.Where(x => x.stat.name == "hp").Select(x => x.base_stat).FirstOrDefault();
            resp.PontosAtaque = pokemon.stats.Where(x => x.stat.name == "attack").Select(x => x.base_stat).FirstOrDefault();
            resp.PontosDefesa = pokemon.stats.Where(x => x.stat.name == "defense").Select(x => x.base_stat).FirstOrDefault();

            resp.Base64 = await HttpRequestUtils.GetBase64FromURL(pokemon.sprites.front_default); 
            resp.Evolucoes = await GetEvolutionsByPokemonId(id);

            return resp;
        }

        public static async Task<ResponsePokemonModel> GetPokemonName(string name)
        {
            var url = BASE_URL + $"pokemon/{name}";
            var pokemon = await HttpRequestUtils.Get<PokemonModel>(url);

            if (pokemon != null) {
                ResponsePokemonModel resp = new();

                resp.Id = pokemon.id;
                resp.Nome = pokemon.name;
                resp.Tipos = pokemon.types.Select(x => x.type.name).ToList();
                resp.PontosVida = pokemon.stats.Where(x => x.stat.name == "hp").Select(x => x.base_stat).FirstOrDefault();
                resp.PontosAtaque = pokemon.stats.Where(x => x.stat.name == "attack").Select(x => x.base_stat).FirstOrDefault();
                resp.PontosDefesa = pokemon.stats.Where(x => x.stat.name == "defense").Select(x => x.base_stat).FirstOrDefault();

                resp.Base64 = await HttpRequestUtils.GetBase64FromURL(pokemon.sprites.front_default); 
                resp.Evolucoes = await GetEvolutionsByPokemonId(pokemon.id);

                return resp;
            }
            else
                return  null;            
        }

        public static async Task<List<string>> GetEvolutionsByPokemonId(int id)
        {
            var especies = await GetSpeciesByPokemonId(id);
            var evolutionChain = await HttpRequestUtils.Get<EvolutionChainModel>(especies.evolution_chain.url);
            var evolutions = PokemonEvolutions(evolutionChain.chain);

            return evolutions;
        }

        public static async Task<PokemonSpeciesModel> GetSpeciesByPokemonId(int id)
        {
            var url = BASE_URL + $"pokemon-species/{id}";
            var resp = await HttpRequestUtils.Get<PokemonSpeciesModel>(url);

            return resp;
        }
    }
}
