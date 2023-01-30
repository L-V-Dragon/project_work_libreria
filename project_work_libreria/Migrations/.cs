using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectworklibreria.Migrations
{
    /// <inheritdoc />
    public partial class NewGenere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewGenere",
                table: "Genere",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewGenere",
                table: "Genere");
        }
    }
}
