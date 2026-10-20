# <dot:FormControlColorPicker>
A special version of the [ColorPicker](~/controls/bootstrap5/ColorPicker) control that can be used in [Form](~/controls/bootstrap5/Form).

See [ColorPicker](~/controls/bootstrap5/ColorPicker) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/form-control>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|String|Gets or sets the color picker value.|attribute, static value, bindable||
|`ColorPickerSize`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size attribute of the color picker.|attribute, static value, bindable||
|`ControlSizeAll`|String|Gets or sets the size of the control for all screen sizes.|attribute, static value||
|`ControlSizeLarge`|String|Gets or sets the size of the control for large screen sizes.|attribute, static value||
|`ControlSizeMedium`|String|Gets or sets the size of the control for medium screen sizes.|attribute, static value||
|`ControlSizeSmall`|String|Gets or sets the size of the control for small screen sizes.|attribute, static value||
|`ControlSizeXLarge`|String|Gets or sets the size of the control for extra large screen sizes.|attribute, static value||
|`ControlSizeXXLarge`|String|Gets or sets the size of the control for extra extra large screen sizes.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the color picker is enabled.|attribute, static value, bindable|True|
|`FormControlCssClass`|String|Gets or sets the CSS class to apply to the form control element.|attribute, static value||
|`FormControlType`|FormControlType?|Gets or sets the available form control type.|attribute, static value||
|`HelpContent`|List<DotvvmControl>|Gets or sets a custom template for for the help text. Cannot be combined with a `HelpText` property.|inner element, static value||
|`HelpText`|String|Gets or sets a plain text for the help text. Cannot be combined with a `HelpContent` property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`LabelContent`|List<DotvvmControl>|Gets or sets a custom template for for the control label. Cannot be combined with a `LabelText` property.|inner element, static value||
|`LabelSizeAll`|String|Gets or sets the size of the label for all screen sizes.|attribute, static value||
|`LabelSizeLarge`|String|Gets or sets the size of the label for large screen sizes.|attribute, static value||
|`LabelSizeMedium`|String|Gets or sets the size of the label for medium screen sizes.|attribute, static value||
|`LabelSizeSmall`|String|Gets or sets the size of the label for small screen sizes.|attribute, static value||
|`LabelSizeXLarge`|String|Gets or sets the size of the label for extra large screen sizes.|attribute, static value||
|`LabelSizeXXLarge`|String|Gets or sets the size of the label for extra extra large screen sizes.|attribute, static value||
|`LabelText`|String|Gets or sets a plain text for the control label. Cannot be combined with a `LabelContent` property.|attribute, static value, bindable||
|`LabelType`|LabelType?|Gets or sets the label type. Possible values are `Default` and `Floating`.|attribute, static value||
|`Layout`|FormControlLayout?|Gets or sets the form control layout. Possible values are `Default`, `Horizontal` and `Grid`.|attribute, static value||
|`RenderLabel`|Boolean?|Gets or sets whether the label is rendered.|attribute, static value||
|`Size`|Size?|Gets or sets the size of the label and form control elements.|attribute, static value||
|`Title`|String|Gets or sets the title attribute of the color picker.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The `FormControl` control can render a label for any child control placed inside it.

Consider using some existing controls that combine FormControl with the most popular form elements:

* [FormControlTextBox](~/controls/bootstrap5/FormControlTextBox)
* [FormControlCheckBox](~/controls/bootstrap5/FormControlCheckBox)
* [FormControlComboBox](~/controls/bootstrap5/FormControlComboBox)
* [FormControlRadioButton](~/controls/bootstrap5/FormControlRadioButton)
* [FormControlRange](~/controls/bootstrap5/FormControlRange)

```DOTHTML
<bs:FormControlColorPicker Value="{Value: "#070a64"}"
                           Title="My Color Picker"
                           LabelText="My Color Picker" />

```

