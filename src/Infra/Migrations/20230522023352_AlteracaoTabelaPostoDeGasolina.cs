using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoTabelaPostoDeGasolina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carros_PostoDeGasolina_PostoDeGasolinaId1",
                table: "Carros");

            migrationBuilder.DropIndex(
                name: "IX_Carros_PostoDeGasolinaId1",
                table: "Carros");

            migrationBuilder.DropColumn(
                name: "PostoDeGasolinaId1",
                table: "Carros");

            migrationBuilder.AddColumn<bool>(
                name: "BombaOcupada",
                table: "PostoDeGasolina",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomeCombustivel",
                table: "PostoDeGasolina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "PostoDeGasolina",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Vendido",
                table: "PostoDeGasolina",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BombaOcupada",
                table: "PostoDeGasolina");

            migrationBuilder.DropColumn(
                name: "NomeCombustivel",
                table: "PostoDeGasolina");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "PostoDeGasolina");

            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "PostoDeGasolina");

            migrationBuilder.AddColumn<int>(
                name: "PostoDeGasolinaId1",
                table: "Carros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carros_PostoDeGasolinaId1",
                table: "Carros",
                column: "PostoDeGasolinaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carros_PostoDeGasolina_PostoDeGasolinaId1",
                table: "Carros",
                column: "PostoDeGasolinaId1",
                principalTable: "PostoDeGasolina",
                principalColumn: "Id");
        }
    }
}
