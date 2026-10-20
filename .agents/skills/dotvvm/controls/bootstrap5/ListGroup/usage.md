# <dot:ListGroup>
Renders a Bootstrap list group of items, links or buttons.

<https://getbootstrap.com/docs/5.2/components/list-group>

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
|`IsTabList`|Boolean|If set to true, `role` attribute is set to `tablist`|attribute, static value|False|
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

## Sample 1: Basic ListGroup

Each item inside the `ListGroup` is represented by the [ListGroupButton](~/controls/bootstrap5/ListGroupButton), [ListGroupLink](~/controls/bootstrap5/ListGroupLink) or [ListGroupText](~/controls/bootstrap5/ListGroupText) control.

Place the items inside the `ListGroup`.


```DOTHTML
<bs:ListGroup>
  <bs:ListGroupText Text="{value: Text}" />
  <bs:ListGroupText Text="Item 2" />
  <bs:ListGroupText Text="Item 3" />
  <bs:ListGroupText>
    <h3>Custom content</h3>
    <p>Custom list item content</p>
  </bs:ListGroupText>
</bs:ListGroup>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; } = "Data-bound text of the item.";
}
```

## Sample 2: ListGroup - Item types

The `ListGroup` control has the `ItemType` property which specified the type of list group items - `Default`, `Link` and `Button`. With each item type, different wrapper tag is rendered.

```DOTHTML
<%--div and button tags--%>
<bs:ListGroup ItemType="Button">
    <bs:ListGroupButton Text="Item 2" />
    <bs:ListGroupButton Text="{value: Text}" />
</bs:ListGroup>

<%--Div and a tags--%>
<bs:ListGroup ItemType="Link">
    <bs:ListGroupLink Text="Item 2" Color="Danger" />
    <bs:ListGroupLink Text="{value: Text}" Color="Success" />
    <bs:ListGroupLink Text="{value: Text}" Enabled="False" />
    <bs:ListGroupLink Selected="True">
        <h3>Custom content</h3>
        <p>Custom list item content</p>
    </bs:ListGroupLink>
</bs:ListGroup>

<%--Ul and li tags--%>
<bs:ListGroup>
    <bs:ListGroupText Text="Item 2" Color="Danger" />
    <bs:ListGroupText Text="{value: Text}" Color="Success" />
    <bs:ListGroupText Text="{value: Text}" Enabled="False" />
    <bs:ListGroupText Selected="True">
        <h3>Custom content</h3>
        <p>Custom list item content</p>
    </bs:ListGroupText>
</bs:ListGroup>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; } = "This is sample text.";
}
```

## Sample 3: DataSource and Item* bindings

The `DataSource` property can be used to generate the items from an `IEnumerable` in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `ItemText` specifies the property of the collection elements to be used as list item text.
* `ItemColor` specifies the property of the collection elements to be used as list item color.
* `ItemNavigateUrl` specifies the property of the collection elements to be used as list item link URL.
* `ItemIsEnabled` specifies the property of the collection elements indicating whether the list item is enabled or not.
* `ItemIsSelected` specifies the property of the collection elements indicating whether the list item is active or not.
* `ItemClick` specifies a command in the viewmodel to be called when the list item is clicked.

```DOTHTML
<bs:ListGroup ItemType="Link" 
              DataSource="{value: LinksDataSet}" 
              ItemEnabled="{value: IsEnabled}" 
              ItemSelected="{value: IsSelected}" 
              ItemText="{value: Text}" 
              ItemColor="{value: Color}" 
              ItemNavigateUrl="{value: NavigateUrl}" />
```

