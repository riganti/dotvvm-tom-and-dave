# <bs:Button>
Extends the builtin [Button](~/controls/builtin/Button) control to allow applying Bootstrap CSS classes to the button and sizes.

<https://getbootstrap.com/docs/3.3/css/#buttons>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonTagName`|([ButtonTagName](../../builtin/_enums/DotVVM.Framework.Controls.ButtonTagName.md))|Gets or sets whether the control should render the <input> or the <button> tag in the HTML.|attribute, static value|input|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the button is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsSubmitButton`|Boolean|Gets or sets whether the control should render a submit button or a normal button (type="submit" or type="button").             The submit button has some special features in the browsers, e.g. handles the Return key in HTML forms etc.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap.Size.md))|Gets or sets the size of the button.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the text on the button.|attribute, static value, bindable||
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the color of the button.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

## Sample 1: Button Sizing

Use the `Size` property to set the size of the button.

```DOTHTML
<bs:Button Click="{command: DoSomething()}" 
           Text="Button" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Button" 
           Size="Large" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Button" 
           Size="Small" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Button" 
           Size="ExtraSmall" />

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Button.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {

        public void DoSomething()
        {
        }
    }
}
```

## Sample 2: Button Types

The `Type` property specifies the color of the button (using standard Bootstrap classes).  


```DOTHTML
<bs:Button Click="{command: DoSomething()}"
           Text="Default"
           Type="Default" />

<bs:Button Click="{command: DoSomething()}"
           Text="Primary"
           Type="Primary" />

<bs:Button Click="{command: DoSomething()}"
           Text="Success"
           Type="Success" />
<bs:Button Click="{command: DoSomething()}"
           Text="Info"
           Type="Info" />

<bs:Button Click="{command: DoSomething()}"
           Text="Warning"
           Type="Warning" />

<bs:Button Click="{command: DoSomething()}"
           Text="Danger"
           Type="Danger" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Button.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {

        public void DoSomething()
        {
        }
    }
}
```

