# <bs:ModalConfirmPostBackHandler>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AcceptButtonId`|String|Gets or sets accept button id.|attribute, static value||
|`AcceptButtonText`|String|Gets or sets accept button text.|attribute, static value, bindable|Accept|
|`CancelButtonId`|String|Gets or sets cancel button it.|attribute, static value||
|`CancelButtonText`|String|Gets or sets cancel button text.|attribute, static value, bindable|Cancel|
|`ConfirmDialogId`|String|Gets or sets confirm dialog id.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether this PostBackHandler is enabled.|attribute, static value, bindable|True|
|`EventName`|String|Gets or sets the name of the event which the handler applies to. If this property is not set, it applies to all events.|attribute, static value||
|`GenerateModalDialog`|Boolean|Gets or sets if modal dialog will be automatically generated.|attribute, static value, bindable|True|
|`Message`|String|Gets or sets dialog message.|attribute, static value, bindable||
|`MessageLiteralId`|String|Gets or sets dialog message Id.|attribute, static value||

