namespace PokedexApi.Integrations.PokeApi.Models
{
    public class ResponsePokemonModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosDefesa { get; set; }
        public string Base64 { get; set; }
        public List<string> Tipos { get; set; }
        public List<string> Evolucoes { get; set; }
    }
}