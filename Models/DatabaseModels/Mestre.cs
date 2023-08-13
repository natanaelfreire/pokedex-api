using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Models.DatabaseModels
{
    [Table("mestre")]
    public class Mestre
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }
        
        [Column("idade")]
        public int Idade { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }
    }
}