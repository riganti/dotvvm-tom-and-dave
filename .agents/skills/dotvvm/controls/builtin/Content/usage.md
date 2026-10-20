# <dot:Content>
Contains markup that will be placed inside the according ContentPlaceHolder in the master page.

See [Master Pages](~/pages/concepts/layout/master-pages) tutorial for more information.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentPlaceHolderID`|String|Gets or sets the ID of the ContentPlaceHolder control in the master page in which the content will be placed.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The *Content* control the `ContentPlaceHolderID` which contains the *ID* of the corresponding *ContentPlaceHolder* control in the master page.

```DOTHTML
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="TopMenu">
  Here is the CONTENT from this page with id TopMenu
</dot:Content>

<dot:Content ContentPlaceHolderID="Main">
  Here is the CONTENT from this page with id Main
</dot:Content>

```

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

    <div>
        <dot:ContentPlaceHolder ID="TopMenu">
            <!-- Content from page.dothtml with id TopMenu will be placed here. -->
        </dot:ContentPlaceHolder>
    </div>

    <div>
        <dot:ContentPlaceHolder ID="Main">
            <!-- Content from page.dothtml with id Main will be placed here. -->
        </dot:ContentPlaceHolder>
    </div>

</body>
</html>

```

## Sample 2: Viewmodel Inheritance

Typically, the viewmodel of the content page derives the viewmodel of the master page. Note that the viewmodel of the master page can be an interface.

Notice that the `PageViewModel` class derives from the `BaseViewModel`. Also, all properties referenced in bindings in the master page must be declared
in the `BaseViewModel` class.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.Content.sample2.PageViewModel, DotvvmWeb
@masterPage master.dotmaster

<dot:Content ContentPlaceHolderID="Content">

    <dot:Button Click="{command: Calculate()}" 
                Text="Button" />

    <p>Current value: {{value: CurrentValue}}</p>

</dot:Content>
```

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.Content.sample2.BaseViewModel, DotvvmWeb

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title></title>
</head>
<body>

    <h1>MasterPage sample</h1>

    <dot:Repeater DataSource="{value: MenuItems}" WrapperTagName="menu">
        <ItemTemplate>
            <li>{{value: _this}}</li>
        </ItemTemplate>
    </dot:Repeater>

	<div>
		<dot:ContentPlaceHolder ID="Content" />
	</div>

</body>
</html>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Content.sample2
{
    public class PageViewModel : BaseViewModel
    {
        public int CurrentValue { get; set; } = 0;

        public void Calculate()
        {
            CurrentValue++;
        }
    }
}

```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.builtin.Content.sample2
{
    public abstract class BaseViewModel
    {

        public string[] MenuItems { get; set; } = { "Index", "About" };

    }
}
```

