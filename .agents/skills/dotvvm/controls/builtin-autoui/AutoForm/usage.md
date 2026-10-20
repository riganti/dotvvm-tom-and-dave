# <auto:AutoForm>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EditorCellCssClass`|String|Gets or sets the CSS class that will be used for the table cell with editor control.|attribute, static value, bindable||
|`ExcludeProperties`|String[]|The specified properties will not be included in this form.|attribute, static value|System.String[]|
|`GroupName`|String|Gets or sets the group of fields that should be rendered. If not set, fields from all groups will be rendered.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IncludeProperties`|String[]|Only the specified properties will be included in this form. Using ViewName, GroupName or ExcludedProperties at the same time as IncludedProperties does not make sense. The properties will be listed in the exact order defined in this property.|attribute, static value||
|`LabelCellCssClass`|String|Gets or sets the CSS class that will be used for the table cell with field labels.|attribute, static value, bindable||
|`ViewName`|String|Gets or sets the view name (e.g. Insert, Edit, ReadOnly). Some fields may have different metadata for each view.|attribute, static value, bindable||

