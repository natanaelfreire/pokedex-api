using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Models.DatabaseModels
{
    [Table("mestre_pokemons")]
    public class MestrePokemons
    {
        [Column("id")]
        public int Id { get; set; }

        public Mestre Mestre { get; set; }

        [Column("id_mestre")]
        public int MestreId { get; set; }

        public Pokemon Pokemon { get; set; }

        [Column("id_pokemon")]
        public int PokemonId { get; set; }
    }
}