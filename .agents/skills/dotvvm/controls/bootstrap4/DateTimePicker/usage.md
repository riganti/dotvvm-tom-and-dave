# <bs:DateTimePicker>
Renders a textbox control which lets the user either to type the date, or select it from a calendar popup.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the control is enabled.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets format string that will be used to display the date.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Mode`|DateTimePickerType?|Gets or sets whether you want the user to pick only date, only time, or both date and time.|attribute, static value|DateTime|
|`PickOnly`|Boolean|Gets or sets whether the typing into textbox will be allowed.|attribute, static value|False|
|`SelectedDate`|DateTime?|Gets or sets the date selected in the control.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control text is changed.|

## Sample 1: Basic Usage

Use the `SelectedDate` property to get or set the selected date.

The `DateTimePicker` can be switched into three different modes using the `Mode` property: `DateTime`, `Date` and `Time`. 

The `FormatString` property specifies the format that will be used to display selected date. Use [standard](https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx) or 
[custom](https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx) .NET date format strings.

The language of the calendar and the first day of week is specified by the request culture. You can find more info in the [Globalization](~/pages/concepts/localization-and-cultures/multi-language-applications) tutorial.


```DOTHTML
<bs:DateTimePicker SelectedDate="{value: Date}" FormatString="d" Mode="DateTime" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DateTimePicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; }

        public ViewModel()
        {
            Date = DateTime.Now;
        }
    }
}

```

