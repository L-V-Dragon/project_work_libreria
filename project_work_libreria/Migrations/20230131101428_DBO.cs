using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class DBO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Foprnitore_FornitoreId",
                table: "Libri");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordine_Foprnitore_FornitoreId",
                table: "Ordine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foprnitore",
                table: "Foprnitore");

            migrationBuilder.RenameTable(
                name: "Foprnitore",
                newName: "Fornitore");

            migrationBuilder.AlterColumn<int>(
                name: "FornitoreId",
                table: "Ordine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Prezzo",
                table: "Ordine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Autore",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Libri",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Libri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Prezzo",
                table: "Libri",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornitore",
                table: "Fornitore",
                column: "Id");

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
                name: "FK_Libri_Fornitore_FornitoreId",
                table: "Libri",
                column: "FornitoreId",
                principalTable: "Fornitore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordine_Fornitore_FornitoreId",
                table: "Ordine",
                column: "FornitoreId",
                principalTable: "Fornitore",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Fornitore_FornitoreId",
                table: "Libri");

            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Genere_GenereId",
                table: "Libri");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordine_Fornitore_FornitoreId",
                table: "Ordine");

            migrationBuilder.DropTable(
                name: "Genere");

            migrationBuilder.DropIndex(
                name: "IX_Libri_GenereId",
                table: "Libri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornitore",
                table: "Fornitore");

            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Ordine");

            migrationBuilder.DropColumn(
                name: "Autore",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "GenereId",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "Isbn",
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

            migrationBuilder.RenameTable(
                name: "Fornitore",
                newName: "Foprnitore");

            migrationBuilder.AlterColumn<int>(
                name: "FornitoreId",
                table: "Ordine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foprnitore",
                table: "Foprnitore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Foprnitore_FornitoreId",
                table: "Libri",
                column: "FornitoreId",
                principalTable: "Foprnitore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordine_Foprnitore_FornitoreId",
                table: "Ordine",
                column: "FornitoreId",
                principalTable: "Foprnitore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
