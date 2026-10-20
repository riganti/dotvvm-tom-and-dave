using System.ComponentModel.DataAnnotations;

namespace _10_Passkeys.Models;

public class RegisterPasskeyForm
{
	[Required]
	[StringLength(100)]
	public string DeviceName { get; set; } = string.Empty;
}