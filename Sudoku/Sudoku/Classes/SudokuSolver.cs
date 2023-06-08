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

		public void GenerateSolution(Sudoku sudoku, int numberOfSolutions = 1)
		{
			SolveSudoku(sudoku, numberOfSolutions);
			sudoku.SolvingProzessFinished = true;
		} 

		private void SolveSudoku(Sudoku sudoku, int numberOfSolutions = 1, int rowIdx = 0, int colIdx = 0)
		{
			//Stop if sudoku is solved
			if (sudoku.IsSolved())
			{
				sudoku.Print();
				//store current solution
				sudoku.AddCurrentSolution();

				if (sudoku.BoardSolutions.Count < numberOfSolutions) 
				{
					//clear last field to continue
					sudoku.ClearLastField();
				}
                return;
			}

			//callculate next Row/Col indicies: e.g. 0/8 -> 1/0
			int nextRowIdx = colIdx == (colSize - 1) ? rowIdx + 1 : rowIdx;
			int nextColIdx = colIdx == (colSize - 1) ? 0 : colIdx + 1;

			//jump to next field if already filled
			if (!sudoku.IsFieldEmpty(rowIdx, colIdx))
			{
				SolveSudoku(sudoku, numberOfSolutions, nextRowIdx, nextColIdx);
			}
			else
			{
				for (int i = 1; i <= 9; i++)
				{
					//change field value if possible
					if (IsNumberPossible(sudoku, rowIdx, colIdx, i))
					{
						sudoku.ChangeNumberOfField(rowIdx, colIdx, i);
						SolveSudoku(sudoku, numberOfSolutions, nextRowIdx, nextColIdx);
					}
				}

				//clear current field if no number is possible (to jump back, backtracking)
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
