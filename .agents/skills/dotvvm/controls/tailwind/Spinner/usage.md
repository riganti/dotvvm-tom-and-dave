# <t:Spinner>
Displays an animated loading indicator. Use `AriaLabelText` to customize the screen-reader text.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AriaLabelText`|String|The text rendered inside the sr-only span for screen readers. Defaults to "Loading...".|attribute, static value|Loading...|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic and localized spinner

Shows the default spinner and a second spinner with a custom `AriaLabelText` value.


```DOTHTML
<div class="space-y-4">
    <div class="flex items-center gap-3">
        <t:Spinner />
        <span>Loading data...</span>
    </div>

    <div class="flex items-center gap-3">
        <t:Spinner AriaLabelText="Synchronizing dashboard widgets..." />
        <span>Custom accessible label</span>
    </div>
</div>

```

## Sample 2: Conditional visibility

Uses the standard `Visible` property to show and hide the spinner while a command toggles the loading state.


```DOTHTML
<div class="space-y-4">
    <div class="space-y-2">
        <t:Spinner Visible="{value: IsLoading}" />
        <p Visible="{value: IsLoading}" class="text-sm text-gray-500">Loading data...</p>
    </div>

    <t:Button Type="Primary" Text="Toggle loading" Click="{command: ToggleLoading()}" />
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Spinner.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsLoading { get; set; }

        public void ToggleLoading()
        {
            IsLoading = !IsLoading;
        }
    }
}

```

