# <bs:AccordionItem>
Represents an item in [Accordion](~/controls/bootstrap4/Accordion) control.

This control inherits from [Card](~/controls/bootstrap4/Card). 

It has an additional property `IsExpanded` which determines whether the card content is expanded or not.

<https://getbootstrap.com/docs/4.3/components/collapse/#accordion-example>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<ICardItem>|Gets or sets the contents of the main section of the panel.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets the contents of the footer section of the panel.|inner element, static value||
|`FooterText`|String|Gets or sets footer text|attribute, static value, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the contents of the header section of the panel.|inner element, static value||
|`HeaderText`|String|Gets or sets header text.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`SubtitleText`|String|Gets or sets subtitle of the card.|attribute, static value, bindable||
|`Text`|String|Gets or sets inner text of the card.|attribute, static value, bindable||
|`TitleText`|String|Gets or sets title of the card.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

