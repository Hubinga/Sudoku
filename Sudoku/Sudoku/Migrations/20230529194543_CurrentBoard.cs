using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sudoku.Migrations
{
    /// <inheritdoc />
    public partial class CurrentBoard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Board",
                table: "SudokuModel",
                newName: "CurrentBoard");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "SudokuModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentBoard",
                table: "SudokuModel",
                newName: "Board");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "SudokuModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
