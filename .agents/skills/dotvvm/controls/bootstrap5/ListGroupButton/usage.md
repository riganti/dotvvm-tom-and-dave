# <dot:ListGroupButton>
Represents a button item in [ListGroup](~/controls/bootstrap5/ListGroup).

This control shares some properties with [ListGroupLinkItem](~/controls/bootstrap5/ListGroupLink) and [ListGroupTextItem](~/controls/bootstrap5/ListGroupText), but has some additional ones. 

<https://getbootstrap.com/docs/5.2/components/list-group/#links-and-buttons>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BadgeTemplate`|ITemplate|Gets or sets a custom template for a Badge control inside a ListGroupItem.|inner element, static value||
|`BadgeText`|String|Gets or sets a plain text for a Badge control inside a ListGroupItem.|attribute, static value, bindable||
|`BadgeType`|([BadgeColor](../_enums/DotVVM.Bootstrap5.Controls.BadgeColor.md))|Gets or sets a badge color.|attribute, static value, bindable|Primary|
|`BadgeVisualStyle`|([BadgeVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.BadgeVisualStyle.md))|Gets or sets a badge visual style. Possible values are `Default` Badge control or `Pill`.|attribute, static value|Default|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([ListGroupItemColor](../_enums/DotVVM.Bootstrap5.Controls.ListGroupItemColor.md))|Gets or sets a ListGroupItem color.|attribute, static value, bindable|Default|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a ListGroupItem's disabled state.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsJustified`|Boolean|When DataSource is set, adds `justify-content-between` and `align-items-center` CSS classes.|attribute, static value|False|
|`Selected`|Boolean|Gets or sets if ListGroupItem control is selected.|attribute, static value, bindable||
|`Template`|ITemplate|Gets or sets a custom template for a ListGroupItem control.|inner element, static value||
|`Text`|String|Gets or sets a plain text for a ListGroupItem control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when a `Button` ListGroupItem is clicked.|

## Sample 1: ListGroupButtonItem static items

When using static `ListGroupButtonItem` controls, `ItemType` property of a parent `ListGroup` control shall be set to `Button`. Visit [ListGroup](~/controls/bootstrap5/ListGroup) to see some examples with the `DataSource` property.

```DOTHTML
<bs:ListGroup ItemType="Button">
    <bs:ListGroupButton Text="{value: Text}" />
    <bs:ListGroupButton Text="Item 2" Click="{command: ChangeListGroup()}" />
    <bs:ListGroupButton Text="Item 2" Enabled="{value: Enabled}" />
    <bs:ListGroupButton Text="Item 2" Selected="{value: IsSelected}" />
</bs:ListGroup>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; } = "Data-bound text of the item.";
    public bool Enabled { get; set; }
    public bool IsSelected { get; set; }
    public void ChangeListGroup()
    {
        Enabled = !Enabled;
        IsSelected = !IsSelected;
        Text = "Changed";
    }

}
```

