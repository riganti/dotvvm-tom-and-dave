# <bs:LinkButton>
Extends the built-in [LinkButton](~/controls/builtin/LinkButton) control to allow applying Bootstrap CSS classes to the button and sizes.

<https://getbootstrap.com/docs/4.3/components/buttons/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the button is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsBlockButton`|Boolean|Gets or sets whether the button should be styled as a block element.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the button.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the text on the button.|attribute, static value, bindable||
|`Type`|([BootstrapButtonColor](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapButtonColor.md))|Gets or sets the color of the button.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.ButtonVisualStyle.md))|Gets or sets whether the button has solid fill, or whether it is only an outline.|attribute, static value, bindable|SolidFill|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

## Sample 1: Button Sizing

Use the `Size` property to set the size of the button.

```DOTHTML
<bs:LinkButton Click="{command: DoSomething()}" 
               Text="Button" />

<bs:LinkButton Click="{command: DoSomething()}" 
               Text="Button" 
               Size="Large" />

<bs:LinkButton Click="{command: DoSomething()}" 
               Text="Button" 
               Size="Small" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public void DoSomething()
    {
    }
}
```

## Sample 2: Button Types

The `Type` property specifies the color of the button (using standard Bootstrap classes).  


```DOTHTML
<bs:LinkButton Click="{command: DoSomething()}"
               Text="Primary"
               Type="Primary" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Secondary"
               Type="Secondary" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Success"
               Type="Success" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Danger"
               Type="Danger" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Warning"
               Type="Warning" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Info"
               Type="Info" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Light"
               Type="Light" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Dark"
               Type="Dark" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Link"
               Type="Link" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public void DoSomething()
    {
    }
}
```

## Sample 3: Button VisualStyle

The `VisualStyle` property allows to switch between buttons with solid fill and outline buttons.


```DOTHTML
<bs:LinkButton Click="{command: DoSomething()}"
               Text="Solid Fill"
               Type="Primary"
               VisualStyle="SolidFill" />

<bs:LinkButton Click="{command: DoSomething()}"
               Text="Outline"
               Type="Primary"
               VisualStyle="Outline" />

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public void DoSomething()
    {
    }
}
```

## Sample 4: Block Buttons

To make the button behave like a block element, use the `IsBlockButton` property.


```DOTHTML
<bs:LinkButton Click="{command: DoSomething()}"
               Text="Solid Fill"
               Type="Primary"
               IsBlockButton="true" />

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public void DoSomething()
    {
    }
}
```

