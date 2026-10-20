# <bp:Slider>
Renders a slider with a numeric scale which allows the user to select a value.

For a range selection, you can use the [RangeSlider](~/controls/businesspack/RangeSlider) control.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`MaxValue`|Double||attribute, static value, bindable|100|
|`MinValue`|Double||attribute, static value, bindable|0|
|`SelectedValue`|Double||attribute, bindable|0|
|`Step`|Double||attribute, static value, bindable|1|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `SelectedValue` properties represent the value selected by the user.

The `MinValue` and `MaxValue` properties specify the start and end point of the scale.


```DOTHTML
<bp:Slider SelectedValue="{value: Value}"
           MinValue="0"
           MaxValue="100" />

<p>Selected value: {{value: Value}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Slider.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Value { get; set; } = 50;
    }
}
```

## Sample 2: Step

The `Step` property defines a size of a step. The slider value is increased or decreased by this value.


```DOTHTML
<bp:Slider SelectedValue="{value: Value}"
           Step="0.1"
           MinValue="0"
           MaxValue="5" />

<p>Selected value: {{value: Value}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Slider.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Value { get; set; } = 2.5;
    }
}
```

## Sample 3: Changed Event

The `Changed` property specifies a command in the viewmodel that is triggered whenever the selected value change.


```DOTHTML
<bp:Slider SelectedValue="{value: Price}"
           Changed="{command: PriceChanged()}"
           MinValue="0"
           MaxValue="100" />

<p>Selected price: {{value: PriceString}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Slider.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Price { get; set; } = 50;
        public string PriceString { get; set; }

        public void PriceChanged()
        {
            PriceString = $"{Price}$";
        }
    }
}
```

