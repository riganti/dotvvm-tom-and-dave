# <bs:MetaViewport>
Renders the HTML `<meta name="viewport" ... />` element. This element ensures proper rendering and touch zooming on mobile devices. 

See details on <https://getbootstrap.com/docs/4.3/getting-started/introduction/#responsive-meta-tag>.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InitialScale`|String|Gets or sets the initial-scale parameter value(initial zoom level).|attribute, static value|1|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsUserScalable`|Boolean|Gets or sets the user-scalable parameter value which controls if user can zoom in on mobile device.|attribute, static value|True|
|`MaximumScale`|String|Gets or sets the maximum-scale parameter value.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String|Gets or sets the width parameter value with default set to use width of mobile device(device-width).|attribute, static value|device-width|

## Sample 1: MetaViewport

Place the control inside the `head` element. It uses Bootstrap API to control zooming and presentation on mobile devices.

The `MetaViewport` control has the `Width` property which sets the width of the page.

The `InitialScale` property is used to set initial zoom level which is applied when the page is first loaded.
The `MaximumScale` property defines maximum zoom level the user can set.

It is also possible to disable zooming at all with the `IsUserScalable` property. 

```DOTHTML
<!-- Default meta viewport -->
<bs:MetaViewport/>

<!-- Custom meta viewport -->
<bs:MetaViewport Width="320" InitialScale="2" MaximumScale="4" />

<!-- Meta viewport with disabled user scaling -->
<bs:MetaViewport IsUserScalable="false" />
```

