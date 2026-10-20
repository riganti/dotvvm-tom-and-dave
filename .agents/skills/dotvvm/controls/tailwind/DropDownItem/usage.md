# <t:DropDownItem>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Culture`|String||attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Icon`|HeroIcon?|Gets or sets the icon displayed before the item label. Cannot be combined with a template set via inner content.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`NavigateUrl`|String|Gets or sets the URL to navigate to when the item is clicked. Mutually exclusive with Click and RouteLink.|attribute, static value, bindable||
|`RouteName`|String||attribute, static value||
|`Template`|ITemplate||inner element, static value, default property||
|`Text`|String||attribute, static value, bindable||
|`UrlSuffix`|String||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command invoked when the item is clicked. Mutually exclusive with NavigateUrl and RouteLink.|

