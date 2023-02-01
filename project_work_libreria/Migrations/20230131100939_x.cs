using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class x : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornitore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornitore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FornitoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordine_Fornitore_FornitoreId",
                        column: x => x.FornitoreId,
                        principalTable: "Fornitore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: true),
                    Like = table.Column<int>(type: "int", nullable: true),
                    GenereId = table.Column<int>(type: "int", nullable: true),
                    FornitoreId = table.Column<int>(type: "int", nullable: true),
                    OrdineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libri_Fornitore_FornitoreId",
                        column: x => x.FornitoreId,
                        principalTable: "Fornitore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Libri_Genere_GenereId",
                        column: x => x.GenereId,
                        principalTable: "Genere",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Libri_Ordine_OrdineId",
                        column: x => x.OrdineId,
                        principalTable: "Ordine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_FornitoreId",
                table: "Libri",
                column: "FornitoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_GenereId",
                table: "Libri",
                column: "GenereId");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_OrdineId",
                table: "Libri",
                column: "OrdineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_FornitoreId",
                table: "Ordine",
                column: "FornitoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libri");

            migrationBuilder.DropTable(
                name: "Genere");

            migrationBuilder.DropTable(
                name: "Ordine");

            migrationBuilder.DropTable(
                name: "Fornitore");
        }
    }
}
