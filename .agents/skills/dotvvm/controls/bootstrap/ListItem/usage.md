# <bs:ListItem>
Represents a single item in Bootstrap lists and menus.

This control is used inside several Bootstrap controls - e.g. the [Breadcrumb](~/controls/bootstrap/Breadcrumb) and [NavigationBar](~/controls/bootstrap/NavigationBar) controls.

_In the `ListGroup` control, you have to use the [ListGroupItem](~/controls/bootstrap/ListGroupItem) control._



If you set the `NavigateUrl` property or you use the `RouteName` and `Param-*` properties,
the item behaves like a hyperlink. For more information about `RouteName` properties see the
[RouteLink](~/controls/builtin/RouteLink) control - the usage is the same.

If you set the `Click` command, the specified method in the viewmodel will be 
triggered.

Remember that you cannot use those two features together.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisabled`|Boolean|Gets or sets whether this item is disabled.|attribute, static value, bindable|False|
|`IsSelected`|Boolean|Gets or sets whether this item is selected.|attribute, static value, bindable|False|
|`NavigateUrl`|String|Gets or sets the URL of the item hyperlink.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the name of the route for the item hyperlink.|attribute, static value||
|`Text`|String|Gets or sets the text of the item.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Action|Gets or sets the command that will be triggered when the button is clicked.|

