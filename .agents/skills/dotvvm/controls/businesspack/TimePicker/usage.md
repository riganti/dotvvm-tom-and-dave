# <bp:TimePicker>
Renders a text field that allows the user to enter or select time.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowUnselect`|Boolean||attribute, static value, bindable|True|
|`AmPmDesignatorText`|String||attribute, static value|AM/PM|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ConfirmIcon`|IconBase||inner element, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FormatString`|String||attribute, static value||
|`HourText`|String||attribute, static value|Hour|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxTime`|DateTime?||attribute, bindable||
|`MinTime`|DateTime?||attribute, bindable||
|`MinuteText`|String||attribute, static value|Minute|
|`NextIcon`|IconBase||inner element, static value, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`PrevIcon`|IconBase||inner element, static value, bindable||
|`Restrictions`|IEnumerable<TimeRestriction>||attribute, bindable||
|`SecondText`|String||attribute, static value|Second|
|`SelectedTime`|DateTime?||attribute, bindable||
|`ShowInline`|Boolean||attribute, static value|False|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`ToggleIcon`|IconBase||inner element, static value, bindable||
|`UnselectIcon`|IconBase||inner element, static value, bindable||
|`UseFormatStringAsPlaceholder`|Boolean||attribute, static value|True|
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `SelectedTime` property represents a `Time` value with a time selected in the control.

```DOTHTML
<bp:TimePicker SelectedTime="{value: SelectedTime}" />

<p>Selected time: <dot:Literal Text="{value: SelectedTime}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;
    }
}
```

## Sample 2: Selection Bounds

You can use the `MinTime` and `MaxTime` properties to specify the minimum and maximum values for the selection.


```DOTHTML
<bp:TimePicker SelectedTime="{value: SelectedTime}"
               MinTime="{value: MinimumTime}"
               MaxTime="{value: MaximumTime}" />

<p>Selected time: <dot:Literal Text="{value: SelectedTime}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;
        public DateTime MinimumTime { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 
            7, 30, 0);
        public DateTime MaximumTime { get; set; } = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 
            19, 30, 0);
    }
}
```

## Sample 3: Restrictions

If you require more granular control over what dates can be selected, you can use the `Restrictions` property.

- **TimeRangeRestriction** - Allows to disable selection of a specific time range. You just need to set the `StartTime` and `EndTime` properties, where the `StartTime` represents inclusive start of the restriction and `EndTime` represents end of the restriction. Date part of the `DateTime` values is ignored so any date can be provided.


```DOTHTML
<bp:TimePicker SelectedTime="{value: SelectedTime}"
               Restrictions="{value: Restrictions}" />

<p>Selected time: <dot:Literal Text="{value: SelectedTime}" FormatString="g" /></p>
```

```CSHARP
using System;
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;

        public List<TimeRestriction> Restrictions { get; set; } = new List<TimeRestriction>()
        {
            //This will prevent selection of any time between 11:45:00 to 13:14:59
            new TimeRangeRestriction() {
                StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    11, 45, 0),
                EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    13, 15, 0)
            },
            //This will prevent selection of any time between 16:30:00 to 17:29:59
            new TimeRangeRestriction() {
                StartTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    16, 30, 0),
                EndTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                    17, 30, 0)
            }
        };
    }
}

```

## Sample 4: Inline

The `ShowInline` property toggle whether the TimePicker is displayed inline in page or as a drop-down editor.

```DOTHTML
<bp:TimePicker SelectedTime="{value: SelectedTime}"
               ShowInline />

<p>Selected time: <dot:Literal Text="{value: SelectedTime}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TimePicker.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedTime { get; set; } = DateTime.Now;
    }
}
```

