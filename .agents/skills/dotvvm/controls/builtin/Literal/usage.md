# <dot:Literal>
This control is used to render a text in the page. If you use the binding with double curly braces `{{value: Something}}`, it generates the *Literal* control.

If you set the `FormatString` property, you can apply a format string to numbers and date-time values. Most of .NET Framework format strings is supported.

By default, the *Literal* encodes the text, so you don't have to worry about the *script injection* attacks. 

If you want to render raw HTML content in the page, use [HtmlLiteral](~/controls/builtin/HtmlLiteral) control instead.

## Rendered output
In the [Client rendering mode](~/pages/concepts/server-side-rendering), the control renders a span with Knockout `data-bind` expression:

```DOTHTML
<span data-bind="text: expression"></span>
```

If you set the `RenderSpanElement` to *false*, the span won't be rendered. In this mode you cannot apply HTML attributes to the control and use some properties (e.g. `Visible`, `ID`).

```DOTHTML
<!-- ko text: expression --><!-- /ko -->
```



In the [Server rendering mode](~/pages/concepts/server-side-rendering), the text is rendered directly to the response. 
This helps the search engines to understand the page content.

```DOTHTML
<span data-bind="text: expression">Text</span>
```

If you turn the span element off, only the raw text will be rendered.

> From DotVVM 4.0, the Knockout data-bind expression is rendered even in the server-rendering mode so the text can reflect further updates of the property.

If you want the render just the text without the Knockout data-binding expression, use the [resource binding](~/pages/concepts/data-binding/resource-binding). This will behave the same way as using hard-coded value in the markup.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FormatString`|String|Gets or sets the format string that will be applied to numeric or date-time values.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RenderSpanElement`|Boolean|Gets or sets whether the literal should render the wrapper span HTML element.|attribute, static value|True|
|`Text`|Object|Gets or sets the text displayed in the control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Literal

Use the `Text` property to supply the value to be rendered.

If the value is a number or a DateTime, you can set the `FormatString` property to specify the format of the value.
Make sure that the correct culture is set on the server side. See the [Globalization](/docs/tutorials/basics-globalization) tutorial.


```DOTHTML
<dot:Literal Text="{value: Text}" />

<dot:Literal Text="{value: Date}" FormatString="d.M.yyyy H:mm:ss" />
```

```CSHARP
using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Literal.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text => "Hello DotVVM";

        public DateTime Date => DateTime.Now;
    }
}
```

## Sample 2: Disabling the SPAN element

Sometimes you just need to render the text itself without any wrapper element. You can use the `RenderSpanElement` property
to disable rendering the `<span>` element around the text.

Please keep in mind that if you disable the *span* element, you won't be able to add HTML attributes to the `Literal` (e.g. class, style)
and you won't be able to set the `Visible` property because there is no element on which this properties could be applied.

```DOTHTML
<dot:Literal Text="{value: Text}" RenderSpanElement="false" />
```

```CSHARP
using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Literal.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text => "Hello DotVVM";

        public DateTime Date => DateTime.Now;
    }
}
```

