using _10_Passkeys.Models;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace _10_Passkeys.Pages.Account.SignIn;

public class SignInViewModel(SignInManager<ApplicationUser> signInManager) : DotvvmViewModelBase
{
    public SignInForm Form { get; set; } = new();

    [Bind(Direction.ServerToClient)]
    public string? ErrorMessage { get; set; }

    public async Task SignIn()
    {
        var result = await signInManager.PasswordSignInAsync(Form.Email, Form.Password, false, false);
        if (!result.Succeeded)
        {
            ErrorMessage = "Invalid email or password.";
            return;
        }

        Context.RedirectToRoute("Profile");
    }
}
