namespace PokedexApi.DTOs
{
    public class InputPokemonDTO
    {
        public int? IntegracaoId { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public int? PontosVida { get; set; } = null;
        public int? PontosAtaque { get; set; } = null;
        public int? PontosDefesa { get; set; } = null;
        public string Base64 { get; set; } = string.Empty;
        public List<string> Tipos { get; set; }
        public List<string> Evolucoes { get; set; }
    }
}