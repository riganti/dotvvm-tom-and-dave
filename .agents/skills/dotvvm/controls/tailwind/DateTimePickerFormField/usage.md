# <t:DateTimePickerFormField>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Culture`|String|The culture name used for localization. When omitted, CurrentUICulture is used.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DateFormat`|String|The .NET date format string used for display. Supported tokens: d, M, y.|attribute, static value||
|`Enabled`|Boolean|Determines whether the input is enabled.|attribute, static value, bindable||
|`HoursStep`|Int32?|The hour step used by the time picker.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InputSize`|([InputSize](../_enums/DotVVM.Controls.Tailwind.InputSize.md))|Controls the visual input size.|attribute, static value, bindable|Default|
|`LabelTemplate`|ITemplate||inner element, static value||
|`LabelText`|String||attribute, static value, bindable||
|`MaxDate`|DateTime?|The maximum selectable date and time.|attribute, static value, bindable||
|`MaxHours`|Int32|The maximum selectable hour when time selection is enabled.|attribute, static value, bindable||
|`MinDate`|DateTime?|The minimum selectable date and time.|attribute, static value, bindable||
|`MinHours`|Int32|The minimum selectable hour when time selection is enabled.|attribute, static value, bindable||
|`MinutesStep`|Int32?|The minute step used by the time picker.|attribute, static value||
|`Placeholder`|String|The placeholder text shown when no value is selected.|attribute, static value, bindable||
|`SelectedValue`|IValueBinding<DateTime?>|The selected date and time value bound to the control.|attribute, bindable||
|`Size`|([FormFieldSize](../_enums/DotVVM.Controls.Tailwind.FormFieldSize.md))|The width behavior of the form field inside a form row.|attribute, static value, bindable|Auto|
|`TimeFormat`|String|The .NET time format string used for display. Accepted tokens are limited to h, H, m, s, and t. Seconds currently throw because AIR Datepicker does not support them.|attribute, static value||
|`Type`|([DateTimePickerType](../_enums/DotVVM.Controls.Tailwind.Controls.DateTimePickerType.md))|Determines whether the control displays a date picker, time picker, or both.|attribute, static value|Date|
|`ValidatorProperty`|IValueBinding|An optional property used for validation message lookup instead of .|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

