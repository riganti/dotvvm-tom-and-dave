# <dot:HtmlLiteral>
This control is used to render raw HTML content in the page. 

> Be very careful when using this control. If you allow users to enter HTML into your application and then you render this HTML,
it can make your application vulnerable. Always make sure that the HTML you pass in this control is safe and doesn't contain
any scripts because the browser would have run them.

If you want to render a text in the page, use the [Literal](~/controls/builtin/Literal) control instead.


## Rendered output
By default, the control renders a `<div>` element which will contain the specified HTML. 
You can change it to any other tag name using the `WrapperTagName` property.

```DOTHTML
<div data-bind="html: expression"></div>
```

If you set the `RenderWrapperTag` to *false*, only the pure HTML content will be rendered. However, removing the wrapper tag
is supported only in the [Server rendering mode](/docs/tutorials/basics-server-side-html-generation).


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Html`|String|Gets or sets the HTML that will be rendered in the control.|attribute, static value, bindable, default property||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: Basic HtmlLiteral

Use the `Html` property to supply the raw HTML to be rendered.


```DOTHTML
<dot:HtmlLiteral Html="{value: Html}" />

```

```CSHARP
using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.HtmlLiteral.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Html => "Hello <strong>DotVVM</strong>";
    }
}
```

