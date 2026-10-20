# <dot:FormControlTextBox>
A special version of the [TextBox](~/controls/bootstrap5/TextBox) control that can be used in [Form](~/controls/bootstrap5/Form).

See [TextBox](~/controls/bootstrap5/TextBox) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/form-control>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ControlSizeAll`|String|Gets or sets the size of the control for all screen sizes.|attribute, static value||
|`ControlSizeLarge`|String|Gets or sets the size of the control for large screen sizes.|attribute, static value||
|`ControlSizeMedium`|String|Gets or sets the size of the control for medium screen sizes.|attribute, static value||
|`ControlSizeSmall`|String|Gets or sets the size of the control for small screen sizes.|attribute, static value||
|`ControlSizeXLarge`|String|Gets or sets the size of the control for extra large screen sizes.|attribute, static value||
|`ControlSizeXXLarge`|String|Gets or sets the size of the control for extra extra large screen sizes.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable||
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
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
|`Placeholder`|String|Gets or sets a placeholder value. Cannot be combined with a floating label type.|attribute, static value, bindable||
|`RenderLabel`|Boolean?|Gets or sets whether the label is rendered.|attribute, static value||
|`SelectAllOnFocus`|Boolean|Gets or sets whether all text inside the TextBox becomes selected when the element gets focused.|attribute, static value, bindable||
|`Size`|Size?|Gets or sets the size of the label and form control elements.|attribute, static value||
|`Text`|IValueBinding|Gets or sets the text in the control.|attribute, bindable||
|`TextBoxType`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))|Gets or sets the mode of the text field.|attribute, static value|Normal|
|`UpdateTextOnInput`|Boolean|Gets or sets whether the viewmodel property will be updated immediately after change. By default, the viewmodel is updated after the control loses its focus.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Gets or sets the command that will be triggered when the onchange event is fired.|
|`TextInput`|ICommandBinding|Gets or sets the command that will be triggered when the user is typing in the field. Be careful when using this event - triggering frequent postbacks can make bad user experience. Consider using static commands or a throttling postback handler.|

## Sample 1: Basic Usage

```DOTHTML
<bs:FormControlTextBox LabelText="Basic" 
                       Text="{value: TextValue}" 
                       Placeholder="Basic"/>

<bs:FormControlTextBox LabelText="horizontal" 
                       Layout="Horizontal" 
                       Text="{value: TextValue}" 
                       Size="small"/>

<bs:FormControlTextBox LabelText="Basic" 
                       LabelType="Floating" 
                       Text="{value: TextValue}" />

```

