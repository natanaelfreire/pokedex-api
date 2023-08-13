using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokedexApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mestre",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    idade = table.Column<int>(type: "INTEGER", nullable: false),
                    cpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mestre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_integracao = table.Column<int>(type: "INTEGER", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    pontos_vida = table.Column<int>(type: "INTEGER", nullable: false),
                    pontos_ataque = table.Column<int>(type: "INTEGER", nullable: false),
                    pontos_defesa = table.Column<int>(type: "INTEGER", nullable: false),
                    base64 = table.Column<string>(type: "TEXT", nullable: true),
                    tipos = table.Column<string>(type: "TEXT", nullable: true),
                    evolucoes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mestre_pokemons",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_mestre = table.Column<int>(type: "INTEGER", nullable: false),
                    id_pokemon = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mestre_pokemons", x => x.id);
                    table.ForeignKey(
                        name: "FK_mestre_pokemons_mestre_id_mestre",
                        column: x => x.id_mestre,
                        principalTable: "mestre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mestre_pokemons_pokemon_id_pokemon",
                        column: x => x.id_pokemon,
                        principalTable: "pokemon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mestre_pokemons_id_mestre",
                table: "mestre_pokemons",
                column: "id_mestre");

            migrationBuilder.CreateIndex(
                name: "IX_mestre_pokemons_id_pokemon",
                table: "mestre_pokemons",
                column: "id_pokemon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mestre_pokemons");

            migrationBuilder.DropTable(
                name: "mestre");

            migrationBuilder.DropTable(
                name: "pokemon");
        }
    }
}
