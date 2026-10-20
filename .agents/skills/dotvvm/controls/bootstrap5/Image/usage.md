# <dot:Image>
Renders an image and allows to apply Bootstrap CSS classes - e.g. rounded corners, circle crop etc.

<https://getbootstrap.com/docs/5.2/content/images/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AlternateText`|String|Gets or sets the alt attribute value.|attribute, static value, bindable||
|`BorderColor`|([BorderColor](../_enums/DotVVM.Bootstrap5.BorderColor.md))|Gets or sets the border color. Possible values are Primary, Secondary, Success, Danger, Warning, Info, Light, Dark and White.|attribute, static value, bindable|Default|
|`BorderOpacity`|([BorderOpacity](../_enums/DotVVM.Bootstrap5.BorderOpacity.md))|Gets or sets the border radius opacity. Possible values are XLow (10%), Low (25%), Medium(50%), High(75%), XHigh(100%).|attribute, static value, bindable|Default|
|`BorderPositions`|BorderPosition[]|Gets or sets a comma-separated list of border positions. Possible values are Full, Top, Bottom, Left, Right.|attribute, static value||
|`BorderRadius`|BorderRadius[]|Gets or sets the border radius css classes, that allow to round the corners.|attribute, static value||
|`BorderRadiusSize`|([BorderRadiusSize](../_enums/DotVVM.Bootstrap5.BorderRadiusSize.md))|Gets or sets the border radius size. Possible values are XSmall, Small, Medium, Large, XLarge.|attribute, static value, bindable|None|
|`BorderWidth`|([BorderWidth](../_enums/DotVVM.Bootstrap5.BorderWidth.md))|Gets or sets the border width. Possible values are XSmall, Small, Medium, Large, XLarge.|attribute, static value, bindable|None|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Height`|String|Gets or sets the height attribute value.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrl`|String|Gets or sets the src attribute value.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ToolTip`|String|Gets or sets the title attribute value.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyles`|ImageVisualStyle[]|Gets or sets a comma-separated list of CSS classes. Possible values are Thumbnail (img-thumbnail), Responsive (img-fluid), Rounded (img-rounded).|attribute, static value||
|`Width`|String|Gets or sets the width attribute value.|attribute, static value, bindable||

## Sample 1: Basic Image

The most important property is the `ImageUrl` which sets the `src` attribute of the rendered image.

The `Image` control has the `ToolTip` and `AlternateText` properties which set the `title` and `alt` attributes.

There are also `Width` and `Height` properties which apply the width and a height of the image using inline CSS styles.


```DOTHTML
<bs:Image ImageUrl="~/Images/LA.jpg" 
          AlternateText="Los Angeles" 
          Height="50%" Width="50%" 
          ToolTip="Hard coded ToolTip"/>
```

## Sample 2: Image VisualStyles

The `VisualStyles` property specifies which type of the image should be rendered. One image can contains more than one VisualStyles.

The available VisualStyles are:

* `Default`
* `Thumbnail`
* `Responsive`
* `Rounded`
* `Circle`

```DOTHTML
<bs:Image ImageUrl="~/Images/LA.jpg" VisualStyles="Rounded, Responsive"/>

<bs:Image ImageUrl="~/Images/LA.jpg" VisualStyles="Thumbnail, Rounded"/>
```

## Sample 3: Border properties

Use property `BorderColor` to specify color of border. For list of colors visit [Bootstrap documentation colors](https://getbootstrap.com/docs/5.2/utilities/colors/)

Use property `BorderOpacity` to specify opacity of border. Avalaible values for opacity are `XLow`, `Low`, `Medium`, `High` and `XHigh`.

Use property `BorderPosition` to specify position of border. Avalaible values for position are `Full`, which set border around image, and `Top`, `Left`, `Right` and `Bottom`, which can be combined together.

Use property `BorderRadiusSize` to specify size of border radius. Avalaible values for radius size are `XLow`, `Low`, `Medium`, `High` and `XHigh`.

Use property `BorderRadius` to specify style or position of border. Avalaible values for opacity are `Circle`, `Pill` and `Full` and then `Top`, `Left`, `Right` and `Bottom`, which can be combined together.

Use property `BorderWidth` to specify width of border. Avalaible values for opacity are `XSmall`, `Small`, `Medium`, `Large` and `XLarge`.


```DOTHTML
<bs:Image ImageUrl="~/Images/LA.jpg" BorderPositions="Full" BorderColor="Primary" BorderWidth="XLarge" />
<bs:Image ImageUrl="~/Images/LA.jpg" BorderColor="Primary" BorderPositions="Full" BorderWidth="XLarge" BorderOpacity="XHigh" />
<bs:Image ImageUrl="~/Images/LA.jpg" BorderColor="Primary" BorderWidth="XLarge" BorderPositions="Top, Left, Bottom" />
<bs:Image ImageUrl="~/Images/LA.jpg" BorderColor="Primary" BorderWidth="XLarge" BorderRadius="Full" BorderRadiusSize="XSmall" />
```

