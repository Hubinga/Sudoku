using Microsoft.EntityFrameworkCore;
using Sudoku.Data;
using Sudoku.Models;

namespace Sudoku.Classes
{
    public class DbService
    {
        private readonly SudokuContext _context;
        public DbService(SudokuContext context)
        {
            _context = context;
        }
        public async Task<List<SudokuModel>> GetSudokuModelsAsync()
        {
            return await _context.SudokuModel.AsNoTracking().ToListAsync();
        }

		public async Task<SudokuModel?> GetSudokuModelAsync(int id)
		{
			return await _context.SudokuModel.Where(s => s.Id == id).FirstOrDefaultAsync();
		}

		public Task<int> AddSudokuModelAsync(SudokuModel sudokuModel)
        {
            var addedEntry = _context.SudokuModel.Add(sudokuModel);
            _context.SaveChanges();
            //return Id (primary key)
            return Task.FromResult(addedEntry.Entity.Id);
        }

        public Task<bool> UpdateSudokuModelAsync(SudokuModel sudokuModel)
        {
            var existingSudokuModel = _context.SudokuModel.Where(x => x.Id == sudokuModel.Id).FirstOrDefault();

            if (existingSudokuModel != null)
            {
                existingSudokuModel.OriginalBoard = sudokuModel.OriginalBoard;
                existingSudokuModel.Difficulty = sudokuModel.Difficulty;
                existingSudokuModel.Time = sudokuModel.Time;
                existingSudokuModel.Solved = sudokuModel.Solved;
                existingSudokuModel.SolvedBoard = sudokuModel.SolvedBoard;
                existingSudokuModel.CurrentBoard = sudokuModel.CurrentBoard;

                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

		public Task<bool> DeleteSudokuModelAsync(SudokuModel sudokuModel)
		{
			var existingSudokuModel = _context.SudokuModel.Where(x => x.Id == sudokuModel.Id).FirstOrDefault();

			if (existingSudokuModel != null)
			{
				_context.SudokuModel.Remove(existingSudokuModel);
				_context.SaveChanges();
			}
			else
			{
				return Task.FromResult(false);
			}
			return Task.FromResult(true);
		}
	}
}
