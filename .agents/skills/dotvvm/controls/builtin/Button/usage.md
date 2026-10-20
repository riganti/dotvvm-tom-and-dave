# <dot:Button>
This control renders HTML button which is able to trigger a postback.

## Rendered output
Depending on the `ButtonTagName` property, the control renders one of these HTML elements:

```DOTHTML
<input type="submit" onclick="dotvvm.postBack(...);" value="Text" />
```

```DOTHTML
<button type="submit" onclick="dotvvm.postBack(...);">
	Text
</button>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonTagName`|([ButtonTagName](../_enums/DotVVM.Framework.Controls.ButtonTagName.md))|Gets or sets whether the control should render the <input> or the <button> tag in the HTML.|attribute, static value|input|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the button is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsSubmitButton`|Boolean|Gets or sets whether the control should render a submit button or a normal button (type="submit" or type="button").             The submit button has some special features in the browsers, e.g. handles the Return key in HTML forms etc.|attribute, static value|False|
|`Text`|String|Gets or sets the text on the button.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

## Sample 1: Basic Usage

The Button control has a `Text` property that holds the text displayed in the button.

In the `Click` event you can specify which method will be called in the viewmodel.

```DOTHTML
<dot:Button Click="{command: Calculate()}" Text="Sample Button" />

<dot:Literal Text="{value: CurrentValue}"></dot:Literal>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CurrentValue { get; set; } = 0;

        public void Calculate()
        {
            CurrentValue++;
        }

    }
}
```

## Sample 2: Disable or Hide the Button

To disable or enable the button, use the `Enabled` property. It supports the data-binding.

It's also possible to hide the button completely by using the `Visible` property.

```DOTHTML
<dot:Button Click="{command: SetVisible()}" Text="Button" Enabled="{value: Enabled}"/>

<dot:Button Click="{command: SetEnabled()}" Text="Invisible Button" Visible="{value: Visible}"/>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {

        public bool Enabled { get; set; } = true;

        public bool Visible { get; set; } = false;

        public void SetEnabled()
        {
            Enabled = true;
            Visible = false;
        }

        public void SetVisible()
        {
            Visible = true;
            Enabled = false;
        }

    }

}
```

## Sample 3: Button Types

The Button control has the `ButtonTagName` property which specifies the tag rendered by the button.  
Pass either **input** (*<input ... />*) or **button** (*<button ... />*) values.

You can also choose whether it is a submit button or a normal button using the `IsSubmitButton` property.

```DOTHTML
<dot:Button Click="{command: Calculate()}" Text="Button with Input tag" ButtonTagName="input"/>

<dot:Button Click="{command: ShowMessage()}" Text="Submit Button" IsSubmitButton="true"/>

<dot:Literal Text="{value: Message}"/>

<dot:Literal Text="Current value: "></dot:Literal><dot:Literal Text="{value: CurrentValue}"/>

<dot:Literal Text="Submitted value: "></dot:Literal><dot:Literal Text="{value: SubmittedValue}"/>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SubmittedValue { get; set; } = 0;
        public int CurrentValue { get; set; } = 0;

        public string Message { get; set; } = "";

        public void Calculate()
        {
            CurrentValue++;
            Message = "";
        }

        public void ShowMessage()
        {
            Message = "Value submitted.";
            SubmittedValue = CurrentValue;
        }

    }
}
```

## Sample 4: Image in the Button

The `<button>` tag supports more than just a text in the button. Instead of using the `Text` property, you can put the content inside the button.


```DOTHTML
<dot:Button ButtonTagName="button" Click="{command: Click()}">
    <img src="~/images/delete.png" alt="Delete" />
    Delete
</dot:Button>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        
        public void Click()
        {
        }
        
    }
}
```

## Sample 5: Async commands

All DotVVM controls support async methods in [command bindings](~/pages/concepts/respond-to-user-actions/commands).

> You should always use `async Task` instead of `async void` - it would probably end with an exception. 


```DOTHTML
<dot:Button Click="{command: Calculate()}" Text="Sample Button" />

<dot:Literal Text="{value: CurrentValue}"></dot:Literal>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Button.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CurrentValue { get; set; } = 0;

        public async Task Calculate()
        {
            CurrentValue++;
        }

    }
}
```

