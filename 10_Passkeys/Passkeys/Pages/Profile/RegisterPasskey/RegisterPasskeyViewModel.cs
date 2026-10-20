using _10_Passkeys.Models;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;

namespace _10_Passkeys.Pages.Profile.RegisterPasskey;

public class RegisterPasskeyViewModel : LayoutViewModel
{
    public RegisterPasskeyForm Form { get; set; } = new();

    public override async Task Init()
    {
        await Context.Authorize();
        await base.Init();
    }
}
