# <bs:ResponsiveEmbed>
Allows blocks to be properly scaled by creating intrinsic ratio using Bootstrap Responsive Embed.

<https://getbootstrap.com/docs/4.3/utilities/embed/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([ResponsiveEmbedType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveEmbedType.md))|Gets or sets the type of the embed.|attribute, static value|OneByOne|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic ResponsiveEmbed

The `ResponsiveEmbed` control has the `Type` property for specifying the embed type. The options are:

* `OneByOne` (1:1)
* `FourByThree` (4:3)
* `SixteenByNine` (16:9)
* `TwentyoneByNine` (21:9)

```DOTHTML
<!-- 16:9 -->
<bs:ResponsiveEmbed Type="SixteenByNine">
  <iframe src="https://www.youtube.com/embed/m0gjBDswmsA" frameborder="0" allowfullscreen=""></iframe>
</bs:ResponsiveEmbed>
<br />
<!-- 4:3 -->
<bs:ResponsiveEmbed Type="FourByThree">
  <iframe src="https://www.youtube.com/embed/anXu-v6-roE" frameborder="0" allowfullscreen=""></iframe>
</bs:ResponsiveEmbed>
```

