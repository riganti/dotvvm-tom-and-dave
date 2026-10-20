using System.ComponentModel.DataAnnotations;

namespace _10_Passkeys.Models;

public class ChangePasswordForm
{
	[Required]
	[DataType(DataType.Password)]
	public string CurrentPassword { get; set; } = string.Empty;

	[Required]
	[StringLength(100, MinimumLength = 6)]
	[DataType(DataType.Password)]
	public string NewPassword { get; set; } = string.Empty;

	[Required]
	[Compare(nameof(NewPassword))]
	[DataType(DataType.Password)]
	public string ConfirmPassword { get; set; } = string.Empty;
}