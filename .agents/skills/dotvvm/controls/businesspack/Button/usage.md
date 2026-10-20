# <bp:Button>
Inherits the built-in [Button](~/controls/builtin/Button) control with a *DotVVM Business Pack* visual style.

## Rendered output
Depending on the `ButtonTagName` property, the control renders one of these HTML elements:

```DOTHTML
<input type="submit" value="Text" />
```

```DOTHTML
<button type="submit">Text</button>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ButtonTagName`|([ButtonTagName](../../builtin/_enums/DotVVM.Framework.Controls.ButtonTagName.md))||attribute, static value|button|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DisableContentStyle`|Boolean||attribute, static value, bindable|False|
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsSubmitButton`|Boolean||attribute, static value|False|
|`Outline`|Boolean||attribute, static value, bindable|False|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|String||attribute, static value, bindable||
|`Type`|ButtonType||attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command||

## Sample 1: Basic Usage

The `Button` control has the `Text` property that specifies the text displayed on the button.

Using the `Click` event, you can specify which method in the viewmodel will be called when the button is clicked.

```DOTHTML
<bp:Button Text="Click me!"
           Click="{command: Click()}" />

<p>Clicks count: {{value: ClicksCount}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Button.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int ClicksCount { get; set; }

        public void Click()
        {
            ClicksCount++;
        }
    }
}
```

## Sample 2: Disable or Hide the Button

To disable or enable the button, use the `Enabled` property. 

It's also possible to hide the button completely by using the `Visible` property.

```DOTHTML
<p>Show button is enabled only when Hide button is visible.</p>

<bp:Button Text="Show Button"
           Enabled="{value: IsEnabled}"
           Click="{command: ShowButton()}" />

<bp:Button Text="Hide Button"
           Visible="{value: IsVisible}"
           Click="{command: HideButton()}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Button.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEnabled { get; set; }
        public bool IsVisible { get; set; } = true;

        public void ShowButton()
        {
            IsEnabled = false;
            IsVisible = true;
        }

        public void HideButton()
        {
            IsVisible = false;
            IsEnabled = true;
        }
    }
}
```

## Sample 3: Button Types

The `Button` control has the `ButtonTagName` property which specifies the tag rendered by the button. You can also choose whether it is a submit button or a normal button using the `IsSubmitButton` property.

The `Type` of the button can be set to `Primary`, `Secondary`, `Success`, `Info`, `Warning` and `Danger`. It will change the color and visual style.

```DOTHTML
<bp:Button Text="Button"
           ButtonTagName="button"
           Type="Info" />

<br />

<bp:Button Text="Input Button"
           ButtonTagName="input" />

<br />

<bp:Button Text="Submit Button"
           IsSubmitButton="true"
           Type="Primary" />
```

## Sample 4: Image in the Button

The `<button>` tag supports more than just a text in the button. Instead of using the `Text` property, you can put the content inside the element.


```DOTHTML
<bp:Button ButtonTagName="button">
    <bp:Icon Icon="Star"></bp:Icon>   
    <span>Custom Button with Icon<span/>
</bp:Button>
```

