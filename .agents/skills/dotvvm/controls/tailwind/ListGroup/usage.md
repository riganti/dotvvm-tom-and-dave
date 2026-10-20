# <t:ListGroup>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the collection used to generate list items automatically.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemBadgeColor`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|Gets or sets the badge color used for each generated list item.|attribute, static value, bindable|Default|
|`ItemBadgeText`|String|Gets or sets the badge text rendered at the end of each generated list item.|attribute, static value, bindable||
|`ItemCulture`|String|Gets or sets the culture segment used when each generated list item navigates by route.|attribute, static value||
|`ItemIcon`|HeroIcon?|Gets or sets the icon displayed at the start of each generated list item.|attribute, static value||
|`ItemNavigateUrl`|String|Gets or sets the URL assigned to each generated list item.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the DotVVM route name each generated list item navigates to.|attribute, static value||
|`Items`|List<ListItem>|Gets or sets hardcoded  children rendered inside the list.|inner element, static value, default property||
|`ItemTemplate`|ITemplate|Gets or sets custom content rendered for each generated list item instead of plain text.|inner element, static value||
|`ItemText`|String|Gets or sets the plain text rendered for each generated list item.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets the URL suffix appended to each generated route-based list item.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command invoked when a generated list item is clicked.|

