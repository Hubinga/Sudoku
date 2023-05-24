namespace Sudoku.Classes
{
	public class SudokuSolver
	{
		private int colSize = 9;

		public bool IsSudokuPossible(Sudoku sudoku)
		{
			if(sudoku.HasDublicateInRow() || sudoku.HasDublicateInCol() || sudoku.HasDublicateInBlock())
			{
				return false;
			}

			return true;
		}

		public void UncoverRandomField(Sudoku sudoku)
		{
			sudoku.UncoverRandomField();
		}

		public bool IsNumberPossible(Sudoku sudoku, int rowIdx, int colIdx, int number)
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
			int rowIdxStart = rowIdx / 3 * 3;
			int colIdxStart = colIdx / 3 * 3;

			for (int i = rowIdxStart; i < rowIdxStart + 2; i++)
			{
				for (int j = colIdxStart; j < colIdxStart + 2; j++)
				{
					if (sudoku.Board[i,j] == number && (i != rowIdx && j != colIdx))
					{
						return false;
					}
				}
			}

			return true;
		}

		public void SolveSudoku(Sudoku sudoku, int rowIdx = 0, int colIdx = 0)
		{

			if (sudoku.IsSolved())
			{
				sudoku.Print();
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
						sudoku.ChangeNumberOfField(rowIdx, colIdx, i);
						SolveSudoku(sudoku, nextRowIdx, nextColIdx);
					}
				}

				if (!sudoku.IsSolved())
				{
					sudoku.ClearField(rowIdx, colIdx);
				}	
			}
		}
	}
}
