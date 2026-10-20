# <t:DateTimePicker>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Culture`|String|Gets or sets the culture name used for localization. When omitted,  is used.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DateFormat`|String|Gets or sets the .NET date format string used for display. Supported tokens: d, M, and y.|attribute, static value||
|`Enabled`|Boolean|Gets or sets whether the input is enabled.|attribute, static value, bindable||
|`HoursStep`|Int32?|Gets or sets the hour step used by the time picker.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InputSize`|([InputSize](../_enums/DotVVM.Controls.Tailwind.InputSize.md))|Gets or sets the visual input size.|attribute, static value, bindable|Default|
|`MaxDate`|DateTime?|Gets or sets the maximum selectable date and time.|attribute, static value, bindable||
|`MaxHours`|Int32|Gets or sets the maximum selectable hour when time selection is enabled.|attribute, static value, bindable||
|`MinDate`|DateTime?|Gets or sets the minimum selectable date and time.|attribute, static value, bindable||
|`MinHours`|Int32|Gets or sets the minimum selectable hour when time selection is enabled.|attribute, static value, bindable||
|`MinutesStep`|Int32?|Gets or sets the minute step used by the time picker.|attribute, static value||
|`Placeholder`|String|Gets or sets the placeholder text shown when no value is selected.|attribute, static value, bindable||
|`SelectedValue`|IValueBinding<DateTime?>|Gets or sets the selected date and time value bound to the control.|attribute, bindable||
|`TimeFormat`|String|Gets or sets the .NET time format string used for display. Accepted tokens are limited to h, H, m, s, and t.|attribute, static value||
|`Type`|([DateTimePickerType](../_enums/DotVVM.Controls.Tailwind.Controls.DateTimePickerType.md))|Gets or sets whether the control displays a date picker, time picker, or both.|attribute, static value|Date|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

