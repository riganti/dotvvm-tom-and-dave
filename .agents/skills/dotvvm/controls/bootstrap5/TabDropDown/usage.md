# <dot:TabDropDown>
A special version of the [DropDown](~/controls/bootstrap5/DropDown) control that can be used in [TabControl](~/controls/bootstrap5/TabControl).

See [DropDown](~/controls/bootstrap5/DropDown) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/components/navs-tabs>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([DropAlignment](../_enums/DotVVM.Bootstrap5.Controls.DropAlignment.md))||attribute, static value|Start|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseBehavior`|([DropDownCloseBehavior](../_enums/DotVVM.Bootstrap5.Controls.DropDownCloseBehavior.md))|Gets or sets the dropdown closing behavior. Possible values are `Default`, `Inside`, `Outside` and `Manual`.|attribute, static value|Default|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the data source for the items in the dropdown menu.|attribute, bindable||
|`DropDirection`|([DropDirection](../_enums/DotVVM.Bootstrap5.Controls.DropDirection.md))|Gets or sets the direction in which the dropdown menu should open.|attribute, static value|DropDown|
|`Enabled`|Boolean|Gets or sets whether the toggle button is enabled or disabled.|attribute, static value, bindable|True|
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for the dropdown button.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for the dropdown button.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsCollapsed`|IValueBinding<Boolean>|Gets or sets whether the dropdown menu is collapsed or expanded.|attribute, bindable||
|`ItemEnabled`|Boolean|Gets or sets whether the individual items in the dropdown menu should be enabled or disabled when DataSource is set.|attribute, static value, bindable|True|
|`ItemNavigateUrl`|String|Gets or sets the URL to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the route name to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value||
|`Items`|List<IDropDownItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether an individual item in the dropdown menu is selected when DataSource is set.|attribute, static value, bindable||
|`ItemTarget`|String||attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets the template to use for rendering each item in the dropdown menu when DataSource is set.|inner element, static value||
|`ItemText`|String|Gets or sets the text to display for each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets a suffix to append to the URL of each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command that will be triggered when individual items in the dropdown menu are clicked and DataSource is set.|

## Sample 1: TabDropDown Control

The `<bs:TabDropDown>` control has limited features for drop down toggle button in comparison with a standard [DropDown](~/controls/bootstrap5/DropDown) control.  Nevertheless, both [DropDown](~/controls/bootstrap5/DropDown) and `<bs:TabDropDown>` share the same child control `DropDownItem`.

```DOTHTML
<bs:TabControl HorizontalAlingment="Center" 
               Justify="fill">
  <bs:TabDropDown HeaderText="Header">
    <bs:DropDownItem>item</bs:DropDownItem>
    <bs:DropDownSeparator />
    <bs:DropDownItem>item</bs:DropDownItem>
    <bs:DropDownItem>item</bs:DropDownItem>
  </bs:TabDropDown>
  <bs:TabItem>
    <HeaderTemplate> Tab 1 </HeaderTemplate>
    My tab 1
  </bs:TabItem>
  <bs:TabItem>
  <HeaderTemplate> Tab 2 </HeaderTemplate>
    tab 2
  </bs:TabItem>
</bs:TabControl>
```

