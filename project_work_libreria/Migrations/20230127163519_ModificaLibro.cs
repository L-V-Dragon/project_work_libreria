using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class ModificaLibro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri");

            migrationBuilder.AlterColumn<int>(
                name: "Quantita",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Prezzo",
                table: "Libri",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenereId",
                table: "Libri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Autore",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Isbm",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Autore",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Isbm",
                table: "Libri");

            migrationBuilder.AlterColumn<int>(
                name: "Quantita",
                table: "Libri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Prezzo",
                table: "Libri",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "GenereId",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
