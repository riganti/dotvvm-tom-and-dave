# <dot:DropDownItem>
Represents a single item inside a dropdown menu.

<https://getbootstrap.com/docs/5.2/components/dropdowns>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the item in the dropdown menu should be enabled or disabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`NavigateUrl`|String|Gets or sets the URL to navigate to when an item in the dropdown menu is clicked.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the route name to navigate to when an item in the dropdown menu is clicked.|attribute, static value||
|`Selected`|Boolean|Gets or sets whether an item in the dropdown menu is selected.|attribute, static value, bindable||
|`Target`|String||attribute, static value, bindable||
|`Template`|ITemplate|Gets or sets the template to use for item in the dropdown menu.|inner element, static value, default property||
|`Text`|String|Gets or sets the text to display item in the dropdown menu.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets a suffix to append to the URL for item in the dropdown menu.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when item in the dropdown menu are clicked.|

## Sample 1: Basic Usage

This child control is shared across all DropDown controls:

* [DropDown](~/controls/bootstrap5/DropDown)
* [TabDropDown](~/controls/bootstrap5/TabDropDown)
* [InputGroupDropDown](~/controls/bootstrap5/InputGroupDropDown)
* [NavBarDropDown](~/controls/bootstrap5/NavBarDropDown)

All properties of `DropDownItem` control could be binded with a `Item` prefix property (`ItemEnabled`, `ItemSelected`, `ItemNavigateUrl`, `ItemRouteName`...) on the parent controls above.

```DOTHTML
<bs:DropDown Text="Very Simple Dropdown">
    <bs:DropDownItem NavigateUrl="https://www.google.com/">
      Google
    </bs:DropDownItem>
    <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm" Text="DotVVM" />
</bs:DropDown>

<bs:DropDown ButtonType="Link" >
  <Content>
    <bs:Icon Type="Calendar" />
    <strong>Simple Dropdown</strong>
    with custom toggle
  </Content>
  <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
    Google
  </bs:DropDownItem>
  <bs:DropDownSeparator />
  <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownItem>
</bs:DropDown>

<bs:DropDown Text="Drop up Button" DropDirection="DropUp">
  <bs:DropDownItem NavigateUrl="https://www.google.com/">
      Google is a <strong>search engine</strong>
  </bs:DropDownItem>
  <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownItem>
</bs:DropDown>


<p>IsCollapsed: {{value: Collapsed}}</p>
<bs:DropDown IsCollapsed="{value: Collapsed}" Text="Collapse test">
  <bs:DropDownItem NavigateUrl="https://www.google.com">Google</bs:DropDownItem>
</bs:DropDown>

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool Collapsed { get; set; }
}
```

