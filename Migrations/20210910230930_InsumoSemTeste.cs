using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCOREADS2021.Migrations
{
    public partial class InsumoSemTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "teste",
                table: "Insumos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "teste",
                table: "Insumos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
