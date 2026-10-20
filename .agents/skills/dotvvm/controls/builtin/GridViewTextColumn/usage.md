# <dot:GridViewTextColumn>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowSorting`|Boolean||attribute, static value|False|
|`CellDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each cell which is not in the edit mode.|inner element, static value||
|`CssClass`|String||attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EditCellDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each cell which is in the edit mode.|inner element, static value||
|`EditTemplate`|ITemplate||inner element, static value||
|`FilterTemplate`|ITemplate||inner element, static value, bindable||
|`FormatString`|String|Gets or sets the format string that will be applied to numeric or date-time values.|attribute, static value||
|`HeaderCellDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each header cell.|inner element, static value||
|`HeaderCssClass`|String||attribute, static value, bindable||
|`HeaderTemplate`|ITemplate||inner element, static value, bindable||
|`HeaderText`|String||attribute, static value, bindable||
|`IsEditable`|Boolean||attribute, static value|True|
|`SortAscendingHeaderCssClass`|String||attribute, static value|sort-asc|
|`SortDescendingHeaderCssClass`|String||attribute, static value|sort-desc|
|`SortExpression`|String||attribute, static value||
|`ValidatorPlacement`|([ValidatorPlacement](../_enums/DotVVM.Framework.Controls.ValidatorPlacement.md))|Whether to automatically attach Validator.Value onto the TextBox or add a standalone Validator component.|attribute, static value|None|
|`ValueBinding`|IStaticValueBinding|Gets or sets a binding which retrieves the value to display from the current data item.|attribute, bindable||
|`Visible`|Boolean||attribute, static value, bindable|True|
|`Width`|String||attribute, static value||

## Events
|Name|Type|Description|
|---|---|---|
|`ChangedBinding`|ICommandBinding|Gets or sets the command that will be triggered when the control text is changed.|

