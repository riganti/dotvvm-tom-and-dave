# <bp:SwitchButton>
 Renders the button that can switch states like the [CheckBox](~/controls/businesspack/CheckBox)

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Checked`|Boolean||attribute, bindable|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DisableContentStyle`|Boolean||attribute, static value, bindable|False|
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Text`|String||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command||

## Sample 1: Basic Usage

The SwitchButton control has the `Checked` property of *boolean* which indicates whether the control is checked or not.

You can use the `Text` property to specify the button text. Or you can put contents inside the `bp:SwitchButton` element.

```DOTHTML
<bp:SwitchButton Text="Switch button"
                 Checked="{value: Checked}">
</bp:SwitchButton>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.SwitchButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Checked { get; set; }
    }
}
```

## Sample 2: Click Event

You can set which command will be triggered when the button is clicked with `click` property.

```DOTHTML
<bp:SwitchButton Checked="{value: Checked}"
                 Click="{command: ClickCount = ClickCount + 1}">
    <span>Switch button</span> &nbsp;
</bp:SwitchButton>

<p>Click counter: {{value: ClickCount}}</p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.SwitchButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Checked { get; set; }
        public int ClickCount { get; set; }
    }
}
```

