# <bs:ProgressBar>
Renders Bootstrap Progress Bar widget.

<https://getbootstrap.com/docs/3.3/components/#progress>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([ContextualColor](../_enums/DotVVM.Framework.Controls.Bootstrap.ContextualColor.md))|Gets or sets contextual color.|attribute, static value, bindable|Default|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HiddenTemplate`|ITemplate|Gets or sets additional hidden information of progress bar.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsAnimated`|Boolean|Gets or sets if progress bar is animated.|attribute, static value, bindable|False|
|`IsStriped`|Boolean|Gets or sets if progress bar is striped.|attribute, static value, bindable|False|
|`Value`|Double|Gets or sets value of current progress.|attribute, static value, bindable|100|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Progress Bar

The `ProgressBar` control has `Value` property that sets value of current progress.
Contextual color of `ProgressBar` can be set with `Color` property.

To show `ProgressBar` custom text or label, place it inside the control. Default label is blank.

It is also possible to have hidden label in progress bar with `HiddenTemplate` element.

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

You can set `ProgressBar` to have striped design with `IsStriped` property.

Is is also possible to animate `ProgressBar` with `IsAnimated` property.

```DOTHTML
<bs:ProgressBar Color="Danger" IsStriped="true" Value="39">
  39%
</bs:ProgressBar>


<bs:ProgressBar Color="Success" IsStriped="true" IsAnimated="true" Value="100">
  COMPLETED
</bs:ProgressBar>

```

## Sample 3: Stacked Progress Bar

You can create Bootstrap stacked `ProgressBars` using [StackedProgressBar](~/controls/bootstrap/StackedProgressBar) control.

```DOTHTML
<bs:StackedProgressBar>
  <bs:ProgressBar Color="Success" Value="25">
    25%
  </bs:ProgressBar>

  <bs:ProgressBar Color="Info" Value="25">
    25%
  </bs:ProgressBar>

  <bs:ProgressBar Color="Warning" Value="11">
    11%
  </bs:ProgressBar>

  <bs:ProgressBar Color="Danger" Value="14">
    14%
  </bs:ProgressBar>
</bs:StackedProgressBar>
```

## Sample 4: ProgressBar - Bindings

All properties in `ProgressBar` are bindable.

```DOTHTML
  <bs:ProgressBar Value="{value: Width}" Color="{value: Color}" IsStriped="{value: Striped}" IsAnimated="{value: Animated}">
  </bs:ProgressBar>

<dot:Button Text="Change width" Click="{command: ChangeWidth()}" />
<dot:Button Text="Change color" Click="{command: ChangeColor()}" />
<dot:Button Text="Change striped" Click="{command: ChangeStriped()}" />
<dot:Button Text="Change animated" Click="{command: ChangeAnimated()}" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ProgressBar.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Width { get; set; } = 95;
        public ContextualColor Color { get; set; } = ContextualColor.Info;
        public bool Striped { get; set; } = true;
        public bool Animated { get; set; } = true;

        public void ChangeWidth()
        {
            var random = new Random();
            Width = random.Next(101);
        }

        public void ChangeColor()
        {
            var colors = Enum.GetValues(typeof(ContextualColor)).Cast<ContextualColor>().ToList(); ;
            var random = new Random();
            var c = random.Next(colors.Count);
            Color = colors[c];
        }

        public void ChangeStriped()
        {
            Striped = !Striped;
        }

        public void ChangeAnimated()
        {
            Animated = !Animated;
        }
    }
}

```

