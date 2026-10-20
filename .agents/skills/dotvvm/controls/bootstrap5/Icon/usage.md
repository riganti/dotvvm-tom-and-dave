# <dot:Icon>
Renders a Bootstrap Icon.

<https://icons.getbootstrap.com/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Type`|([Icons](../_enums/DotVVM.Bootstrap5.Controls.Icons.md))|Gets or sets the used icon.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The `Icon` control has the `Type` property which determines used icon.


```DOTHTML
<bs:Icon Type="check" />
```

## Sample 2: Button with Icon

The `Icon` control can be used together with the `Button` controls and because `Type` property is a data binding, icon can be changes after some operation is finished.


```DOTHTML
<bs:Button Click="{command: ChangeIcon(); }">
  <bs:Icon Type="{value: PostbackIcon}" />
  {{value: ButtonText}}
</bs:Button>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public Icons PostbackIcon { get; set; } = Icons.Clipboard;

    public string ButtonText { get; set; } = "Copy to clipboard";
    public void ChangeIcon()
    {
        if (PostbackIcon == Icons.Clipboard)
        {
            PostbackIcon = Icons.Check;
        }

        ButtonText = "Copied!";
    }
}
```

