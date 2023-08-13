namespace PokedexApi.Integrations.PokeApi.Models
{
    public class EvolutionChainModel
    {
        public Chain chain { get; set; }
    }

    public class Chain 
    {
        public List<Chain> evolves_to { get; set; }
        public Species species { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
    }
}