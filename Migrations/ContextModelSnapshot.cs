﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokedexApi;

#nullable disable

namespace PokedexApi.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("PokedexApi.Models.DatabaseModels.Mestre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT")
                        .HasColumnName("cpf");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER")
                        .HasColumnName("idade");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("mestre");
                });

            modelBuilder.Entity("PokedexApi.Models.DatabaseModels.MestrePokemons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("MestreId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_mestre");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_pokemon");

                    b.HasKey("Id");

                    b.HasIndex("MestreId");

                    b.HasIndex("PokemonId");

                    b.ToTable("mestre_pokemons");
                });

            modelBuilder.Entity("PokedexApi.Models.DatabaseModels.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Base64")
                        .HasColumnType("TEXT")
                        .HasColumnName("base64");

                    b.Property<string>("Evolucoes")
                        .HasColumnType("TEXT")
                        .HasColumnName("evolucoes");

                    b.Property<int>("IntegracaoId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_integracao");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT")
                        .HasColumnName("nome");

                    b.Property<int>("PontosAtaque")
                        .HasColumnType("INTEGER")
                        .HasColumnName("pontos_ataque");

                    b.Property<int>("PontosDefesa")
                        .HasColumnType("INTEGER")
                        .HasColumnName("pontos_defesa");

                    b.Property<int>("PontosVida")
                        .HasColumnType("INTEGER")
                        .HasColumnName("pontos_vida");

                    b.Property<string>("Tipos")
                        .HasColumnType("TEXT")
                        .HasColumnName("tipos");

                    b.HasKey("Id");

                    b.ToTable("pokemon");
                });

            modelBuilder.Entity("PokedexApi.Models.DatabaseModels.MestrePokemons", b =>
                {
                    b.HasOne("PokedexApi.Models.DatabaseModels.Mestre", "Mestre")
                        .WithMany()
                        .HasForeignKey("MestreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokedexApi.Models.DatabaseModels.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mestre");

                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
