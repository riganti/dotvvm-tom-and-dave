# <dot:NavBarSection>
Represents an section in [NavBar](~/controls/bootstrap5/NavBar).

<https://getbootstrap.com/docs/5.2/components/navbar/>


The `DataSource` property define the collection of objects which will be used to create the navigation items.

Using the following properties, you can specify, which properties of objects in the collection will be used to configure the navigation items.

* `ItemText` specifies the property of the collection elements to be used as navigation item text.
* `ItemNavigateUrl` specifies the property of the collection elements to be used as navigation item link URL.
* `ItemEnabled` specifies the property of the collection elements indicating whether the navigation item is enabled or not.
* `ItemSelected` specifies the property of the collection elements indicating whether the navigation item is active or not.
* `ItemClick` specifies a command in the viewmodel to be called when the navigation item is clicked.
* `ItemVisible` specifies the property of the collection elements indicating whether the navigation item is visible or not.
* `ItemID` specifies the property of the collection elements indicating navigation item ID.
* `ItemTemplate` specifies a custom template for navigation item.
* `ItemUrlSuffix` specifies the property of the collection elements indicating the URL suffix for navigation item.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsScrollable`|Boolean|Gets or sets whether the vertical scrollbar should be displayed when the navigation is collapsed and takes more than 75% of the viewport height.|attribute, static value, bindable|False|
|`ItemEnabled`|Boolean|Gets or sets whether the navigation item is enabled when DataSource is set.|attribute, static value, bindable|True|
|`ItemID`|String|Gets or sets the navigation item ID when DataSource is set.|attribute, static value, bindable||
|`ItemNavigateUrl`|String|Gets or sets a URL for navigation item when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets a route name for navigation item when DataSource is set.|attribute, static value||
|`Items`|List<INavItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether the navigation item is selected when DataSource is set.|attribute, static value, bindable||
|`ItemTarget`|String||attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets a custom template for navigation item when DataSource is set.|inner element, static value||
|`ItemText`|String|Gets or sets a plain text for navigation item when DataSource is set.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets a URL suffix for navigation item when DataSource is set.|attribute, static value, bindable||
|`ItemVisible`|Boolean|Gets or sets whether the navigation item is visible when DataSource is set.|attribute, static value, bindable|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets a click action for navigation item when DataSource is set.|

## Sample 1: Generated Navigation Items

The `NavBar` control cannot directly generate the items from a collection in the viewmodel but can use a [NavBarSection](~/controls/bootstrap5/NavBarSection) control.


```DOTHTML
<bs:NavBar>
    <BrandTemplate>
        Brand Name
    </BrandTemplate>
    <bs:NavBarSection Datasource="{value: ItemSectionsSource}" ItemText="{value: Text}" ItemNavigateUrl="{value: Url}"/>
    <bs:NavBarText>
        text
    </bs:NavBarText>
</bs:NavBar>

<bs:NavBar>
    <BrandTemplate>
        Brand Name
    </BrandTemplate>
    <bs:NavBarSection Datasource="{value: ItemSectionsSource}" ItemNavigateUrl="{value: Url}"  >
        <ItemTemplate>
            <bs:Icon Type="{value: IconType}" />
            {{value: Text}}
        </ItemTemplate>
    </bs:NavBarSection>
</bs:NavBar>
```

```CSHARP
public class ViewModel
{
    public List<ItemSectionModel> ItemSectionsSource { get; set; }

    public ViewModel()
    {
        ItemSectionsSource = new List<ItemSectionModel>()
        {
            new ItemSectionModel()
            {
                Text = "Riganti",
                Url = "https://riganti.cz/",
                Visible = false,
                IconType = Icons.Window_Desktop
            },
            new ItemSectionModel()
            {
                Text = "Google",
                Url = "https://www.google.com/",
                Selected = true,
                Visible = true,
                IconType = Icons.Window_Dock
            },
        };
    }
}


public class ItemSectionModel
{
    public string Text { get; set; }
    public string Url { get; set; }
    public Icons IconType { get; set; }
    public bool Visible { get; set; }
    public bool Selected { get; set; }
}
```

