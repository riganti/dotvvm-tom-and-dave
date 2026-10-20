# <dot:TextBox>
Renders a HTML text input control.

## Rendered output
Depending on the `Type` property, the control renders either `<input>` or `<textarea>` element.

```DOTHTML
<input type="text" data-bind="..." />

<textarea data-bind="..."></textarea>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`SelectAllOnFocus`|Boolean|Gets or sets whether all text inside the TextBox becomes selected when the element gets focused.|attribute, static value, bindable|False|
|`Text`|Object|Gets or sets the text in the control.|attribute, static value, bindable||
|`Type`|([TextBoxType](../_enums/DotVVM.Framework.Controls.TextBoxType.md))|Gets or sets the mode of the text field (input/textarea and its type attribute)|attribute, static value|Normal|
|`UpdateTextOnInput`|Boolean|Gets or sets whether the viewmodel property will be updated immediately after change.              By default, the viewmodel is updated after the control loses its focus.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the onchange event is fired.|
|`TextInput`|Command|Gets or sets the command that will be triggered when the user is typing in the field.             Be careful when using this event - triggering frequent postbacks can make bad user experience. Consider using static commands or a throttling postback handler.|

## Sample 1: Binding Support

The TextBox control has the `Text` property which is used data-bind the value from the viewmodel.

```DOTHTML
<dot:TextBox Text="{value: Name}" />

<dot:TextBox Text="static text" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.TextBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Name { get; set; } = "John Green";
    }
}

```

## Sample 2: TextBox Types

The `TextBox` control has the `Type` property which you can use to set up **Password**, **Multiline** or other types of a text field. Default value is **Normal** which renders type="text" on `TextBox`.

```DOTHTML
<!-- normal textbox -->
<dot:TextBox Text="{value: Text}" Type="Normal" />

<!-- password textbox -->
<dot:TextBox Text="{value: Password}" Type="Password" />

<!-- textarea -->
<dot:TextBox Text="{value: Message}" Type="MultiLine" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.TextBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "Simple Text";

        public string Password { get; set; } = "1234";

        public string Message { get; set; } = "Message with \n multiple lines.";
    }
}

```

## Sample 3: Changed Event and UpdateTextOnInput

By default, if you type something in the TextBox, the value will be propagated in the viewmodel when the TextBox loses its focus.
However, sometimes you need to update the TextBox immediately. Therefore, the TextBox also has the `UpdateTextOnInput` which 
will propagate the value in the viewmodel after each key press.

The `Changed` event is triggered when the value of the control changes.

```DOTHTML
<dot:TextBox Text="{value: Text}" 
             UpdateTextOnInput="true" 
             Changed="{command: TextToUpperCase()}"/>

{{value: Text}}
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.TextBox.sample3
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

`TextBox` has `Enabled` property for setting if `TextBox` input is enabled. You can bind and switch it for example with [CheckBox](~/controls/builtin/CheckBox).

```DOTHTML
<p>
  <dot:CheckBox Checked="{value: IsCompany}" 
                Text="The customer is a company." />
</p>

<p>
  Company Number:
  <dot:TextBox Text="{value: CompanyNumber}"
               Enabled="{value: IsCompany}"/>
</p>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.TextBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCompany { get; set; }

        public string CompanyNumber { get; set; } = "";
        
    }
}

```

