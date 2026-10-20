# <bs:NavigationBar>
Renders a Bootstrap Navs widget.

<https://getbootstrap.com/docs/4.3/components/navs/>

If you want to create a responsive menu (Navbar), use the [ResponsiveNavigation](~/controls/bootstrap/ResponsiveNavigation) control instead.

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
|`Items`|List<INavigationItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`ItemsLayout`|([ItemsLayout](../_enums/DotVVM.Framework.Controls.Bootstrap4.ItemsLayout.md))|Gets or sets layout of inner items.|attribute, static value|Default|
|`ItemType`|([NavigationItemType](../_enums/DotVVM.Framework.Controls.Bootstrap4.NavigationItemType.md))|Gets or sets the type of the items.|attribute, static value|Default|
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`ScrollSpyEnabled`|Boolean||attribute, static value, bindable|False|
|`ScrollSpyOffset`|Int32||attribute, static value|10|
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([NavigationBarVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.NavigationBarVisualStyle.md))|Gets or sets the type of the navigation bar.|attribute, static value|Tabs|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic Usage

The `NavigationBar` control has the `ItemType` property which specified the type of list group items - `Default`, `Link` and `Button`.

Use [NavigationItem](~/controls/bootstrap4/NavigationItem) controls inside the navigation bar.

```DOTHTML
<bs:NavigationBar>
    <bs:NavigationItem NavigateUrl="https://www.google.com/" 
                       Text="Google" 
                       IsSelected="true" />
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" 
                       Text="W3 Schools" 
                       IsDisabled="true" />
</bs:NavigationBar>
```

## Sample 2: NavigationBar Appearance

The `VisualStyle` property specifies how the navigation bar should look like - `Tabs`, `Pills` and `Simple`.

The `ItemsLayout` property defines whether the navigation items should occupy all available horizontal space.

```DOTHTML
<bs:NavigationBar VisualStyle="Pills">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
<br />
<bs:NavigationBar VisualStyle="Tabs">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
<br />
<bs:NavigationBar ItemsLayout="StretchEvenly">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
<br />
<bs:NavigationBar ItemsLayout="Stretch">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
```

## Sample 3: Data-Binding Navigation Items

The `NavigationBar` control can also generate the items from a collection in the viewmodel.

The `DataSource` property define the collection of objects which will be used to create the list items.  

Using the following properties, you can specify, which properties of objects in the collection will be used to configure the navigation items.

+ `ClickBinding`
+ `IsEnabledBinding`
+ `IsSelectedBinding`
+ `NavigateUrlBinding`
+ `TextBinding`

```DOTHTML
<bs:NavigationBar Type="Pills" IsJustified="true" 
                  DataSource="{value: LinksDataSet}" 
                  IsEnabledBinding="{value: IsEnabled}" 
                  IsSelectedBinding="{value: IsSelected}"
                  TextBinding="{value: Text}" 
                  NavigateUrlBinding="{value:  NavigateUrl}" />
```

```CSHARP
public class ViewModel
{
    public List<NavigationItem> LinksDataSet { get; set; }

    private static IQueryable<NavigationItem> GetData()
    {
        return new[]
        {
            new NavigationItem() { IsEnabled = true, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google" },
            new NavigationItem() { IsEnabled = true, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools" },
            new NavigationItem() { IsEnabled = true, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft" },
            new NavigationItem() { IsEnabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github" }
        }.AsQueryable();
    }

    public ViewModel()
    {
        LinksDataSet = new List<NavigationItem>();
        foreach (NavigationItem l in GetData())
        {
            LinksDataSet.Add(l);
        }
    }

}


public class NavigationItem
{
    public string Text { get; set; }
    public string NavigateUrl { get; set; }
    public bool IsSelected { get; set; }
    public bool IsEnabled { get; set; }
}
```

