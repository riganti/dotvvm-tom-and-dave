# <t:TopMenu>
Renders a Tailwind top navigation bar with `StartTemplate`, `MiddleTemplate`, `EndTemplate`, and optional `MobileTemplate`. Set `HamburgerPosition` when the mobile toggle should appear at the end of the bar.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EndTemplate`|ITemplate|Gets or sets the content rendered in the end zone, such as actions, icons, or the user menu.|inner element, static value||
|`HamburgerPosition`|([HamburgerPosition](../_enums/DotVVM.Controls.Tailwind.Controls.HamburgerPosition.md))|Gets or sets whether the mobile hamburger toggle is rendered before or after the menu zones.|attribute, static value|Start|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MiddleTemplate`|ITemplate|Gets or sets the content rendered in the middle zone, typically the main navigation items.|inner element, static value||
|`MobileTemplate`|ITemplate|Gets or sets the content rendered inside the collapsible mobile navigation panel.|inner element, static value||
|`StartTemplate`|ITemplate|Gets or sets the content rendered in the start zone, typically a logo or brand link.|inner element, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Full Top Menu Layout

This sample uses all main layout areas of `TopMenu`. It also includes `MobileTemplate` and `HamburgerPosition="End"` so the menu stays usable on smaller screens.


```DOTHTML
<t:TopMenu HamburgerPosition="End">
    <StartTemplate>
        <span class="text-lg font-bold text-blue-600">DocsApp</span>
    </StartTemplate>
    <MiddleTemplate>
        <t:MenuItem Text="Dashboard" NavigateUrl="#dashboard" IsActive="true" />
        <t:MenuItem Text="Projects" NavigateUrl="#projects" />
        <t:MenuDropDownItem Text="Reports">
            <t:MenuItem Text="Weekly" NavigateUrl="#weekly" />
            <t:MenuItem Text="Monthly" NavigateUrl="#monthly" />
        </t:MenuDropDownItem>
    </MiddleTemplate>
    <EndTemplate>
        <t:Button Type="Ghost" Icon="Bell" />
        <t:DropDownButton Text="Profile" Alignment="End">
            <t:DropDownItem Text="Settings" NavigateUrl="#settings" />
            <t:DropDownItem Text="Sign out" NavigateUrl="#signout" />
        </t:DropDownButton>
    </EndTemplate>
    <MobileTemplate>
        <t:MenuItem Text="Dashboard" NavigateUrl="#dashboard" IsActive="true" />
        <t:MenuItem Text="Projects" NavigateUrl="#projects" />
        <t:MenuItem Text="Weekly" NavigateUrl="#weekly" />
        <t:MenuItem Text="Monthly" NavigateUrl="#monthly" />
    </MobileTemplate>
</t:TopMenu>

<h3 id="dashboard">Dashboard</h3>
<p>The top menu can host menu items, dropdowns, and arbitrary controls.</p>

<h3 id="projects">Projects</h3>
<p>These links stay inside the sample by using anchor navigation.</p>

<h3 id="weekly">Weekly report</h3>
<p>The nested dropdown items use the same menu styling.</p>

<h3 id="monthly">Monthly report</h3>
<p>The end dropdown aligns to the right edge.</p>

<h3 id="settings">Settings</h3>
<p>End-template actions can also navigate inside the sample.</p>

<h3 id="signout">Sign out</h3>
<p>`DropDownButton` works well inside the `EndTemplate` area.</p>

```

## Sample 2: DataSource-Driven Dropdown Items

`MenuDropDownItem` can render data-driven items inside the `MiddleTemplate`. This sample shows both `ItemClick` and `ItemNavigateUrl`.


```DOTHTML
<t:TopMenu>
    <StartTemplate>
        <span class="text-lg font-bold text-blue-600">Workspace</span>
    </StartTemplate>
    <MiddleTemplate>
        <t:MenuItem Text="Overview" NavigateUrl="#overview" IsActive="true" />
        <t:MenuDropDownItem Text="Actions"
                            DataSource="{value: ActionItems}"
                            ItemText="{value: Text}"
                            ItemClick="{command: _parent.RecordClick(Text)}" />
        <t:MenuDropDownItem Text="Sections"
                            DataSource="{value: SectionItems}"
                            ItemText="{value: Text}"
                            ItemNavigateUrl="{value: Url}" />
    </MiddleTemplate>
</t:TopMenu>

<p>Last clicked action: {{value: LastClicked}}</p>

<h3 id="overview">Overview</h3>
<p>The first dropdown posts back using `ItemClick`.</p>

<h3 id="release">Release notes</h3>
<p>The second dropdown uses `ItemNavigateUrl` for in-page navigation.</p>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.TopMenu.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LastClicked { get; set; } = "(none)";

        public List<MenuOption> ActionItems { get; set; } = new List<MenuOption>
        {
            new MenuOption { Text = "Refresh" },
            new MenuOption { Text = "Export" }
        };

        public List<MenuOption> SectionItems { get; set; } = new List<MenuOption>
        {
            new MenuOption { Text = "Release notes", Url = "#release" }
        };

        public void RecordClick(string action)
        {
            LastClicked = action;
        }
    }

    public class MenuOption
    {
        public string Text { get; set; }

        public string Url { get; set; }
    }
}

```

## Sample 3: Minimal Start and End Templates

`TopMenu` does not require a middle area. Omitting `MiddleTemplate` produces a simple brand-and-actions bar.


```DOTHTML
<t:TopMenu>
    <StartTemplate>
        <span class="text-lg font-bold text-blue-600">BrandLogo</span>
    </StartTemplate>
    <EndTemplate>
        <t:Button Type="Primary" Text="Sign in" />
    </EndTemplate>
</t:TopMenu>

```

