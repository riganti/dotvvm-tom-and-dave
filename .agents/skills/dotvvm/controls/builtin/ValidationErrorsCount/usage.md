# <dot:ValidationErrorsCount>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FormatErrorsCount`|IValueBinding<Func<Int32,String>>|Gets or sets a function that formats the error count. The function receives the error count as a parameter and should return the string to be displayed. If not set, the error count will be displayed as a string.|attribute, bindable||
|`HideWhenValid`|Boolean|Gets or sets whether the control will be hidden when there are no validation errors. Default is false.|attribute, static value|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeErrorsFromChildren`|Boolean|Gets or sets whether the errors from child objects in the viewmodel will be counted too.              Default is true (unlike ValidationSummary which defaults to false).|attribute, static value|True|
|`IncludeErrorsFromTarget`|Boolean|Gets or sets whether the errors from the TargetProperty object will be counted too.|attribute, static value|True|
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InvalidCssClass`|String|Gets or sets the CSS class that will be applied to the control when there are validation errors.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the control.|attribute, static value|span|

