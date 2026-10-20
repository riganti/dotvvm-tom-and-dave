# <bs:Breadcrumb>
Renders a Bootstrap breadcrumb navigation control with data-binding support.

<https://getbootstrap.com/docs/4.3/components/breadcrumb/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IBreadcrumbItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`RenderLinkForSelectedItem`|Boolean|Gets or sets whether a hyperlink should be rendered for selected breadcrumb items. If set to false, no link will be rendered.|attribute, static value|False|
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Static Breadcrumbs

You can place `<bs:BreadcrumbItem>` elements inside the `Breadcrumbs` control. 

* The `Text` property or the contents inside the `BreadcrumbItem` element specifies the text of the menu item.
* You may set `NavigateUrl` to make the badge to link to a specific URL.
* The `Click` event can be used to invoke a command in the viewmodel.
* You may also use `RouteName`, `Param-*`, `Query-*` and `UrlSuffix` properties to build a link from a route table. See [RouteLink](~/controls/builtin/RouteLink) for details.

The `BreadcrumbItem` inherits from the [ListItem](~/controls/bootstrap4/ListItem) and uses the same properties.

```DOTHTML
<bs:Breadcrumb>
  <bs:BreadcrumbItem NavigateUrl="https://www.google.com/"
                     Text="Google"/>

  <bs:BreadcrumbItem NavigateUrl="http://www.w3schools.com/"
                     Text="Wc3Schools"
                     Enabled="false"/>

  <bs:BreadcrumbItem RouteName="Breadcrumb_sample1"
                     Param-Id="{value: Test}"
                     Text="Route link" />

  <bs:BreadcrumbItem Click="{command: ItemClicked()}"
                     Text="Clickable item" />
</bs:Breadcrumb>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Test { get; set; } = "Test";

    public void ItemClicked() 
    {
        
    }

}

```

## Sample 2: Selected Items

The `IsSelected` property defines whether the list item is selected or not. 

Selected items are not clickable by default - the links are not rendered. You can set `RenderLinkForSelectedItem` to `true` if you want to render links even for selected items.

```DOTHTML
<bs:Breadcrumb RenderLinkForSelectedItem="true">

  <bs:BreadcrumbItem NavigateUrl="https://www.google.com/"
                     Text="Google"/>

  <bs:BreadcrumbItem RouteName="Breadcrumb_sample2"
                     Param-Id="{value: Test}"
                     Text="Route link"
                     IsSelected="true" />

</bs:Breadcrumb>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Test { get; set; } = "abc";

}
```

## Sample 3: Data-bound Breadcrumbs

If you want to data-bind the items inside the `Breadcrumbs` control, use the `DataSource` property. This property expects `IEnumerable`. 

Using the `TextBinding`, `NavigateUrlBinding`, `IsSelectedBinding`, `IsEnabledBinding` and `ClickBinding`, you can declare how the generated items will look.
Bindings in these properties are evaluated for every collection item and set to the corresponding properties of the generated list items.

```DOTHTML
<bs:Breadcrumb DataSource="{value: Links}"
               IsEnabledBinding="{value: IsEnabled}"
               IsSelectedBinding="{value: IsSelected}"
               TextBinding="{value: Text}"
               NavigateUrlBinding="{value: NavigateUrl}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<LinkItem> Links { get; set; }

    public ViewModel()
    {
        Links = new List<LinkItem>()
        {
            new LinkItem()
            {
                IsEnabled = true,
                IsSelected = false,
                NavigateUrl = "https://www.google.com/",
                Text = "Google"
            },
            new LinkItem()
            {
                IsEnabled = false,
                IsSelected = false,
                NavigateUrl = "http://www.w3schools.com/html/",
                Text = "W3Schools"
            },
            new LinkItem()
            {
                IsEnabled = false,
                IsSelected = true,
                NavigateUrl = "https://www.microsoft.com/en-us/",
                Text = "Microsoft"
            },
            new LinkItem()
            {
                IsEnabled = false,
                IsSelected = false,
                NavigateUrl = "https://github.com/riganti/dotvvm",
                Text = "DotVVM Github"
            }
        };
    }

}

public class LinkItem
{
    public string Text { get; set; }
    public string NavigateUrl { get; set; }
    public bool IsSelected { get; set; }
    public bool IsEnabled { get; set; }

}

```

