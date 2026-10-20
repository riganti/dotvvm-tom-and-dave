# <bp:NumericUpDown>
A text field which allows to enter numeric values and to increase or decrease them by the specified step.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ButtonPlacement`|([NumericUpDownButtonPlacement](../_enums/DotVVM.BusinessPack.Controls.NumericUpDownButtonPlacement.md))||attribute, static value, bindable|Right|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DecreaseIcon`|IconBase||inner element, static value, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FormatString`|String||attribute, static value|G|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IncreaseIcon`|IconBase||inner element, static value, bindable||
|`MaxValue`|Double?||attribute, static value, bindable||
|`MinValue`|Double?||attribute, static value, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`Step`|Double||attribute, static value, bindable|1|
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`UseFormatStringAsPlaceholder`|Boolean||attribute, static value|True|
|`Value`|Double?||attribute, bindable||
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `Value` property represents the numeric value entered in the control.

The `MinValue` and `MaxValue` specifies the range or values which are allowed in the control.

The `Step` property specifies a value to be added or subtracted when the user clicks the Up and Down buttons in the control.


```DOTHTML
<bp:NumericUpDown Value="{value: Value}"
                  MinValue="0.5"
                  MaxValue="5"
                  Step="0.5" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.NumericUpDown.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Value { get; set; } = 1.5;
    }
}
```

## Sample 2: Changed Event

The `Changed` event specifies a command in the viewmodel which is triggered whenever the value is changed.


```DOTHTML
<bp:NumericUpDown Value="{value: Value}"
                  Changed="{command: ValueChanged()}" />

<p>Numeric value has changed {{value: ChangeCount}} times.</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.NumericUpDown.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Value { get; set; }
        public int ChangeCount { get; set; }

        public void ValueChanged()
        {
            ChangeCount++;
        }
    }
}
```

## Sample 3: Format Strings

The `FormatString` property specifies the format that will be used to display the number. Use [standard](https://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx) or 
[custom](https://msdn.microsoft.com/en-us/library/0c899ak8(v=vs.110).aspx) .NET number format strings.

The exact format of the number is determined from the culture that was used in the HTTP request on the server. You can find more info in the [Globalization](~/pages/concepts/localization-and-cultures/multi-language-applications) tutorial.


```DOTHTML
<bp:NumericUpDown Value="{value: Value}"
                  FormatString="C"
                  Step="{value: 0.1}"
                  MinValue="0" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.NumericUpDown.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Value { get; set; }
    }
}
```

## Sample 4: Customizing Icons

The icons used by the control can be customized using the following inner elements:

* `IncreaseIcon` represents an icon that allows to increase the value. The default is `Plus` icon.

* `DecreaseIcon` represents an icon that allows to decrease the value. The default is `Minus` icon.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:NumericUpDown Value="{value: Value}"
                  MinValue="0.5"
                  MaxValue="5"
                  Step="0.5">
    <IncreaseIcon>
        <bp:Icon Icon="Plus"></bp:Icon>
    </IncreaseIcon>
    <DecreaseIcon>
        <bp:Icon Icon="Minus"></bp:Icon>
    </DecreaseIcon>
</bp:NumericUpDown>
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.NumericUpDown.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Value { get; set; } = 1.5;
    }
}
```

