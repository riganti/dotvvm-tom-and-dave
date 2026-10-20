# <dot:FormControl>
The FormControl (known as [FormGroup](~/controls/bootstrap4/FormGroup) in Boostrap4) is used inside the Form control and renders a form field with a label.

<https://getbootstrap.com/docs/5.2/forms/form-control>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|DotvvmControl|Gets or sets the inner form element.|inner element, static value, default property||
|`ControlSizeAll`|String|Gets or sets the size of the control for all screen sizes.|attribute, static value||
|`ControlSizeLarge`|String|Gets or sets the size of the control for large screen sizes.|attribute, static value||
|`ControlSizeMedium`|String|Gets or sets the size of the control for medium screen sizes.|attribute, static value||
|`ControlSizeSmall`|String|Gets or sets the size of the control for small screen sizes.|attribute, static value||
|`ControlSizeXLarge`|String|Gets or sets the size of the control for extra large screen sizes.|attribute, static value||
|`ControlSizeXXLarge`|String|Gets or sets the size of the control for extra extra large screen sizes.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
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

## Sample 1: Basic Usage

The `FormControl` control can render a label for any child control placed inside it.

Consider using some existing controls that combine FormControl with the most popular form elements:

* [FormControlTextBox](~/controls/bootstrap5/FormControlTextBox)
* [FormControlCheckBox](~/controls/bootstrap5/FormControlCheckBox)
* [FormControlComboBox](~/controls/bootstrap5/FormControlComboBox)
* [FormControlRadioButton](~/controls/bootstrap5/FormControlRadioButton)
* [FormControlRange](~/controls/bootstrap5/FormControlRange)
* [FormControlColorPicker](~/controls/bootstrap5/FormControlColorPicker)

```DOTHTML
<bs:FormControl LabelText="Feedback" HelpText="You can describe it in a few sentences.">
    <bs:TextBox Type="MultiLine" Text="{value: 'Test'}" />
</bs:FormControl>
```

