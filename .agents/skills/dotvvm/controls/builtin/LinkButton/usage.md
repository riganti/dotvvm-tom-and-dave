# <dot:LinkButton>
Renders the hyperlink which behaves like a button.

## Rendered output
The control renders a hyperlink:

```DOTHTML
<a href="#" onclick="...">Text or inner content</a>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the button is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Text`|String|Gets or sets the text on the button.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

## Sample 1: Basic LinkButton

The *LinkButton* control can use the `Text` property or the inner content to specify what's inside.

The `Click` event specifies, which method in the viewmodel will be triggered.

```DOTHTML
<dot:LinkButton Click="{command: DoSomething()}" Text="Simple Link Button" />

<dot:LinkButton Click="{command: DeleteSomething()}">
  <img src="~/images/delete.png" /> Delete
</dot:LinkButton>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.LinkButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public void DoSomething()
        {
            // do what you have to do
        }

        public void DeleteSomething()
        {
            // do what you have to do
        }
    }
}
```

## Sample 2: Disable or Hide the LinkButton

To disable or enable the button, use the `Enabled` property. It supports the data-binding.

It's also possible to hide the button completely by using the `Visible` property.

```DOTHTML
<dot:LinkButton Click="{command: Switch()}" Text="Switch"/>

<dot:LinkButton Click="{command: DoSomething()}" Text="Link Button with Enabled binding" Enabled="{value: Enabled}"/>

<dot:LinkButton Click="{command: DoSomething()}" Text="Link Button with Visible binding" Visible="{value: Enabled}"/>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.LinkButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Enabled { get; set; } = true;

        public void Switch()
        {
            Enabled = !Enabled;
        }

        public void DoSomething()
        {
            
        }

    }
}
```

