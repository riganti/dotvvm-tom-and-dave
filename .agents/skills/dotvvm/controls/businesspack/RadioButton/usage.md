# <bp:RadioButton>
Inherits the built-in [RadioButton](~/controls/builtin/RadioButton) control with a *DotVVM Business Pack* visual style.



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
|`AutoFocus`|Boolean||attribute, static value|False|
|`Checked`|Boolean||attribute, bindable|False|
|`CheckedIcon`|IconBase||inner element, static value||
|`CheckedItem`|Object||attribute, bindable||
|`CheckedValue`|Object||attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate||inner element, static value, bindable, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`GroupName`|String||attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|String||attribute, static value, bindable||
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic RadioButtons

The RadioButton control has the `Checked` property of *boolean* which indicates whether the control is checked or not.

Optionally, you can use the `Text` property to specify the label for the radio button. Or you can put the label contents inside the `bp:RadioButton` element.



```DOTHTML
<bp:RadioButton Checked="{value: IsCompany}" 
                CheckedValue="{value: true}"
                GroupName="RadioGroup" 
                Text="company" />

<bp:RadioButton Checked="{value: IsCompany}" 
                CheckedValue="{value: false}"
                GroupName="RadioGroup">
    person <em>(default)</em>
</bp:RadioButton>

<p>Is company: {{value: IsCompany}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCompany { get; set; }
    }
}
```

## Sample 2: Multiple RadioButtons

The RadioButton has also a property `CheckedItem` which point to a property in the viewmodel. This is an alternative to the `Checked` property - 
they cannot be used together.

The property referenced by the `CheckedItem` will contain the value of the radio button which is checked. 

In the example, the second radio button will be checked when the page loads. That's because the initial value of the `Color` property is "g".
If you click another radio button, the property value will be updated immediately.

```DOTHTML
<bp:RadioButton CheckedItem="{value: Color}" CheckedValue="r" Text="R" />
<bp:RadioButton CheckedItem="{value: Color}" CheckedValue="g" Text="G" />
<bp:RadioButton CheckedItem="{value: Color}" CheckedValue="b" Text="B" />

<p>Selected color: {{value: Color}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Color { get; set; } = "g";
    }
}
```

## Sample 3: RadioButton's Changed Event

The RadioButton has the `Changed` event which is fired whenever the radio button is checked or unchecked.

Notice the `CheckedItem` and `CheckedValue` properties. The first radio button will set `true` to the `Value` property in the viewmodel,
the second one will set `false`. 

The value binding in the `CheckedValue` must be used, otherwise the `true` and `false` values would be treated as strings.

```DOTHTML
<bp:RadioButton CheckedItem="{value: Value}" CheckedValue="{value: true}" Changed="{command: OnChanged()}" />
<bp:RadioButton CheckedItem="{value: Value}" CheckedValue="{value: false}" Changed="{command: OnChanged()}" />

<p>{{value: NumberOfChanges}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample3
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

## Sample 4: Real World Sample

Final price is calculated by adding a tax to price of selected beverage. Prices are set in `CheckedValue` property and 
the total price is updated after any change by `Changed` event.

> *DotVVM Business Pack* includes the [RadioButtonList](~/controls/businesspack/RadioButtonList), which would make this sample much simpler. If you need to generate multiple radio buttons from a collection in a viewmodel, you can use this control.

```DOTHTML
<h3>Fruits</h3>
<p>
    <bp:RadioButton CheckedItem="{value: PriceWithoutTax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 1}" 
                    Text="Apple" />

    <bp:RadioButton CheckedItem="{value: PriceWithoutTax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 3}" 
                    Text="Lemon" />

    <bp:RadioButton CheckedItem="{value: PriceWithoutTax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 6}" 
                    Text="Orange" />

    <bp:RadioButton CheckedItem="{value: PriceWithoutTax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 5}" 
                    Text="Pineapple" />
</p>

<h3>Tax</h3>
<p>
    <bp:RadioButton CheckedItem="{value: Tax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 5}" 
                    Text="Reasonable" />

    <bp:RadioButton CheckedItem="{value: Tax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 10}" 
                    Text="Still quite reasonable" />

    <bp:RadioButton CheckedItem="{value: Tax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 20}" 
                    Text="European" />

    <bp:RadioButton CheckedItem="{value: Tax}" 
                    Changed="{command: UpdatePrice()}"
                    CheckedValue="{value: 40}" 
                    Text="European in 10 years" />
</p>

<p>Total price: ${{value: Price}}</p>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButton.sample4
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

