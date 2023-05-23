namespace Sudoku.Classes
{
	public class SudokuCreator
	{
		private int rowSize = 9;
		private int colSize = 9;

		public SudokuCreator()
		{
		}

		//format: e.g. 1,0,2,0,0,9,... (0 = empty field)
		public Sudoku? LoadFromFile(string input)
		{
			string[] numbers = input.Split(',');

			if (numbers.Length != rowSize * colSize)
			{
				throw new Exception($"Size has to be {rowSize * colSize}");
			}

			try
			{
				List<int> convertedNumbers = numbers.ToList().ConvertAll(int.Parse);
				int[,] board = new int[rowSize,colSize];
				int currentIdx = 0;

				for (int i = 0; i < board.GetLength(0); i++)
				{
					for (int j = 0; j < board.GetLength(1); j++)
					{
						board[i, j] = convertedNumbers[currentIdx];
						currentIdx++;
					}
				}

				return new Sudoku(board);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
