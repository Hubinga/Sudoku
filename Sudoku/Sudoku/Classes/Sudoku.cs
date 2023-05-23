using Microsoft.AspNetCore.DataProtection.KeyManagement;

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
