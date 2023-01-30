using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class correttonomeisbminisbn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isbm",
                table: "Libri",
                newName: "Isbn");

            migrationBuilder.AlterColumn<int>(
                name: "Quantita",
                table: "Libri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Libri",
                newName: "Isbm");

            migrationBuilder.AlterColumn<int>(
                name: "Quantita",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
