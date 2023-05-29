using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sudoku.Models
{
	public class SudokuModel
	{
		public int Id { get; set; }

		//format: number with comma separated (e.g.: 1,2,0,3,0,0,4)
		[StringLength(161, MinimumLength = 161)]
		[Required]	
		[RegularExpression(@"^\d(\,\d)*$")]
		[Display(Name = "Original Board")]
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
