# <dot:NavBarDropDown>
Represents a drop down button in [NavBarSection](~/controls/bootstrap5/NavBarSection).

<https://getbootstrap.com/docs/5.2/components/navbar/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([DropAlignment](../_enums/DotVVM.Bootstrap5.Controls.DropAlignment.md))|Gets or sets how the dropdown items should be aligned.|attribute, static value|Start|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the toggle button is enabled or disabled.|attribute, static value, bindable|True|
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for the dropdown button.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for the dropdown button.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemEnabled`|Boolean|Gets or sets whether the individual items in the dropdown menu should be enabled or disabled when DataSource is set.|attribute, static value, bindable|True|
|`ItemNavigateUrl`|String|Gets or sets the URL to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the route name to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value||
|`Items`|List<IDropDownItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether an individual item in the dropdown menu is selected when DataSource is set.|attribute, static value, bindable||
|`ItemTarget`|String||attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets the template to use for rendering each item in the dropdown menu when DataSource is set.|inner element, static value||
|`ItemText`|String|Gets or sets the text to display for each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets a suffix to append to the URL of each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command that will be triggered when individual items in the dropdown menu are clicked and DataSource is set.|

