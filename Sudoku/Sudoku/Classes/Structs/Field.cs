namespace Sudoku.Classes.Structs
{
	struct Field
	{
		public int RowIdx;
		public int ColIdx;

		public Field(int rowIdx, int colIdx)
		{
			RowIdx = rowIdx;
			ColIdx = colIdx;
		}
	}
}
