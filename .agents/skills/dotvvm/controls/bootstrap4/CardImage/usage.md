# <bs:CardImage>
Renders an image content inside the [Card](~/controls/bootstrap4/Card) control.

<https://getbootstrap.com/docs/4.3/components/card/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AlternateText`|String|Gets or sets the alternate text of the image.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Height`|String|Gets or sets the height of the image.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrl`|String|Gets or sets the URL of the image.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Overlay`|CardBody|Gets or sets card body which overlays image|inner element, static value, default property||
|`ToolTip`|String|Gets or sets the tool tip text of the image.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String|Gets or sets the width of the image.|attribute, static value, bindable||

## Sample 1: Basic CardImage

Use the `ImageUrl` property to provide URL of the image to be displayed. 

You may use `AlternateText` and `ToolTip` properties to provide `alt` and `title` attributes to the image. 

```DOTHTML
<bs:Card>
  <bs:CardImage
      ImageUrl="~/Images/la.jpg"
      AlternateText="Los Angeles"
      ToolTip="Los Angeles" />
</bs:Card>
```

## Sample 2: Textual Overlay

If you need to overlay the image with text, you can use [CardBody](~/controls/bootstrap4/CardBody) control inside the `CardImage`.

```DOTHTML
<bs:Card>
  <bs:CardImage
      ImageUrl="~/Images/la.jpg"
      AlternateText="Los Angeles"
      ToolTip="Los Angeles">
    <bs:CardBody 
        TitleText="Main title"
        SubtitleText="Secondary title"
        Text="Body of the card" />
  </bs:CardImage>
</bs:Card>
```

