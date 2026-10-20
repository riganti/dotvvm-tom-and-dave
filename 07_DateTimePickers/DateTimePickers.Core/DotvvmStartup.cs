using DotVVM.Framework.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DateTimePickers.Core;

public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
{
    public void Configure(DotvvmConfiguration config, string applicationPath)
    {
        ConfigureRoutes(config, applicationPath);
        ConfigureControls(config, applicationPath);
        ConfigureResources(config, applicationPath);
    }

    private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
    {
        config.RouteTable.Add("Default", "", "Views/Default.dothtml");
    }

    private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
    {
    }

    private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
    {
    }

    public void ConfigureServices(IDotvvmServiceCollection options)
    {
        options.AddHotReload();
        options.AddDefaultTempStorages("Temp");
    }
}
