# <bs:TabControl>
Renders the Bootstrap Tabs widget.

<https://getbootstrap.com/docs/3.3/javascript/#tabs>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ActiveTabIndex`|Int32?|Gets or sets the index of the active tab.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the template for headers of the generated items when using the DataSource property.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsActiveBinding`|IValueBinding|Gets or sets the property on the data-bound object which specifies whether the tab is active.|attribute, bindable||
|`Items`|List<TabItem>|Gets or sets the list of TabItem controls.|attribute, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ActiveTabChanged`|Command|Triggers a command in the viewmodel when an active tab changes.|

## Sample 1: Basic TabControl

Each tab is represented by the [TabItem](~/controls/bootstrap/TabItem) control.

The header and content of each `TabItem` is defined using the `HeaderTemplate` and `ContentTemplate` properties.  

The `IsActive` property specifies whether the tab is currently selected or not.

```DOTHTML
<bs:TabControl>
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
```

## Sample 2: ActiveTabIndex Property

The `ActiveTabIndex` property specifies a zero-base index of the tab which is currently selected.

Please note that the `ActiveTabIndex` takes precedence over the [TabItem](~/controls/bootstrap/TabItem)  

```DOTHTML
<bs:TabControl ActiveTabIndex="{value: Index}" >
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

## Sample 3: TabControl Data-Binding

To create tab items from a collection in the viewmodel, use the `DataSource` property bound to any `IEnumerable` collection in the viewmodel.

The `HeaderTemplate` and `ContentTemplate` specify the templates for the generated tab items.
  
If you want to control which tab item is active in combination with the `DataSource` property, you can do it by setting the `IsActiveBinding` property 
to a property on the data-bound items which specifies whether the tab should be active or not.

```DOTHTML
<bs:TabControl DataSource="{value: Tabs}" 
               IsActiveBinding="{value: IsActive}" >
  <HeaderTemplate>Tab {{value: Name}}</HeaderTemplate>
  <ContentTemplate>
    <p>{{value: Description}}</p>
    <dot:Button Click="{command: _parent.Write(Id)}" Text="Write Contents" />
  </ContentTemplate>
</bs:TabControl>
<p>Result: {{value: Text}}</p>

```

```CSHARP
using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TabControl.sample3
{
    public class ViewModel
    {
        public List<TabData> Tabs { get; set; }

        public void Write(int index)
        {
            var selectedTab = Tabs.Single(t => t.Id == index);
            Text = selectedTab.Id + " - " + selectedTab.Name + " - " + selectedTab.Description;
        }

        public string Text { get; set; }

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
    }
    public class TabData
    {
        public bool IsActive { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
```

## Sample 4: ActiveTabChanged Event

The `ActiveTabChanged` event is triggered when the user select another tab item. 

```DOTHTML
<bs:TabControl ActiveTabChanged="{command: SelectedTabChanged()}">
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

