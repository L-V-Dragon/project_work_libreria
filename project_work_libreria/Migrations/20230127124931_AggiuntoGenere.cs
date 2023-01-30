using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntoGenere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenereId",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Prezzo",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantita",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titolo",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Trama",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Libri_GenereId",
                table: "Libri",
                column: "GenereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri");

            migrationBuilder.DropTable(
                name: "Genere");

            migrationBuilder.DropIndex(
                name: "IX_Libri_GenereId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "GenereId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Quantita",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Titolo",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Trama",
                table: "Libri");
        }
    }
}
