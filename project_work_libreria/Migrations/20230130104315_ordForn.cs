using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class ordForn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FornitoreId",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdineId",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Foprnitore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foprnitore", x => x.Id);
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
                        name: "FK_Ordine_Foprnitore_FornitoreId",
                        column: x => x.FornitoreId,
                        principalTable: "Foprnitore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_FornitoreId",
                table: "Libri",
                column: "FornitoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_OrdineId",
                table: "Libri",
                column: "OrdineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_FornitoreId",
                table: "Ordine",
                column: "FornitoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Foprnitore_FornitoreId",
                table: "Libri",
                column: "FornitoreId",
                principalTable: "Foprnitore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Ordine_OrdineId",
                table: "Libri",
                column: "OrdineId",
                principalTable: "Ordine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Foprnitore_FornitoreId",
                table: "Libri");

            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Ordine_OrdineId",
                table: "Libri");

            migrationBuilder.DropTable(
                name: "Ordine");

            migrationBuilder.DropTable(
                name: "Foprnitore");

            migrationBuilder.DropIndex(
                name: "IX_Libri_FornitoreId",
                table: "Libri");

            migrationBuilder.DropIndex(
                name: "IX_Libri_OrdineId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "FornitoreId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "OrdineId",
                table: "Libri");
        }
    }
}
