namespace PokedexApi.Integrations.PokeApi.Models
{
    public class PokemonSpeciesModel
    {
        public EvolutionChainUrl evolution_chain { get; set; }
    }

    public class EvolutionChainUrl
    {
        public string url { get; set; }
    }
}