# <bs:InputGroupDropDownButton>
A special version of the [DropDownButton](~/controls/bootstrap4/DropDownButton) control that can be used in [InputGroup](~/controls/bootstrap4/InputGroup).

See [DropDownButton](~/controls/bootstrap4/DropDownButton) for more info on how to use this control.

<https://getbootstrap.com/docs/4.3/components/input-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowPopupFlip`|Boolean|Gets or sets whether the pop-up can flip to a different direction when it does not fit on the page.|attribute, static value|True|
|`ButtonContentTemplate`|ITemplate|Gets or sets the template for the button content.|inner element, static value||
|`ButtonType`|([DropDownButtonType](../_enums/DotVVM.Framework.Controls.Bootstrap4.DropDownButtonType.md))|Gets or sets the type of the button.|attribute, static value|Button|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`DropDirection`|([DropDirection](../_enums/DotVVM.Framework.Controls.Bootstrap4.DropDirection.md))|Gets or sets the pop-up direction.|attribute, static value, bindable|DropDown|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsCollapsed`|Boolean|Gets or sets whether the button is collapsed or not.|attribute, bindable|True|
|`IsEnabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IDropDownButtonItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`MenuAlignment`|([DropdownMenuAlignment](../_enums/DotVVM.Framework.Controls.Bootstrap4.DropdownMenuAlignment.md))|Gets or sets whether the pop-up will be aligned to the right of the button.|attribute, static value|Default|
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the button.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the button text.|attribute, static value, bindable||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Type`|([BootstrapButtonColor](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapButtonColor.md))|Gets or sets the color of the button.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.ButtonVisualStyle.md))|Gets or sets whether the button has solid fill, or whether it is only an outline.|attribute, static value, bindable|SolidFill|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

