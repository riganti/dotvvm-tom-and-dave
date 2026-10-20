# <dot:ColorPicker>
Renders a Bootstrap color picker.

<https://getbootstrap.com/docs/5.0/forms/form-control/#color>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|String|Gets or sets the color picker value.|attribute, static value, bindable||
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the color picker is enabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`RenderLabel`|Boolean|Gets or sets whether the label will be rendered. If set to null than the label will be rendered if needed.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the color picker.|attribute, static value, bindable||
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Title`|String|Gets or sets the title attribute of the color picker.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage in Form

The `Color` property can be used with data binding.


```DOTHTML
<bs:TextBox Text="{value: Color}" />

<bs:ColorPicker Title="Color picker" Color="{value: Color}" />

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Color { get; set; } = "#ff4444";
}
```

