# <bs:CollapsiblePanel>
A Bootstrap collapsible panel.

<https://getbootstrap.com/docs/3.3/javascript/#collapse>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AdditionalContentTemplate`|ITemplate|Gets or sets the additional content of the panel. This template is used to place a list group and other content without the padding inside the panel.|inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the content of the panel.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets the contents of the panel footer.|inner element, static value||
|`HeaderTemplate`|ITemplate|Gets or sets the contents of the panel header.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsCollapsed`|Boolean|Gets or sets whether the panel is collapsed or not.|attribute, static value, bindable|True|
|`RenderHeaderLink`|Boolean|Gets or sets whether the header template is wrapped in hyperlink.|attribute, static value, bindable|True|
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the color of the panel header.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Simple Collapsible Panel

Use the `HeaderTemplate` and `ContentTemplate` properties to specify the header and the main content of the panel.

Optionally, you can use the `FooterTemplate` and `AdditionalContentTemplate` to specify the footer and additional content of the panel.  
The additional content is intended to use the `ListGroup` control since it doesn't have any padding around the content.

The `Type` property allows to specify the color of the panel header.

```DOTHTML
<bs:CollapsiblePanel Type="Danger">
  <HeaderTemplate>
    Header
  </HeaderTemplate>
  <ContentTemplate>
    Content
  </ContentTemplate>
  <FooterTemplate>
    Footer
  </FooterTemplate>
  <AdditionalContentTemplate>
    <bs:ListGroup>
      <bs:ListGroupItem Text="ListGroup" />
      <bs:ListGroupItem Text="ListGroup" />
    </bs:ListGroup>
  </AdditionalContentTemplate>
</bs:CollapsiblePanel>
```

## Sample 2: Collapsible Panel State Binding

The `IsCollapsed` property gets or sets, whether the panel is currently collapsed.


```DOTHTML
<bs:CollapsiblePanel IsCollapsed="{value: Collapsed1}">
  <HeaderTemplate>
    Collapsible Panel with Type binding
  </HeaderTemplate>
  <ContentTemplate>
    This is the panel body.
  </ContentTemplate>
</bs:CollapsiblePanel>
<bs:CollapsiblePanel IsCollapsed="{value: Collapsed2}">
  <HeaderTemplate>
    Collapsible Panel with Type binding
  </HeaderTemplate>
  <ContentTemplate>
    This is the panel body.
  </ContentTemplate>
</bs:CollapsiblePanel>

<p>First panel: {{value: Collapsed1}}</p>
<p>Second panel: {{value: Collapsed2}}</p>

<p><dot:Button Text="Collapse All" Click="{command: CollapseAll()}" /></p>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.CollapsiblePanel.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Collapsed1 { get; set; }

        public bool Collapsed2 { get; set; }

        public void CollapseAll()
        {
            Collapsed1 = true;
            Collapsed2 = true;
        }
    }
}
```

