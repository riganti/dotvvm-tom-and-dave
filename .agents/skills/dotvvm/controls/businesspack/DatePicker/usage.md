# <bp:DatePicker>
Renders a text field that allows the user to enter or select date using a Gregorian-style calendar popup.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowUnselect`|Boolean||attribute, static value, bindable|True|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ConfirmIcon`|IconBase||inner element, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FirstDayOfWeek`|DayOfWeek?||attribute, static value||
|`FormatString`|String||attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxDate`|DateTime?||attribute, bindable||
|`MinDate`|DateTime?||attribute, bindable||
|`NextIcon`|IconBase||inner element, static value, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`PrevIcon`|IconBase||inner element, static value, bindable||
|`Restrictions`|IEnumerable<DateRestriction>||attribute, bindable||
|`SelectedDate`|DateTime?||attribute, bindable||
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

The `SelectedDate` property represents a `Date` value with a date selected in the control.

```DOTHTML
<bp:DatePicker SelectedDate="{value: SelectedDate}" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

## Sample 2: Selection Bounds

You can use the `MinDate` and `MaxDate` properties to specify the minimum and maximum values for the selection.


```DOTHTML
<bp:DatePicker SelectedDate="{value: SelectedDate}"
               MinDate="{value: MinimumDate}"
               MaxDate="{value: MaximumDate}" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample2
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

Restrictions can be combined with `MinDate` and `MaxDate` properties and are verified both on client-side and server-side.

```DOTHTML
<bp:DatePicker SelectedDate="{value: SelectedDate}"
               Restrictions="{value: Restrictions}" />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;

        public List<DateRestriction> Restrictions { get; set; } = new List<DateRestriction>()
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

## Sample 4: Format Strings

The `FormatString` property specifies the format that will be used to display selected date. Use [standard](https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx) or 
[custom](https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx) .NET date format strings.

The language of the calendar and the first day of week is specified by the request culture. You can find more info in the [Globalization](~/pages/concepts/localization-and-cultures/multi-language-applications) tutorial.

```DOTHTML
<bp:DatePicker SelectedDate="{value: SelectedDate}"
               FormatString="dd MMM yyyy"/>

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

## Sample 5: Inline

The 'ShowInline' property toggle whether the DatePicker is displayed inline in page or as a drop-down editor.

```DOTHTML
<bp:DatePicker SelectedDate="{value: SelectedDate}"
               ShowInline />

<p>Selected date: <dot:Literal Text="{value: SelectedDate}" FormatString="g" /></p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DatePicker.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime SelectedDate { get; set; } = DateTime.Now;
    }
}
```

