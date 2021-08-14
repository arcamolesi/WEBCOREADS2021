using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCOREADS2021.Migrations
{
    public partial class Anotacoes_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Agricultores_produtorid",
                table: "Areas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agricultores",
                table: "Agricultores");

            migrationBuilder.RenameTable(
                name: "Agricultores",
                newName: "Agricultor");

            migrationBuilder.AlterColumn<string>(
                name: "proprietario",
                table: "Agricultor",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agricultor",
                table: "Agricultor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Agricultor_produtorid",
                table: "Areas",
                column: "produtorid",
                principalTable: "Agricultor",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Agricultor_produtorid",
                table: "Areas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agricultor",
                table: "Agricultor");

            migrationBuilder.RenameTable(
                name: "Agricultor",
                newName: "Agricultores");

            migrationBuilder.AlterColumn<string>(
                name: "proprietario",
                table: "Agricultores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agricultores",
                table: "Agricultores",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Agricultores_produtorid",
                table: "Areas",
                column: "produtorid",
                principalTable: "Agricultores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
