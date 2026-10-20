# <dot:CollapsiblePanel>
Combines [Collapsible](~/controls/bootstrap5/Collapsible) and [Card](~/controls/bootstrap5/Card) into control with always visible header and collapsible content (+ footer).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BorderColor`|([BootstrapColor](../_enums/DotVVM.Bootstrap5.BootstrapColor.md))|Gets or sets the card border color.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([CardColor](../_enums/DotVVM.Bootstrap5.Controls.CardColor.md))|Gets or sets the card color. Both the background and text color css classes are set.|attribute, static value, bindable||
|`Content`|List<ICardItem>|Gets or sets the card content.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets a custom template for panel footer.|inner element, static value||
|`FooterText`|String|Gets or sets a plain text for panel footer.|attribute, static value, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for panel header.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for panel header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsExpanded`|Boolean|Gets or sets whether the panel content is collapsed or not.|attribute, static value, bindable|True|
|`SubtitleText`|String|Gets or sets the control subtitle text. H6 tag is used.|attribute, static value, bindable||
|`Text`|String|Gets or sets the card text content. This property cannot be combined with `Content` property.|attribute, static value, bindable||
|`TitleText`|String|Gets or sets the control title text. H5 tag is used.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`CollapsedOrExpanded`|ICommandBinding|Triggers when the CollapsiblePanel is collapsed or expanded.|

## Sample 1: Simple Collapsible Panel

The Collapsible panel has the same API as [Card](~/controls/bootstrap5/Card). The difference is that only Header is visible when Collapsible panel is collapsed.

Collapsible panel can be collapsed/expanded by clicking on the header or using the `IsExpanded` property.


```DOTHTML
<bs:CollapsiblePanel HeaderText="Always displayed header" Text="Text which is hidden when collapsed." FooterText="Footer which is hidden when collapsed." />

<bs:CollapsiblePanel>
    <HeaderTemplate>
        <bs:Icon Type="check" />
        Always displayed header
    </HeaderTemplate>
    <Content>
        <bs:CardBody>
           Custom CardBody text which is hidden when collapsed.
        </bs:CardBody>
    </Content>
    <FooterTemplate>
        Custom footer which is hidden when collapsed.
    </FooterTemplate>
</bs:CollapsiblePanel>
```

## Sample 2: IsExpanded binding

Use `IsExpanded` to control state of collapsible panel programmatically.

`IsExpanded` property can be also use to set the initial state of Collapsible Panel.

```DOTHTML
<bs:CollapsiblePanel IsExpanded="{value: IsExpanded}" HeaderText="Always displayed header" Text="Text which is hidden when collapsed." />
<bs:CheckBox Checked="{value: IsExpanded}" Text="Is expanded" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool IsExpanded { get; set; }
}
```

