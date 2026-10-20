# <t:Breadcrumb>
Renders breadcrumb navigation from hard-coded `MenuItem` children or a bound `DataSource`. In data-bound mode, use the `Item*` mappings to configure text, templates, commands, URLs, icons, and route navigation.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the collection used to generate breadcrumb items.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemCulture`|String|Gets or sets the culture used when generating each breadcrumb route URL.|attribute, static value||
|`ItemIcon`|HeroIcon?|Gets or sets the icon displayed before each generated breadcrumb item label.|attribute, static value||
|`ItemIsActive`|Boolean|Gets or sets whether each generated breadcrumb item represents the current page.|attribute, static value, bindable|False|
|`ItemNavigateUrl`|String|Gets or sets the target URL for each generated breadcrumb item.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the DotVVM route name for each generated breadcrumb item.|attribute, static value||
|`Items`|List<MenuItem>|Gets or sets hardcoded  children.|inner element, static value, default property||
|`ItemTemplate`|ITemplate|Gets or sets a custom label template for each generated breadcrumb item.|inner element, static value||
|`ItemText`|String|Gets or sets the text displayed for each generated breadcrumb item.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets the URL suffix appended to each generated route link.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command invoked when a generated breadcrumb item is clicked.|

## Sample 1: Basic Breadcrumb

Shows hard-coded breadcrumb items using `MenuItem` children. The sample uses `NavigateUrl`, `Icon`, and `IsActive` with URLs that stay inside the sample app.


```DOTHTML
<t:Breadcrumb>
    <t:MenuItem Text="Home" Icon="Home" NavigateUrl="?section=home" />
    <t:MenuItem Text="Controls" NavigateUrl="?section=controls" />
    <t:MenuItem Text="Breadcrumbs" NavigateUrl="?section=breadcrumbs" />
    <t:MenuItem Text="Current page" IsActive="true" />
</t:Breadcrumb>

```

## Sample 2: Data-bound Breadcrumb (ItemTemplate)

Generates breadcrumb items from a collection and formats each label with `ItemTemplate`. In data-bound mode, the template replaces `ItemText`.


```DOTHTML
<t:Breadcrumb DataSource="{value: BreadcrumbItems}"
              ItemNavigateUrl="{value: Url}"
              ItemIsActive="{value: IsActive}">
    <ItemTemplate>
        <span class="font-medium">{{value: Text}}</span>
    </ItemTemplate>
</t:Breadcrumb>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public List<BreadcrumbItemData> BreadcrumbItems { get; set; } = new()
    {
        new() { Text = "Home", Url = "?step=home" },
        new() { Text = "Products", Url = "?step=products" },
        new() { Text = "Details", Url = "?step=details", IsActive = true }
    };

    public class BreadcrumbItemData
    {
        public string Text { get; set; } = "";
        public string Url { get; set; } = "";
        public bool IsActive { get; set; }
    }
}

```

## Sample 3: Data-bound Breadcrumb (command links)

Uses `ItemText` and `ItemClick` to generate breadcrumb items that invoke a command instead of navigating away. This is useful when the breadcrumb should change viewmodel state inside the current page.


```DOTHTML
<div class="flex flex-col gap-3">
    <t:Breadcrumb DataSource="{value: Actions}"
                  ItemText="{value: Text}"
                  ItemClick="{command: _parent.Select(Text)}" />
    <p>Last clicked item: <strong>{{value: LastSelected}}</strong></p>
</div>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public List<BreadcrumbActionData> Actions { get; set; } = new()
    {
        new() { Text = "Catalog" },
        new() { Text = "Details" },
        new() { Text = "Review" }
    };

    public string LastSelected { get; set; } = "Catalog";

    public void Select(string text)
    {
        LastSelected = text;
    }

    public class BreadcrumbActionData
    {
        public string Text { get; set; } = "";
    }
}

```

## Sample 4: Breadcrumb with RouteName

Uses `RouteName` on `MenuItem` children to navigate between pages registered inside the generated sample app.


```DOTHTML
<t:Breadcrumb>
    <t:MenuItem Text="Overview" RouteName="SampleA" IsActive="true" />
    <t:MenuItem Text="Details" RouteName="SampleB" />
</t:Breadcrumb>

<p>Overview page in the sample app. Use the breadcrumb to navigate to the details page.</p>
```

```DOTHTML
<t:Breadcrumb>
    <t:MenuItem Text="Overview" RouteName="SampleA" />
    <t:MenuItem Text="Details" RouteName="SampleB" IsActive="true" />
</t:Breadcrumb>

<p>Details page in the sample app. The breadcrumb stays inside the generated sample application.</p>
```

