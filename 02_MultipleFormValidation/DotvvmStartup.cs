using DotVVM.Bootstrap5;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MultipleFormValidation
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBootstrap5Configuration();

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
            // register code-only controls and markup controls
            config.Markup.AddCodeControls("cc", typeof(MultipleFormValidation.Components.ValidationCounter));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.RegisterScriptFile("validation-counter", "wwwroot/Resources/validation-counter.js");
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
        }
    }
}