```CSHARP
 public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> LinksDataSet => new List<LinkItem>()
        {
            new LinkItem() { IsEnabled = true, IsSelected = false, NavigateUrl = "/bootstrap4-4.0/?url=https://www.google.com/", Text = "Google", Color = ListGroupItemColor.Info },
            new LinkItem() { IsEnabled = true, IsSelected = false, NavigateUrl = "/bootstrap4-4.0/?url=http://www.w3schools.com/html/", Text = "W3Schools", Color = ListGroupItemColor.Success },
            new LinkItem() { IsEnabled = true, IsSelected = true, NavigateUrl = "/bootstrap4-4.0/?url=https://www.microsoft.com/en-us/", Text = "Microsoft", Color = ListGroupItemColor.Warning },
            new LinkItem() { IsEnabled = false, IsSelected = false, NavigateUrl = "/bootstrap4-4.0/?url=https://github.com/riganti/dotvvm", Text = "DotVVM Github", Color = ListGroupItemColor.Danger }
        };

    }

    public class LinkItem
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public bool IsSelected { get; set; }
        public bool IsEnabled { get; set; }
        public ListGroupItemColor Color { get; set; }

    }

```

## Sample 4: DataSource and ItemClick binding

The `ItemClick` property can be used when the list group contains the buttons.

```DOTHTML
<bs:ListGroup ItemType="Button" 
              DataSource="{value: Values}" 
              ItemText="{value: _this}" 
              ItemClick="{command: _parent.Select(_this)}" />

Selected item: {{value: SelectedValue}}

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<string> Values => new List<string>() { "one", "two", "three" };

    public string SelectedValue { get; set; }


    public void Select(string value)
    {
        SelectedValue = value;
    }
}
```

## Sample 5: Badges

The list items can contain [Badge](~/controls/bootstrap5/Badge) controls. Use the `Badge` inner element property to specify the badge contents.

```DOTHTML
<bs:ListGroup>
  <bs:ListGroupText Text="{value: Text}">
      <BadgeTemplate>
        14
      </BadgeTemplate>
  </bs:ListGroupText>
  <bs:ListGroupText IsJustified="true" Text="Item 2" BadgeType="Danger" BadgeVisualStyle="Pill">
      <BadgeTemplate>
        2
      </BadgeTemplate>
  </bs:ListGroupText>
</bs:ListGroup>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; } = "Data-bound text of the item.";
}
```

## Sample 6: Group types

Set `GroupType` as `Flush` to remove some borders and rounded corners to render list group items edge-to-edge in a parent container (e.g., cards). Set `GroupType` as `Numbered` to opt into numbered list group items.

**Flush mode cannot be combined with horizontal `ListGroup`**

```DOTHTML
<h3>Flush list group</h3>
<bs:ListGroup ItemType="Link" GroupTypes="Flush">
  <bs:ListGroupLink Text="Ab" Color="Danger" />
  <bs:ListGroupLink Text="Cd" Color="Dark" />
  <bs:ListGroupLink Text="Ef" Color="Info" />
</bs:ListGroup>
<h3>Numbered and Flush list group</h3>
<bs:ListGroup GroupTypes="Numbered, Flush">
    <bs:ListGroupText Text="Ab" />
    <bs:ListGroupText Text="Cd" />
    <bs:ListGroupText Text="Ef" />
</bs:ListGroup>
<h3>Numbered and Horizontal list group</h3>
<bs:ListGroup ItemType="Button" Orientation="Horizontal" GroupTypes="Numbered">
  <bs:ListGroupButton Text="Ab" />
  <bs:ListGroupButton Text="Cd" />
  <bs:ListGroupButton Text="Ef" />
</bs:ListGroup>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; } = "Data-bound text of the item.";
}
```

## Sample 7: Orientation and responsibility

The `Orientation` property controls whether the ListGroup would be `Horizontal` or `Vertical`.

When using `Horizontal` ListGroup, than we can also use `ForceVerticalOrientationBreakpoint` to set when the ListGroup should change from `Horizontal` to `Vertical`.  
If set to `None` than the ListGroup will never change to `Vertical`.

```DOTHTML
<bs:ListGroup data-ui="list-group-md" Orientation="Horizontal" ForceVerticalOrientationBreakpoint="Medium">
  <bs:ListGroupText Text="1" />
  <bs:ListGroupText Text="2" />
  <bs:ListGroupText Text="3" />
  <bs:ListGroupText Text="4" />
  <bs:ListGroupText Text="5" />
</bs:ListGroup>
```

