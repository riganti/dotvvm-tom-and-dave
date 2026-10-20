# <t:CheckBox>
The `CheckBox` control renders a Tailwind-styled checkbox. It supports both a single boolean value through `Checked` and multi-select scenarios with `CheckedItems` and `CheckedValue`.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Checked`|IValueBinding<Boolean>|Binds whether the checkbox is selected in single-value mode.|attribute, bindable||
|`CheckedItems`|IValueBinding<IEnumerable>|Binds the collection used in multi-select checkbox scenarios.|attribute, bindable||
|`CheckedValue`|Object|Specifies the value added to or removed from the CheckedItems collection.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets custom label content rendered next to the checkbox. Cannot be combined with Text.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Controls whether the checkbox can be interacted with.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the plain-text label rendered next to the checkbox. Cannot be combined with Content.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Runs after the checked state changes.|

## Sample 1: Boolean Binding

Use the `Checked` property for a single boolean value. The control also supports `Text`, custom inner content, `Enabled`, and the `Changed` command.


```DOTHTML
<div class="space-y-3">
    <t:CheckBox Text="Receive product updates"
                Checked="{value: ReceiveUpdates}"
                Changed="{command: IncrementChanges()}" />

    <t:CheckBox Checked="{value: AcceptTerms}">
        <span>I accept the <strong>terms and conditions</strong>.</span>
    </t:CheckBox>

    <t:CheckBox Text="Locked option"
                Checked="{value: LockedOption}"
                Enabled="false" />
</div>

<p>Receive updates: <strong>{{value: ReceiveUpdates}}</strong></p>
<p>Terms accepted: <strong>{{value: AcceptTerms}}</strong></p>
<p><code>Changed</code> command count: <strong>{{value: ChangeCount}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.CheckBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool ReceiveUpdates { get; set; }

        public bool AcceptTerms { get; set; }

        public bool LockedOption { get; set; } = true;

        public int ChangeCount { get; set; }

        public void IncrementChanges()
        {
            ChangeCount++;
        }
    }
}

```

## Sample 2: CheckedItems Collection

Use `CheckedItems` together with `CheckedValue` when multiple checkboxes should add and remove values in a collection.


```DOTHTML
<div class="space-y-2">
    <t:CheckBox Text="Apple" CheckedItems="{value: SelectedFruits}" CheckedValue="apple" />
    <t:CheckBox Text="Banana" CheckedItems="{value: SelectedFruits}" CheckedValue="banana" />
    <t:CheckBox Text="Cherry" CheckedItems="{value: SelectedFruits}" CheckedValue="cherry" />
</div>

<p>Selected fruits:
    <strong>{{value: SelectedFruits.Count == 0 ? "(none)" : string.Join(", ", SelectedFruits)}}</strong>
</p>

```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.CheckBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> SelectedFruits { get; set; } = new() { "banana" };
    }
}

```

