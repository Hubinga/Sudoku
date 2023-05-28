using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Sudoku.Models.SudokuModel> SudokuModel { get; set; } = default!;
    }
}
