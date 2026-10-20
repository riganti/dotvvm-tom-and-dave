# <dot:NavBarLink>
Represents a link item in [NavBarSection](~/controls/bootstrap5/NavBarSection).

<https://getbootstrap.com/docs/5.2/components/navbar/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the link is enabled or disabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`NavigateUrl`|String|Gets or sets a navigation URL for the link.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets a route name. Cannot be combined with navigateUrl URL.|attribute, static value||
|`Selected`|Boolean|Gets or sets whether the link is selected.|attribute, static value, bindable||
|`Target`|String||attribute, static value, bindable||
|`Template`|ITemplate|Gets or sets a custom template for the link.|inner element, static value, default property||
|`Text`|String|Gets or sets a plain text for the link.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets a URL suffix for the link.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding||

