using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class ToltonulloGenereId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri");

            migrationBuilder.AlterColumn<int>(
                name: "GenereId",
                table: "Libri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id");
        }
    }
}
