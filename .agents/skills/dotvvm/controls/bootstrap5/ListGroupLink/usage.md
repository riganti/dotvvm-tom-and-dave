# <dot:ListGroupLink>
Represents an item in [ListGroup](~/controls/bootstrap5/ListGroup).


This control share some properties with [ListGroupButtonItem](~/controls/bootstrap5/ListGroupButton) and [ListGroupTextItem](~/controls/bootstrap5/ListGroupText), but has some additional ones: 

* `Color` specifies the Bootstrap color to be used for the list item.
* Properties with a `Badge` prefix allow to specify a [Badge](~/controls/bootstrap5/Badge) control inside the list item to render additional content.

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
|`Enabled`|Boolean|Gets or sets a ListGroupItem disabled state.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsJustified`|Boolean|When DataSource is set, adds `justify-content-between` and `align-items-center` CSS classes.|attribute, static value|False|
|`NavigateUrl`|String|Gets or sets a navigation URL for Link ListGroupItem.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets a route name.|attribute, static value||
|`Selected`|Boolean|Gets or sets if ListGroupItem control is selected.|attribute, static value, bindable||
|`Template`|ITemplate|Gets or sets a custom template for a ListGroupItem control.|inner element, static value, default property||
|`Text`|String|Gets or sets a plain text for a ListGroupItem control.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets a URL suffix for a Link ListGroupItem control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: ListGroupLinkItem static items

With `ListGroupLinkItem` more advanced UI with `Badge` control can be generated. `ItemType` of a parent `ListGroup` control shall be set to `Link`. Visit [ListGroup](~/controls/bootstrap5/ListGroup) to see some examples with the `DataSource` property.


```DOTHTML
<bs:ListGroup ItemType="Link">
    <bs:ListGroupLink>
        <Template>
            <div class="d-flex w-100 justify-content-between">
                <h5 class="mb-1">List group item heading</h5>
                <small>3 days ago</small>
            </div>
            <h5 class="mb-1">List group item heading</h5>
            <p class="mb-1">Some placeholder content in a paragraph.</p>
            <small>And some small print.</small>
        </Template>
    </bs:ListGroupLink>
    <bs:ListGroupLink Events.Click="{command: ChangeListGroup()}" Color="Danger" IsJustified="true">
        <BadgeTemplate>
            {{value: Text}}
        </BadgeTemplate>
        <Template>
            <span>{{value: Text}}</span>
        </Template>
    </bs:ListGroupLink>
    <bs:ListGroupLink Color="Success" Enabled="{value: Enabled}" Text="{value: Text}" />
    <bs:ListGroupLink Color="Success" Selected="{value: IsSelected}" Text="{value: Text}" />
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

