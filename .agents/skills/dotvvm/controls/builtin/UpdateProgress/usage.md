# <dot:UpdateProgress>
Container for content that will be displayed for the time the page is doing a postback.

## Rendered output
The content of the `UpdateProgress` is wrapped in the `<div>` element.

```DOTHTML
<div data-bind="..." style="display: none">
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Delay`|Int32|Gets or sets the delay (in ms) after which the content inside UpdateProgress control is shown|attribute, static value|0|
|`ExcludedQueues`|String[]|Gets or sets the comma-separated names of PostBack.ConcurrencyQueue names that should be ignored by this control.             If you don't want to exclude any queue, use an empty string.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludedQueues`|String[]|Gets or sets the comma-separated names of PostBack.ConcurrencyQueue names for which this control should be enabled.             If not set, all queues are included automatically.|attribute, static value||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: UpdateProgress

The content inside the `UpdateProgress` will appear when the user clicks the button. When the postback completes, the content will disappear.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.UpdateProgress.sample1.ViewModel, DotvvmWeb

<dot:Button Text="Perform difficult calculation" Click="{command: CalculateIt()}" />

<p>{{value: Result}}</p>

<dot:UpdateProgress>
	<h4>Calculating...</h4>
</dot:UpdateProgress>

```

```CSHARP
using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.UpdateProgress.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Result { get; set; }

        public void CalculateIt()
        {
            // the calculation is very complicated and it takes a lot of time to get the result
            Thread.Sleep(5000);

            var random = new Random(DateTime.Now.Millisecond);
            Result = random.Next();
        }

    }
}
```

## Sample 2: UpdateProgress with Delay

The `UpdateProgress` control has the `Delay` property which defines the delay (in milliseconds) after which the content inside the `UpdateProgress` will appear when the user clicks a button. If the postback is shorter than the delay, content inside the `UpdateProgress` will not appear.


```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.UpdateProgress.sample2.ViewModel, DotvvmWeb

<!-- the calculation is longer than 1000 ms so the content in UpdateProgress will appear after 1000 ms -->
<dot:Button Text="Perform long calculation" Click="{command: LongCalculation()}" />

<!-- the calculation is shorter than 1000 ms so the content in UpdateProgress will not appear -->
<dot:Button Text="Perform short calculation" Click="{command: ShortCalculation()}" />

<p>{{value: Result}}</p>

<dot:UpdateProgress Delay="1000">
	<h4>Calculating...</h4>
</dot:UpdateProgress>

```

```CSHARP
using System;
using System.Threading;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.UpdateProgress.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Result { get; set; }

        public void LongCalculation()
        {
            // the calculation is very complicated and it takes a lot of time to get the result
            Thread.Sleep(5000);

            var random = new Random(DateTime.Now.Millisecond);
            Result = random.Next();
        }

        public void ShortCalculation()
        {
            // the calculation is not very complicated and it takes less time to get the result
            Thread.Sleep(500);

            var random = new Random(DateTime.Now.Millisecond);
            Result = random.Next();
        }
    }
}

```

