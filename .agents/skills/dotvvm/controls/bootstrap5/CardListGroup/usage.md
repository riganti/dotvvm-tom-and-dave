# <dot:CardListGroup>
A special version of the [ListGroup](~/controls/bootstrap5/ListGroup) control that can be used in [Card](~/controls/bootstrap5/Card).

See [ListGroup](~/controls/bootstrap5/ListGroup) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/components/card/#list-groups>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`ForceVerticalOrientationBreakpoint`|([ResponsiveBreakpoints](../_enums/DotVVM.Bootstrap5.ResponsiveBreakpoints.md))|Sets a breakpoint when ListGroup is changed from horizontal to vertical.|attribute, static value|None|
|`GroupTypes`|ListGroupType[]|Gets or sets the types of the ListGroup. Possible values are `Numbered` or `Flush` or both.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemBadgeTemplate`|ITemplate|Gets or sets a custom template for a Badge control inside a ListGroupItem when DataSource is set.|inner element, static value||
|`ItemBadgeText`|String|Gets or sets a plain text for a Badge control inside a ListGroupItem when DataSource is set.|attribute, static value, bindable||
|`ItemBadgeType`|([BadgeColor](../_enums/DotVVM.Bootstrap5.Controls.BadgeColor.md))|Gets or sets a badge color when DataSource is set.|attribute, static value, bindable|Primary|
|`ItemBadgeVisualStyle`|([BadgeVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.BadgeVisualStyle.md))|Gets or sets a badge visual style when DataSource is set. Possible values are `Default` or `Pill`.|attribute, static value|Default|
|`ItemColor`|([ListGroupItemColor](../_enums/DotVVM.Bootstrap5.Controls.ListGroupItemColor.md))|Gets or sets a ListGroupItem color when DataSource is set.|attribute, static value, bindable|Default|
|`ItemEnabled`|Boolean|Gets or sets a ListGroupItem disabled state when DataSource is set.|attribute, static value, bindable|True|
|`ItemIsJustified`|Boolean|When DataSource is set, adds `justify-content-between` and `align-items-center` CSS classes when DataSource is set.|attribute, static value|False|
|`ItemNavigateUrl`|String|Gets or sets a navigation URL for `Link` ListGroupItem when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets a route name when DataSource is set.|attribute, static value||
|`Items`|List<IListGroupItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether ListGroupItem control is selected when DataSource is set.|attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets a custom template for a ListGroupItem control when DataSource is set.|inner element, static value||
|`ItemText`|String|Gets or sets a plain text for a ListGroupItem control when DataSource is set.|attribute, static value, bindable||
|`ItemType`|([ListGroupItemType](../_enums/DotVVM.Bootstrap5.Controls.ListGroupItemType.md))|Gets or sets a type for a ListGroupItem control when DataSource is set.|attribute, static value|Default|
|`ItemUrlSuffix`|String|Gets or sets a URL suffix for a `Link` ListGroupItem control when DataSource is set.|attribute, static value, bindable||
|`Orientation`|([ListGroupOrientation](../_enums/DotVVM.Bootstrap5.Controls.ListGroupOrientation.md))|Gets or sets a ListGroup orientation.|attribute, static value|Vertical|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command that will be triggered when a `Button` ListGroupItem is clicked. DataSource must be is set.|

## Sample 2: Card with images and lists

The card can contain images or lists. Use any combination of [CardBody](~/controls/bootstrap5/CardBody), [CardImage](~/controls/bootstrap5/CardImage) and [CardListGroup](~/controls/bootstrap5/CardListGroup) controls.

```DOTHTML
<bs:Card>
  <bs:CardListGroup DataSource="{value: Texts}" ItemText="{value: _this}" />
  <bs:CardListGroup class="mb-1">
    <bs:ListGroupText Text="Item 1" />
    <bs:ListGroupText Text="Item 2" />
    <bs:ListGroupText Text="Item 3" />
    <bs:ListGroupText Text="Item 4" />
  </bs:CardListGroup>
</bs:Card>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public string[] Texts { get; } = new[] { "red", "green", "blue" };

    public void DoSomething() 
    {

    }
}
```

