# <dot:ButtonGroupRadioButton>
A special version of the [RadioButton](~/controls/bootstrap5/RadioButton) control that can be used in [ButtonGroup](~/controls/bootstrap5/ButtonGroup).

See [RadioButton](~/controls/bootstrap5/RadioButton) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/components/button-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonFontType`|([ButtonTextColor](../_enums/DotVVM.Bootstrap5.ButtonTextColor.md))|Gets or sets the font color.|attribute, static value, bindable|Default|
|`ButtonSize`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the button size.|attribute, static value, bindable|Default|
|`ButtonType`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the button type.|attribute, static value, bindable|Primary|
|`ButtonVisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets the button visual style.|attribute, static value|SolidFill|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, static value, bindable||
|`CheckedItem`|IValueBinding<Object>|Gets or sets the checked item. Use this property in combination with the CheckedValue property.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked. Use this property in combination with the CheckedItem property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable||
|`GroupName`|String|Gets or sets a unique name for the radio button group.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding||

