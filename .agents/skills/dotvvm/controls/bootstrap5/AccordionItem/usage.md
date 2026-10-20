# <dot:AccordionItem>
Represents an item in [Accordion](~/controls/bootstrap5/Accordion) control.

<https://getbootstrap.com/docs/5.2/components/accordion/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets a custom template for accordion item content when DataSource is set.|inner element, static value, default property||
|`ContentText`|String|Gets or sets a plain text for accordion item content when DataSource is set.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for accordion item header when DataSource is set.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for accordion item header when DataSource is set.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsExpanded`|Boolean|Gets or sets whether the item is expanded.|attribute, static value, bindable|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Text

You can use `HeaderText` or `HeaderTemplate`, and `ContentText`or `ContentTemplate` properties to specify contents of the card header and footer bar.

```DOTHTML
<bs:Accordion>
    <bs:AccordionItem HeaderText="Header" ContentText="Text"/>
    <bs:AccordionItem>
        <HeaderTemplate>
            HeaderTemplate
        </HeaderTemplate>
        <ContentTemplate>
            <bs:CardBody>
                Content
            </bs:CardBody>
        </ContentTemplate>
    </bs:AccordionItem>
</bs:Accordion>
```

