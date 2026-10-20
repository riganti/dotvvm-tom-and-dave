# <t:RangeSlider>
The `RangeSlider` control renders a Tailwind-styled dual-thumb slider for selecting an interval. Bind the range with `SelectedMinValue` and `SelectedMaxValue`, then customize the track with `Type`, `Size`, `ShowValue`, and numeric range settings.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|When false, the slider is disabled and cannot be interacted with.|attribute, static value, bindable||
|`FormatString`|String|Format specifier applied to each displayed value label, e.g. n0 or F1. Passed directly to double.ToString(format).|attribute, static value|n0|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`LabelPosition`|([LabelPosition](../_enums/DotVVM.Controls.Tailwind.Controls.LabelPosition.md))|Position of the current min/max value labels relative to the slider when value labels are shown.|attribute, static value, bindable|Below|
|`MaxValue`|Double|Maximum selectable value.|attribute, static value, bindable|100|
|`MinValue`|Double|Minimum selectable value.|attribute, static value, bindable|0|
|`SelectedMaxValue`|IValueBinding<Double>|Two-way bound upper bound of the selected interval.|attribute, bindable||
|`SelectedMinValue`|IValueBinding<Double>|Two-way bound lower bound of the selected interval.|attribute, bindable||
|`ShowValue`|Boolean|Show the current min/max numeric values next to the slider.|attribute, static value, bindable|True|
|`Size`|([ControlSize](../_enums/DotVVM.Controls.Tailwind.ControlSize.md))|Visual size of the slider: Small, Default, Large, or ExtraLarge.|attribute, static value, bindable|Default|
|`Step`|Double|Increment between selectable values.|attribute, static value, bindable|1|
|`Type`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|Accent color applied to the filled track and thumb(s).|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Interval Selection

Bind the lower and upper values with `SelectedMinValue` and `SelectedMaxValue`. Value labels are shown by default, and `LabelPosition` can move them above the slider.


```DOTHTML
<div class="space-y-4 max-w-md">
    <t:RangeSlider SelectedMinValue="{value: PriceFrom}"
                   SelectedMaxValue="{value: PriceTo}" />

    <t:RangeSlider SelectedMinValue="{value: BudgetFrom}"
                   SelectedMaxValue="{value: BudgetTo}"
                   LabelPosition="Above" />
</div>

<p>Price range: <strong>{{value: PriceFrom}}</strong> – <strong>{{value: PriceTo}}</strong></p>
<p>Budget range: <strong>{{value: BudgetFrom}}</strong> – <strong>{{value: BudgetTo}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RangeSlider.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double PriceFrom { get; set; } = 20;

        public double PriceTo { get; set; } = 80;

        public double BudgetFrom { get; set; } = 100;

        public double BudgetTo { get; set; } = 400;
    }
}

```

## Sample 2: Types and Sizes

Use the `Type` property to change the accent color and `Size` to scale both thumbs and the track.


```DOTHTML
<div class="space-y-4 max-w-md">
    <div class="space-y-2">
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Type="Default" />
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Type="Primary" />
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Type="Success" />
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Type="Danger" />
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Type="Dark" />
    </div>

    <div class="space-y-2">
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Size="Small" />
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Size="Large" />
        <t:RangeSlider SelectedMinValue="{value: IntervalMin}" SelectedMaxValue="{value: IntervalMax}" Size="ExtraLarge" />
    </div>
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RangeSlider.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double IntervalMin { get; set; } = 25;

        public double IntervalMax { get; set; } = 75;
    }
}

```

## Sample 3: Numeric Range, Formatting, and Enabled State

Use `MinValue`, `MaxValue`, `Step`, and `FormatString` to control the interval scale. Set `ShowValue="false"` when the value labels should stay hidden.


```DOTHTML
<div class="space-y-3 max-w-md">
    <t:CheckBox Text="Enable slider" Checked="{value: IsEnabled}" />

    <t:RangeSlider SelectedMinValue="{value: TemperatureFrom}"
                   SelectedMaxValue="{value: TemperatureTo}"
                   MinValue="-20"
                   MaxValue="40"
                   Step="0.5"
                   FormatString="n1"
                   Enabled="{value: IsEnabled}"
                   ShowValue="false" />
</div>

<p>Temperature range: <strong>{{value: TemperatureFrom}}</strong> °C – <strong>{{value: TemperatureTo}}</strong> °C</p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RangeSlider.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEnabled { get; set; } = true;

        public double TemperatureFrom { get; set; } = 18;

        public double TemperatureTo { get; set; } = 24.5;
    }
}

```

