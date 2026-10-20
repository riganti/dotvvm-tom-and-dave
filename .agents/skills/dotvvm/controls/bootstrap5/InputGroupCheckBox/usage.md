# <dot:InputGroupCheckBox>
A special version of the [CheckBox](~/controls/bootstrap5/CheckBox) control that can be used in [InputGroup](~/controls/bootstrap5/InputGroup).

See [CheckBox](~/controls/bootstrap5/CheckBox) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/input-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, static value, bindable||
|`CheckedItems`|IValueBinding<IEnumerable>|Gets or sets the collection of checked items. Use this property in combination with the CheckedValue property.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked. Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Gets or sets the command that will be triggered when the control check state is changed.|

