# <t:TextBoxFormField>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InputSize`|([InputSize](../_enums/DotVVM.Controls.Tailwind.InputSize.md))||attribute, static value, bindable|Default|
|`LabelTemplate`|ITemplate||inner element, static value||
|`LabelText`|String||attribute, static value, bindable||
|`Size`|([FormFieldSize](../_enums/DotVVM.Controls.Tailwind.FormFieldSize.md))||attribute, static value, bindable|Auto|
|`Text`|IValueBinding||attribute, bindable||
|`TextBoxID`|String||attribute, static value, bindable||
|`TextBoxVisible`|Boolean||attribute, static value, bindable|True|
|`Type`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))||attribute, static value, bindable|Normal|
|`ValidatorProperty`|IValueBinding||attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding||

