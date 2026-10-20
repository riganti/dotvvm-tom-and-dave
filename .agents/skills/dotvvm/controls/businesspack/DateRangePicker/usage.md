# <bp:DateRangePicker>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowUnselect`|Boolean||attribute, static value, bindable|True|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ConfirmIcon`|IconBase||inner element, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`EndDatePlaceholder`|String||attribute, static value||
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
|`SelectedEndDate`|DateTime?||attribute, bindable||
|`SelectedStartDate`|DateTime?||attribute, bindable||
|`ShowInline`|Boolean||attribute, static value|False|
|`StartDatePlaceholder`|String||attribute, static value||
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

