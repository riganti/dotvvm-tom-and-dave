using _10_Passkeys.Models;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace _10_Passkeys.Pages.Profile.BasicInfo;

public class BasicInfoViewModel(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : LayoutViewModel
{
    private ApplicationUser? user;

    public BasicInfoForm Form { get; set; } = new();

    [Bind(Direction.ServerToClient)]
    public string? ErrorMessage { get; set; }

    [Bind(Direction.ServerToClient)]
    public bool ProfileSaved { get; set; }

    [Bind(Direction.ServerToClient)]
    public string DisplayName { get; set; } = string.Empty;

    [Bind(Direction.ServerToClient)]
    public string Initials { get; set; } = string.Empty;

    [Bind(Direction.ServerToClient)]
    public string Email { get; set; } = string.Empty;

    public override async Task Init()
    {
        await Context.Authorize();
        PageTitle = "Profile · Passkeys demo";
        await base.Init();
    }

    public override async Task Load()
    {
        user = await userManager.GetUserAsync(Context.HttpContext.User!) ?? throw new UnauthorizedAccessException();

        if (!Context.IsPostBack)
        {
            Form.FirstName = user.FirstName;
            Form.LastName = user.LastName;
        }

        await base.Load();
    }

    public override Task PreRender()
    {
        if (user is not null)
        {
            DisplayName = $"{user.FirstName} {user.LastName}".Trim();
            Initials = string.Concat(new[] { user.FirstName, user.LastName }
                .Where(name => name.Length > 0)
                .Select(name => char.ToUpperInvariant(name[0])));
            Email = user.Email ?? string.Empty;
        }

        return base.PreRender();
    }

    public async Task Save()
    {
        var user = await userManager.GetUserAsync(Context.HttpContext.User!) ?? throw new UnauthorizedAccessException();
        user.FirstName = Form.FirstName;
        user.LastName = Form.LastName;
        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            ErrorMessage = string.Join(" ", result.Errors.Select(error => error.Description));
            return;
        }

        ProfileSaved = true;
    }

    public async Task DeleteAccount()
    {
        var user = await userManager.GetUserAsync(Context.HttpContext.User!) ?? throw new UnauthorizedAccessException();
        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            ErrorMessage = string.Join(" ", result.Errors.Select(error => error.Description));
            return;
        }

        await signInManager.SignOutAsync();
        Context.RedirectToRoute("SignIn");
    }
}
