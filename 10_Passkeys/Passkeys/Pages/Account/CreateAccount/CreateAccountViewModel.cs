using _10_Passkeys.Models;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace _10_Passkeys.Pages.Account.CreateAccount;

public class CreateAccountViewModel(UserManager<ApplicationUser> userManager) : AuthLayoutViewModel
{
    public CreateAccountForm Form { get; set; } = new();

    [Bind(Direction.ServerToClient)]
    public string? ErrorMessage { get; set; }

    [Bind(Direction.ServerToClient)]
    public bool AccountCreated { get; set; }

    public override Task Init()
    {
        PageTitle = "Create account · Passkeys demo";
        return base.Init();
    }

    public async Task CreateAccount()
    {
        var user = new ApplicationUser
        {
            UserName = Form.Email,
            Email = Form.Email,
            EmailConfirmed = true,
            FirstName = Form.FirstName,
            LastName = Form.LastName
        };
        var result = await userManager.CreateAsync(user, Form.Password);
        if (!result.Succeeded)
        {
            ErrorMessage = string.Join(" ", result.Errors.Select(error => error.Description));
            return;
        }

        AccountCreated = true;
        Form = new();
    }
}
