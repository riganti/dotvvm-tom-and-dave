# <t:AppLayout>
Renders the application shell with optional `TopMenuTemplate` and `SideMenuTemplate` regions around the main `Content`.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|ITemplate|Template rendered as the main page content inside the layout body.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`SideMenuTemplate`|ITemplate|Template rendered in the sidebar panel for primary app navigation.|inner element, static value||
|`TopMenuTemplate`|ITemplate|Template rendered at the top of the page, typically for a header or top navigation bar.|inner element, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Top menu layout

Uses `TopMenuTemplate` together with `Content` to build a page shell that has only a top navigation bar.


```DOTHTML
<t:AppLayout>
    <TopMenuTemplate>
        <t:TopMenu HamburgerPosition="End">
            <StartTemplate>
                <a href="?view=home" class="text-xl font-bold text-blue-600 no-underline">Tailwind Docs</a>
            </StartTemplate>
            <MiddleTemplate>
                <t:MenuItem Text="Overview" NavigateUrl="?view=overview" IsActive="true" />
                <t:MenuItem Text="Pricing" NavigateUrl="?view=pricing" />
                <t:MenuItem Text="Contact" NavigateUrl="?view=contact" />
            </MiddleTemplate>
            <MobileTemplate>
                <t:MenuItem Text="Overview" NavigateUrl="?view=overview" IsActive="true" />
                <t:MenuItem Text="Pricing" NavigateUrl="?view=pricing" />
                <t:MenuItem Text="Contact" NavigateUrl="?view=contact" />
            </MobileTemplate>
            <EndTemplate>
                <t:Button Type="Primary" Text="Sign in" />
            </EndTemplate>
        </t:TopMenu>
    </TopMenuTemplate>
    <Content>
        <div class="p-4">
            <h2>Top menu only</h2>
            <p>The main content stays below the navigation bar.</p>
        </div>
    </Content>
</t:AppLayout>

```

## Sample 2: Side menu layout

Uses `SideMenuTemplate` without `TopMenuTemplate`. In this mode, `AppLayout` renders the mobile top bar and sidebar toggle automatically.


```DOTHTML
<t:AppLayout>
    <SideMenuTemplate>
        <t:SideMenu>
            <t:SideMenuSection Title="Workspace">
                <t:MenuItem Text="Dashboard" NavigateUrl="?section=dashboard" Icon="Home" IsActive="true" />
                <t:MenuItem Text="Messages" NavigateUrl="?section=messages" Icon="Envelope" />
                <t:MenuItem Text="Tasks" NavigateUrl="?section=tasks" Icon="CheckCircle" />
            </t:SideMenuSection>
            <t:SideMenuSection Title="Settings">
                <t:MenuItem Text="Profile" NavigateUrl="?section=profile" Icon="UserCircle" />
                <t:MenuItem Text="Billing" NavigateUrl="?section=billing" Icon="CreditCard" />
            </t:SideMenuSection>
        </t:SideMenu>
    </SideMenuTemplate>
    <Content>
        <div class="p-4">
            <h2>Side menu only</h2>
            <p>On small screens, the sidebar opens from the automatic mobile top bar.</p>
        </div>
    </Content>
</t:AppLayout>

```

## Sample 3: Combined top and side menus

Combines `TopMenuTemplate`, `SideMenuTemplate`, and `Content`. Place `SideMenuToggleButton` in the top menu when both menus are present.


```DOTHTML
<t:AppLayout>
    <TopMenuTemplate>
        <t:TopMenu HamburgerPosition="End">
            <StartTemplate>
                <t:SideMenuToggleButton />
                <a href="?view=dashboard" class="text-xl font-bold text-blue-600 no-underline">Admin</a>
            </StartTemplate>
            <EndTemplate>
                <t:MenuItem Icon="Bell" NavigateUrl="?panel=notifications" />
                <t:MenuDropDownItem Icon="UserCircle">
                    <Items>
                        <t:MenuItem Text="Profile" NavigateUrl="?panel=profile" />
                        <t:MenuItem Text="Sign out" NavigateUrl="?panel=signout" />
                    </Items>
                </t:MenuDropDownItem>
            </EndTemplate>
            <MobileTemplate>
                <t:MenuItem Text="Profile" NavigateUrl="?panel=profile" />
                <t:MenuItem Text="Sign out" NavigateUrl="?panel=signout" />
            </MobileTemplate>
        </t:TopMenu>
    </TopMenuTemplate>
    <SideMenuTemplate>
        <t:SideMenu>
            <t:SideMenuSection Title="Reports">
                <t:MenuItem Text="Overview" NavigateUrl="?report=overview" Icon="ChartBar" IsActive="true" />
                <t:MenuItem Text="Revenue" NavigateUrl="?report=revenue" Icon="PresentationChartLine" />
            </t:SideMenuSection>
        </t:SideMenu>
    </SideMenuTemplate>
    <Content>
        <div class="p-4">
            <h2>Dashboard shell</h2>
            <p>The top bar stays visible while the side menu provides section navigation.</p>
        </div>
    </Content>
</t:AppLayout>

```

