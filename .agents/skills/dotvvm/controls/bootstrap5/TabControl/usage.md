# <dot:TabControl>
Renders the Bootstrap Navigation Tabs widget.

<https://getbootstrap.com/docs/5.2/components/navs-tabs>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Animation`|([TabControlAnimation](../_enums/DotVVM.Bootstrap5.Controls.TabControlAnimation.md))|Gets or sets whether the tab changes should use the fade animation.|attribute, static value|Fade|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`HorizontalAlignment`|([TabControlBarHorizontalAlignment](../_enums/DotVVM.Bootstrap5.Controls.TabControlBarHorizontalAlignment.md))|Gets or sets the alignment of the tabs.|attribute, static value, bindable|Left|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemContentTemplate`|ITemplate|Gets or sets a custom template for TabTtem content when DataSource is set.|inner element, static value||
|`ItemContentText`|String|Gets or sets a plain text for TabTtem content when DataSource is set.|attribute, static value, bindable||
|`ItemEnabled`|Boolean|Gets or sets whether the tab is enabled when DataSource is set.|attribute, static value, bindable|True|
|`ItemHeaderTemplate`|ITemplate|Gets or sets a custom template for TabItem header when DataSource is set.|inner element, static value||
|`ItemHeaderText`|String|Gets or sets a plain text for TabItem header when DataSource is set.|attribute, static value, bindable||
|`Items`|List<ITabItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether the tab is selected when DataSource is set.|attribute, static value, bindable||
|`ItemUrlFragment`|String||attribute, static value, bindable||
|`Justify`|([Justify](../_enums/DotVVM.Bootstrap5.Controls.Justify.md))|Gets or sets the justify behavior of the tabs. Fill makes items occupy all horizontal space, but not every nav item has the same width. Justify sets every nav item to the same width.|attribute, static value, bindable|None|
|`SelectedTabIndex`|Int32|Gets or sets the index of the active tab.|attribute, static value, bindable||
|`VerticalBreakPoint`|([TabControlVerticalAlignment](../_enums/DotVVM.Bootstrap5.Controls.TabControlVerticalAlignment.md))|Gets or sets the breakpoint when TabControl changes to column layout.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([NavigationBarVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.NavigationBarVisualStyle.md))|Gets or sets the type of the navigation bar.|attribute, static value|Tabs|

## Events
|Name|Type|Description|
|---|---|---|
|`ActiveTabChanged`|ICommandBinding||

## Sample 1: Basic TabControl

Each tab is represented by the [TabItem](~/controls/bootstrap5/TabItem) control.

The header and content of each `TabItem` is defined using the `HeaderTemplate` and `ContentTemplate` properties.  

The `SelectedTabIndex` property specifies a zero-based index of the tab that is currently selected.

A tab item can be disabled by setting its `Enabled` property to `false`.

```DOTHTML
<bs:TabControl>
  <bs:TabItem>
    <HeaderTemplate>Tab 1</HeaderTemplate>
      <p>First tab</p>
  </bs:TabItem>

  <bs:TabItem>
    <HeaderTemplate>Tab 2</HeaderTemplate>
      <p>Second tab</p>
  </bs:TabItem>

  <bs:TabItem Enabled="false">
    <HeaderTemplate>Tab 3</HeaderTemplate>
      <p>Third tab</p>
  </bs:TabItem>
</bs:TabControl>
```

## Sample 2: SelectedTabIndex Property

The `SelectedTabIndex` property specifies a zero-based index of the tab which is currently selected.

Please note that the `SelectedTabIndex` takes precedence over the `Selected` property of [TabItem](~/controls/bootstrap5/TabItem).

```DOTHTML
<bs:TabControl SelectedTabIndex="{value: Index}">
  <bs:TabItem>
    <HeaderTemplate>Tab 1</HeaderTemplate>
      <p>First tab</p>
  </bs:TabItem>

  <bs:TabItem>
    <HeaderTemplate>Tab 2</HeaderTemplate>
      <p>Second tab</p>
  </bs:TabItem>
</bs:TabControl>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TabControl.sample2
{
    public class ViewModel
    {
        public int Index { get; set; } = 1;
    }
}
```

## Sample 3: Data-Binding Tab Items

To create tab items from a collection in the viewmodel, use the `DataSource` property bound to any `IEnumerable` collection in the viewmodel.

The `ItemHeaderTemplate` and `ItemContentTemplate` specify the templates for the generated tab items. To set a plain text for header and a TabItem content `ItemContentText` and `ItemHeaderText` properties could be used.

The `ItemEnabled` and `ItemSelected` allow to change the TabItem availability and selected state with data binging.

```DOTHTML
<bs:TabControl DataSource="{value: Tabs}">
  <HeaderTemplate>Tab {{value: Name}}</HeaderTemplate>
  <p>{{value: Description}}</p>
  <dot:Button Click="{command: _parent.SelectTab(Id)}" Text="Select Tab" />
</bs:TabControl>

<p>Selected Tab: {{value: Selected}}</p>

```

```CSHARP
public class ViewModel
{
    public List<TabData> Tabs { get; set; }

    public string Selected { get; set; }


    public ViewModel()
    {
        Tabs = new List<TabData>()
        {
            new TabData() { Id = 1, Name = "Tab 1", Description = "Tab one" },
            new TabData() { Id = 2, Name = "Tab 2", Description = "Tab two" },
            new TabData() { Id = 3, Name = "Tab 3", Description = "Tab three"},
            new TabData() { Id = 4, Name = "Tab 4", Description = "Tab four" }
        };
    }

    public void SelectTab(int index)
    {
        var selectedTab = Tabs.Single(t => t.Id == index);
        Selected = selectedTab.Id + " - " + selectedTab.Name + " - " + selectedTab.Description;
    }

}

public class TabData
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

}

```

## Sample 5: TabControl Appearance

<!-- TODO: EnableAnimation -->
<!-- TODO: IsFilled and IsJustified -->

The `VisualStyle` property specifies how the navigation bar should look like - `Tabs`, `Pills` and `Simple`.

<!-- The `IsFilled` property defines whether the navigation bar takes all available horizontal space. 

The `IsJustified` property defines whether the navigation items should have equal width. -->


```DOTHTML
<bs:TabControl VisualStyle="Pills">
  <bs:TabItem IsActive="true">
    <HeaderTemplate>Tab 1</HeaderTemplate>
      <p>First tab</p>
  </bs:TabItem>

  <bs:TabItem>
    <HeaderTemplate>Tab 2</HeaderTemplate>
      <p>Second tab</p>
  </bs:TabItem>

  <bs:TabItem Enabled="false">
    <HeaderTemplate>Tab 3</HeaderTemplate>
      <p>Third tab</p>
  </bs:TabItem>
</bs:TabControl>
```

