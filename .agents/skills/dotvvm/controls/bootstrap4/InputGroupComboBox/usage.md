# <bs:InputGroupComboBox>
A special version of the [ComboBox](~/controls/bootstrap4/ComboBox) control that can be used in [InputGroup](~/controls/bootstrap4/InputGroup).

See [ComboBox](~/controls/bootstrap4/ComboBox) for more info on how to use this control.

<https://getbootstrap.com/docs/4.3/components/input-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyItemText`|String|Text displayed when no value is selected.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormControlStyle`|([BootstrapFormStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapFormStyle.md))|Gets or sets the Bootstrap form style of the control.|attribute, static value|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemTitleBinding`|IValueBinding|The expression of DataSource item that will be placed into html title attribute.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the ComboBox.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

