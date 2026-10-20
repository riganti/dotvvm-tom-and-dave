# <bs:ButtonGroupRadioButton>
A special version of the [RadioButton](~/controls/bootstrap4/RadioButton) control that can be used in [ButtonGroup](~/controls/bootstrap4/ButtonGroup).

See [RadioButton](~/controls/bootstrap4/RadioButton) for more info on how to use this control.

<https://getbootstrap.com/docs/4.3/components/button-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`CheckedItem`|Object|Gets or sets the CheckedValue of the first RadioButton that is checked and bound to this collection.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked.             Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable|True|
|`GroupName`|String|Gets or sets an unique name of the radio button group.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InputCssClass`|String|Gets or sets a CSS class that will be appended on the rendered input element.|attribute, static value||
|`ItemKeyBinding`|IValueBinding|Gets or sets a property that retrieves an unique key for the CheckedValue so it can be compared with objects in the CheckedItems collection. This property must be set if the value of the CheckedValue property is not a primitive type.|attribute, bindable||
|`LabelCssClass`|String|Gets or sets a CSS class that will be appended on the rendered label element.|attribute, static value||
|`Text`|String|Gets or sets the label text that is rendered next to the control.|attribute, static value, bindable||
|`Type`|([BootstrapButtonColor](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapButtonColor.md))|Gets or sets the color of the button.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control check state is changed.|

