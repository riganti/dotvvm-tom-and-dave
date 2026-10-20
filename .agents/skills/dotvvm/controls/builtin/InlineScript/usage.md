# <dot:InlineScript>
Renders a script that is executed when the DotVVM framework is loaded.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Dependencies`|String[]|Gets or sets the comma-separated list of resources that should be loaded before this script is executed.|attribute, static value|System.String[]|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Script`|String||inner element, static value, default property||

## Sample 1: Basic InlineScript

The content of the InlineScript control is rendered as javascript in the page.

The framework adds a global object **dotvvm** which can be used to access client-side features.
You can use the following events fired by the framework.

* **init**: Executed when the DotVVM scripts and all required resources are loaded and the viewmodel is applied to the page.
* **beforePostback**: Executed before the postback is sent to the server.
* **afterPostback**: Executed after the postback response is received from the server.
* **error**: Executed when the postback fails due to a some error on a server.
* **spaNavigating**: Executed when you leave some page in the SPA container.
* **spaNavigated**: Executed when you enter some page in the SPA container.



```DOTHTML
<dot:InlineScript>
  dotvvm.events.init.subscribe(function() { alert("Page loaded"); });
</dot:InlineScript>
```

## Sample 2: Custom Error Handler

If the postback fails, you can invoke your custom code - e.g. display a message to the user.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.InlineScript.sample2.ViewModel, DotvvmWeb

<dot:Button Text="Sample Button" Click="{command: NeverEverRunThis()}" />

<!-- put inline script anywhere in the page -->
<dot:InlineScript>
	
	dotvvm.events.error.subscribe(function(args) {
		alert("Custom error handler!");
		args.handled = true;
	});
</dot:InlineScript>

```

```CSHARP
using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.InlineScript.sample2
{
    public class ViewModel
    {
        public void NeverEverRunThis()
        {
            throw new Exception("This method was called from View Model.");
        }

    }
}
```

