# <dot:NamedCommand>
This control is used to specify commands which can be called from [modules imported by the JS directive](~/pages/concepts/client-side-development/js-directive/call-dotvvm-from-js).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Name`|String|Gets or sets the name of the command to be used in JavaScript code.|attribute, static value||

## Events
|Name|Type|Description|
|---|---|---|
|`Command`|ICommandBinding|Gets or sets a command that will be invoked.|

