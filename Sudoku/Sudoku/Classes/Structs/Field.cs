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

		public void ResetField(int rowIdx = -1, int colIdx = -1)
		{
			RowIdx = rowIdx;
			ColIdx = colIdx;
		}
	}
}
