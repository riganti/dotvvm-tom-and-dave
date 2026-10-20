# <t:ProgressBar>
Displays a progress indicator whose `Value`, `Type`, and `ShowLabel` properties can all be configured statically or through bindings.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ShowLabel`|Boolean|When true, renders a percentage label inside the bar.|attribute, static value, bindable|False|
|`Type`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|Visual color variant of the progress bar.|attribute, static value, bindable|Primary|
|`Value`|Double|Progress percentage (0–100).|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Values and color types

Shows several `Value` settings and a few `Type` variants.


```DOTHTML
<div class="space-y-4">
    <t:ProgressBar Value="25" />
    <t:ProgressBar Value="50" Type="Success" />
    <t:ProgressBar Value="75" Type="Warning" />
    <t:ProgressBar Value="90" Type="Danger" />
</div>

```

## Sample 2: Bindable value and type

Updates `Value` and `Type` through viewmodel bindings.


```DOTHTML
<div class="space-y-4">
    <t:ProgressBar Value="{value: Progress}" Type="{value: SelectedType}" />

    <div class="flex gap-2">
        <t:Button Type="Primary" Text="Increase" Click="{command: Increase()}" Size="Small" />
        <t:Button Type="Secondary" Text="Reset" Click="{command: Reset()}" Size="Small" />
    </div>

    <div class="flex gap-2 flex-wrap">
        <t:Button Text="Primary" Click="{command: SetType(1)}" Size="Small" />
        <t:Button Text="Success" Click="{command: SetType(3)}" Size="Small" />
        <t:Button Text="Warning" Click="{command: SetType(4)}" Size="Small" />
        <t:Button Text="Danger" Click="{command: SetType(5)}" Size="Small" />
    </div>
</div>

```

```CSHARP
using DotVVM.Controls.Tailwind;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ProgressBar.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Progress { get; set; } = 40;

        public TailwindColor SelectedType { get; set; } = TailwindColor.Primary;

        public void Increase()
        {
            Progress = Progress >= 100 ? 100 : Progress + 10;
        }

        public void Reset()
        {
            Progress = 0;
        }

        public void SetType(int type)
        {
            SelectedType = (TailwindColor)type;
        }
    }
}

```

## Sample 3: Percentage label

Shows `ShowLabel` as a static value and as a bindable property.


```DOTHTML
<div class="space-y-4">
    <t:ProgressBar Value="65" Type="Success" ShowLabel="true" />

    <t:ProgressBar Value="80" Type="Primary" ShowLabel="{value: ShowLabel}" />

    <t:CheckBox Text="Show label" Checked="{value: ShowLabel}" />
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ProgressBar.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool ShowLabel { get; set; } = true;
    }
}

```

