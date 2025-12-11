using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Messaging;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using Microsoft.Extensions.DependencyInjection;

namespace EmojiChat.Web
{
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
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");

            // Uncomment the following line to auto-register all dothtml files in the Views folder
            // config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config, viewsFolder: "Views"));   
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddMarkupControl("cc", "Markdown", "Components/Markdown.dotcontrol");
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("bootstrap-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/css/bootstrap.min.css")
            });
            config.Resources.Register("bootstrap", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/js/bootstrap.min.js"),
                Dependencies = new[] { "bootstrap-css", "jquery" }
            });
            config.Resources.Register("jquery", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/jquery/jquery.min.js")
            });
            config.Resources.Register("tailwind", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/css/tailwind.css")
            });
            config.Resources.Register("overrides", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/css/overrides.css")
            });
            config.Resources.RegisterStylesheetUrl("HighlightJsStyle", "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.11.1/styles/atom-one-dark.min.css", null);
            config.Resources.RegisterScriptFile("site.js", "wwwroot/site.js", dependencies: ["showdown", "dotvvm", "marked", "highlightJs", "highlightCsharp", "highlightHtml", "HighlightJsStyle"]);
            config.Resources.RegisterScriptUrl("showdown", "https://cdnjs.cloudflare.com/ajax/libs/showdown/2.1.0/showdown.min.js", "sha512-LhccdVNGe2QMEfI3x4DVV3ckMRe36TfydKss6mJpdHjNFiV07dFpS2xzeZedptKZrwxfICJpez09iNioiSZ3hA==");
            config.Resources.RegisterScriptUrl("marked", "https://cdn.jsdelivr.net/npm/marked/marked.min.js", null);
            config.Resources.RegisterScriptUrl("highlightJs", "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.11.1/highlight.min.js", null);
            config.Resources.RegisterScriptUrl("highlightCsharp", "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.11.1/languages/csharp.min.js", null);
            config.Resources.RegisterScriptUrl("highlightHtml", "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.11.1/languages/html.min.js", null);
        }


        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
            options.AddBusinessPack(BusinessPackTheme.None);
            options.AddBusinessPackMessaging();
        }
    }
}