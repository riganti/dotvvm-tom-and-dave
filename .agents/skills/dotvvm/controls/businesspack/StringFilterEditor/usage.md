# <bp:StringFilterEditor>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowNull`|Boolean||attribute, static value|True|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable<String>||attribute, bindable||
|`EditorTemplate`|ITemplate||inner element, static value, bindable, default property||
|`FieldDisplayName`|String||attribute, static value||
|`FieldName`|String||attribute, static value||
|`Filter`|FilterCondition||attribute, bindable||
|`FilterGroup`|FilterGroup||attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Inline`|Boolean||attribute, static value|False|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Operators`|List<IStringOperator>||inner element, static value||
|`ValueBinding`|IValueBinding||attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

