using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace StaticCommands
{
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
            config.Resources.Register("tailwind", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/css/tailwind.css")
            });

            config.Resources.RegisterScriptFile("diag-js", "wwwroot/diag.js");
            config.Resources.RegisterScriptFile("ko-highlight", "wwwroot/ko-highlight.js", dependencies: ["knockout"]);
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
        }
    }
}
