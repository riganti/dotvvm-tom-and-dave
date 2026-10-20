# <t:ListItem>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BadgeColor`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|The color of the optional badge. Defaults to Default.|attribute, static value, bindable|Default|
|`BadgeText`|String|An optional badge label shown on the right side of the item.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Culture`|String||attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Icon`|HeroIcon?|An optional icon displayed on the left side of the item.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`NavigateUrl`|String|A URL that the entire list item links to. Use either this, RouteLinkCapability properties, or Click.|attribute, static value, bindable||
|`RouteName`|String||attribute, static value||
|`Template`|ITemplate||inner element, static value, default property||
|`Text`|String||attribute, static value, bindable||
|`UrlSuffix`|String||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|A command invoked when the list item is clicked. Use either this, NavigateUrl, or RouteLinkCapability properties.|

