namespace Sudoku.Classes
{
	public class SudokuSolver
	{
		private int colSize = 9;

		public bool IsSudokuPossible(Sudoku sudoku)
		{
			if(sudoku.HasDublicateInRows() || sudoku.HasDublicateInColumns() || sudoku.HasDublicateInBlocks())
			{
				return false;
			}

			return true;
		}

		public void GenerateSolution(Sudoku sudoku)
		{
			SolveSudoku(sudoku);
		} 

		private void SolveSudoku(Sudoku sudoku, int rowIdx = 0, int colIdx = 0)
		{

			if (sudoku.IsSolved())
			{
				sudoku.Print();
				sudoku.SolvingProzessFinished = true;
				return;
			}

			//e.g. 0/8 -> 1/0
			int nextRowIdx = colIdx == (colSize - 1) ? rowIdx + 1 : rowIdx;
			int nextColIdx = colIdx == (colSize - 1) ? 0 : colIdx + 1;

			//jump to next field if already filled
			if (!sudoku.IsFieldEmpty(rowIdx, colIdx))
			{
				SolveSudoku(sudoku, nextRowIdx, nextColIdx);
			}
			else
			{
				for (int i = 1; i <= 9; i++)
				{
					if (IsNumberPossible(sudoku, rowIdx, colIdx, i))
					{
						sudoku.ChangeNumberOfField(rowIdx, colIdx, i, true);
						SolveSudoku(sudoku, nextRowIdx, nextColIdx);
					}
				}

				if (!sudoku.IsSolved())
				{
					sudoku.ClearField(rowIdx, colIdx);
				}	
			}
		}

		private bool IsNumberPossible(Sudoku sudoku, int rowIdx, int colIdx, int number)
		{
			//horizontal
			if (!sudoku.NumberAtRowPossible(rowIdx, number))
			{
				return false;
			}
			//vertical
			if (!sudoku.NumberAtCollumnPossible(colIdx, number))
			{
				return false;
			}
			//3x3 block
			if(!sudoku.NumberAtBlockPossible(rowIdx, colIdx, number))
			{
				return false;
			}

			return true;
		}
	}
}
