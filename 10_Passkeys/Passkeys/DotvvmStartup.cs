using DotVVM.Controls.Tailwind;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using Microsoft.Extensions.DependencyInjection;

namespace _10_Passkeys;

public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
{
    public void Configure(DotvvmConfiguration config, string applicationPath)
    {
        ConfigureRoutes(config, applicationPath);
        ConfigureControls(config, applicationPath);
        ConfigureResources(config, applicationPath);

        config.AddTailwindControls();
    }

    private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
    {
        config.RouteTable.Add("SignIn", "", "Pages/Account/SignIn/SignIn.dothtml");
        config.RouteTable.Add("CreateAccount", "create-account", "Pages/Account/CreateAccount/CreateAccount.dothtml");
        config.RouteTable.Add("Profile", "profile", "Pages/Profile/BasicInfo/BasicInfo.dothtml");
        config.RouteTable.Add("Security", "profile/security", "Pages/Profile/Security/Security.dothtml");
        config.RouteTable.Add("RegisterPasskey", "profile/register-passkey", "Pages/Profile/RegisterPasskey/RegisterPasskey.dothtml");
    }

    private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
    {
    }

    private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
    {
        config.Resources.RegisterStylesheetFile("app.css", "wwwroot/css/app.css", dependencies: ["dotvvm-tailwind-css"]);
        config.Resources.RegisterScriptModuleFile("app.js", "wwwroot/js/app.js");
        config.Resources.RegisterScriptModuleFile("passkeys", "wwwroot/js/passkeys.js");
    }

    public void ConfigureServices(IDotvvmServiceCollection options)
    {
        options.AddDefaultTempStorages("temp");
        options.AddHotReload();
    }
}