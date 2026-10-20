# <bp:CheckBox>
Inherits the built-in [CheckBox](~/controls/builtin/CheckBox) control with a *DotVVM Business Pack* visual style.

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
|`AutoFocus`|Boolean||attribute, static value|False|
|`Checked`|Boolean?||attribute, bindable|False|
|`CheckedIcon`|IconBase||inner element, static value||
|`CheckedItems`|IEnumerable||attribute, static value, bindable||
|`CheckedValue`|Object||attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate||inner element, static value, bindable, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|String||attribute, static value, bindable||
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic CheckBox

The CheckBox control has the `Checked` property of *boolean* which indicates whether the control is checked or not.

Optionally, you can use the `Text` property to specify the label for the checkbox. Or you can put the label contents inside the `bp:CheckBox` element.

```DOTHTML
<bp:CheckBox Text="CheckBox"
             Checked="{value: IsChecked}" />

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsChecked { get; set; }
    }
}
```

## Sample 2: Multiple CheckBoxes

The CheckBox has also a property `CheckedItems` which can bind to any collection. This is an alternative to the `Checked` property - these properties cannot be combined.
The collection will always contain values of the checkboxes which are checked. The value of the checkbox which should be inserted in the collection, is defined in the `CheckedValue` property.

You can also modify the collection contents in the viewmodel code which will update the checkbox check states appropriately.


```DOTHTML
<h3>Select extra ingredients for your pizza:</h3>

<bp:CheckBox Text="Corn (0.5$)" CheckedValue="{value: 0.5}" CheckedItems="{value: Extras}" Changed="{command: UpdatePrice()}" />
<bp:CheckBox Text="Jalapeño (0.75$)" CheckedValue="{value: 0.75}" CheckedItems="{value: Extras}" Changed="{command: UpdatePrice()}" />
<bp:CheckBox Text="Bacon (1$)" CheckedValue="{value: 1}" CheckedItems="{value: Extras}" Changed="{command: UpdatePrice()}" />

<br />

<p>Total Price: {{value: Price}}$</p>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<double> Extras { get; set; } = new List<double>();

        public double Price { get; set; }

        public void UpdatePrice()
        {
            Price = Extras.DefaultIfEmpty(0).Sum();
        }
    }
}
```

## Sample 3: CheckBox's Changed Event

The CheckBox has the `Changed` event which is fired whenever the checkbox is checked or unchecked by the user.

```DOTHTML
<bp:CheckBox Checked="{value: Value}" Changed="{command: OnChanged()}" />

<p>{{value: NumberOfChanges}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
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

Because the collection holds floats instead of strings, we have to use the `{value: 0.5}` binding instead of just `"0.5"` so the value is treated as a number and not as a string.

```DOTHTML
<h3>Additional ingredients for your pizza!</h3>
<p>
    <bp:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.5}" Text="Jalapeño (0.5$)" />
    <br />

    <bp:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.45}" Text="Egg (0.45$)" />
    <br />

    <bp:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.75}" Text="Tuna (0.75$)" />
    <br />

    <bp:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.2}" Text="Garlic (0.2$)" />
    <br />

    <bp:CheckBox CheckedItems="{value: Extra}" 
                  Changed="{command: UpdatePrice()}" 
                  CheckedValue="{value: 0.8}" Text="Magic Mushrooms (0.8$)" />
</p>

<p>Total price: ${{value: Price}}</p>


```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<float> Extra { get; set; } = new List<float>();

        public float Price { get; set; } = 4;

        public void UpdatePrice()
        {
            Price = 4 + Extra.DefaultIfEmpty(0).Sum();
        }

    }
}
```

