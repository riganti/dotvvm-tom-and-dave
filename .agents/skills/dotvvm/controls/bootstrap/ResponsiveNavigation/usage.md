# <bs:ResponsiveNavigation>
Renders a Bootstrap Navbar widget.

<https://getbootstrap.com/docs/3.3/components/#navbar>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CollapseButtonTemplate`|ITemplate|Gets or sets the template items for collapse button.|inner element, static value||
|`ContainerType`|([ContainerType](../_enums/DotVVM.Framework.Controls.Bootstrap.ContainerType.md))|Gets or sets whether the menu should render as a fluid container or a normal container. The default is fluid container.|attribute, static value|Fluid|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`FixedTo`|([ResponsiveNavigationFixedTo](../_enums/DotVVM.Framework.Controls.Bootstrap.ResponsiveNavigationFixedTo.md))|Gets or sets to which part of screen is ResponsiveNavigation fixed to.|attribute, static value|Nothing|
|`HeaderImageUrl`|String|Gets or sets image url that will be put in header. If HeaderText is set it will be used as alternate image text.|attribute, static value, bindable||
|`HeaderLinkUrl`|String|Gets or sets url which will be Header linked to.|attribute, static value, bindable||
|`HeaderText`|String|Gets or sets text that will be put in header. If HeaderImage is set this text will be used as alternate image text.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsInverted`|Boolean|Gets or sets if colors of ResponsiveNavigation are inverted.|attribute, static value, bindable|False|
|`IsResponsivelyCollapsing`|Boolean||attribute, static value, bindable|False|
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`IsStaticTop`|Boolean|Gets or sets value indicating whether it is full-width navbar that scrolls away with the page.             It removes the left, right and top border so that it looks better at the top of the page.|attribute, static value|False|
|`Items`|List<IListItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`LeftAlignedItemsTemplate`|ITemplate|Gets or sets the template items that will be aligned to left.|inner element, static value||
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`RightAlignedItemsTemplate`|ITemplate|Gets or sets the template items that will be aligned to right.|inner element, static value||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic Usage

Each menu item in the `ResponsiveNavigation` control is represented by the [NavigationItem](~/controls/bootstrap/NavigationItem) control. 

The `HeaderText` property specifies the text that will be placed in the logo section of the navbar. 
If the `HeaderLinkUrl` property is set, the header will be rendered as a hyperlink for that URL.

```DOTHTML
<bs:ResponsiveNavigation HeaderText="Header" HeaderLinkUrl="http://www.dotvvm.com">
  <bs:NavigationItem NavigateUrl="https://www.google.com/" 
                     Text="Google"
                     IsSelected="true" />
  <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/"
                     Text="W3 Schools"
                     IsDisabled="true" />
</bs:ResponsiveNavigation>
```

## Sample 2: Advanced ResponsiveNavigation

If the `HeaderImageUrl` is set, the header section will render the image and the value of the `HeaderText` property will be used for the alternate text of the image.

The `IsInverted` property can switch the navbar to the inverse colors.

The `IsStaticTop` property controls whether the `ResponsiveNavigation` is full-width navbar that scrolls away with the page. 
It also removes the left, right and top border to make it look better at the top of the page.


```DOTHTML
<bs:ResponsiveNavigation 
        HeaderImageUrl="~/Images/person.png" 
        HeaderText="Alt text for image" 
        HeaderLinkUrl="http://www.dotvvm.com" 
        IsInverted="true" 
        IsStaticTop="true">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" />
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" />
</bs:ResponsiveNavigation>
```

## Sample 3: Fixed ResponsiveNavigation and Alignment

The `ResponsiveNavigation` has also the `FixedTo` property which controls whether the navbar is fixed to *Top* or *Bottom* of the screen, or fixed to *Nothing* (which is the default value).

The items inside the `ResponsiveNavigation` can also be aligned to the left or right side by placing the items into the `LeftAlignedItemsTemplate` and `RightAlignedItemsTemplate` properties.   
If you need to use other items than [NavigationItem](~/controls/bootstrap/NavigationItem) (e.g. the [DropDownButton](~/controls/bootstrap/DropDownButton), 
you have to place them in the `LeftAlignedItemsTemplate` or `RightAlignedItemsTemplate` element.

```DOTHTML
<bs:ResponsiveNavigation HeaderText="Fixed to top" FixedTo="Top">
  <RightAlignedItemsTemplate>
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" />
  </RightAlignedItemsTemplate>
  <LeftAlignedItemsTemplate>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" />
  </LeftAlignedItemsTemplate>
