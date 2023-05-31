using Microsoft.EntityFrameworkCore;
using Sudoku.Models;

namespace Sudoku.Data
{
    public class SudokuContext : DbContext
    {
        public SudokuContext (DbContextOptions<SudokuContext> options)
            : base(options)
        {
        }

        public DbSet<SudokuModel> SudokuModel { get; set; } = default!;
    }
}
