# <t:Range>
The `Range` control renders a Tailwind-styled single-thumb slider. Bind the current value with `SelectedValue` and customize the track with `Type`, `Size`, `ShowValue`, and numeric range settings.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|When false, the slider is disabled and cannot be interacted with.|attribute, static value, bindable||
|`FormatString`|String|Format specifier applied to the displayed value, e.g. n0 or F1. Passed directly to double.ToString(format).|attribute, static value|n0|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`LabelPosition`|([LabelPosition](../_enums/DotVVM.Controls.Tailwind.Controls.LabelPosition.md))|Position of the current value label relative to the slider when value labels are shown.|attribute, static value, bindable|Below|
|`MaxValue`|Double|Maximum selectable value.|attribute, static value, bindable|100|
|`MinValue`|Double|Minimum selectable value.|attribute, static value, bindable|0|
|`SelectedValue`|IValueBinding<Double>|Two-way bound current value of the slider.|attribute, bindable||
|`ShowValue`|Boolean|Show the current numeric value next to the slider.|attribute, static value, bindable|False|
|`Size`|([ControlSize](../_enums/DotVVM.Controls.Tailwind.ControlSize.md))|Visual size of the slider: Small, Default, Large, or ExtraLarge.|attribute, static value, bindable|Default|
|`Step`|Double|Increment between selectable values.|attribute, static value, bindable|1|
|`Type`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|Accent color applied to the filled track and thumb(s).|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

Bind the slider with `SelectedValue`. Use `ShowValue` to render the numeric label and `LabelPosition` to place it above or below the slider.


```DOTHTML
<div class="space-y-4 max-w-md">
    <t:Range SelectedValue="{value: Satisfaction}" />

    <t:Range SelectedValue="{value: Volume}"
             ShowValue="true"
             LabelPosition="Above" />
</div>

<p>Satisfaction: <strong>{{value: Satisfaction}}</strong></p>
<p>Volume: <strong>{{value: Volume}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Range.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Satisfaction { get; set; } = 70;

        public double Volume { get; set; } = 45;
    }
}

```

## Sample 2: Types and Sizes

Use the `Type` property to change the accent color and `Size` to scale the slider to match the rest of the form controls.


```DOTHTML
<div class="space-y-4 max-w-md">
    <div class="space-y-2">
        <t:Range SelectedValue="{value: AccentValue}" Type="Default" ShowValue="true" />
        <t:Range SelectedValue="{value: AccentValue}" Type="Primary" ShowValue="true" />
        <t:Range SelectedValue="{value: AccentValue}" Type="Success" ShowValue="true" />
        <t:Range SelectedValue="{value: AccentValue}" Type="Danger" ShowValue="true" />
        <t:Range SelectedValue="{value: AccentValue}" Type="Dark" ShowValue="true" />
    </div>

    <div class="space-y-2">
        <t:Range SelectedValue="{value: AccentValue}" Size="Small" ShowValue="true" />
        <t:Range SelectedValue="{value: AccentValue}" Size="Large" ShowValue="true" />
        <t:Range SelectedValue="{value: AccentValue}" Size="ExtraLarge" ShowValue="true" />
    </div>
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Range.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double AccentValue { get; set; } = 55;
    }
}

```

## Sample 3: Numeric Range and Enabled State

Use `MinValue`, `MaxValue`, `Step`, and `FormatString` to control the numeric scale. The `Enabled` property can be bound dynamically.


```DOTHTML
<div class="space-y-3 max-w-md">
    <t:CheckBox Text="Enable slider" Checked="{value: IsEnabled}" />

    <t:Range SelectedValue="{value: Temperature}"
             MinValue="-20"
             MaxValue="40"
             Step="0.5"
             ShowValue="true"
             FormatString="n1"
             Enabled="{value: IsEnabled}" />
</div>

<p>Temperature: <strong>{{value: Temperature}}</strong> °C</p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Range.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEnabled { get; set; } = true;

        public double Temperature { get; set; } = 21.5;
    }
}

```

