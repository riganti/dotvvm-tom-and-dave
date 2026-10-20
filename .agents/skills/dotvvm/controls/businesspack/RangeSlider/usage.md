# <bp:RangeSlider>
Renders a slider with a numeric scale which allows the user to select two values.

For a single value selection, you can use the [Slider](~/controls/businesspack/Slider) control.

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
|`SelectedMaxValue`|Double||attribute, bindable|0|
|`SelectedMinValue`|Double||attribute, bindable|0|
|`Step`|Double||attribute, static value, bindable|1|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `SelectedMinValue` and `SelectedMaxValue` properties represent the values selected by the user.

The `MinValue` and `MaxValue` properties specify the start and end point of the scale.


```DOTHTML
<bp:RangeSlider SelectedMinValue="{value: Minimum}"
                SelectedMaxValue="{value: Maximum}"
                MinValue="0"
                MaxValue="100" />

<p>Selected range: {{value: Minimum}} - {{value: Maximum}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RangeSlider.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; } = 100;
    }
}
```

## Sample 2: Step

The `Step` property defines a size of a step. The slider values are increased or decreased by this value.


```DOTHTML
<bp:RangeSlider SelectedMinValue="{value: Minimum}"
                SelectedMaxValue="{value: Maximum}"
                Step="0.1"
                MinValue="0"
                MaxValue="5" />

<p>Selected range: {{value: Minimum}} - {{value: Maximum}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RangeSlider.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; } = 5;
    }
}
```

## Sample 3: Changed Event

The `Changed` property specifies a command in the viewmodel that is triggered whenever any of the selected values change.


```DOTHTML
<bp:RangeSlider SelectedMinValue="{value: MinimumPrice}"
                SelectedMaxValue="{value: MaximumPrice}"
                Changed="{command: PriceRangeChanged()}"
                MinValue="0"
                MaxValue="100" />

<p>Selected price range: {{value: PriceRangeString}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RangeSlider.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int MinimumPrice { get; set; }
        public int MaximumPrice { get; set; } = 100;
        public string PriceRangeString { get; set; }

        public void PriceRangeChanged()
        {
            PriceRangeString = $"{MinimumPrice}$ - {MaximumPrice}$";
        }
    }
}
```

