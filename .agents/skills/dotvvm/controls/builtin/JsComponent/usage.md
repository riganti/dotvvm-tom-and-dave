# <dot:JsComponent>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Global`|Boolean|If set to true, view modules are ignored and JsComponents registered using dotvvm.registerGlobalComponent will be considered for client-side rendering.|attribute, static value|False|
|`Html:ID`|String||attribute, static value, bindable||
|`Html:Visible`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Name`|String|Name by which the client-side component was registered. The name is case sensitive.|attribute, static value||
|`WrapperTagName`|String|The JsComponent must have a wrapper HTML tag, this property configures which tag is used. By default, `div` is used.|attribute, static value|div|

