# <dot:RadioButton>
This control renders HTML radio button.

Use the `GroupName` property to define radio button groups (only one radio button in each group can be checked).
Please note that the all radio buttons in the same group must be bound to the same property in the viewmodel.

## Rendered output
With no `Text` or an inner content specified, the control renders just the radio button.

```DOTHTML
<input type="radio" data-bind="..." />
```


If there is a `Text` or an inner content, the label is rendered around the radio button.

```DOTHTML
<label>
  <input type="radio" data-bind="..." />
  Text or inner content
</label>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`CheckedItem`|Object|Gets or sets the CheckedValue of the first RadioButton that is checked and bound to this collection.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked.             Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable|True|
|`GroupName`|String|Gets or sets an unique name of the radio button group.|attribute, static value, bindable||
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

## Sample 1: Basic RadioButtons

The RadioButton control has the `Checked` property of *boolean* which indicates whether the control is checked or not.

Optionally, you can use the `Text` property to specify the label for the radio button. Or you can put the label contents inside the `dot:RadioButton` element.



```DOTHTML
<dot:RadioButton Checked="{value: IsCompany}" CheckedValue="{value: false}"
                 GroupName="RadioGroup">
  <img src="~/images/person.png" /> person
</dot:RadioButton>

<dot:RadioButton Checked="{value: IsCompany}" CheckedValue="{value: true}"
                 GroupName="RadioGroup" Text="company" />

<p>Is company: {{value: IsCompany}}</p>
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample1
{
    public class ViewModel
    {
        public bool IsCompany { get; set; }
    }
}
```

## Sample 2: Multiple RadioButtons

The RadioButton has also a property `CheckedItem` which point to a property in the viewmodel. This is an alternative to the `Checked` property - 
they cannot be combined.

The property referenced by the `CheckedItem`, holds the value of the radio button which is checked. 

In the example, the second radio button will be checked when the page loads. That's because the initial value of the `Color` property is "g".
If you click another radio button, the property value will be updated immediately.

```DOTHTML
<dot:RadioButton CheckedItem="{value: Color}" CheckedValue="r" Text="R"/>
<dot:RadioButton CheckedItem="{value: Color}" CheckedValue="g" Text="G"/>
<dot:RadioButton CheckedItem="{value: Color}" CheckedValue="b" Text="B"/>

<p>Selected color: {{value: Color}}</p>
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample2
{
    public class ViewModel
    {
        public string Color { get; set; } = "g";
    }
}
```

## Sample 3: RadioButton's Changed Event

The RadioButton has the `Changed` event which is fired whenever the radio button is checked or unchecked.

Notice the `CheckedItem` and `CheckedValue` properties. The first radio button will set **true** to the `Value` property in the viewmodel,
the second one will set **false**. The value binding in the `CheckedValue` must be used, otherwise the *true* and *false* values would
be treated as strings.

```DOTHTML
<dot:RadioButton CheckedItem="{value: Value}" CheckedValue="{value: true}" Changed="{command: OnChanged()}" />
<dot:RadioButton CheckedItem="{value: Value}" CheckedValue="{value: false}" Changed="{command: OnChanged()}" />

<p>{{value: NumberOfChanges}}</p>
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample3
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

## Sample 4: Real World Sample

Final price is calculated by adding a tax to price of selected beverage. Prices are set in `CheckedValues` property and 
the total price is updated after any change by `Changed` event.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample4.ViewModel, DotvvmWeb

<h3>Fruits</h3>
<p>
	<dot:RadioButton CheckedItem="{value: PriceWithoutTax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 1.0f}" Text="Apple"/>
	<dot:RadioButton CheckedItem="{value: PriceWithoutTax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 3.0f}" Text="Lemon"/>
	<dot:RadioButton CheckedItem="{value: PriceWithoutTax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 6.0f}" Text="Orange"/>
	<dot:RadioButton CheckedItem="{value: PriceWithoutTax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 5.0f}" Text="Pineapple"/>
</p>

<h3>Tax</h3>
<p>
	<dot:RadioButton CheckedItem="{value: Tax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 5.0f}" Text="Reasonable"/>
	<dot:RadioButton CheckedItem="{value: Tax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 10.0f}" Text="Still quite reasonable"/>
	<dot:RadioButton CheckedItem="{value: Tax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 20.0f}" Text="European"/>
	<dot:RadioButton CheckedItem="{value: Tax}" Changed="{command: UpdatePrice()}" 
					 CheckedValue="{value: 40.0f}" Text="European in 10 years"/>
</p>

<p>Total price: ${{value: Price}}</p>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.RadioButton.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public float PriceWithoutTax { get; set; }

        public float Tax { get; set; }

        public float Price { get; set; }

        public void UpdatePrice()
        {
            Price = PriceWithoutTax + ((PriceWithoutTax / 100) * Tax);
        }

    }
}
```

