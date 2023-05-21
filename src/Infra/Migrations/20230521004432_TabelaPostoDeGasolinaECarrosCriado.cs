using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPostoDeGasolinaECarrosCriado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostoDeGasolina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeBombas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostoDeGasolina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCarro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoAbastecimento = table.Column<int>(type: "int", nullable: false),
                    PostoDeGasolinaId = table.Column<int>(type: "int", nullable: true),
                    PostoDeGasolinaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carros_PostoDeGasolina_PostoDeGasolinaId",
                        column: x => x.PostoDeGasolinaId,
                        principalTable: "PostoDeGasolina",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carros_PostoDeGasolina_PostoDeGasolinaId1",
                        column: x => x.PostoDeGasolinaId1,
                        principalTable: "PostoDeGasolina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_PostoDeGasolinaId",
                table: "Carros",
                column: "PostoDeGasolinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Carros_PostoDeGasolinaId1",
                table: "Carros",
                column: "PostoDeGasolinaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "PostoDeGasolina");
        }
    }
}
