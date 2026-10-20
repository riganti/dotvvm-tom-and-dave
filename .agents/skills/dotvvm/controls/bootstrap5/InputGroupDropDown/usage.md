# <dot:InputGroupDropDown>
A special version of the [DropDown](~/controls/bootstrap5/DropDown) control that can be used in [InputGroup](~/controls/bootstrap5/InputGroup).

See [DropDown](~/controls/bootstrap5/DropDown) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/input-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([DropAlignment](../_enums/DotVVM.Bootstrap5.Controls.DropAlignment.md))||attribute, static value|Start|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseBehavior`|([DropDownCloseBehavior](../_enums/DotVVM.Bootstrap5.Controls.DropDownCloseBehavior.md))|Gets or sets the dropdown closing behavior. Possible values are `Default`, `Inside`, `Outside` and `Manual`.|attribute, static value|Default|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the data source for the items in the dropdown menu.|attribute, bindable||
|`DropDirection`|([DropDirection](../_enums/DotVVM.Bootstrap5.Controls.DropDirection.md))|Gets or sets the direction in which the dropdown menu should open.|attribute, static value|DropDown|
|`Enabled`|Boolean|Gets or sets a button disabled state.|attribute, static value, bindable|True|
|`FontType`|([ButtonTextColor](../_enums/DotVVM.Bootstrap5.ButtonTextColor.md))|Gets or sets the font color for button toggle.|attribute, static value, bindable|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsCollapsed`|IValueBinding<Boolean>|Gets or sets whether the dropdown menu is collapsed or expanded.|attribute, bindable||
|`IsSplitButton`|Boolean|Gets or sets whether the dropdown button should be a split button.|attribute, static value|False|
|`ItemEnabled`|Boolean|Gets or sets whether the individual items in the dropdown menu should be enabled or disabled when DataSource is set.|attribute, static value, bindable|True|
|`ItemNavigateUrl`|String|Gets or sets the URL to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the route name to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value||
|`Items`|List<IDropDownItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether an individual item in the dropdown menu is selected when DataSource is set.|attribute, static value, bindable||
|`ItemTarget`|String||attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets the template to use for rendering each item in the dropdown menu when DataSource is set.|inner element, static value||
|`ItemText`|String|Gets or sets the text to display for each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets a suffix to append to the URL of each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the dropdown button toggle.|attribute, static value, bindable|Default|
|`SplitButtonMenuAlignment`|([SplitButtonMenuAlignment](../_enums/DotVVM.Bootstrap5.Controls.SplitButtonMenuAlignment.md))|Gets or sets whether the toggle menu should be displayed next to a button or next to an arrow.|attribute, static value|AlignWithArrow|
|`Text`|String|Gets or sets the text to display on the dropdown button.|attribute, static value, bindable||
|`ToggleType`|([DropDownType](../_enums/DotVVM.Bootstrap5.Controls.DropDownType.md))|Gets or sets the toggle button type. Possible values are the `Button` or `Link`.|attribute, static value|Button|
|`Type`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the command that will be triggered when individual items in the dropdown menu are clicked and DataSource is set.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets the command that will be triggered when individual items in the dropdown menu are clicked and DataSource is set.|attribute, static value|SolidFill|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when the dropdown button is clicked.|
|`ItemClick`|ICommandBinding|Gets or sets the command that will be triggered when individual items in the dropdown menu are clicked and DataSource is set.|

