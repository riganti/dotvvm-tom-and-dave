# <t:TabControl>
Renders a Tailwind tab strip composed of `TabItem` children. Use `HeaderText` or `HeaderTemplate` for the tab label, `ContentTemplate` for each panel, and `SelectedTabIndex` to control the active tab.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<TabItem>|Gets or sets the tab items inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`SelectedTabIndex`|Int32|Gets or sets the index of the currently selected tab (0-based).|attribute, static value, bindable|0|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: HeaderText and ContentTemplate

Each `TabItem` needs content inside `ContentTemplate`. `HeaderText` is the simplest way to define the tab caption.


```DOTHTML
<t:TabControl>
    <t:TabItem HeaderText="Profile">
        <ContentTemplate>
            <p>Profile information is displayed in this panel.</p>
        </ContentTemplate>
    </t:TabItem>
    <t:TabItem HeaderText="Settings">
        <ContentTemplate>
            <p>Settings are rendered in a separate panel.</p>
        </ContentTemplate>
    </t:TabItem>
    <t:TabItem HeaderText="Activity">
        <ContentTemplate>
            <p>Use more tabs when you need to split related content.</p>
        </ContentTemplate>
    </t:TabItem>
</t:TabControl>

```

## Sample 2: HeaderTemplate

Use `HeaderTemplate` when the tab header needs richer markup, such as badges or emphasized text.


```DOTHTML
<t:TabControl>
    <t:TabItem>
        <HeaderTemplate>
            <span>Inbox <span class="ml-1 rounded-full bg-blue-600 px-2 py-0.5 text-xs text-white">3</span></span>
        </HeaderTemplate>
        <ContentTemplate>
            <p>The header can contain custom HTML content.</p>
        </ContentTemplate>
    </t:TabItem>
    <t:TabItem>
        <HeaderTemplate>
            <span class="font-semibold">Starred</span>
        </HeaderTemplate>
        <ContentTemplate>
            <p>Template headers are useful for icons, badges, or formatted labels.</p>
        </ContentTemplate>
    </t:TabItem>
</t:TabControl>

```

## Sample 3: SelectedTabIndex Binding

Bind `SelectedTabIndex` to the viewmodel when another control should select the active tab programmatically.


```DOTHTML
<p>Selected tab index: {{value: SelectedTabIndex}}</p>

<t:Button Type="Primary" Text="Select tab 0" Click="{command: SelectTab(0)}" />
<t:Button Type="Secondary" Text="Select tab 1" Click="{command: SelectTab(1)}" />
<t:Button Type="Success" Text="Select tab 2" Click="{command: SelectTab(2)}" />

<t:TabControl SelectedTabIndex="{value: SelectedTabIndex}">
    <t:TabItem HeaderText="Overview">
        <ContentTemplate>
            <p>Overview tab content.</p>
        </ContentTemplate>
    </t:TabItem>
    <t:TabItem HeaderText="Details">
        <ContentTemplate>
            <p>Details tab content.</p>
        </ContentTemplate>
    </t:TabItem>
    <t:TabItem HeaderText="History">
        <ContentTemplate>
            <p>History tab content.</p>
        </ContentTemplate>
    </t:TabItem>
</t:TabControl>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.TabControl.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SelectedTabIndex { get; set; }

        public void SelectTab(int index)
        {
            SelectedTabIndex = index;
        }
    }
}

```

