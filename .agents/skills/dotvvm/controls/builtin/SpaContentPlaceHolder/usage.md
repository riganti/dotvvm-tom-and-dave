# <dot:SpaContentPlaceHolder>
Container which can host a single page application.

To get better understanding how SPAs work, look at the [SPA tutorial](~/pages/concepts/layout/master-pages).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: Simple SPA

A simple example of the SPA.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1.BaseViewModel, DotvvmWeb
<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>
	
     <menu>
        <li>
          <dot:RouteLink RouteName="SampleA" Text="TextBox sample" />
        </li>
        <li>
          <dot:RouteLink RouteName="SampleB" Text="Literal sample" />
        </li>
    </menu>

    <dot:SpaContentPlaceHolder ID="Sample" />

</body>
</html>
```

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1.ViewModelA, DotvvmWeb
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Sample">
  <dot:TextBox Text="{value: FirstName}" />
</dot:Content>
```

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1.ViewModelB, DotvvmWeb
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Sample">
  {{value: Text}}
</dot:Content>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.Configuration;

namespace DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1
{
    public class Startup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("SampleA", "SampleA", "SampleA.dothtml", null);
            config.RouteTable.Add("SampleB", "SampleB/{Id}", "SampleB.dothtml", null);
        }
    }
}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1
{
    public class ViewModelA : BaseViewModel
    {

        public string FirstName { get; set; } = "Tomas";

    }
}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1
{
    public class ViewModelB : BaseViewModel
    {

        public string Text { get; set; } = "Test value";

    }
}
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.SpaContentPlaceHolder.sample1
{
    public abstract class BaseViewModel : DotvvmViewModelBase
    {
        
    }
}
```

