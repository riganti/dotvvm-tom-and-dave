# <bs:Accordion>
Wraps a group of [CollapsiblePanel](~/controls/bootstrap/CollapsiblePanel) controls to create an accordion-like behavior.
When you expand one of the panels inside, the others will collapse. Only one panel can be expanded at the same time.

<https://getbootstrap.com/docs/3.3/javascript/#collapse-example-accordion>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ExpandedPanelIndex`|Int32|Gets or sets the index of the CollapsiblePanel which is currently expanded.|attribute, bindable|-1|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Accordion Control

To use this control, just place several `CollapsiblePanel`s inside the `Accordion` control.
  
In the most common scenario, you need the first panel to be expanded while the others are collapsed.


```DOTHTML
<bs:Accordion>
  
  <bs:CollapsiblePanel Type="Warning" IsCollapsed="false">
    <HeaderTemplate>
      Collapsible Panel Number 1
    </HeaderTemplate>
    <ContentTemplate>
      This is panel body.
    </ContentTemplate>
    <FooterTemplate>
      Footer.
    </FooterTemplate>
  </bs:CollapsiblePanel>

  <bs:CollapsiblePanel Type="Danger">
    <HeaderTemplate>
      Collapsible Panel Number 2
    </HeaderTemplate>
    <ContentTemplate>
      This is panel body.
    </ContentTemplate>
  </bs:CollapsiblePanel>

  <bs:CollapsiblePanel Type="Warning">
    <HeaderTemplate>
      Collapsible Panel Number 3
    </HeaderTemplate>
    <ContentTemplate>
      This is panel body.
    </ContentTemplate>
  </bs:CollapsiblePanel>
  
</bs:Accordion>
```

## Sample 2: Data-binding the CollapsiblePanels

You can data-bind the panels using the [Repeater](~/controls/builtin/Repeater) control and use the `ExpandedPanelIndex` property to determine which panel is currently expanded.  
When none of the panels is expanded, the value of this property will be -1.

Because we don't want the `Repeater` to place the panels inside one `<div>` element, we are using the `RenderWrapperTag` property to modify the default behavior.

```DOTHTML
<bs:Accordion ExpandedPanelIndex="{value: Index}">

  <dot:Repeater DataSource="{value: Panels}" RenderWrapperTag="true">
    <ItemTemplate>
      
      <bs:CollapsiblePanel>
        <HeaderTemplate>
          <dot:Literal Text="{value: Header}" />
        </HeaderTemplate>
        <ContentTemplate>
          <dot:Literal Text="{value: Text}" />
        </ContentTemplate>
      </bs:CollapsiblePanel>
    
    </ItemTemplate>
  </dot:Repeater>

</bs:Accordion>

<p>Expanded panel index: {{value: Index}}</p>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Accordion.sample2
{
    public class ViewModel
    {
        public int Index { get; set; } = 1;

        public PanelData[] Panels { get; set; } =
        {
            new PanelData("Footer 1", "Header 1", "Text 1"),
            new PanelData("Footer 2", "Header 2", "Text 2"),
            new PanelData("Footer 3", "Header 3", "Text 3")
        };
    }

    public class PanelData
    {
        public string Text { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public PanelData()
        {
        }

        public PanelData(string footer, string header, string text)
        {
            Footer = footer;
            Header = header;
            Text = text;
        }
    }
}
```

