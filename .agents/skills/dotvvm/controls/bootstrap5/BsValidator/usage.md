# <dot:BsValidator>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HideWhenValid`|Boolean|Gets or sets whether the control should be hidden even for valid values.|attribute, static value, bindable|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InvalidCssClass`|String|Gets or sets the name of CSS class which is applied to the control when it is not valid.|attribute, static value||
|`SetToolTipText`|Boolean|Gets or sets whether the title attribute should be set to the error message.|attribute, static value|False|
|`ShowErrorMessageText`|Boolean|Gets or sets whether the error message text should be displayed.|attribute, static value|False|
|`Value`|Object|Gets or sets a binding that points to the validated value.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

