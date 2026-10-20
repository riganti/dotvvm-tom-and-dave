using System.ComponentModel.DataAnnotations;

namespace _10_Passkeys.Models;

public class BasicInfoForm
{
	[Required]
	[StringLength(100)]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	[StringLength(100)]
	public string LastName { get; set; } = string.Empty;
}