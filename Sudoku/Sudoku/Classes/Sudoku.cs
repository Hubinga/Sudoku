namespace Sudoku.Classes
{
	public class Sudoku
	{
		public Sudoku(int[,] board)
		{
			Board = board;

			OriginalBoard = new int[board.GetLength(0), board.GetLength(1)];
			Array.Copy(board, OriginalBoard, board.Length);

			SolvedBoard = new int[board.GetLength(0), board.GetLength(1)];
			Array.Copy(board, SolvedBoard, board.Length);

			SolvingProzessFinished = false;
			Solved = false;
		}

		//for creating Sudoku with database entry (sudokumodel) 
		public Sudoku(int[,] originalBoard, int[,] currentBoard, int[,] solvedBoard, bool solved)
		{
			OriginalBoard = originalBoard;

			Board = currentBoard;

			if (solved)
			{
				SolvedBoard = solvedBoard;
			}
			else
			{
				SolvedBoard = new int[originalBoard.GetLength(0), originalBoard.GetLength(1)];
				Array.Copy(originalBoard, SolvedBoard, originalBoard.Length);
			}

			SolvingProzessFinished = solved;
			Solved = solved;
		}

		public int[,] Board { get; private set; }
		public readonly int[,] OriginalBoard;
		public readonly int[,] SolvedBoard;

		public bool SolvingProzessFinished { get; set; } = false;
		public bool Solved { get; set; } = false;

		#region check if possible Prozess
		public bool HasDublicateInRows()
		{
			for (int i = 0; i < Board.GetLength(0); i++)
			{
				//get current row
				List<int> currentRow = Enumerable.Range(0, Board.GetLength(1)).Select(x => Board[i, x]).Where(e=>e!=0).ToList();
				List<int> distinctNumbers = currentRow.Distinct().ToList();
				//e.g. filled fields: 5 (1,2,3,2,4) -> distinct numbers: 4 -> dublicate
				//e.g. filled fields: 4 (1,2,3,4) -> distinct numbers: 4 -> no dublicate
				if(currentRow.Count != distinctNumbers.Count)
				{
					return true;
				}
			}

			return false;
		}

		public bool HasDublicateInColumns()
		{
			for (int i = 0; i < Board.GetLength(1); i++)
			{
				//get current row
				List<int> currentCol = Enumerable.Range(0, Board.GetLength(0)).Select(x => Board[x, i]).Where(e => e != 0).ToList();
				List<int> distinctNumbers = currentCol.Distinct().ToList();
				//e.g. filled fields: 5 (1,2,3,2,4) -> distinct numbers: 4 -> dublicate
				//e.g. filled fields: 4 (1,2,3,4) -> distinct numbers: 4 -> no dublicate
				if (currentCol.Count != distinctNumbers.Count)
				{
					return true;
				}
			}

			return false;
		}

		public bool HasDublicateInBlocks()
		{
			for (int i = 0; i < 9; i+=3)
			{
				for (int j = 0; j < 3; j++)
				{
					if (BlockHasDublicate(i, j * 3))
					{
						return true;
					}
				}
			}

			return false;
		}

		private bool BlockHasDublicate(int rowIdxStart, int colIdxStart)
		{
			List<int> numbersInBlock = new List<int>();

			for (int i = rowIdxStart; i < rowIdxStart + 3; i++)
			{
				for (int j = colIdxStart; j < colIdxStart + 3; j++)
				{
					int currentNumber = Board[i, j];

					if (numbersInBlock.Contains(currentNumber))
					{
						return true;
					}

					if (currentNumber != 0)
					{
						numbersInBlock.Add(currentNumber);
					}
				}
			}

			return false;
		}
		#endregion

		#region Solving Prozess
		public bool IsFieldEmpty(int rowIdx, int colIdx) => SolvedBoard[rowIdx, colIdx] == 0;

		public void ClearField(int rowIdx, int colIdx) => SolvedBoard[rowIdx, colIdx] = 0;

		public bool IsSolved()
		{
			for (int i = 0; i < SolvedBoard.GetLength(0); i++)
			{
				for (int j = 0; j < SolvedBoard.GetLength(1); j++)
				{
					if (SolvedBoard[i, j] == 0)
					{
						return false;
					}
				}
			}

			return true;
		}

		public bool NumberAtRowPossible(int rowIdx, int number)
		{
			for (int i = 0; i < SolvedBoard.GetLength(1); i++)
			{
				if (SolvedBoard[rowIdx, i] == number)
				{
					return false;
				}
			}

			return true;
		}

		public bool NumberAtCollumnPossible(int colIdx, int number)
		{
			for (int i = 0; i < SolvedBoard.GetLength(0); i++)
			{
				if (SolvedBoard[i, colIdx] == number)
				{
					return false;
				}
			}

			return true;
		}

		public bool NumberAtBlockPossible(int rowIdx, int colIdx, int number)
		{
			int rowIdxStart = (rowIdx / 3) * 3;
			int colIdxStart = (colIdx / 3) * 3;

			for (int i = rowIdxStart; i <= rowIdxStart + 2; i++)
			{
				for (int j = colIdxStart; j <= colIdxStart + 2; j++)
				{
					if (SolvedBoard[i, j] == number)
					{
						return false;
					}
				}
			}

			return true;
		}

		#endregion

		public void Print()
		{
            Console.WriteLine("Solved Board:");
            string solvedBoardAsString = "";

			for (int i = 0; i < SolvedBoard.GetLength(0); i++)
			{
				for (int j = 0; j < SolvedBoard.GetLength(1); j++)
				{
					Console.Write(SolvedBoard[i,j] + " ");
					solvedBoardAsString += $"{SolvedBoard[i,j]},";
				}
				Console.WriteLine();
			}

            Console.WriteLine(solvedBoardAsString);
        }

		public void Reset()
		{
			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					Board[i, j] = OriginalBoard[i, j];
				}
			}
		}

		public bool IsCorrectSoulution()
		{
			if (!SolvingProzessFinished)
			{
				throw new Exception("Solving Prozess not yet finished");
			}

			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					if(Board[i, j] != SolvedBoard[i, j])
					{
						return false;
					}
				}
			}

			return true;
		}

		public void TryUncoverSolution()
		{
			if (!SolvingProzessFinished)
			{
				throw new Exception("Solving Prozess not yet finished");
			}

			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					Board[i, j] = SolvedBoard[i, j];
				}
			}
		}

		public bool IsInitialFieldStateFilled(int rowIdx, int colIdx)
		{
			return OriginalBoard[rowIdx, colIdx] != 0;
		}

		public void ChangeNumberOfField(int rowIdx, int colIdx, int number, bool generateSolution = false)
		{
			if (generateSolution)
			{
				SolvedBoard[rowIdx, colIdx] = number;
			}
			else
			{
				Board[rowIdx, colIdx] = number;
			}
		}

		public void TryUncoverRandomField()
		{
			if (!SolvingProzessFinished)
			{
				throw new Exception("Solving Prozess not yet finished");
			}

			List<Tuple<int, int>> emptyFields = new List<Tuple<int, int>>();

			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					if (Board[i, j] == 0)
					{
						emptyFields.Add(Tuple.Create(i, j));
					}
				}
			}

			if (emptyFields.Count == 0)
			{
				throw new TryUncoverRandomFieldException("Board is already filled: You can press \"End\" now!");
			}

			Random random = new Random();
			int idx = random.Next(0, emptyFields.Count);
			Tuple<int, int> fieldIndicies = emptyFields[idx];
			Console.WriteLine("uncovered field idx: {0}/{1}", fieldIndicies.Item1, fieldIndicies.Item2);

			Board[fieldIndicies.Item1, fieldIndicies.Item2] = SolvedBoard[fieldIndicies.Item1, fieldIndicies.Item2];
		}
	}
}
