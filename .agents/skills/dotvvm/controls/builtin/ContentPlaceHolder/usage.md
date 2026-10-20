# <dot:ContentPlaceHolder>
Represents a placeholder in the master page that contains the Content from the content page.

See [Master Pages](~/pages/concepts/layout/master-pages) tutorial for more information.

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

## Sample 1 : Example on Master Page

The *ContentPlaceHolder* has the `ID` property which identifies the corresponding *Content* in the content page.

You can specify a default content for a *ContentPlaceHolder*. This default content is used when there is no *Content* with the corresponding ID
in the content page. If the *Content* is present in the content page, it is rendered instead of the the default content.

```DOTHTML
@viewModel object

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <meta charset="utf-8" />
    <title></title>
  </head>
  <body>

    <h1>My Awesome App</h1>
	  
    <dot:ContentPlaceHolder ID="Menu">
      <!-- This default content can be overridden in the content page. -->
	  <menu>
		<li><a href="#">Page 1</a></li>
		<li><a href="#">Page 2</a></li>
		<li><a href="#">Page 3</a></li>
		<li><a href="#">Page 4</a></li>
		<li><a href="#">Page 5</a></li>
	  </menu>
    </dot:ContentPlaceHolder>

    <dot:ContentPlaceHolder ID="Content">
      <!-- Content from page.dothtml with id Main will be placed here. -->
    </dot:ContentPlaceHolder>

  </body>
</html>

```

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.Content.sample2.ViewModel, DotvvmWeb
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Content">
	<h3>Welcome! {{value: WelcomeMessage}}</h3>
	<p>Content of the page</p>
</dot:Content>

<dot:Content ContentPlaceHolderID="Menu">
	<!-- This overrides the default content from the master page. -->
	There is no menu available on this page.
</dot:Content>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ContentPlaceHolder.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string WelcomeMessage { get; set; } = "DotVVM ContentPlaceHolder sample.";
    }
}

```

