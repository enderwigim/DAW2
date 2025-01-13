using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiluTienda.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrecioCadena",
                table: "Variantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioCadena",
                table: "Variantes");
        }
    }
}
