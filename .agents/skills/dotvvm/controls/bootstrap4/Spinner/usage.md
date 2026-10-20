# <bs:Spinner>
Spinners can be used as loading animation.

<https://getbootstrap.com/docs/4.3/components/spinners/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ScreenReaderOnlyText`|String|Gets or sets text displayed to users of screen readers.|attribute, static value, bindable|Loading...|
|`Size`|([SpinnerSize](../_enums/DotVVM.Framework.Controls.Bootstrap4.SpinnerSize.md))|Gets or sets the size of Spinner component.             Inside other components (buttons,...) the other size is small.|attribute, static value, bindable|Default|
|`Type`|([BootstrapTextColor](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapTextColor.md))|Gets or sets the color of Spinner component.|attribute, static value, bindable|Dark|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([SpinnerVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.SpinnerVisualStyle.md))|Gets or sets the style of Spinner component.|attribute, static value, bindable|Spinner|

## Sample 1: Basic Spinners

The `Spinner` control has the `Type` property which you can use to set the color of the component.

The size of the control can be configured via `Size` property.

```DOTHTML
<bs:Spinner />
<bs:Spinner Type="Success" />
<bs:Spinner Size="Small"/>
```

## Sample 2: Visual style

The design of the spinner can be modified by `VisualStyle` property.

```DOTHTML
<bs:Spinner />
<bs:Spinner VisualStyle="Grow" />
```

## Sample 3: Screen reader only text

The `Spinner` component can generate an alternate text for screen readers.  
The default text is "Loading...".

The text can be changed using `ScreenReaderOnlyText` property.

```DOTHTML
<bs:Spinner ScreenReaderOnlyText="Processing" />
```

