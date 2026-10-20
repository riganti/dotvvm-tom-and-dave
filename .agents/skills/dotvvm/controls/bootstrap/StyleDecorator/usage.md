# <bs:StyleDecorator>
Decorates inner elements with various properties and Bootstrap CSS classes.

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
|`TextColor`|([BootstrapContextualColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapContextualColor.md))||attribute, static value, bindable|None|
|`Visibility`|([BootstrapVisibility](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapVisibility.md))||attribute, static value|None|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: StyleDecorator - Text Colors

The `StyleDecorator` control has the `TextColor` property for setting the text color of inner element using Bootstrap colors.

```DOTHTML
<bs:StyleDecorator TextColor="None">
  <p>Text with TextColor set to: None</p>
</bs:StyleDecorator>

<bs:StyleDecorator TextColor="Muted">
  <p>Text with TextColor set to: Muted</p>
</bs:StyleDecorator>

<bs:StyleDecorator TextColor="Primary">
  <p>Text with TextColor set to: Primary</p>
</bs:StyleDecorator>

<bs:StyleDecorator TextColor="Success">
  <p>Text with TextColor set to: Success</p>
</bs:StyleDecorator>

<bs:StyleDecorator TextColor="Info">
  <p>Text with TextColor set to: Info</p>
</bs:StyleDecorator>

<bs:StyleDecorator TextColor="Warning">
  <p>Text with TextColor set to: Warning</p>
</bs:StyleDecorator>

<bs:StyleDecorator TextColor="Danger">
  <p>Text with TextColor set to: Danger</p>
</bs:StyleDecorator>
```

## Sample 2: StyleDecorator - Background colors

The `StyleDecorator` control has the `BackgroundColor` property for setting the background color of inner element using Bootstrap colors.

```DOTHTML
<bs:StyleDecorator BackgroundColor="None">
  <p>Text with BackgroundColor set to: None</p>
</bs:StyleDecorator>

<bs:StyleDecorator BackgroundColor="Primary">
  <p>Text with BackgroundColor set to: Primary</p>
</bs:StyleDecorator>

<bs:StyleDecorator BackgroundColor="Success">
  <p>Text with BackgroundColor set to: Success</p>
</bs:StyleDecorator>

<bs:StyleDecorator BackgroundColor="Info">
  <p>Text with BackgroundColor set to: Info</p>
</bs:StyleDecorator>

<bs:StyleDecorator BackgroundColor="Warning">
  <p>Text with BackgroundColor set to: Warning</p>
</bs:StyleDecorator>

<bs:StyleDecorator BackgroundColor="Danger">
  <p>Text with BackgroundColor set to: Danger</p>
</bs:StyleDecorator>
```

## Sample 3: StyleDecorator - Visibility

The `StyleDecorator` control has the `Visibility` property for setting inner element visible or hidden option for specific screen sizes.

The values are: 

* `None`

* `VisibleExtraSmallBlock`
* `VisibleExtraSmallInline`
* `VisibleExtraSmallInlineBlock`

* `VisibleSmallBlock`
* `VisibleSmallInline` 
* `VisibleSmallInlineBlock`

* `VisibleMediumBlock`
* `VisibleMediumInline`
* `VisibleMediumInlineBlock`

* `VisibleLargeBlock`
* `VisibleLargeInline`
* `VisibleLargeInlineBlock`

* `HiddenExtraSmall`
* `HiddenSmall`
* `HiddenMedium`
* `HiddenLarge`

```DOTHTML
<bs:StyleDecorator Visibility="VisibleExtraSmallBlock">
  <p>Text visible on extra small devices.</p>
</bs:StyleDecorator>

<bs:StyleDecorator Visibility="VisibleMediumBlock">
  <p>Text visible on devices with medium sized display.</p>
</bs:StyleDecorator>

<bs:StyleDecorator Visibility="HiddenSmall">
  <p>Text hidden on small devices.</p>
</bs:StyleDecorator>

<bs:StyleDecorator Visibility="HiddenLarge">
  <p>Text hidden on large devices.</p>
</bs:StyleDecorator>
```

## Sample 4: StyleDecorator - Other properties

`StyleDecorator` control has `Center` property of *bool* for centering text in wrapping element and `ClearFix` property of *bool* for using clearfix.

It is also possible to force inner element to be shown with `ForceShown` property or hidden with `ForceHidden` property.

To float inner element to the left or right `Float` property is used.

```DOTHTML
<bs:StyleDecorator Centered="true">
  <p style="max-width: 200px">Centered text</p>
</bs:StyleDecorator>

<bs:StyleDecorator ClearFix="true">
  <p>Text with ClearFix.</p>
</bs:StyleDecorator>

<bs:StyleDecorator ForceShown="true">
  <p>Force shown text.</p>
</bs:StyleDecorator>

<bs:StyleDecorator ForceHidden="true">
  <p>Force hidden text.</p>
</bs:StyleDecorator>

<bs:StyleDecorator Float="Left">
  <p>Text with float:left.</p>
</bs:StyleDecorator>

<bs:StyleDecorator Float="Right">
  <p>Text with float:right.</p>
</bs:StyleDecorator>

```

## Sample 5: StyleDecorator - Active properties

All properties of `StyleDecorator` can be used on other elements.
(You can set `TextColor` on `<div>` for example.)

```DOTHTML
<p StyleDecorator.BackgroundColor="Success" StyleDecorator.TextColor="Danger" StyleDecorator.Visibility="HiddenSmall" StyleDecorator.Float="Right" StyleDecorator.ClearFix="true" StyleDecorator.Centered="true" data-ui="activeProp-background-text-binding-all-true">
  Text text text text.
</p>
```

