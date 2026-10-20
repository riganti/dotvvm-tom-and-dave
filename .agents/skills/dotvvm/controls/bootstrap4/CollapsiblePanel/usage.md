# <bs:CollapsiblePanel>
Combines [Collapsible](~/controls/bootstrap4/Collapsible) and [Card](~/controls/bootstrap4/Card) into control with always visible header and collapsible content (+ footer).

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
|`IsCollapsed`|Boolean|Gets or sets whether the content is collapsed or not.|attribute, bindable|True|
|`SubtitleText`|String|Gets or sets subtitle of the card.|attribute, static value, bindable||
|`Text`|String|Gets or sets inner text of the card.|attribute, static value, bindable||
|`TitleText`|String|Gets or sets title of the card.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Simple Collapsible Panel

The Collapsible panel has the same API as [Card](~/controls/bootstrap4/Card). The difference is that only Header is visible when Collapsible panel is collapsed.

Collapsible panel can be collapsed/expanded by clicking on the header or using the `IsCollapsed` property.


```DOTHTML
<bs:CollapsiblePanel HeaderText="Always displayed header" Text="Text which is hidden when collapsed." FooterText="Footer which is hidden when collapsed." />

<bs:CollapsiblePanel>
    <HeaderTemplate>
        Always displayed header
    </HeaderTemplate>
    <Content>
        <bs:CardBody>
            Text which is hidden when collapsed.
        </bs:CardBody>
    </Content>
    <FooterTemplate>
        Footer which is hidden when collapsed.
    </FooterTemplate>
</bs:CollapsiblePanel>
```

## Sample 2: IsCollapsed binding

Use `IsCollapsed` to control state of collapsible panel programmatically.

`IsCollapsed` property can be also use to set the initial state of Collapsible Panel.

```DOTHTML
<bs:CollapsiblePanel IsCollapsed="{value: IsCollapsed}" HeaderText="Always displayed header" Text="Text which is hidden when collapsed." />
<dot:CheckBox Checked="{value: IsCollapsed}" Text="Is collapsed" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.CollapsiblePanel.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCollapsed { get; set; }
    }
}
```

