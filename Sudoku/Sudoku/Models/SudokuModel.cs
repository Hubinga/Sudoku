using System.ComponentModel.DataAnnotations;

namespace Sudoku.Models
{
	public class SudokuModel
	{
		public int Id { get; set; }

		[StringLength(161, MinimumLength = 161)]
		[Required]
		//format: number with comma separated (e.g.: 1,2,0,3,0,0,4)
		[RegularExpression(@"^\d(\,\d)*$")]
		public string? OriginalBoard { get; set; }

		[StringLength(161, MinimumLength = 161)]
		[RegularExpression(@"^\d(\,\d)*$")]
		public string? SolvedBoard { get; set; }

		[StringLength(161, MinimumLength = 161)]
		[RegularExpression(@"^\d(\,\d)*$")]
		public string? CurrentBoard { get; set; }

		[Required]
		public string? Difficulty { get; set; }
		public bool Solved { get; set; }
		public int Time { get; set; }
	}
}
