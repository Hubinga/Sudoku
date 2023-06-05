namespace Sudoku.Classes
{
    public class SudokuData
    {
		public SudokuData(int[,] originalBoard, int[,] currentBoard, int[,] solvedBoard, bool solved)
		{
			OriginalBoard = originalBoard;
			CurrentBoard = currentBoard;
			SolvedBoard = solvedBoard;
			Solved = solved;
		}

		public int[,] OriginalBoard { get; private set; } = new int[9,9];
        public int[,] CurrentBoard { get; private set; } = new int[9,9];
        public int[,] SolvedBoard { get; private set; } = new int[9,9];
        public bool Solved { get; private set; } = false;
    }
}
