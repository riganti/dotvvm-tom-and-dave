# <bs:Panel>
Renders the Bootstrap panel with optional header and footer.

<https://getbootstrap.com/docs/3.3/components/#panels>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AdditionalContentTemplate`|ITemplate|Gets or sets the contents of the additional content section of the panel. The additional content section has no padding and is intended to place ListGroups or similar controls inside.|inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the contents of the main section of the panel.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets the contents of the footer section of the panel.|inner element, static value||
|`HeaderTemplate`|ITemplate|Gets or sets the contents of the header section of the panel.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the type of the panel.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Panel

The contents of the panel can be defined using the `ContentTemplate` property, or by specifying the content just inside the `<bs:Panel>` control.

You can change the contextual color of the Panel using the `Type` property.

```DOTHTML
<bs:Panel Type="Danger">
  <ContentTemplate>
    This is panel body.
  </ContentTemplate>
</bs:Panel>

<bs:Panel Type="Default">
    This is panel body.
</bs:Panel>

```

## Sample 2: Panel Templates

The Header part of the `Panel` can be customized using the `HeaderTemplate` property.

Similarly, the `FooterTemplate` property allows to customize the footer of the panel. 

If you need to add additional content which should have zero padding, like a [ListGroup](~/controls/bootstrap/ListGroup) 
or [Table](~/controls/bootstrap/Table), use the `AdditionalContentTemplate` property.

```DOTHTML
<bs:Panel Type="Primary">
  <HeaderTemplate>
    My Panel
  </HeaderTemplate>
  <ContentTemplate>
    This is panel body.
  </ContentTemplate>
  <FooterTemplate>
    Footer template
  </FooterTemplate>
  <AdditionalContentTemplate>
    <table class="table">
      <tr>
        <td>Test</td>
        <td>Test</td>
      </tr>
      <tr>
        <td>Test</td>
        <td>Test</td>
      </tr>
    </table>
  </AdditionalContentTemplate>
</bs:Panel>

```

