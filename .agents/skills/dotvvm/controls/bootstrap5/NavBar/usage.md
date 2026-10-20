# <dot:NavBar>
Renders responsive and customizable Bootstrap navigation widget.

<https://getbootstrap.com/docs/5.2/components/navbar/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BrandImageHeight`|String|Gets or sets the brand image height.|attribute, static value||
|`BrandImageUrl`|String|Gets or sets the brand image URL.|attribute, static value||
|`BrandImageWidth`|String|Gets or sets the brand image width.|attribute, static value||
|`BrandLinkUrl`|String|Gets or sets the navigation link for brand image.|attribute, static value||
|`BrandTemplate`|ITemplate|Gets or sets the a custom template for brand section of the navigation.|inner element, static value||
|`BrandText`|String|Gets or sets the a plain text for brand section of the navigation.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CollapseBehavior`|([NavbarCollapseBehavior](../_enums/DotVVM.Bootstrap5.Controls.NavbarCollapseBehavior.md))|Gets or sets the maximum screen to which navbar control can expand.|attribute, static value, bindable|CollapseOnLarge|
|`Content`|List<INavBarSection>|Gets or sets the inner elements containing only NavText, NavLink, and NavDropDown controls.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerContainerResponsiveBreakpoint`|([ContainerResponsiveBreakpoints](../_enums/DotVVM.Bootstrap5.Controls.ContainerResponsiveBreakpoints.md))|Gets or sets the navigation container size. The default is Fluid, so the navigation takes all available space.|attribute, static value|Fluid|
|`Justify`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for navigation items.|attribute, static value, bindable|None|
|`Placement`|([NavBarPlacement](../_enums/DotVVM.Bootstrap5.Controls.NavBarPlacement.md))|Gets or sets the navbar placement. Possible values are Default, FixedTop, FixedBottom, StickyTop, StickyBottom.|attribute, static value, bindable|Default|
|`TogglerPlacement`|([NavBarTogglerPlacement](../_enums/DotVVM.Bootstrap5.Controls.NavBarTogglerPlacement.md))|Gets or sets the placement of a hamburger menu. Possible values are Left or Right.|attribute, static value|Right|
|`Type`|([NavBarType](../_enums/DotVVM.Bootstrap5.Controls.NavBarType.md))|Gets or sets the navbar background color.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The `NavBar` control can contain any number of child controls.

The following controls are supported inside `NavBar`:

* [NavBarText](~/controls/bootstrap5/NavBarText)
* [NavBarSection](~/controls/bootstrap5/NavBarSection)


```DOTHTML
<bs:NavBar>
    <bs:NavBarText>
       Simple text!
    </bs:NavBarText>
    <bs:NavBarSection>
        <bs:NavBarLink Click="{staticCommand: null}">
            Link item
        </bs:NavBarLink>
        <bs:NavBarDropDown HeaderText="DropDownMenu">
            <bs:DropDownItem>
                item
            </bs:DropDownItem>
            <bs:DropDownItem Enabled="false">
                item
            </bs:DropDownItem>
        </bs:NavBarDropDown>
    </bs:NavBarSection>
</bs:NavBar>
```

## Sample 2: NavBar Brand options

You can customize the navigation with your brand using properties with `Brand` prefix

```DOTHTML
<h3>Brand BrandImageUrl and BrandLinkUrl</h3>
<bs:NavBar BrandImageUrl="https://via.placeholder.com/50?text=Brand" BrandLinkUrl="https://www.dotvvm.com" backgroundColor="Primary">
    <bs:NavBarSection>
        <bs:NavBarLink Click="{staticCommand: null}">
            item
        </bs:NavBarLink>
        <bs:NavBarDropDown HeaderText="DropDownMenu">
            <bs:DropDownItem>
                item
            </bs:DropDownItem>
        </bs:NavBarDropDown>
    </bs:NavBarSection>
</bs:NavBar>

<h3>Brand Placement HiddenWhenCollapsed</h3>
<bs:NavBar BrandPlacement="HiddenWhenCollapsed" backgroundColor="Danger">
    <BrandTemplate>
        Brand Placement HiddenWhenCollapsed
    </BrandTemplate>
    <bs:NavBarSection>
        <bs:NavBarLink Click="{staticCommand: null}">
            item
        </bs:NavBarLink>
        <bs:NavBarDropDown HeaderText="DropDownMenu">
            <bs:DropDownItem>
                item
            </bs:DropDownItem>
        </bs:NavBarDropDown>
    </bs:NavBarSection>
</bs:NavBar>

<h3>BrandTemplate</h3>
<bs:NavBar backgroundColor="Warning">
    <BrandTemplate>
       <bs:Icon Type="Activity" />
        You can put here anything!
    </BrandTemplate>
    <bs:NavBarSection>
        <bs:NavBarLink Click="{staticCommand: null}">
            item
        </bs:NavBarLink>
        <bs:NavBarDropDown HeaderText="DropDownMenu">
            <bs:DropDownItem>
                item
            </bs:DropDownItem>
        </bs:NavBarDropDown>
    </bs:NavBarSection>
</bs:NavBar>
```

## Sample 3: Generated Navigation Items

The `NavBar` control cannot directly generate the items from a collection in the viewmodel but can use a [NavBarSection](~/controls/bootstrap5/NavBarSection) control as showed in sample bellow.


```DOTHTML
<bs:NavBar >
    <BrandTemplate>
        Brand Name
    </BrandTemplate>
    <bs:NavBarSection DataSource="{value: LinksDataSet}"
                      ItemIsSelected="{value: IsSelected}"
                      ItemText="{value: Text}"
                      ItemNavigateUrl="{value: NavigateUrl}" />
    <bs:NavBarText>
        text
    </bs:NavBarText>
</bs:NavBar>
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

## Sample 5: Navigation Placement and Items Positions

The navigation control has a few options how to be placed:

* `Default` the navigation has a static position
* `FixedTop` the navigation is fixed to the top
* `FixedBottom` the navigation is fixed on the bottom
* `StickyTop` scrolls with the page until it reaches the top, then stays there
* `StickyBottom` scrolls with the page until it reaches the bottom, then stays there

`NavBar` property `Justify` allows adding a flex CSS utility class to position the navigation items in a specific way. 

```DOTHTML
<h3>IsJustified = End</h3>
<bs:NavBar Justify="End" Placement="FixedTop" backgroundColor="Primary">
    <BrandTemplate>
        Brand Name
    </BrandTemplate>
    <bs:NavBarSection>
        <bs:NavBarLink Click="{staticCommand: null}">
            item
        </bs:NavBarLink>
        <bs:NavBarDropDown HeaderText="DropDownMenu">
            <bs:DropDownItem>
                item
            </bs:DropDownItem>
        </bs:NavBarDropDown>
    </bs:NavBarSection>
</bs:NavBar>

<bs:NavBar Justify="Center" Placement="FixedBottom" backgroundColor="Primary">
    <BrandTemplate>
        Brand Name
    </BrandTemplate>
    <bs:NavBarSection>
        <bs:NavBarLink Click="{staticCommand: null}">
            item
        </bs:NavBarLink>
        <bs:NavBarDropDown HeaderText="DropDownMenu">
            <bs:DropDownItem>
                item
            </bs:DropDownItem>
        </bs:NavBarDropDown>
    </bs:NavBarSection>
</bs:NavBar>
```

