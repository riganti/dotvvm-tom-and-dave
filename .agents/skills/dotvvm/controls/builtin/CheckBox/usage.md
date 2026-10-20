# <dot:CheckBox>
This control renders HTML checkbox.

## Rendered output
With no `Text` or an inner content specified, the control renders just the checkbox.

```DOTHTML
<input type="checkbox" data-bind="..." />
```


If there is a `Text` or an inner content, the label is rendered around the checkbox.

```DOTHTML
<label>
  <input type="checkbox" data-bind="..." />
  Text or inner content
</label>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, bindable||
|`CheckedItems`|IEnumerable|Gets or sets a collection of values of all checked checkboxes. Use this property in combination with the CheckedValue property.|attribute, static value, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked.             Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DisableIndeterminate`|Boolean|When set to true, `null` in the Checked property will be treated as `false`, instead of marking the checkbox as indeterminate|attribute, static value, bindable|False|
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InputCssClass`|String|Gets or sets a CSS class that will be appended on the rendered input element.|attribute, static value||
|`ItemKeyBinding`|IValueBinding|Gets or sets a property that retrieves an unique key for the CheckedValue so it can be compared with objects in the CheckedItems collection. This property must be set if the value of the CheckedValue property is not a primitive type.|attribute, bindable||
|`LabelCssClass`|String|Gets or sets a CSS class that will be appended on the rendered label element.|attribute, static value||
|`Text`|String|Gets or sets the label text that is rendered next to the control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control check state is changed.|

## Sample 1: Basic CheckBox

The CheckBox control has the `Checked` property of *boolean* which indicates whether the control is checked or not.

Optionally, you can use the `Text` property to specify the label for the checkbox. Or you can put the label contents inside the `dot:CheckBox` element.

```DOTHTML
<dot:CheckBox Text="CheckBox Label" Checked="{value: Checked}" />

<p>{{value: Checked}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.CheckBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        
        public bool Checked { get; set; }
        
    }
}
```

## Sample 2: Multiple CheckBoxes

The CheckBox has also a property `CheckedItems` which can hold any collection. This is an alternative to the `Checked` property - they cannot be combined.
The collection holds values of all checkboxes which are checked. The value of the checkbox which should be inserted in the collection, is defined in the
`CheckedValue` property.



The first two checkboxes will be checked by default because the collection holds initial values "r" and "g".
If you uncheck or check a checkbox, the collection will be updated immediately.


You can also modify the collection contents in the viewmodel code which will update the checkbox check states appropriately.


```DOTHTML
<dot:CheckBox Text="Red" CheckedItems="{value: Colors}" CheckedValue="r" Changed="{command: UpdateSelectedColors()}" />
<dot:CheckBox Text="Green" CheckedItems="{value: Colors}" CheckedValue="g" Changed="{command: UpdateSelectedColors()}" />
<dot:CheckBox Text="Blue" CheckedItems="{value: Colors}" CheckedValue="b" Changed="{command: UpdateSelectedColors()}" />

<p>{{value: SelectedColors}}</p>
```

```CSHARP
using System.Linq;
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.builtin.CheckBox.sample2
{
    public class ViewModel
    {
        public string SelectedColors { get; set; }

        public List<string> Colors { get; set; } = new List<string>() {"r", "g"};

        public ViewModel()
        {
            UpdateSelectedColors();
        }

        public void UpdateSelectedColors()
        {
            SelectedColors = string.Join(", ", Colors.Select(i => i.ToString()));
        }
    }
}
```

## Sample 3: CheckBox's Changed Event

The CheckBox has the `Changed` event which is fired whenever the checkbox is checked or unchecked.

```DOTHTML
<dot:CheckBox Checked="{value: Value}" Changed="{command: OnChanged()}" />

<p>{{value: NumberOfChanges}}</p>
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.builtin.CheckBox.sample3
{
    public class ViewModel
    {
        public bool Value { get; set; }

        public int NumberOfChanges { get; set; } = 0;

        public void OnChanged()
        {
            NumberOfChanges++;
        }

    }
}
```

## Real World Sample

The total price is calculated by summing of all `CheckedValues` and is updated after any change by `Changed` event.

Because the collection holds floats instead of strings, we have to use the `{value: 0.5}` binding instead of just `"0.5"`. 
It would be treated as string otherwise.

```DOTHTML
<h3>Additional ingredients for your pizza!</h3>
<p>
    <dot:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.5}" Text="Jalapeño" />
    <br />

    <dot:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.45}" Text="Egg" />
    <br />

    <dot:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.75}" Text="Tuna" />
    <br />

    <dot:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.2}" Text="Garlic" />
    <br />

    <dot:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.8}" Text="Magic Mushrooms" />
</p>

<p>Total price: ${{value: Price}}</p>


```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.CheckBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<double> Extra { get; set; } = new List<double>();

        public double Price { get; set; } = 4;

        public void UpdatePrice()
        {
            Price = 4 + Extra.DefaultIfEmpty(0).Sum();
        }

    }
}
```

