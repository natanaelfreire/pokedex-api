using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Models.DatabaseModels
{
    [Table("pokemon")]
    public class Pokemon
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("id_integracao")]
        public int IntegracaoId { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("pontos_vida")]
        public int PontosVida { get; set; }

        [Column("pontos_ataque")]
        public int PontosAtaque { get; set; }

        [Column("pontos_defesa")]
        public int PontosDefesa { get; set; }

        [Column("base64")]
        public string Base64 { get; set; }

        [Column("tipos")]
        public string Tipos { get; set; }

        [Column("evolucoes")]
        public string Evolucoes { get; set; }
    }
}