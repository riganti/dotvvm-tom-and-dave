# <bs:CardListGroup>
A special version of the [ListGroup](~/controls/bootstrap4/ListGroup) control that can be used in [Card](~/controls/bootstrap4/Card).

See [ListGroup](~/controls/bootstrap4/ListGroup) for more info on how to use this control.

<https://getbootstrap.com/docs/4.3/components/card/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BadgeBinding`|Badge|Gets or sets a binding which defines the contents of the badge that will be created in each item.             Use this property in combination with the DataSource property.|inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ColorBinding`|IValueBinding|Gets or sets a binding which defines color of each generated item.             Use this property in combination with the DataSource property.|attribute, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsFlush`|Boolean|Gets or sets whether to remove some borders and rounded corners to render list group items edge-to-edge in a parent container.|attribute, static value, bindable|False|
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IListGroupItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`ItemType`|([ListGroupItemType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ListGroupItemType.md))|Gets or sets the type of the items.|attribute, static value|Default|
|`MaximumScreenSizeBeforeChangeToVertical`|([ResponsiveBreakpoints](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveBreakpoints.md))|Gets or sets the maximum screen size before the ListGroup will change to vertical mode.             If set to None than the ListGroup will never change to vertical.|attribute, static value|None|
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`ScrollSpyEnabled`|Boolean||attribute, static value, bindable|False|
|`ScrollSpyOffset`|Int32||attribute, static value|10|
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Type`|([ListGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ListGroupType.md))|Gets or sets the type of ListGroup.             e.g. Vertical, Horizontal|attribute, static value|Vertical|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

