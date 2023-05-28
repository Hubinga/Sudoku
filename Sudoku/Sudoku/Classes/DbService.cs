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

        public Task<SudokuModel> AddSudokuModelAsync(SudokuModel sudokuModel)
        {
            _context.SudokuModel.Add(sudokuModel);
            _context.SaveChanges();
            return Task.FromResult(sudokuModel);
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
