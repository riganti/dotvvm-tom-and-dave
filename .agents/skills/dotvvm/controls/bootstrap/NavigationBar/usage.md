# <bs:NavigationBar>
Renders a Bootstrap Navs widget.

<https://getbootstrap.com/docs/3.3/components/#nav>

If you want to create a responsive menu (NavBar), use the [ResponsiveNavigation](~/controls/bootstrap/ResponsiveNavigation) control instead.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsJustified`|Boolean|Gets or sets whether the items should be justified to fill all available space in the horizontal direction.|attribute, static value|False|
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IListItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Type`|([NavigationBarType](../_enums/DotVVM.Framework.Controls.Bootstrap.NavigationBarType.md))|Gets or sets the type of the navigation bar.|attribute, static value|Tabs|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic Usage

The `NavigationItem` control has the `NavigateUrl` property which specifies target URL, or the `Click` property which invokes a command on the viewmodel.

The `Text` property defines the contents of the item. Alternatively, you can also place the contents inside the control.

The `IsSelected` and `IsDisabled` properties define whether the control gets the active or disabled CSS classes.

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

The `Type` and `IsJustified` properties can modify the visual appearance of the navigation bar.

```DOTHTML
<bs:NavigationBar Type="Pills">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
<br />
<bs:NavigationBar Type="PillsStacked">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
<br />
<bs:NavigationBar Type="Tabs">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
<br />
<bs:NavigationBar IsJustified="true">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true"/>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3Schools"/>
</bs:NavigationBar>
```

## Sample 3: Data Binding Navigation Items

The `NavigationBar` control can also generate the items from a collection in the viewmodel.

The `DataSource` property define the collection of objects which will be used to create the list items.  

Using the following properties, you can specify, which properties of objects in the collection will be used to configure the navigation items.

+ `ClickBinding`
+ `IsDisabledBinding`
+ `IsSelectedBinding`
+ `NavigateUrlBinding`
+ `TextBinding`

```DOTHTML
<bs:NavigationBar Type="Pills" IsJustified="true" 
                  DataSource="{value: LinksDataSet}" 
                  IsDisabledBinding="{value: IsDisabled}" 
                  IsSelectedBinding="{value: IsSelected}"
                  TextBinding="{value: Text}" 
                  NavigateUrlBinding="{value:  NavigateUrl}" />
```

```CSHARP
using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.NavigationBar.sample3
{
    public class ViewModel
    {
        public List<NavigationItem> LinksDataSet { get; set; }

        private static IQueryable<NavigationItem> GetData()
        {
            return new[]
            {
                new NavigationItem() { NavigateUrl = "https://www.google.com/", Text = "Google" },
                new NavigationItem() { NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools" },
                new NavigationItem() { IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft" },
                new NavigationItem() { IsDisabled = true, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github" }
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
        public bool IsDisabled { get; set; }
    }
}
```

