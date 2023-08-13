namespace PokedexApi.DTOs
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        public int IntegracaoId { get; set; }
        public string Nome { get; set; }
        public int PontosVida { get; set; }
        public int PontosAtaque { get; set; }
        public int PontosDefesa { get; set; }
        public string Base64 { get; set; }
        public List<string> Tipos { get; set; }
        public List<string> Evolucoes { get; set; }
    }
}