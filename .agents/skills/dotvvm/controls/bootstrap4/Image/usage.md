# <bs:Image>
Renders an image and allows to apply Bootstrap CSS classes - e.g. rounded corners, circle crop etc.

<https://getbootstrap.com/docs/4.3/content/images/>

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
|`ToolTip`|String|Gets or sets the tool tip text of the image.|attribute, static value, bindable||
|`Type`|([ImageType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ImageType.md))|Gets or sets the type of the image - e.g. rounded, circle, responsive etc.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String|Gets or sets the width of the image.|attribute, static value, bindable||

## Sample 1: Basic Image

The most important property is the `ImageUrl` which sets the `src` attribute of the rendered image.

The `Image` control has the `ToolTip` and `AlternateText` properties which set the `title` and `alt` attributes.

There are also `Width` and `Height` properties which apply the width and a height of the image using inline CSS styles.


```DOTHTML
<bs:Image ImageUrl="~/Images/LA.jpg" 
          AlternateText="Los Angeles" 
          Height="50%" Width="50%" />
```

## Sample 2: Image Types

The `Type` property specifies which type of the image should be rendered.

The available types are:

* `Default`
* `Thumbnail`
* `Responsive`
* `Rounded`
* `Circle`

```DOTHTML
<bs:Image ImageUrl="~/Images/LA.jpg" AlternateText="Los Angeles" />
<br/>
<bs:Image ImageUrl="~/Images/LA.jpg" AlternateText="Los Angeles" 
          Type="Thumbnail" />
<br/>
<bs:Image ImageUrl="~/Images/LA.jpg" AlternateText="Los Angeles" 
          Type="Responsive" />
<br/>
<bs:Image ImageUrl="~/Images/LA.jpg" AlternateText="Los Angeles" 
          Type="Rounded" />
<br/>
<bs:Image ImageUrl="~/Images/LA.jpg" AlternateText="Los Angeles" 
          Type="Circle" />

```

