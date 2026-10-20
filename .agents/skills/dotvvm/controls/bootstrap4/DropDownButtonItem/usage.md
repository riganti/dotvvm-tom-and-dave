# <bs:DropDownButtonItem>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the template for content of the item.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether this item is enabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsSelected`|Boolean|Gets or sets whether this item is selected.|attribute, static value, bindable|False|
|`NavigateUrl`|String|Gets or sets the URL of the item hyperlink.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the name of the route for the item hyperlink.|attribute, static value||
|`Text`|String|Gets or sets the text of the item.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

