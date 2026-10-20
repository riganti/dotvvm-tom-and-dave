# <bp:TextBox>
Inherits the built-in [TextBox](~/controls/builtin/TextBox) control with a *DotVVM Business Pack* visual style.



## Rendered output
Depending on the `Type` property, the control renders either `<input>` or `<textarea>` element.

```DOTHTML
<input type="text" data-bind="..." />

<textarea data-bind="..."></textarea>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FormatString`|String||attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxLength`|String||attribute, static value, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`SelectAllOnFocus`|Boolean||attribute, static value, bindable|False|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|Object||attribute, static value, bindable||
|`Type`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))||attribute, static value|Normal|
|`UpdateTextOnInput`|Boolean||attribute, static value|False|
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||
|`TextInput`|Command||

## Sample 1: Binding Support

The TextBox control has the `Text` property which is used data-bind the value from the viewmodel.

```DOTHTML
<bp:TextBox Text="{value: Name}" />

<bp:TextBox Text="static text" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Name { get; set; } = "John Green";
    }
}
```

## Sample 2: TextBox Types

The `TextBox` control has the `Type` property which you can use to set up `Password`, `MultiLine` or other types of a text field. Default value is `Normal` which renders `type="text"` on `TextBox`.

```DOTHTML
<!-- normal textbox -->
<bp:TextBox Text="{value: Text}" Type="Normal" />

<!-- password textbox -->
<bp:TextBox Text="{value: Password}" Type="Password" />

<!-- textarea -->
<bp:TextBox Text="{value: Message}" Type="MultiLine" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "Simple Text";

        public string Password { get; set; } = "1234";

        public string Message { get; set; } = "Message with \n multiple lines.";
    }
}
```

## Sample 3: Changed Event and UpdateAfterKeydown

By default, if you type something in the TextBox, the value will be propagated in the viewmodel when the TextBox loses its focus.

However, sometimes you need to update the TextBox immediately. Therefore, the TextBox also has the `UpdateTextOnInput` which 
will propagate the value in the viewmodel after each key press.

The `Changed` event is triggered when the value of the control changes


```DOTHTML
<bp:TextBox Text="{value: Text}"
            UpdateTextOnInput="true"
            Changed="{command: TextToUpperCase()}" />

{{value: Text}}

```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "";

        public void TextToUpperCase()
        {
            Text = Text.ToUpper();
        }
    }
}
```

## Sample 4: TextBox Enabled with CheckBox

`TextBox` has `Enabled` property for setting if `TextBox` input is enabled. You can bind and switch it for example with [CheckBox](~/controls/businesspack/CheckBox).

```DOTHTML
<p>
    <bp:CheckBox Checked="{value: IsCompany}"
                 Text="The customer is a company." />
</p>

<p>
    Company Number:
    <bp:TextBox Text="{value: CompanyNumber}"
                Enabled="{value: IsCompany}" />
</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TextBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCompany { get; set; }

        public string CompanyNumber { get; set; } = "";
    }
}
```

