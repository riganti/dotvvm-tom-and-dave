# <bp:Panel>
Renders a box with header, main content and footer.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate||inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DisableContentStyle`|Boolean||attribute, static value, bindable|False|
|`DisableFooterStyle`|Boolean||attribute, static value, bindable|False|
|`DisableHeaderStyle`|Boolean||attribute, static value, bindable|False|
|`FooterTemplate`|ITemplate||inner element, static value||
|`FooterText`|String||attribute, static value, bindable||
|`HeaderTemplate`|ITemplate||inner element, static value||
|`HeaderText`|String||attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The content inside the `<bp:Panel>` element is treated as a `ContentTemplate` property which specifies the main content of the panel.

The `HeaderText` can be used to specify the text in the panel header. Alternatively, you can use the `HeaderTemplate` property to be able to use any HTML content inside the header.

The same applies to the `FooterText` and `FooterTemplate` properties which can be used to customize the panel footer row.



```DOTHTML
<%-- Simple text header and footer --%>
<bp:Panel HeaderText="This is Header"
          FooterText="This is Footer">
    <ContentTemplate>
        This is content
    </ContentTemplate>
</bp:Panel>

<br />

<%-- Templated header and footer --%>
<bp:Panel>
    <HeaderTemplate>
        <h3>This is Header</h3>
    </HeaderTemplate>
    <ContentTemplate>
        This is content
    </ContentTemplate>
    <FooterTemplate>
        <i>This is footer</i>
    </FooterTemplate>
</bp:Panel>
```

