# <dot:Button>
Extends the built-in [Button](~/controls/builtin/Button) control to allow applying Bootstrap CSS classes to the button and sizes.

<https://getbootstrap.com/docs/5.2/components/buttons/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonTagName`|([ButtonTagName](../../builtin/_enums/DotVVM.Framework.Controls.ButtonTagName.md))|Gets or sets whether the control should render the input or the button tag in the HTML.|attribute, static value|button|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a button disabled state.|attribute, static value, bindable|True|
|`FontType`|([ButtonTextColor](../_enums/DotVVM.Bootstrap5.ButtonTextColor.md))|Gets or sets the button font color.|attribute, static value, bindable|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsSubmitButton`|Boolean|Gets or sets whether the control should render a submit button or a normal button (type="submit" or type="button"). The submit button has some special features in the browsers, e.g. handles the Return key in HTML forms etc.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the button size. Possible values are `Small` `Default` and `Large`.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Type`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the button type.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets the button visual style. Possible values are `SolidFill` and `Outline`.|attribute, static value|SolidFill|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when the button is clicked.|

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
<bs:Button Click="{command: DoSomething()}" 
           Text="Primary" 
           Type="Primary" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Secondary" 
           Type="Secondary" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Success" 
           Type="Success" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Danger" 
           Type="Danger" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Warning" 
           Type="Warning" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Info" 
           Type="Info" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Light" 
           Type="Light" />

<bs:Button Click="{command: DoSomething()}" 
           Text="Dark" 
           Type="Dark" />

<bs:Button Click="{command: DoSomething()}" 
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

## Sample 3: Button Shapes

The `VisualStyle` property allows to switch between buttons with solid fill and outline buttons.


```DOTHTML
<bs:Button Click="{command: DoSomething()}" 
           Text="Solid Fill" 
           Type="Primary" 
           VisualStyle="SolidFill" />

<bs:Button Click="{command: DoSomething()}" 
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

## Sample 5: FontType

The `FontType` property specifies the color of the text inside of the button (using standard Bootstrap classes).


```DOTHTML
<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Primary" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Secondary" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Success" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Danger" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Warning" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Info" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Dark" 
           FontType="Light" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Dark" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Dark" 
           FontType="White" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Dark" 
           FontType="Muted" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Dark" 
           FontType="WhiteOpacity" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="BlackOpacity" 
           Text="Text"  />

<bs:Button Click="{command: DoSomething()}" 
           Type="Light" 
           FontType="Body" 
           Text="Text"  />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public void DoSomething()
    {
    }
}
```

