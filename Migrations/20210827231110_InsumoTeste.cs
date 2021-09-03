using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCOREADS2021.Migrations
{
    public partial class InsumoTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "teste",
                table: "Insumos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Insumos");
        }
    }
}
