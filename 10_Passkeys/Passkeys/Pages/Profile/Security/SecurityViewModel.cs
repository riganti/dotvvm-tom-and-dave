using _10_Passkeys.Models;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace _10_Passkeys.Pages.Profile.Security;

public class SecurityViewModel(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : LayoutViewModel
{
    public ChangePasswordForm PasswordForm { get; set; } = new();

    [Bind(Direction.ServerToClient)]
    public string? PasswordError { get; set; }

    [Bind(Direction.ServerToClient)]
    public bool PasswordChanged { get; set; }

    public List<PasskeyListItem> Passkeys { get; set; } = [];

    public override async Task Init()
    {
        await Context.Authorize();
        await base.Init();
    }

    public override async Task Load()
    {
        await LoadPasskeys();
        await base.Load();
    }

    public async Task ChangePassword()
    {
        var user = await GetUser();
        var result = await userManager.ChangePasswordAsync(user, PasswordForm.CurrentPassword, PasswordForm.NewPassword);
        if (!result.Succeeded)
        {
            PasswordError = string.Join(" ", result.Errors.Select(error => error.Description));
            return;
        }

        await signInManager.RefreshSignInAsync(user);
        PasswordForm = new();
        PasswordChanged = true;
    }

    public async Task DeletePasskey(string credentialId)
    {
        var user = await GetUser();
        var passkey = (await userManager.GetPasskeysAsync(user))
            .SingleOrDefault(item => Convert.ToBase64String(item.CredentialId) == credentialId);
        if (passkey is null)
        {
            return;
        }

        var result = await userManager.RemovePasskeyAsync(user, passkey.CredentialId);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException("Could not delete the passkey.");
        }

        await LoadPasskeys();
    }

    private async Task<ApplicationUser> GetUser() =>
        await userManager.GetUserAsync(Context.HttpContext?.User ?? throw new UnauthorizedAccessException())
        ?? throw new UnauthorizedAccessException();

    private async Task LoadPasskeys()
    {
        var user = await GetUser();
        Passkeys = (await userManager.GetPasskeysAsync(user))
            .Select(passkey => new PasskeyListItem
            {
                CredentialId = Convert.ToBase64String(passkey.CredentialId),
                Name = passkey.Name ?? string.Empty,
                CreatedAt = passkey.CreatedAt.ToLocalTime().ToString("d")
            })
            .ToList();
    }
}