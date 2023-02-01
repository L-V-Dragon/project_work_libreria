using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class addedtableOrdiniId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prezzo",
                table: "Ordine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdineClienteId",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrdineCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdineCliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_OrdineClienteId",
                table: "Libri",
                column: "OrdineClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_OrdineCliente_OrdineClienteId",
                table: "Libri",
                column: "OrdineClienteId",
                principalTable: "OrdineCliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_OrdineCliente_OrdineClienteId",
                table: "Libri");

            migrationBuilder.DropTable(
                name: "OrdineCliente");

            migrationBuilder.DropIndex(
                name: "IX_Libri_OrdineClienteId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Ordine");

            migrationBuilder.DropColumn(
                name: "OrdineClienteId",
                table: "Libri");
        }
    }
}
