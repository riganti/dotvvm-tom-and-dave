# <bs:RadioButtonListGroup>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`CheckedBinding`|IValueBinding|Gets or sets whether the CheckBox is checked.|attribute, bindable||
|`CheckedItem`|IValueBinding||attribute, bindable||
|`CheckedValueBinding`|IValueBinding|Gets or sets the value that will be used as a result when the CheckBox is checked.             Use this property in combination with the !:CheckedItems property.|attribute, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data used in the CheckBoxes.|attribute, bindable||
|`EnabledBinding`|IValueBinding|Gets or sets a value indicating whether the CheckBox is enabled and can be clicked on.|attribute, bindable||
|`GroupMode`|([BootstrapGroupMode](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapGroupMode.md))|Gets or sets which container element will be rendered around the CheckBoxes.|attribute, static value|FormGroup|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsInlineBinding`|IValueBinding|Gets or sets whether there will be more CheckBoxes on the same line. When this property is true, the CheckBox gets the Boostrap "inline" CSS class.|attribute, bindable||
|`IsJustified`|Boolean|Gets or sets whether the ButtonGroup should justify to fill all available space in the horizontal direction.             Is only available if GroupMode is set to ButtonGroup.|attribute, static value|False|
|`IsVertical`|Boolean|Gets or sets whether the ButtonGroup is rendered in the vertical mode.             Is only available if GroupMode is set to ButtonGroup.|attribute, static value|False|
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area of the FormGroup. This property cannot be combined with the LabelText property.             Is only available if GroupMode is set to FormGroup.|inner element, static value||
|`LabelText`|String|Gets or sets the label text of the FormGroup. This property cannot be combined with the LabelTemplate property.             Is only available if GroupMode is set to FormGroup.|attribute, static value, bindable||
|`RenderContentContainers`|Boolean|Gets or sets whether an additional container will be rendered around the content.             Is only available if GroupMode is set to FormGroup.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap.Size.md))|Gets or sets the size of the buttons in the ButtonGroup.             Is only available if GroupMode is set to ButtonGroup.|attribute, static value|Default|
|`TextBinding`|IValueBinding|Gets or sets the label text that is rendered next to the CheckBox.|attribute, bindable||
|`TypeBinding`|IValueBinding|Gets or sets the BootstrapColor of the CheckBox.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisibleBinding`|IValueBinding|Gets or set whether the CheckBox will be visible.|attribute, bindable||

## Events
|Name|Type|Description|
|---|---|---|
|`ChangedBinding`|ICommandBinding|Gets or sets the command that will be triggered when the CheckBox's check state is changed.|

