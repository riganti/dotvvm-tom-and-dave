# <bp:DateTimePicker>
Renders a text field that allows the user to enter or select date and time using a Gregorian-style calendar popup.

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
|`FirstDayOfWeek`|DayOfWeek?||attribute, static value||
|`FormatString`|String||attribute, static value||
|`HourText`|String||attribute, static value|Hour|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxDateTime`|DateTime?||attribute, bindable||
|`MinDateTime`|DateTime?||attribute, bindable||
|`MinuteText`|String||attribute, static value|Minute|
|`NextDateIcon`|IconBase||inner element, static value, bindable||
|`NextTimeIcon`|IconBase||inner element, static value, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`PrevDateIcon`|IconBase||inner element, static value, bindable||
|`PrevTimeIcon`|IconBase||inner element, static value, bindable||
|`Restrictions`|IEnumerable<DateTimeRestriction>||attribute, bindable||
|`SecondText`|String||attribute, static value|Second|
|`SelectedDateTime`|DateTime?||attribute, bindable||
|`ShowInline`|Boolean||attribute, static value|False|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`ToggleIcon`|IconBase||inner element, static value, bindable||
|`UnselectIcon`|IconBase||inner element, static value, bindable||
|`UseFormatStringAsPlaceholder`|Boolean||attribute, static value|True|
|`Visible`|Boolean||attribute, bindable|True|
|`WeekNumberMode`|WeekNumberMode||attribute, static value|Disabled|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `SelectedDateTime` property represents a `DateTime` value with a date selected in the control.

```DOTHTML
<bp:DateTimePicker SelectedDateTime="{value: SelectedDate}" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

## Sample 2: Selection Bounds

You can use the `MinDateTime` and `MaxDateTime` properties to specify the minimum and maximum values for the selection.


```DOTHTML
<bp:DateTimePicker SelectedDateTime="{value: SelectedDate}"
                   MinDateTime="{value: MinimumDate}"
                   MaxDateTime="{value: MaximumDate}" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public DateTime MinimumDate { get; set; } = DateTime.Now.AddDays(-5);
        public DateTime MaximumDate { get; set; } = DateTime.Now.AddDays(5);
    }
}
```

## Sample 3: Restrictions

If you require more granular control over what dates can be selected, you can use the `Restrictions` property. We currently support the following types of restrictions:

- **DayOfWeekRestriction** - Allows to disable selection of a specific day of week.
- **DateRangeRestriction** - Allows to disable a specific range of dates (one day, one month, etc.). You just need to set the `StartDate` and `EndDate` properties, where the `StartDate` represents inclusive start of the restriction and `EndDate` represents exclusive end of the restriction. 
- **TimeRangeRestriction** - Allows to disable selection of a specific time range. You just need to set the `StartTime` and `EndTime` properties, where the `StartTime` represents inclusive start of the restriction and `EndTime` represents end of the restriction.

Restrictions can be combined with `MinDateTime` and `MaxDateTime` properties and are verified both on client-side and server-side.

```DOTHTML
<bp:DateTimePicker SelectedDateTime="{value: SelectedDate}"
                   Restrictions="{value: Restrictions}" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public List<DateTimeRestriction> Restrictions { get; set; } = new List<DateTimeRestriction>()
        {
            //These will prevent saturdays and sundays from being selected
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Saturday },
            new DayOfWeekRestriction() { DayOfWeek = DayOfWeek.Sunday },
            //This will prevent selection of all dates from the 1st of June to the 6th of June of current year
            new DateRangeRestriction() 
            { 
                StartDate = new DateTime(DateTime.Today.Year, 6, 1), 
                EndDate = new DateTime(DateTime.Today.Year, 6, 7)
            }
        };
    }
}

```

## Sample 4: Show Inline

The 'ShowInline' property toggle whether the DateTimePicker is displayed inline in page or as a drop-down editor.

```DOTHTML
<bp:DateTimePicker SelectedDateTime="{value: SelectedDate}"
                   ShowInline="true" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

## Sample 5: Custom Icons

To customize the look of icons in the control, you can use the following inner elements:

* `ToggleIcon` allows to customize the toggle icon. The default value is `Calendar`.

* `UnselectIcon` allows to customize the unselect icon. The default value is `Close`.

* `PrevDateIcon` allows to customize the icon displayed on the button navigating to previous page of date picker. The default value is `ChevronLeft`.

* `NextDateIcon` allows to customize the icon displayed on the button navigating to next page of date picker. The default value is `ChevronRight`.

* `PrevTimeIcon` allows to customize the icon displayed on the button navigating to previous page of time picker. The default value is `ChevronUp`.

* `NextTimeIcon` allows to customize the icon displayed on the button navigating to next page of time picker. The default value is `ChevronDown`.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:DateTimePicker SelectedDateTime="{value: SelectedDate}">
    <ToggleIcon>
        <bp:Icon Icon="Calendar"></bp:Icon>
    </ToggleIcon>
    <UnselectIcon>
        <bp:Icon Icon="Close"></bp:Icon>
    </UnselectIcon>
    <PrevDateIcon>
        <bp:Icon Icon="ChevronLeft"></bp:Icon>
    </PrevDateIcon>
    <NextDateIcon>
        <bp:Icon Icon="ChevronRight"></bp:Icon>
    </NextDateIcon>
    <PrevTimeIcon>
        <bp:Icon Icon="ChevronUp"></bp:Icon>
    </PrevTimeIcon>
    <NextTimeIcon>
        <bp:Icon Icon="ChevronDown"></bp:Icon>
    </NextTimeIcon>
</bp:DateTimePicker>

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

## Sample 6: Custom Texts

To customize the text displayed in the control, you can use the following properties:

* `HourText` allows to customize the text displayed above a dial used to select hour. The default value is `Hour`.

* `MinuteText` allows to customize the text displayed above a dial used to select minute. The default value is `Minute`.

* `SecondText` allows to customize the text displayed above a dial used to select second. The default value is `Second`.

* `AmPmDesignatorText` allows to customize the text displayed above a dial used to select AM / PM designator. The default value is `AM/PM`.


```DOTHTML
<bp:DateTimePicker SelectedDateTime="{value: SelectedDate}"
                   HourText="Hours"
                   MinuteText="Minutes"
                   SecondText="Seconds"
                   AmPmDesignatorText="AM/PM"/>

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DateTimePicker.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

