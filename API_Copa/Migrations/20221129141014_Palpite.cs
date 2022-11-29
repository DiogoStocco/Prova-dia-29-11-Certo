using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Copa.Migrations
{
    public partial class Palpite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Selecoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    placar = table.Column<int>(type: "INTEGER", nullable: false),
                    placarB = table.Column<int>(type: "INTEGER", nullable: false),
                    selecaoAId = table.Column<int>(type: "INTEGER", nullable: false),
                    selecaoBId = table.Column<int>(type: "INTEGER", nullable: false),
                    gol = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Selecoes_selecaoAId",
                        column: x => x.selecaoAId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_Selecoes_selecaoBId",
                        column: x => x.selecaoBId,
                        principalTable: "Selecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_selecaoAId",
                table: "Jogos",
                column: "selecaoAId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_selecaoBId",
                table: "Jogos",
                column: "selecaoBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Selecoes");
        }
    }
}
