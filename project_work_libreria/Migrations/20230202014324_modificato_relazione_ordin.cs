using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class modificatorelazioneordin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibroOrdine_Libri_LibriId",
                table: "LibroOrdine");

            migrationBuilder.RenameColumn(
                name: "LibriId",
                table: "LibroOrdine",
                newName: "ListaLibriId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibroOrdine_Libri_ListaLibriId",
                table: "LibroOrdine",
                column: "ListaLibriId",
                principalTable: "Libri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibroOrdine_Libri_ListaLibriId",
                table: "LibroOrdine");

            migrationBuilder.RenameColumn(
                name: "ListaLibriId",
                table: "LibroOrdine",
                newName: "LibriId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibroOrdine_Libri_LibriId",
                table: "LibroOrdine",
                column: "LibriId",
                principalTable: "Libri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
