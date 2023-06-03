namespace Sudoku.Classes
{
	[Serializable]
	public class TryUncoverRandomFieldException : Exception
	{
		public TryUncoverRandomFieldException() : base() { }
		public TryUncoverRandomFieldException(string message) : base(message) { }
		public TryUncoverRandomFieldException(string message, Exception inner) : base(message, inner) { }
	}
}
