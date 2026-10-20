# <t:DropDownButton>
Renders a Tailwind-styled button that opens a dropdown menu. Use hardcoded `DropDownItem` children or bind `DataSource` with `Item*` properties to generate the menu from data.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([DropDownAlignment](../_enums/DotVVM.Controls.Tailwind.Controls.DropDownAlignment.md))|Gets or sets whether the dropdown menu aligns to the start or end edge of the trigger.|attribute, static value, bindable|Start|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets custom content rendered inside the dropdown trigger button.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the collection used to generate dropdown items automatically.|attribute, bindable||
|`Icon`|HeroIcon?|Gets or sets an optional icon rendered before the trigger text or content.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemCulture`|String|Gets or sets the culture segment used when each generated dropdown item navigates by route.|attribute, static value||
|`ItemIcon`|HeroIcon?|Gets or sets the icon displayed before each generated item label when DataSource is used. Cannot be combined with ItemTemplate.|attribute, static value||
|`ItemNavigateUrl`|String|Gets or sets the URL assigned to each generated dropdown item when DataSource is used.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the DotVVM route name each generated dropdown item navigates to when DataSource is used.|attribute, static value||
|`Items`|List<IDropDownMenuItem>|Gets or sets hardcoded  and  children rendered inside the dropdown menu.|inner element, static value, default property||
|`ItemTemplate`|ITemplate|Gets or sets a rich content template rendered for each generated dropdown item when DataSource is used. Mutually exclusive with ItemText.|inner element, static value||
|`ItemText`|String|Gets or sets the plain text rendered for each generated dropdown item when DataSource is used. Mutually exclusive with ItemTemplate.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets the URL suffix appended to each generated route-based dropdown item.|attribute, static value, bindable||
|`Text`|String|Gets or sets plain text rendered inside the dropdown trigger button.|attribute, static value, bindable||
|`Type`|([ButtonType](../_enums/DotVVM.Controls.Tailwind.Controls.ButtonType.md))|Gets or sets the visual style of the trigger button.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command invoked for each generated dropdown item when DataSource is used.|

## Sample 1: Hardcoded Items and Separators

Place `DropDownItem` children directly inside `DropDownButton` when you need a fixed menu. This sample shows trigger `Text`, `Icon`, `Type`, item `Click`, item `Icon`, and a `DropDownItemSeparator`.

```DOTHTML
<t:DropDownButton Text="Actions" Icon="Bolt" Type="Primary">
    <t:DropDownItem Text="Edit" Click="{command: RecordAction("Edit")}" />
    <t:DropDownItem Text="Duplicate" Icon="DocumentDuplicate" Click="{command: RecordAction("Duplicate")}" />
    <t:DropDownItemSeparator />
    <t:DropDownItem Text="Jump to summary" NavigateUrl="#summary" />
</t:DropDownButton>

<p>Last action: {{value: LastAction}}</p>

<h3 id="summary">Summary target</h3>
<p>The navigate item stays inside the sample and scrolls to this section.</p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.DropDownButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LastAction { get; set; } = "(none)";

        public void RecordAction(string action)
        {
            LastAction = action;
        }
    }
}

```

## Sample 2: DataSource, Content, Alignment, and Item Bindings

When the menu is generated from `DataSource`, use the `Item*` properties to map fields from each collection item. This sample shows trigger `Content`, `Alignment`, `ItemText`, `ItemIcon`, `ItemClick`, and `ItemNavigateUrl`.


```DOTHTML
<t:DropDownButton Type="Secondary"
                  DataSource="{value: ActionItems}"
                  ItemText="{value: Text}"
                  ItemIcon="Bolt"
                  ItemClick="{command: _parent.RecordAction(Text)}">
    <Content>
        <span>Quick actions</span>
    </Content>
</t:DropDownButton>

<t:DropDownButton Text="Jump to section"
                  Type="Default"
                  Alignment="End"
                  DataSource="{value: SectionItems}"
                  ItemText="{value: Text}"
                  ItemNavigateUrl="{value: Url}" />

<p>Last action: {{value: LastAction}}</p>

<h3 id="drafts">Drafts</h3>
<p>The second dropdown uses `ItemNavigateUrl` to jump to anchors inside the sample.</p>

<h3 id="reports">Reports</h3>
<p>Use `Alignment="End"` when the menu is near the right edge.</p>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.DropDownButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LastAction { get; set; } = "(none)";

        public List<DropDownOption> ActionItems { get; set; } = new List<DropDownOption>
        {
            new DropDownOption { Text = "Save draft" },
            new DropDownOption { Text = "Publish" },
            new DropDownOption { Text = "Archive" }
        };

        public List<DropDownOption> SectionItems { get; set; } = new List<DropDownOption>
        {
            new DropDownOption { Text = "Drafts", Url = "#drafts" },
            new DropDownOption { Text = "Reports", Url = "#reports" }
        };

        public void RecordAction(string action)
        {
            LastAction = action;
        }
    }

    public class DropDownOption
    {
        public string Text { get; set; }

        public string Url { get; set; }
    }
}

```

## Sample 3: ItemTemplate and Route Navigation

Use `RouteName` for hardcoded route-based items. In `DataSource` mode, `ItemTemplate` lets you render richer item content, and `ItemRouteName` can send generated items to a route inside the sample app.


```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Main">
    <t:DropDownButton Text="Route items" Type="Primary">
        <t:DropDownItem Text="Overview" RouteName="SampleA" />
        <t:DropDownItem Text="Details" RouteName="SampleB" />
    </t:DropDownButton>

    <t:DropDownButton Text="Template items"
                      Type="Default"
                      DataSource="{value: RouteOptions}"
                      ItemRouteName="SampleB">
        <ItemTemplate>
            <span>
                <strong>{{value: Title}}</strong>
                <span> - {{value: Description}}</span>
            </span>
        </ItemTemplate>
    </t:DropDownButton>

    <p>Current page: Sample A</p>
</dot:Content>

```

```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Main">
    <t:DropDownButton Text="Back to overview" Type="Primary">
        <t:DropDownItem Text="Open Sample A" RouteName="SampleA" />
    </t:DropDownButton>

    <p>Current page: Sample B</p>
</dot:Content>

```

```DOTHTML
<dot:ContentPlaceHolder ID="Main" />

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.DropDownButton.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<RouteOption> RouteOptions { get; set; } = new List<RouteOption>
        {
            new RouteOption { Title = "Orders", Description = "Open the details page." },
            new RouteOption { Title = "Invoices", Description = "This item uses the same route target." }
        };
    }

    public class RouteOption
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

```

```CSHARP
using DotVVM.Framework.Configuration;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.DropDownButton.sample3
{
    public class Startup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("SampleA", "", "SampleA.dothtml", null);
            config.RouteTable.Add("SampleB", "details", "SampleB.dothtml", null);
        }
    }
}

```

