namespace Sudoku.Classes
{
	public class Sudoku
	{
		public Sudoku(int[,] board)
		{
			OriginalBoard = board;
			Board = new int[board.GetLength(0), board.GetLength(1)];
			Array.Copy(board, Board, board.Length);
		}

		public int[,] Board { get; private set; }
		private readonly int[,] OriginalBoard;

		public bool IsSolved()
		{
			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					if (Board[i,j] == 0)
					{
						return false;
					}
				}
			}

			return true;
		}

		public bool NumberAtRowPossible(int rowIdx, int number) 
		{
			for (int i = 0; i < Board.GetLength(1); i++)
			{
				if (Board[rowIdx, i] == number)
				{
					return false;
				}
			}

			return true;
		}

		public bool NumberAtCollumnPossible(int colIdx, int number)
		{
			for (int i = 0; i < Board.GetLength(0); i++)
			{
				if (Board[i, colIdx] == number)
				{
					return false;
				}
			}

			return true;
		}


		public bool HasDublicateInRow()
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

		public bool HasDublicateInCol()
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

		public bool HasDublicateInBlock()
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

		public bool IsInitialFieldStateFilled(int rowIdx, int colIdx)
		{
			return OriginalBoard[rowIdx, colIdx] != 0;
		}

		public void UncoverRandomField()
		{
			List<Tuple<int,int>> emptyFields = new List<Tuple<int,int>>();

			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					if (Board[i, j] == 0)
					{
						emptyFields.Add(Tuple.Create(i,j));
					}
				}
			}

			if(emptyFields.Count == 0)
			{
				return;
			}

			Random random = new Random();
			int idx = random.Next(0, emptyFields.Count);
			Tuple<int, int> fieldIndicies = emptyFields[idx];
            Console.WriteLine("uncovered field idx: {0}/{1}", fieldIndicies.Item1, fieldIndicies.Item2);

            Board[fieldIndicies.Item1, fieldIndicies.Item2] = 2;
		}

		public bool IsFieldEmpty(int rowIdx, int colIdx) => Board[rowIdx, colIdx] == 0;
		public void ChangeNumberOfField(int rowIdx, int colIdx, int number) => Board[rowIdx, colIdx] = number;

		public void ClearField(int rowIdx, int colIdx) => Board[rowIdx, colIdx] = 0;

		public void Print()
		{
			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int j = 0; j < Board.GetLength(1); j++)
				{
					Console.Write(Board[i,j] + " ");
				}
				Console.WriteLine();
			}
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
	}
}
