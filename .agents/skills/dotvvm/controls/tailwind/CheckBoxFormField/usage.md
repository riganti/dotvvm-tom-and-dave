# <t:CheckBoxFormField>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`CheckBoxID`|String||attribute, static value, bindable||
|`CheckBoxVisible`|Boolean||attribute, static value, bindable|True|
|`Checked`|IValueBinding<Boolean>||attribute, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`ValidatorProperty`|IValueBinding||attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding||

