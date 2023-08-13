using Microsoft.EntityFrameworkCore;
using PokedexApi.Models.DatabaseModels;

namespace PokedexApi
{
    public class Context : DbContext
    {
        public string DbPath { get; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            DbPath = "sqlite.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public DbSet<Mestre> Mestre { get; set; }        
        public DbSet<Pokemon> Pokemon { get; set; }        
        public DbSet<MestrePokemons> MestrePokemons { get; set; }        
    }
}