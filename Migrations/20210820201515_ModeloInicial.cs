using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBCOREADS2021.Migrations
{
    public partial class ModeloInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agricultores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proprietario = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    idade = table.Column<int>(type: "Int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    tipoinsumo = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<double>(type: "float", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtorID = table.Column<int>(type: "int", nullable: false),
                    hectares = table.Column<double>(type: "float", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    gps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Areas_Agricultores_produtorID",
                        column: x => x.produtorID,
                        principalTable: "Agricultores",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "InsumosArea",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    areaID = table.Column<int>(type: "int", nullable: false),
                    insumoID = table.Column<int>(type: "int", nullable: false),
                    data = table.Column<DateTime>(type: "Date", nullable: false),
                    quantidade = table.Column<double>(type: "float", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumosArea", x => x.id);
                    table.ForeignKey(
                        name: "FK_InsumosArea_Areas_areaID",
                        column: x => x.areaID,
                        principalTable: "Areas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_InsumosArea_Insumos_insumoID",
                        column: x => x.insumoID,
                        principalTable: "Insumos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agricultores_cpf",
                table: "Agricultores",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_produtorID",
                table: "Areas",
                column: "produtorID");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosArea_areaID",
                table: "InsumosArea",
                column: "areaID");

            migrationBuilder.CreateIndex(
                name: "IX_InsumosArea_insumoID",
                table: "InsumosArea",
                column: "insumoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsumosArea");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Agricultores");
        }
    }
}
