using DotVVM.Controls.Tailwind;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using Microsoft.Extensions.DependencyInjection;

namespace AppTemplate;

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
        config.RouteTable.Add("Home", "", "Pages/Home/Home.dothtml");
    }

    private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
    {
    }

    private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
    {
        config.Resources.RegisterStylesheetFile("app.css", "wwwroot/css/app.css", dependencies: ["dotvvm-tailwind-css"]);
        config.Resources.RegisterScriptModuleFile("app.js", "wwwroot/js/app.js");
    }

    public void ConfigureServices(IDotvvmServiceCollection options)
    {
        options.AddDefaultTempStorages("temp");
        options.AddHotReload();
    }
}