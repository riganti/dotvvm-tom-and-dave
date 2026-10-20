# <t:SideMenu>
Renders a Tailwind sidebar navigation panel composed of `SideMenuSection`, `MenuItem`, and `MenuDropDownItem`. Use `collapseBreakpoint` to control when the menu switches to its mobile overlay behavior.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CollapseBreakpoint`|([TailwindBreakpoint](../_enums/DotVVM.Controls.Tailwind.Controls.TailwindBreakpoint.md))|Gets or sets the Tailwind breakpoint where the side menu switches from the mobile overlay mode to the always-visible desktop layout.|attribute, static value|Large|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Sections`|List<DotvvmControl>|Gets or sets the collection of  controls rendered inside the side menu.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Sections, Items, and Dropdown Items

This sample shows the main `SideMenu` building blocks: section titles, flat menu items, separators, and nested `MenuDropDownItem` navigation. All links stay inside the sample by using page anchors.


```DOTHTML
<div style="display:flex;min-height:20rem;border:1px solid #e5e7eb;">
    <t:SideMenu>
        <t:SideMenuSection Title="Main">
            <t:MenuItem Text="Overview" NavigateUrl="#overview" Icon="Home" IsActive="true" />
            <t:MenuItem Text="Messages" NavigateUrl="#messages" Icon="Envelope" />
            <t:MenuItemSeparator />
            <t:MenuItem Text="Tasks" NavigateUrl="#tasks" Icon="CheckCircle" />
        </t:SideMenuSection>
        <t:SideMenuSection Title="Reports">
            <t:MenuDropDownItem Text="Analytics" Icon="ChartBar">
                <t:MenuItem Text="Traffic" NavigateUrl="#traffic" />
                <t:MenuItem Text="Conversions" NavigateUrl="#conversions" />
            </t:MenuDropDownItem>
        </t:SideMenuSection>
    </t:SideMenu>

    <div style="padding:1rem;flex:1;">
        <h3 id="overview">Overview</h3>
        <p>The menu can mix plain items and dropdown sections.</p>

        <h3 id="messages">Messages</h3>
        <p>`MenuItem` can navigate to anchors inside the same page.</p>

        <h3 id="tasks">Tasks</h3>
        <p>Use `MenuItemSeparator` to break larger groups.</p>

        <h3 id="traffic">Traffic</h3>
        <p>The dropdown opens nested links.</p>

        <h3 id="conversions">Conversions</h3>
        <p>All links stay inside the generated sample app.</p>
    </div>
</div>

```

## Sample 2: DataSource and Repeater-Based Menus

`MenuDropDownItem` can generate its child items from `DataSource`, and flat groups can still be produced with a `dot:Repeater`. This mirrors the current Tailwind samples for data-driven side menus.


```DOTHTML
<div style="display:flex;min-height:20rem;border:1px solid #e5e7eb;">
    <t:SideMenu>
        <t:SideMenuSection Title="Settings">
            <t:MenuDropDownItem Text="Account" Icon="Cog6Tooth"
                                DataSource="{value: SettingsLinks}"
                                ItemText="{value: Text}"
                                ItemNavigateUrl="{value: Url}" />
        </t:SideMenuSection>
        <t:SideMenuSection Title="Quick Links">
            <dot:Repeater DataSource="{value: QuickLinks}" RenderWrapperTag="false">
                <t:MenuItem Text="{value: Text}" NavigateUrl="{value: Url}" />
            </dot:Repeater>
        </t:SideMenuSection>
    </t:SideMenu>

    <div style="padding:1rem;flex:1;">
        <h3 id="profile">Profile</h3>
        <p>The dropdown items were generated from `SettingsLinks`.</p>

        <h3 id="security">Security</h3>
        <p>`ItemText` and `ItemNavigateUrl` map the current item fields.</p>

        <h3 id="help">Help</h3>
        <p>The repeater generates a flat list of `MenuItem` controls.</p>
    </div>
</div>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.SideMenu.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<NavItem> SettingsLinks { get; set; } = new List<NavItem>
        {
            new NavItem { Text = "Profile", Url = "#profile" },
            new NavItem { Text = "Security", Url = "#security" }
        };

        public List<NavItem> QuickLinks { get; set; } = new List<NavItem>
        {
            new NavItem { Text = "Help", Url = "#help" }
        };
    }

    public class NavItem
    {
        public string Text { get; set; }

        public string Url { get; set; }
    }
}

```

## Sample 3: Mobile Wrapper and Collapse Breakpoint

Use `collapseBreakpoint` to decide when the sidebar switches to its mobile overlay mode. The `.hamburger-button`, `.side-menu-mobile`, and overlay markup make the sample interactive on smaller screens.


```DOTHTML
<div style="position:relative;min-height:18rem;border:1px solid #e5e7eb;overflow:hidden;">
    <button class="hamburger-button"
            data-sidemenu-toggle="docs-mobile-menu"
            style="position:absolute;top:0.75rem;left:0.75rem;z-index:20;display:flex;">
        <svg xmlns="http://www.w3.org/2000/svg" style="width:1.5rem;height:1.5rem;" fill="none" viewBox="0 0 24 24" stroke="currentColor" stroke-width="2">
            <path stroke-linecap="round" stroke-linejoin="round" d="M4 6h16M4 12h16M4 18h16" />
        </svg>
    </button>

    <div class="side-menu-mobile-overlay"></div>

    <div class="side-menu-mobile" id="docs-mobile-menu">
        <t:SideMenu collapseBreakpoint="md">
            <t:SideMenuSection Title="Navigation">
                <t:MenuItem Text="Overview" NavigateUrl="#overview-mobile" Icon="Home" IsActive="true" />
                <t:MenuItem Text="Team" NavigateUrl="#team-mobile" Icon="Users" />
            </t:SideMenuSection>
        </t:SideMenu>
    </div>

    <div style="padding:3.5rem 1rem 1rem 1rem;">
        <h3 id="overview-mobile">Overview</h3>
        <p>Resize the sample below the `md` breakpoint and use the hamburger button to open the menu.</p>

        <h3 id="team-mobile">Team</h3>
        <p>The sidebar closes automatically when the screen reaches the configured breakpoint again.</p>
    </div>
</div>

```

