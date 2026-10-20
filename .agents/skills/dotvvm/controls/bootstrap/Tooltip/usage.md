# <bs:Tooltip>
Adds the Bootstrap Tooltip to an element or control.

<https://getbootstrap.com/docs/3.3/javascript/#tooltips>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BackgroundColor`|([BootstrapContextualBackgroundColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapContextualBackgroundColor.md))||attribute, static value, bindable|None|
|`Centered`|Boolean||attribute, static value|False|
|`ClearFix`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Float`|([BootstrapQuickFloat](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapQuickFloat.md))||attribute, static value|None|
|`ForceHidden`|Boolean||attribute, static value, bindable|False|
|`ForceShown`|Boolean||attribute, static value|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Position`|([TooltipPosition](../_enums/DotVVM.Framework.Controls.Bootstrap.TooltipPosition.md))|Gets or sets the position of the tooltip.|attribute, static value|Left|
|`TextColor`|([BootstrapContextualColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapContextualColor.md))||attribute, static value, bindable|None|
|`Title`|String|Gets or sets the text of the tooltip.|attribute, static value, bindable||
|`Visibility`|([BootstrapVisibility](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapVisibility.md))||attribute, static value|None|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Tooltip Usage

The Tooltip control has the `Title` property which holds the text used in the Tooltip.

The position of the tooltip can be set using the `Position` property.

```DOTHTML
<bs:Tooltip Position="Left" Title="This element has simple tooltip">
  <a href="#">Link 1</a>
</bs:Tooltip>

<bs:Tooltip Position="Right" Title="This element has simple tooltip">
  <a href="#">Link 2</a>
</bs:Tooltip>

<bs:Tooltip Position="Bottom" Title="This element has simple tooltip">
  <a href="#">Link 3</a>
</bs:Tooltip>

<bs:Tooltip Position="Top" Title="This element has simple tooltip">
  <a href="#">Link 4</a>
</bs:Tooltip>
```

