# <bs:TabControl>
Renders the Bootstrap Navigation Tabs widget.

<https://getbootstrap.com/docs/4.3/components/navs/#javascript-behavior>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ActiveTabIndex`|Int32?|Gets or sets the index of the active tab.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection to data-bind the tab items.|attribute, bindable||
|`EnableAnimation`|Boolean|Gets or sets whether the tab changes should use the fade animation.|attribute, static value|False|
|`HeaderTemplate`|ITemplate|Gets or sets the template for headers of the generated items when using the DataSource property.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnabledBinding`|IValueBinding|Gets or sets the property on the data-bound object which specifies whether the tab is enabled.|attribute, bindable||
|`Items`|List<TabItem>|Gets or sets the list of TabItem controls.|inner element, static value, default property||
|`ItemsLayout`|([ItemsLayout](../_enums/DotVVM.Framework.Controls.Bootstrap4.ItemsLayout.md))|Gets or sets layout of inner items.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([NavigationBarVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.NavigationBarVisualStyle.md))|Gets or sets the type of the navigation bar.|attribute, static value|Tabs|

## Events
|Name|Type|Description|
|---|---|---|
|`ActiveTabChanged`|Command|Triggers a command in the viewmodel when an active tab changes.|

## Sample 1: Basic TabControl

Each tab is represented by the [TabItem](~/controls/bootstrap4/TabItem) control.

The header and content of each `TabItem` is defined using the `HeaderTemplate` and `ContentTemplate` properties.  

The `ActiveTabIndex` property specifies a zero-based index of the tab that is currently selected.

A tab item can be disabled by setting its `Enabled` property to `false`.

```DOTHTML
<bs:TabControl>
  <bs:TabItem>
    <HeaderTemplate>Tab 1</HeaderTemplate>
    <ContentTemplate>
      <p>First tab</p>
    </ContentTemplate>
  </bs:TabItem>

  <bs:TabItem>
    <HeaderTemplate>Tab 2</HeaderTemplate>
    <ContentTemplate>
      <p>Second tab</p>
    </ContentTemplate>
  </bs:TabItem>

  <bs:TabItem Enabled="false">
    <HeaderTemplate>Tab 3</HeaderTemplate>
    <ContentTemplate>
      <p>Third tab</p>
    </ContentTemplate>
  </bs:TabItem>
</bs:TabControl>
```

## Sample 2: ActiveTabIndex Property

The `ActiveTabIndex` property specifies a zero-based index of the tab which is currently selected.

Please note that the `ActiveTabIndex` takes precedence over the `IsActive` property of [TabItem](~/controls/bootstrap4/TabItem).

```DOTHTML
<bs:TabControl ActiveTabIndex="{value: Index}">
  <bs:TabItem>
    <HeaderTemplate>Tab 1</HeaderTemplate>
    <ContentTemplate>
      <p>First tab</p>
    </ContentTemplate>
  </bs:TabItem>

  <bs:TabItem>
    <HeaderTemplate>Tab 2</HeaderTemplate>
    <ContentTemplate>
      <p>Second tab</p>
    </ContentTemplate>
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

The `HeaderTemplate` and `ContentTemplate` specify the templates for the generated tab items.

<!-- TODO: IsActiveBinding and IsEnabledBinding -->

```DOTHTML
<bs:TabControl DataSource="{value: Tabs}">
  <HeaderTemplate>Tab {{value: Name}}</HeaderTemplate>
  <ContentTemplate>
    <p>{{value: Description}}</p>
    <dot:Button Click="{command: _parent.SelectTab(Id)}" Text="Select Tab" />
  </ContentTemplate>
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

## Sample 4: ActiveTabChanged Event

The `ActiveTabChanged` event is triggered when the user select another tab item. 

```DOTHTML
<bs:TabControl ActiveTabChanged="{command: SelectedTabChanged()}">
    <bs:TabItem IsActive="true">
        <HeaderTemplate>Tab 1</HeaderTemplate>
        <ContentTemplate>
            <p>First tab</p>
        </ContentTemplate>
    </bs:TabItem>

    <bs:TabItem>
        <HeaderTemplate>Tab 2</HeaderTemplate>
        <ContentTemplate>
            <p>Second tab</p>
        </ContentTemplate>
    </bs:TabItem>
</bs:TabControl>

{{value: NumberOfChanges}}
```

```CSHARP
using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TabControl.sample3
{
    public class ViewModel
    { 
        public int NumberOfChanges { get; set; } = 0;   
                 
        public void SelectedTabChanged()
        {
            NumberOfChanges++;
        }
    }
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
    <ContentTemplate>
      <p>First tab</p>
    </ContentTemplate>
  </bs:TabItem>

  <bs:TabItem>
    <HeaderTemplate>Tab 2</HeaderTemplate>
    <ContentTemplate>
      <p>Second tab</p>
    </ContentTemplate>
  </bs:TabItem>

  <bs:TabItem Enabled="false">
    <HeaderTemplate>Tab 3</HeaderTemplate>
    <ContentTemplate>
      <p>Third tab</p>
    </ContentTemplate>
  </bs:TabItem>
</bs:TabControl>
```

