# <bp:ColorPicker>
Allows the user to pick a color using a color palette.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowAlphaChannel`|Boolean||attribute, static value|False|
|`AllowCustomColors`|Boolean||attribute, static value|True|
|`AllowUnselect`|Boolean||attribute, static value, bindable|True|
|`Appearance`|([ColorPickerAppearance](../_enums/DotVVM.BusinessPack.Controls.ColorPickerAppearance.md))||attribute, static value, bindable|Popup|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EditorSwitchIcon`|IconBase||inner element, static value, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Placeholder`|String||attribute, static value, bindable||
|`PredefinedColors`|IEnumerable<String>||attribute, bindable||
|`SelectedColor`|String||attribute, bindable||
|`SelectedRgbaColor`|RgbaColor||attribute, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`ToggleIcon`|IconBase||inner element, static value, bindable||
|`UnselectIcon`|IconBase||inner element, static value, bindable||
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `SelectedRgbaColor` property should be bound to an object of type `RgbaColor` with the `Red`, `Green`, `Blue` and `Alpha` properties. 
The `Red`, `Green` and `Blue` properties are `byte` (0 - 255), the `Alpha` property is `double` (0 - 1).

The `Placeholder` property specifies a watermark text which is displayed when no color is selected.

```DOTHTML
<bp:ColorPicker SelectedRgbaColor="{value: Color}"
                Placeholder="Select color" />

<p>R: {{value: Color.Red}}, G: {{value: Color.Green}}, B: {{value: Color.Blue}}, A: {{value: Color.Alpha}}</p>
```

```CSHARP
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);
    }
}

```

## Sample 2: Predefined Colors

The `PredefinedColors` property can be bound to a collection of colors that display under the color scale and can be easily selected by the user.

Using the `AllowCustomColors` property, you can turn the standard color scale off and keep only the list of predefined colors.


```DOTHTML
<p>Custom and predefined colors</p>
<bp:ColorPicker SelectedRgbaColor="{value: Color}"
                PredefinedColors="{value: MyColors}"
                Placeholder="Select color" />

<br />

<p>Only predefined colors</p>
<bp:ColorPicker SelectedRgbaColor="{value: Color}"
                PredefinedColors="{value: MyColors}"
                AllowCustomColors="false"
                Placeholder="Select color" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);

        public List<string> MyColors { get; set; } = new List<string> {
            "#FFFFFF", "#000", "C00000", "#E6E6E6", "44546A", "447260",
            "ED7D31", "FFC000", "5B9BD5", "70AD47", "#FF0000"
        };
    }
}

```

## Sample 3: Alpha Channel

The `AllowAlphaChannel` property can be used to display an additional slider with the alpha values. The user can then select also the `Alpha` channel of the color.

The  default value is `false`.

```DOTHTML
<bp:ColorPicker SelectedRgbaColor="{value: Color}"
                AllowAlphaChannel="true"
                Placeholder="Select color" />

<p>R: {{value: Color.Red}}, G: {{value: Color.Green}}, B: {{value: Color.Blue}}, A: {{value: Color.Alpha}}</p>
```

```CSHARP
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);
    }
}

```

## Sample 4: Changed Event

The `Changed` event can be used to trigger a command in the viewmodel whenever the control value changes.

The `RgbaColor` object contains the `ToHexColor` and the `ToCssColor` which can be used to generate the values in hex (`#112233`) or CSS format (`rgba(10, 20, 30, 1)`).

There are also the `TryParseHexColor` and `ParseHexColor` methods that can be used to transform the hex string representation of the color back to the `RgbaColor` object.

```DOTHTML
<p style="{value: "color: " + CssColor}">Custom colored text</p>

<bp:ColorPicker SelectedRgbaColor="{value: Color}"
                Changed="{command: ColorChanged()}"
                Placeholder="Select color" />
```

```CSHARP
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);
        public string CssColor { get; set; }

        public void ColorChanged()
        {
            if( Color != null )
            {
                CssColor = Color.ToHexColor();
            }
        }
    }
}

```

## Sample 5: Customizing Icons

The icons used by the control can be customized using the following inner elements:

* `ToggleIcon` represents an icon that opens the popup with color scale and predefined colors. The default is `Palette` icon.

* `UnselectIcon` represents an icon that allows the user to deselect the color. The default is `Close` icon.

* `EditorSwitchIcon` represents an icon that allows the user to switch between the RGB editor fields and one text field with the hex representation of the color. The default is `Switch` icon.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.


```DOTHTML
<bp:ColorPicker SelectedRgbaColor="{value: Color}"
                Placeholder="Select color" >
    <ToggleIcon>
       <bp:Icon Icon="Pallete"></bp:Icon>
    </ToggleIcon>
    <UnselectIcon>
        <bp:Icon Icon="Close"></bp:Icon>
    </UnselectIcon>
    <EditorSwitchIcon>
        <bp:Icon Icon="Switch"></bp:Icon>
    </EditorSwitchIcon>
</bp:ColorPicker>

```

```CSHARP
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public RgbaColor Color { get; set; } = new RgbaColor(0, 0, 0, 1);
    }
}

```

## Sample 6: HEX Colors

If you prefer to work with HEX colors, use the `SelectedColor` property instead of the `SelectedRgbaColor` property. We support `#RGB` and `#RRGGBB` color formats (the `#` is optional).

When the `AllowAlphaChannel` property is set to `true`, you can also use `#RGBA` HEX colors.

```DOTHTML
<bp:ColorPicker SelectedColor="{value: Color}"
                Placeholder="Select color" />

<p>Color: {{value: Color}}</p>
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ColorPicker.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Color { get; set; } = "#000";
    }
}
```

