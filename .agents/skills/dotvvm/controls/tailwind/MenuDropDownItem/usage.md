# <t:MenuDropDownItem>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>||attribute, bindable||
|`Icon`|HeroIcon?|Gets or sets the icon displayed on the dropdown trigger button.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemCulture`|String||attribute, static value||
|`ItemIcon`|HeroIcon?|Gets or sets the icon for each item when DataSource is set. Cannot be combined with a template.|attribute, static value||
|`ItemIsActive`|Boolean|Gets or sets whether each item is active when DataSource is set.|attribute, static value, bindable|False|
|`ItemNavigateUrl`|String|Gets or sets the URL each item links to when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the DotVVM route name each item navigates to when DataSource is set.|attribute, static value||
|`Items`|List<IMenuItem>||inner element, static value, default property||
|`ItemTemplate`|ITemplate|Gets or sets the template for each item when DataSource is set. Cannot be combined with ItemIcon.|inner element, static value||
|`ItemText`|String|Gets or sets the text of each item when DataSource is set.|attribute, static value, bindable||
|`ItemUrlSuffix`|String||attribute, static value, bindable||
|`Text`|String|Gets or sets the plain text label of the dropdown trigger button.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command invoked when an item is clicked when DataSource is set.|