</bs:ResponsiveNavigation>
```

## Sample 4: DropDownButton and Form Controls in ResponsiveNavigation

You can also use other control inside the `ResponsiveNavigation` control.
You have to place them in the  `LeftAlignedItemsTemplate` or `RightAlignedItemsTemplate` elements.

There are some limitations of the Bootstrap navbar. For example, we don't recommend to use the `Label` properties on the `<bs:Form>` because it won't render correctly.

```DOTHTML
<bs:ResponsiveNavigation>
  <LeftAlignedItemsTemplate>
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true" />
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" IsDisabled="true" />
    <bs:DropDownButton Text="DropDownButton">
      <Items>
        <bs:DropDownButtonItem NavigateUrl="https://www.google.com/">
          Google
        </bs:DropDownButtonItem>
        <bs:DropDownButtonItem NavigateUrl="https://github.com/riganti/dotvvm">
          DotVVM
        </bs:DropDownButtonItem>
      </Items>
    </bs:DropDownButton>
  </LeftAlignedItemsTemplate>
  <RightAlignedItemsTemplate>
    <bs:Form>
      <bs:FormGroup>
        <dot:TextBox Text="TEST" />
      </bs:FormGroup>
    </bs:Form>
  </RightAlignedItemsTemplate>
</bs:ResponsiveNavigation>
```

## Sample 5: Responsiveness

It's possible to collapse the `ResponsiveNavigation` into a single button when the content cannot fit the screen. 

To do so, you have to the change the value of the `AllowCollapsingToButton` property to *true*.

Optionally, you can set your own content of the collapsed button by placing in into the `CollapsedButtonTemplate` template. 
If the `CollapsedButtonTemplate` is not set, the standard button with three stripes will be rendered.

```DOTHTML
<bs:ResponsiveNavigation 
    HeaderText="If this menu cannot fit screen it will collapse to button." 
    IsResponsivelyCollapsing="true">
  <CollapseButtonTemplate>
    <bs:GlyphIcon Icon="Arrow_down" />
  </CollapseButtonTemplate>
  <bs:NavigationItem NavigateUrl="https://www.google.cz/" Text="Google" />
  <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" />
</bs:ResponsiveNavigation>
```

## Sample 6: ResponsiveNavigation Data-Binding

The `ResponsiveNavigation` can be also used with the `DataSource` property to generate the menu items from the collection.

The `TextBinding` property specifies which property of the collection items will be used as the text of the menu item.

The `NavigateUrlBinding` property specifies which property will be used as the URL of the hyperlink.

You can also use the `IsDisabledBinding` to specify which property controls whether the menu item is disabled or enabled.

Also, there is the `IsSelectedBinding` property which controls whether the menu item is selected.

```DOTHTML
<bs:ResponsiveNavigation DataSource="{value: LinksDataSet}" IsDisabledBinding="{value: IsDisabled}" IsSelectedBinding="{value: IsSelected}"
					  TextBinding="{value: Text}" NavigateUrlBinding="{value:  NavigateUrl}">
</bs:ResponsiveNavigation>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ResponsiveNavigation.sample6
{
    public class ViewModel
    {
        public List<NavigationItem> LinksDataSet { get; set; }

        private static IQueryable<NavigationItem> GetData()
        {
            return new[]
            {
                new NavigationItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google"},
                new NavigationItem() {  IsDisabled = true, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools"},
                new NavigationItem() {  IsDisabled = false, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft"},
                new NavigationItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github"}
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

