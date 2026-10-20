using System.ComponentModel.DataAnnotations;

namespace _10_Passkeys.Models;

public class CreateAccountForm
{
	[Required]
	[StringLength(100)]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	[StringLength(100)]
	public string LastName { get; set; } = string.Empty;

	[Required]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required]
	[StringLength(100, MinimumLength = 6)]
	[DataType(DataType.Password)]
	public string Password { get; set; } = string.Empty;

	[Required]
	[Compare(nameof(Password))]
	[DataType(DataType.Password)]
	public string ConfirmPassword { get; set; } = string.Empty;
}