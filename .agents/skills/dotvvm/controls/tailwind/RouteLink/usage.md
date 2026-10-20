# <t:RouteLink>
Renders a Tailwind-styled route link that shares the same visual API as the Tailwind `Button`. Use the built-in route properties such as `RouteName` and `Param-*`, together with Tailwind-specific `Type`, `Size`, `Icon`, and `IconPosition`.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Culture`|String|Gets or sets the culture segment used when generating the route URL.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the route link is enabled and can be clicked.|attribute, static value, bindable|True|
|`Icon`|([HeroIcon](../_enums/DotVVM.Controls.Tailwind.Controls.HeroIcon.md))||attribute, static value, bindable||
|`IconPosition`|([IconPosition](../_enums/DotVVM.Controls.Tailwind.Controls.IconPosition.md))||attribute, static value, bindable|Start|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`RouteName`|String|Gets or sets the DotVVM route name this link navigates to.|attribute, static value||
|`Size`|([ControlSize](../_enums/DotVVM.Controls.Tailwind.ControlSize.md))||attribute, static value, bindable|Default|
|`Template`|ITemplate|Gets or sets custom content rendered inside the route link instead of plain text.|inner element, static value, default property||
|`Text`|String|Gets or sets the plain text label rendered inside the route link.|attribute, static value, bindable||
|`Type`|([ButtonType](../_enums/DotVVM.Controls.Tailwind.Controls.ButtonType.md))||attribute, static value, bindable|Default|
|`UrlSuffix`|String|Gets or sets the URL suffix appended after the generated route URL.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Button-Like Route Links

The Tailwind `RouteLink` supports the same `Type`, `Size`, `Icon`, `IconPosition`, and template content combinations as the Tailwind `Button`, while still navigating through the DotVVM route table.


```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Main">
    <div class="flex flex-wrap gap-2 items-center">
        <t:RouteLink Type="Default" Text="Default" RouteName="SampleB" />
        <t:RouteLink Type="Primary" Text="Primary" RouteName="SampleB" />
        <t:RouteLink Type="Success" Text="Icon + text" Icon="Check" RouteName="SampleB" />
        <t:RouteLink Type="Secondary" Icon="Plus" RouteName="SampleB" />
        <t:RouteLink Type="Primary" Text="Large" Size="Large" RouteName="SampleB" />
        <t:RouteLink Type="Primary" Text="Next" Icon="ArrowRight" IconPosition="End" RouteName="SampleB" />
        <t:RouteLink Type="Ghost" RouteName="SampleA">
            <strong>Content only</strong>
        </t:RouteLink>
    </div>

    <p>Current page: Sample A</p>
</dot:Content>

```

```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Main">
    <t:RouteLink Type="Primary" Text="Back to Sample A" RouteName="SampleA" Icon="ArrowLeft" />

    <p>Current page: Sample B</p>
</dot:Content>

```

```DOTHTML
<dot:ContentPlaceHolder ID="Main" />

```

```CSHARP
using DotVVM.Framework.Configuration;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RouteLink.sample1
{
    public class Startup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("SampleA", "", "SampleA.dothtml", null);
            config.RouteTable.Add("SampleB", "target", "SampleB.dothtml", null);
        }
    }
}

```

## Sample 2: Route Parameters

Use the built-in route-link properties such as `RouteName` and `Param-*` to navigate to routes with parameters. The target page reads the parameter value from `Context.Parameters`.


```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Main">
    <div class="flex flex-wrap gap-2 items-center">
        <t:RouteLink Type="Primary" Text="Open detail 42" RouteName="SampleB" Param-Id="42" />
        <t:RouteLink Type="Secondary" Text="Open detail 99" RouteName="SampleB" Param-Id="99" Icon="DocumentText" />
    </div>

    <p>Current page: Sample A</p>
</dot:Content>

```

```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Main">
    <p>Current route parameter: {{value: RouteId}}</p>

    <t:RouteLink Type="Primary" Text="Back to Sample A" RouteName="SampleA" />
</dot:Content>

```

```DOTHTML
<dot:ContentPlaceHolder ID="Main" />

```

```CSHARP
using System;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RouteLink.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string RouteId { get; set; } = "(none)";

        public override Task Init()
        {
            if (Context.Parameters.ContainsKey("Id"))
            {
                RouteId = Convert.ToString(Context.Parameters["Id"]);
            }

            return base.Init();
        }
    }
}

```

```CSHARP
using DotVVM.Framework.Configuration;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RouteLink.sample2
{
    public class Startup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("SampleA", "", "SampleA.dothtml", null);
            config.RouteTable.Add("SampleB", "detail/{Id?}", "SampleB.dothtml", null);
        }
    }
}

```

