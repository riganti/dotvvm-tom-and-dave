# <t:ProcessTimeline>
Displays a step-by-step progress indicator. Use `CurrentStep` on `ProcessTimeline` and define each step with `ProcessTimelineStep`.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CurrentStep`|Int32|The 1-based index of the currently active step. Steps up to and including this value are highlighted.|attribute, static value, bindable|0|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Steps`|List<ProcessTimelineStep>|The list of  child controls defining each step.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Bindable current step

Shows `CurrentStep` bound to the viewmodel and step labels provided through the `Text` property.


```DOTHTML
<t:ProcessTimeline CurrentStep="{value: CurrentStep}">
    <t:ProcessTimelineStep Text="Choose source" Step="1" />
    <t:ProcessTimelineStep Text="Review details" Step="2" />
    <t:ProcessTimelineStep Text="Confirm changes" Step="3" />
    <t:ProcessTimelineStep Text="Complete" Step="4" />
</t:ProcessTimeline>

<div class="flex gap-2 mt-4">
    <t:Button Type="Default" Text="Previous" Click="{command: Previous()}" />
    <t:Button Type="Primary" Text="Next" Click="{command: Next()}" />
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ProcessTimeline.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CurrentStep { get; set; } = 2;

        public void Previous()
        {
            if (CurrentStep > 1)
            {
                CurrentStep--;
            }
        }

        public void Next()
        {
            if (CurrentStep < 4)
            {
                CurrentStep++;
            }
        }
    }
}

```

## Sample 2: Custom step content

Places rich markup directly inside `ProcessTimelineStep`, which fills the step template region.


```DOTHTML
<t:ProcessTimeline CurrentStep="2">
    <t:ProcessTimelineStep Step="1">
        <span><strong>Import</strong><br /><small>Finished</small></span>
    </t:ProcessTimelineStep>
    <t:ProcessTimelineStep Step="2">
        <span><strong>Validate</strong><br /><small>In progress</small></span>
    </t:ProcessTimelineStep>
    <t:ProcessTimelineStep Step="3">
        <span><strong>Publish</strong><br /><small>Pending</small></span>
    </t:ProcessTimelineStep>
</t:ProcessTimeline>

```

