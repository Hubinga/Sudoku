using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sudoku.Migrations
{
    /// <inheritdoc />
    public partial class Help : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Help",
                table: "SudokuModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Help",
                table: "SudokuModel");
        }
    }
}
