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
		public Sudoku? GenerateSudokuFromFile(string input)
		{
			string[] numbers = input.Split(',');

			if (numbers.Length != rowSize * colSize)
			{
				throw new Exception($"Wrong Format, Size has to be {rowSize * colSize}");
			}

			int[,] board = ConvertBoardStringToIntArray(numbers);

			return new Sudoku(board);
		}

		public int[,] ConvertBoardStringToIntArray(string[] numbers)
		{
			try
			{
				List<int> convertedNumbers = numbers.ToList().ConvertAll(int.Parse);
				int[,] board = new int[rowSize, colSize];
				int currentIdx = 0;

				for (int i = 0; i < board.GetLength(0); i++)
				{
					for (int j = 0; j < board.GetLength(1); j++)
					{
						board[i, j] = convertedNumbers[currentIdx];
						currentIdx++;
					}
				}

				return board;
			}
			catch (Exception)
			{
				throw new Exception("Input Data has wrong format!\nFormat has to be: e.g: 1,0,2,0,3,... (0 = empty field)");
			}
		}

		public string ConvertIntArrayToBoardString(int[,] board)
		{
			string numbers = "";

			for(int i = 0;i < board.GetLength(0);i++)
			{
				for (int j = 0; j < board.GetLength(0); j++)
				{
					numbers += $"{board[i, j]},";
				}
			}

			return numbers.Substring(0, numbers.Length - 1);
		}
	}
}
