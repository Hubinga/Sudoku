using CurrieTechnologies.Razor.SweetAlert2;

namespace Sudoku.Classes
{
	public static class AlertBox
	{
		public static async Task DisplayAlert(SweetAlertService sweetAlertService, string message)
		{
			await sweetAlertService.FireAsync(message);
		}

		public static async Task DisplayError(SweetAlertService sweetAlertService, string message)
		{
			await sweetAlertService.FireAsync(message: message, icon: "error");
		}

		public static async Task<SweetAlertResult> DisplayAlertWithButtons(SweetAlertService sweetAlertService, string message, string confirmButtonText, string cancelButtonText)
		{
			return await sweetAlertService.FireAsync(new SweetAlertOptions
			{
				Text = message,
				Icon = SweetAlertIcon.Question,
				ShowCancelButton = true,
				ConfirmButtonText = confirmButtonText,
				CancelButtonText = cancelButtonText
			});
		}

		public static async Task DisplaySudokuNotPossibleAlert(SweetAlertService sweetAlertService)
		{
			await sweetAlertService.FireAsync("Sudoku not possible to solve (dublicate in collumn, row or block)!");
		}
	}
}
