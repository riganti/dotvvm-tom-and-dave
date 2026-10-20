# <bs:ComboBoxGroup>
Represents a group of Label and ComboBox in the Form control.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyItemText`|String|Gets or sets a text of an empty item. This item is auto-generated and is not part of the DataSource collection. The empty item has a value of null.|attribute, static value||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormContent`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area. This property cannot be combined with the LabelText property.|inner element, static value||
|`LabelText`|String|Gets or sets the label text. This property cannot be combined with the LabelTemplate property.|attribute, static value, bindable||
|`RenderContentContainers`|Boolean|Gets or sets whether an additional container will be rendered around the content.|attribute, static value|True|
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Basic Usage

The collection of items for selection in the combo box is set with the `DataSource` property.
Item selected by user is then stored in the `SelectedValue` property bound to a property in viewmodel.

The `LabelText` property is used to set the label of the `ComboBoxGroup` control.

```DOTHTML
<bs:Form>
    <bs:ComboBoxGroup LabelText="Animals" DataSource="{value: Animals}" SelectedValue="{value: SelectedAnimal}" />
</bs:Form>

<span>Selected: {{value: SelectedAnimal}}</span>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ComboBoxGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedAnimal { get; set; }
        public string[] Animals { get; set; } = { "Cat", "Dog", "Pig", "Mouse", "Rabbit" };
    }
}

```

## Sample 2: Enabled, Visible and EmptyItemText

The `EmptyItemText` property is used to set text of an empty item. The empty item has a value of *null*.

It is also possible to enable / disable the `ComboBoxGroup` control with the `Enabled` property.

To show / hide the `ComboBoxGroup` control the `Visible` property can be used.

```DOTHTML
<span>Selected: {{value: SelectedAnimal}}</span>

<bs:Form>
    <bs:ComboBoxGroup LabelText="Enabled" 
                      DataSource="{value: Animals}" 
                      SelectedValue="{value: SelectedAnimal}" 
                      Enabled="{value: TrueValue}" />

    <bs:ComboBoxGroup LabelText="Disabled" 
                      DataSource="{value: Animals}" 
                      SelectedValue="{value: SelectedAnimal}" 
                      Enabled="{value: FalseValue}" />

    <bs:ComboBoxGroup LabelText="Animals" 
                      DataSource="{value: Animals}" 
                      SelectedValue="{value: SelectedAnimal2}" 
                      EmptyItemText="Select..." />
</bs:Form>

<span>Selected: {{value: SelectedAnimal2}}</span>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ComboBoxGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedAnimal { get; set; }
        public string SelectedAnimal2 { get; set; }
        public string[] Animals { get; set; } = { "Cat", "Dog", "Pig", "Mouse", "Rabbit" };
        public bool TrueValue { get; set; } = true;
        public bool FalseValue { get; set; } = false;
    }
}

```

## Sample 3: Object Binding

You can also bind the `DataSource` property to a collection of complex objects. 
The text which will be then shown inside the combo box for all items is taken from a property 
of that complex item specified in the `ItemTextBinding` property. 
Returned value of selected item is taken from a property specified in the `ItemValueBinding` property.

```DOTHTML
<bs:Form>
    <bs:ComboBoxGroup DataSource="{value: Items}" 
                      SelectedValue="{value: SelectedItem}" 
                      LabelText="Label" 
                      ItemValueBinding="{value: Id}" 
                      ItemTextBinding="{value: Name}" />
</bs:Form>

<span>Selected: {{value: SelectedItem}}</span>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ComboBoxGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SelectedItem { get; set; }
        public Item[] Items { get; set; } =
        {
            new Item { Id = 1, Name = "Item 1" },
            new Item { Id = 2, Name = "Item 2" },
            new Item { Id = 3, Name = "Item 3" },
        };
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

```

## Sample 4: SelectionChanged event

It is also possible to bind an action to the event when the selected value in the combo box has changed. 
Use the `SelectionChanged` property to set a command which will be executed when the event triggers.

```DOTHTML
<bs:Form>
    <bs:ComboBoxGroup EmptyItemText="Select..." 
                    LabelText="Select prime number" 
                    DataSource="{value: Numbers}" 
                    SelectedValue="{value: SelectedNumber}" 
                    SelectionChanged="{command: SelectionChanged()}" />
</bs:Form>

<span>{{value: Result}}</span>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ComboBoxGroup.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SelectedNumber { get; set; }
        public int[] Numbers { get; set; } = { 7, 10, 13, 19 };
        public string Result { get; set; } = "Select something...";

        public void SelectionChanged()
        {
            Result = SelectedNumber != 10 ? "Correct!" : "10 is not a prime number!";
        }
    }
}

```

