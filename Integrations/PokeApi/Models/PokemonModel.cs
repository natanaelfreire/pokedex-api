namespace PokedexApi.Integrations.PokeApi.Models
{
    public class PokemonModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public Sprites sprites { get; set; }
        public List<TypeItem> types { get; set; }
        public List<StatItem> stats { get; set; }
    }

    public class Sprites
    {
        public string front_default { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
    }

    public class TypeItem
    {
        public int slot { get; set; }
        public Type type { get; set; }
    }

    public class Stat
    {
        public string name { get; set; }
    }

    public class StatItem {
        public int base_stat { get; set; }
        public Stat stat { get; set; }
    }
}