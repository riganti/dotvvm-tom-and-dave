# <bs:InputGroupButton>
A special version of the [Button](~/controls/bootstrap4/Button) control that can be used in [InputGroup](~/controls/bootstrap4/InputGroup).

See [Button](~/controls/bootstrap4/Button) for more info on how to use this control.

<https://getbootstrap.com/docs/4.3/components/input-group/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonTagName`|([ButtonTagName](../../builtin/_enums/DotVVM.Framework.Controls.ButtonTagName.md))|Gets or sets whether the control should render the <input> or the <button> tag in the HTML.|attribute, static value|input|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate||inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the button is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsBlockButton`|Boolean|Gets or sets whether the button should be styled as a block element.|attribute, static value|False|
|`IsSubmitButton`|Boolean|Gets or sets whether the control should render a submit button or a normal button (type="submit" or type="button").             The submit button has some special features in the browsers, e.g. handles the Return key in HTML forms etc.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the button.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the text on the button.|attribute, static value, bindable||
|`Type`|([BootstrapButtonColor](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapButtonColor.md))|Gets or sets the color of the button.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.ButtonVisualStyle.md))|Gets or sets whether the button has solid fill, or whether it is only an outline.|attribute, static value, bindable|SolidFill|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

