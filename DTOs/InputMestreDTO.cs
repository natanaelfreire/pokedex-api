namespace PokedexApi.DTOs
{
    public class InputMestreDTO
    {
        public int? Id { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public int? Idade { get; set; } = null;
        public string Cpf { get; set; } = string.Empty;
    }
}