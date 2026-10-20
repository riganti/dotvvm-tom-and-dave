# <bp:ColorPickerItem>
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

