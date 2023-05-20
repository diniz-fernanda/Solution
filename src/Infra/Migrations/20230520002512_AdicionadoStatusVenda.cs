using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoStatusVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Vendido",
                table: "Produtos",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Vendido",
                table: "Produtos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
