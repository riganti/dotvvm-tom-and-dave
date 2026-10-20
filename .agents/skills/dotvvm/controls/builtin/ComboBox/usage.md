# <dot:ComboBox>
Renders the HTML drop-down list.

## Rendered output
The control renders the HTML select element.

```DOTHTML
<select data-bind="..."></select>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyItemText`|String|Text displayed when no value is selected.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemTitleBinding`|IValueBinding|The expression of DataSource item that will be placed into html title attribute.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Basic ComboBox Usage

The ComboBox control has property `DataSource` which expects an *IEnumerable*. Each object is treated as an item in the drop-down list.

The `SelectedValue` property will contain the selected value.

```DOTHTML
<dot:ComboBox DataSource="{value: Fruits}" 
              SelectedValue="{value: SelectedFruit}"/>

{{value: SelectedFruit}}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "Orange" };

        public string SelectedFruit { get; set; }
    }
}
```

## Sample 2: Empty Item

There is the `EmptyItemText` property which adds an empty item which means that nothing is selected.

The `SelectedFruit` property will be null when nothing is selected.

```DOTHTML
<dot:ComboBox DataSource="{value: Fruits}" 
              SelectedValue="{value: SelectedFruit}" 
              EmptyItemText="Select..." />

{{value: SelectedFruit}}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "Orange" };

        public string SelectedFruit { get; set; }
    }
}
```

## Sample 3: ItemValueBinding and ItemTextBinding

Typically, the `DataSource` is not a collection of strings, but a collection of some complex objects. 

The `ItemValueBinding` property defines which property of the object will be passed to the `SelectedValue` property.

The `ItemTextBinding` property defines which property of the object will be displayed in the drop-down list.

```DOTHTML
<dot:ComboBox DataSource="{value: Fruits}" 
              SelectedValue="{value: SelectedFruitId}" 
              ItemValueBinding="{value: Id}" 
              ItemTextBinding="{value: Name}" />

{{value: SelectedFruitId}}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Fruit[] Fruits { get; set; } = 
        {
            new Fruit { Id = 0, Name = "Apple" },
            new Fruit { Id = 1, Name = "Banana" },
            new Fruit { Id = 2, Name = "Orange" }
        };

        public int SelectedFruitId { get; set; } = 1;

    }

    public class Fruit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }
}
```

## Sample 4: SelectionChanged Event

The ComboBox control also has the `SelectionChanged` event which is fired whenever the selection changes.

```DOTHTML
<dot:ComboBox DataSource="{value: Fruits}" 
              SelectedValue="{value: SelectedFruit}" 
              SelectionChanged="{command: IsItReallyFruit()}"/>

{{value: Message}}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "IceCream", "Orange" };

        public string SelectedFruit { get; set; }

        public string Message { get; set; }

        public void IsItReallyFruit()
        {
            if (SelectedFruit == "IceCream")
            {
                Message = "Ice cream isn't a fruit!";
            }
            else
            {
                Message = "Yes, it's a fruit!";
            }
        }
    }
}
```

## Sample 5: Cascading ComboBoxes

This is an example of two connected ComboBoxes.

```DOTHTML
<dot:ComboBox DataSource="{value: Groups}" 
              SelectedValue="{value: SelectedGroup}" 
              SelectionChanged="{command: GroupSelectionChanged()}" 
              EmptyItemText="Select Group..."/> 
<br />

<dot:ComboBox DataSource="{value: Items}" 
              SelectedValue="{value: SelectedItem}" 
              Visible="{value: SelectedGroup != null}" /> 
<br />

{{value: SelectedItem}}

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ComboBox.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Groups { get; set; } = { "Vegetables", "Fruits" };
        
        public string SelectedGroup { get; set; }


        public string[] Items { get; set; }
        
        public string SelectedItem { get; set; }
                


        public void GroupSelectionChanged()
        {
            if (SelectedGroup == "Fruits")
            {
                Items = new string[] { "Apple", "Banana", "Orange" };
            }
            else if (SelectedGroup == "Vegetables")
            {
                Items = new string[] { "Broccolini", "Lettuce", "Cabbage" };
            }
            else
            {
                Items = new string[] { };
            }
        }
    }
}
```

