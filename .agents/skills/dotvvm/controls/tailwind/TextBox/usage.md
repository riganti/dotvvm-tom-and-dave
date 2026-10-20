# <t:TextBox>
The Tailwind `TextBox` uses the same API as the built-in [TextBox](~/controls/builtin/TextBox) and only adds Tailwind styling. Use `TextBoxFormField` when you need a label and validation message inside a Tailwind form.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`SelectAllOnFocus`|Boolean|Gets or sets whether all text inside the TextBox becomes selected when the element gets focused.|attribute, static value, bindable|False|
|`Text`|Object|Gets or sets the text in the control.|attribute, static value, bindable||
|`Type`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))|Gets or sets the mode of the text field (input/textarea and its type attribute)|attribute, static value|Normal|
|`UpdateTextOnInput`|Boolean|Gets or sets whether the viewmodel property will be updated immediately after change.              By default, the viewmodel is updated after the control loses its focus.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the onchange event is fired.|
|`TextInput`|Command|Gets or sets the command that will be triggered when the user is typing in the field.             Be careful when using this event - triggering frequent postbacks can make bad user experience. Consider using static commands or a throttling postback handler.|

## Sample 1: Styled TextBox

The Tailwind `TextBox` keeps the built-in `TextBox` API, so the [built-in TextBox documentation](~/controls/builtin/TextBox) covers the full feature set. This sample shows the styled wrapper with `Text`, `Placeholder`, `Type`, `Enabled`, and the `Changed` command.


```DOTHTML
<div class="space-y-3 max-w-md">
    <t:TextBox Text="{value: SearchText}"
               placeholder="Search the documentation"
               Changed="{command: IncrementChanges()}" />

    <t:TextBox Text="{value: Password}"
               Type="Password"
               placeholder="Password"
               Enabled="{value: PasswordEnabled}" />

    <t:CheckBox Text="Enable password field" Checked="{value: PasswordEnabled}" />
</div>

<p>Search text: <strong>{{value: SearchText}}</strong></p>
<p>Password length: <strong>{{value: Password.Length}}</strong></p>
<p><code>Changed</code> command count: <strong>{{value: ChangeCount}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.TextBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SearchText { get; set; } = "Tailwind";

        public string Password { get; set; } = "secret";

        public bool PasswordEnabled { get; set; } = true;

        public int ChangeCount { get; set; }

        public void IncrementChanges()
        {
            ChangeCount++;
        }
    }
}

```

