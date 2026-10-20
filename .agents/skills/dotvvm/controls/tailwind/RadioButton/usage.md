# <t:RadioButton>
The `RadioButton` control renders a Tailwind-styled radio input. Bind the selected value with `CheckedItem` and specify the option value with `CheckedValue`.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`CheckedItem`|IValueBinding|Binds the selected value for the radio group.|attribute, bindable||
|`CheckedValue`|Object|Specifies the value represented by this radio button.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets custom label content rendered next to the radio button. Cannot be combined with Text.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Controls whether the radio button can be interacted with.|attribute, static value, bindable|True|
|`GroupName`|String|Specifies the name attribute of the radio input, used to group radio buttons together.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the plain-text label rendered next to the radio button. Cannot be combined with Content.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Runs after the selected value changes.|

## Sample 1: Radio Group

Group radio buttons by binding them to the same `CheckedItem`. This sample also shows `GroupName`, custom content, `Enabled`, and the `Changed` command.


```DOTHTML
<div class="space-y-2">
    <t:RadioButton Text="Email"
                   CheckedValue="email"
                   CheckedItem="{value: ContactMethod}"
                   GroupName="contact-method"
                   Changed="{command: IncrementChanges()}" />

    <t:RadioButton Text="Phone"
                   CheckedValue="phone"
                   CheckedItem="{value: ContactMethod}"
                   GroupName="contact-method" />

    <t:RadioButton CheckedValue="chat"
                   CheckedItem="{value: ContactMethod}"
                   GroupName="contact-method">
        <span>Team chat <strong>(recommended)</strong></span>
    </t:RadioButton>

    <t:RadioButton Text="Disabled option"
                   CheckedValue="mail"
                   CheckedItem="{value: ContactMethod}"
                   GroupName="contact-method"
                   Enabled="false" />
</div>

<p>Selected contact method: <strong>{{value: ContactMethod}}</strong></p>
<p><code>Changed</code> command count: <strong>{{value: ChangeCount}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.RadioButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ContactMethod { get; set; } = "email";

        public int ChangeCount { get; set; }

        public void IncrementChanges()
        {
            ChangeCount++;
        }
    }
}

```

