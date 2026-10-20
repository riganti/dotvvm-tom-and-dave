# <dot:ProgressBar>
Renders Bootstrap Progress Bar widget.

<https://getbootstrap.com/docs/5.2/components/progress/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([BootstrapColor](../_enums/DotVVM.Bootstrap5.BootstrapColor.md))|Gets or sets the color of the control.|attribute, static value, bindable|Primary|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HiddenTemplate`|ITemplate|Gets or sets additional hidden information of the progress bar.|inner element, static value, default property||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Value`|Double|Gets or sets the percentage value (0-100) indicating the current progress.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ProgressBarVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ProgressBarVisualStyle.md))|Gets or sets whether the progress bar has solid fill, stripes or animated stripes.|attribute, static value, bindable|Solid|

## Sample 1: Basic Progress Bar

The `ProgressBar` control has the `Value` property that sets value between 0 and 100.
Contextual color of `ProgressBar` can be set with `Color` property.

To show `ProgressBar` custom text or label, place it inside the control. Default label is blank.

It is also possible to have hidden label in progress bar with `HiddenTemplate` element. This content is wrapped in `sr-only` CSS class to be read by screen readers.

```DOTHTML
<bs:ProgressBar Value="25">
  25% completed...
</bs:ProgressBar>

<bs:ProgressBar Color="Info" Value="85">
  <HiddenTemplate>
    69% completed...
  </HiddenTemplate>
</bs:ProgressBar>

```

## Sample 2: Striped and Animated Progress Bars

You can set `ProgressBar` to have various skins using the `VisualStyle` property - the options are `Solid`, `Striped` or `AnimatedStriped`.

```DOTHTML
<bs:ProgressBar Color="Danger" VisualStyle="Striped" Value="39">
  39%
</bs:ProgressBar>


<bs:ProgressBar Color="Success" VisualStyle="AnimatedStriped" Value="100">
  COMPLETED
</bs:ProgressBar>

```

## Sample 3: ProgressBar - Bindings

The `Value` and `Color` properties of `ProgressBar` are bindable.

```DOTHTML
  <bs:ProgressBar Value="{value: Width}" Color="{value: Color}">
    {{value: Width}}%
  </bs:ProgressBar>

<dot:Button Text="Change width" Click="{command: ChangeWidth()}" />
<dot:Button Text="Change color" Click="{command: ChangeColor()}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public double Width { get; set; } = 95;
    public BootstrapColor Color { get; set; } = BootstrapColor.Info;

    public void ChangeWidth()
    {
        var random = new Random();
        Width = random.Next(101);
    }

    public void ChangeColor()
    {
        var colors = Enum.GetValues(typeof(BootstrapColor)).Cast<BootstrapColor>().ToList();
        var random = new Random();
        var c = random.Next(colors.Count);
        Color = colors[c];
    }
}

```

