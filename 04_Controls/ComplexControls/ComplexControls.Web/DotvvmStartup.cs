using DotVVM.Framework;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;
using DotVVM.Framework.ResourceManagement;

namespace ComplexControls.Web;
public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
{
    // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
    public void Configure(DotvvmConfiguration config, string applicationPath)
    {
        ConfigureRoutes(config, applicationPath);
        ConfigureControls(config, applicationPath);
        ConfigureResources(config, applicationPath);

        // https://www.dotvvm.com/docs/4.0/pages/concepts/configuration/explicit-assembly-loading
        config.ExperimentalFeatures.ExplicitAssemblyLoading.Enable();

        // Use this for command heavy applications
        // - DotVVM will store the viewmodels on the server, and client will only have to send back diffs
        // https://www.dotvvm.com/docs/4.0/pages/concepts/viewmodels/server-side-viewmodel-cache
        // config.ExperimentalFeatures.ServerSideViewModelCache.EnableForAllRoutes();

        // Use this if you are deploying to containers or slots
        //  - DotVVM will precompile all views before it appears as ready
        // https://www.dotvvm.com/docs/4.0/pages/concepts/configuration/view-compilation-modes
        // config.Markup.ViewCompilation.Mode = ViewCompilationMode.DuringApplicationStart;
    }

    private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
    {
        config.RouteTable.Add("Default", "", "Pages/Basic/Basic.dothtml");
        config.RouteTable.Add("MarkupControls", "markup-controls", "Pages/MarkupControls/MarkupControls.dothtml");
        config.RouteTable.Add("LegacyCodeOnlyControls", "legacy-code-only-controls", "Pages/LegacyCodeOnlyControls/LegacyCodeOnlyControls.dothtml");
        config.RouteTable.Add("ControlsWithViewModels", "controls-with-viewmodels", "Pages/ControlsWithViewModels/ControlsWithViewModels.dothtml");
        config.RouteTable.Add("JsEnhanced", "js-enhanced", "Pages/JsEnhanced/JsEnhanced.dothtml");
        config.RouteTable.Add("Error", "error", "Pages/Error/Error.dothtml");

        // Uncomment the following line to auto-register all dothtml files in the Pages folder
        // config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config, viewsFolder: "Pages"));    
    }

    private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
    {
        // register code-only controls and markup controls
        config.Markup.AddCodeControls("cc", typeof(Controls.Icon));
        config.Markup.AutoDiscoverControls(new DefaultControlRegistrationStrategy(config, "cc", "Controls"));

    }

    private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
    {
        // register custom resources and adjust paths to the built-in resources
        config.Resources.Register("tailwind", new StylesheetResource()
        {
            Location = new UrlResourceLocation("~/css/tailwind.css")
        });
        config.Resources.Register("InfiniteScrollModule", new ScriptModuleResource(new UrlResourceLocation("~/scripts/InfiniteScrollModule.js")));
    }

    public void ConfigureServices(IDotvvmServiceCollection options)
    {
        //register only services that are supported by DotVVM (otherwise, register your services in Startup.cs)
        options.AddDefaultTempStorages("Temp");
    }
}
