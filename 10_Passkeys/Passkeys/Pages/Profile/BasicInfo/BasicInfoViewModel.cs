using _10_Passkeys.Models;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace _10_Passkeys.Pages.Profile.BasicInfo;

public class BasicInfoViewModel(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager) : LayoutViewModel
{
    public BasicInfoForm Form { get; set; } = new();

    [Bind(Direction.ServerToClient)]
    public string? ErrorMessage { get; set; }

    [Bind(Direction.ServerToClient)]
    public bool ProfileSaved { get; set; }

    public override async Task Init()
    {
        await Context.Authorize();
        await base.Init();
    }

    public override async Task Load()
    {
        if (!Context.IsPostBack)
        {
            var user = await userManager.GetUserAsync(Context.HttpContext.User!) ?? throw new UnauthorizedAccessException();

            Form.FirstName = user.FirstName;
            Form.LastName = user.LastName;
        }

        await base.Load();
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
