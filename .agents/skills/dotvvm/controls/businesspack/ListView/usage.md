# <bp:ListView>
Renders a list of items and allows the user to select one or more items.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowDragDropSelection`|Boolean||attribute, static value|True|
|`AutoFocus`|Boolean||attribute, static value|False|
|`AutoFocusFirstItem`|Boolean||attribute, static value|True|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable||attribute, bindable||
|`DisplayMode`|ListViewDisplayMode||attribute, static value, bindable|List|
|`EmptyDataTemplate`|ITemplate||inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemEnabledBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemKeyBinding`|IValueBinding||attribute, bindable||
|`ItemValueBinding`|IValueBinding||attribute, bindable||
|`MaxSelectedValues`|Int32?||attribute, static value||
|`RowTemplate`|ITemplate||inner element, static value||
|`SelectedValues`|IEnumerable||attribute, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`TileTemplate`|ITemplate||inner element, static value||
|`ToggleSelectionOnClick`|Boolean||attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WarnWhenValueNotInDataSource`|Boolean||attribute, static value|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. For each item in the collection, a list item is created.

The `SelectedValues` property is bound to a collection which contains all selected strings. The data-binding works in both ways, so you can either read, or modify the collection in the viewmodel and the control will be synchronized to reflect the changes.

```DOTHTML
<bp:ListView DataSource="{value: Fruit}"
             SelectedValues="{value: SelectedFruit}">
    <RowTemplate>
        <span>{{value: _this}}</span>
    </RowTemplate>
</bp:ListView>

<p>
    Selected items: 

    <dot:Repeater DataSource="{value: SelectedFruit}" RenderWrapperTag="false" >
        <ItemTemplate>
            <span>{{value: _this}},</span>
        </ItemTemplate>
    </dot:Repeater>
</p>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Fruit { get; set; } = new List<string> {
            "Apple",
            "Banana",
            "Orange",
            "Watermelon"
        };

        public List<string> SelectedFruit { get; set; } = new List<string>();
    }
}
```

## Sample 2: Select Restrictions

The `MaxSelectedValues` configures the maximum number of selected items in the control.


```DOTHTML
<p>Hold CTRL and select up to 3 items.</p>
<bp:ListView DataSource="{value: Fruit}"
             SelectedValues="{value: SelectedFruit}"
             MaxSelectedValues="3">
    <RowTemplate>
        <p>{{value: _this}}</p>
    </RowTemplate>
</bp:ListView>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Fruit { get; set; } = new List<string> {
            "Apple",
            "Banana",
            "Orange",
            "Watermelon"
        };

        public List<string> SelectedFruit { get; set; } = new List<string>();
    }
}
```

## Sample 3: Changed Event

The `Changed` event triggers a command in the viewmodel whenever the selection changes.


```DOTHTML
<p>Hold CTRL and select up to 3 items.</p>
<bp:ListView DataSource="{value: Fruit}"
             SelectedValues="{value: SelectedFruit}"
             MaxSelectedValues="3"
             Changed="{command: SelectionChanged()}">
    <RowTemplate>
        <p>{{value: _this}}</p>
    </RowTemplate>
</bp:ListView>

<p>You can  select {{value: RemainingSelections}} more items.</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int RemainingSelections { get; set; } = 3;

        public List<string> Fruit { get; set; } = new List<string> {
            "Apple",
            "Banana",
            "Orange",
            "Watermelon"
        };

        public List<string> SelectedFruit { get; set; } = new List<string>();

        public void SelectionChanged()
        {
            RemainingSelections = 3 - SelectedFruit.Count;
        }
    }
}
```

## Sample 4: Display Modes

The `DisplayMode` property defines whether the list is vertical (`Row`) or horizontal (`Tile`).

In the `Row` mode, the `RowTemplate` property is used to define the look of a particular item.

In the `Tile` mode, the `TileTemplate` property is used to define the look of a particular item.


```DOTHTML
<bp:ListView DataSource="{value: Fruit}"
             SelectedValues="{value: SelectedFruit}"
             DisplayMode="List">
    <RowTemplate>
        <p>{{value: _this}}</p>
    </RowTemplate>
</bp:ListView>

<bp:ListView DataSource="{value: Fruit}"
             SelectedValues="{value: SelectedFruit}"
             DisplayMode="Tiles">
    <TileTemplate>
        <p>{{value: _this}}</p>
    </TileTemplate>
</bp:ListView>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Fruit { get; set; } = new List<string> {
            "Apple",
            "Banana",
            "Orange",
            "Watermelon"
        };

        public List<string> SelectedFruit { get; set; } = new List<string>();
    }
}
```

## Sample 5: Working with Objects

To make the `SelectedValues` property contain only some values from the `DataSource` objects (like the `Id` property of the object), you may use the `ItemValueBinding` property.

The `SelectedValues` will then contain only the values of the properties specified in the `ItemValueBinding`. Provided the values of the properties used as a value are unique, you don't need to specify the `ItemKeyBinding` property.

> The `ItemKeyBinding` property is required only when the control cannot compare the objects in the `DataSource` collection with the objects in the `SelectedValues`. If the `ItemValueBinding` is set and makes the `SelectedValues` collection use primitive types that can be compared, the `ItemKeyBinding` property is not needed. Similarly, if the `DataSource` collection contains only primitive values (`string`, `int` etc.), the `ItemKeyBinding` property is not necessary. 


```DOTHTML
<bp:ListView DataSource="{value: Cities}"
             SelectedValues="{value: SelectedCityIds}"
             ItemValueBinding="{value: Id}"
             ItemKeyBinding="{value: Id}"
             Changed="{command: SelectionChanged()}">
    <RowTemplate>
        <p>{{value: Name}}, {{value: Country}}</p>
    </RowTemplate>
</bp:ListView>

<p>Selected Ids: {{value: Summary}}</p>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Summary { get; set; }

        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Prague", Country = "Czech Republic" },
            new City { Id = 2, Name = "Bratislava", Country = "Slovakia" }
        };

        public List<int> SelectedCityIds { get; set; } = new List<int>();

        public void SelectionChanged()
        {
            Summary = string.Join(", ", SelectedCityIds.Select(c => c.ToString()));
        }
    }
}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.ListView.sample5
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
```

