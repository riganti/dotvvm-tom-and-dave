# <bs:ResponsiveNavigation>
Renders a Bootstrap Navbar widget.

Each menu item in the `ResponsiveNavigation` control is represented by the [NavigationItem](~/controls/bootstrap4/NavigationItem) control. 
You can also use [Form](~/controls/bootstrap4/Form) and [DropDownButton](~/controls/bootstrap4/DropDownButton) controls inside the navigation bar.

<https://getbootstrap.com/docs/4.3/components/navbar/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CollapseButtonTemplate`|ITemplate|Gets or sets the template items for collapse button.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`HeaderImageAltText`|String|Gets or sets alternative text for image.|attribute, static value, bindable||
|`HeaderImageTooltip`|String|Gets or sets Tooltip (Title) for image.|attribute, static value, bindable||
|`HeaderImageUrl`|String|Gets or sets image URL that will be put in header. If HeaderText is set it will be used as alternate image text.|attribute, static value, bindable||
|`HeaderLinkUrl`|String|Gets or sets URL which will be Header linked to.|attribute, static value, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets inner content of header link.|inner element, static value||
|`HeaderText`|String|Gets or sets text that will be put in header. If HeaderImage is set this text will be used as alternate image text.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`LeftAlignedItems`|List<IResponsiveNavigationItem>|Gets or sets a collection of responsive navigation items which would be aligned to the left.|inner element, static value, default property||
|`MaximumScreenSizeBeforeCollapse`|([ResponsiveBreakpoints](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveBreakpoints.md))|Gets or sets the maximum screen size in which the navbar should still be collapsed.             Setting to none will disable collapsing.|attribute, static value|Medium|
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`RightAlignedItems`|List<IResponsiveNavigationItem>|Gets or sets a collection of responsive navigation items which would be aligned to the right.|inner element, static value||
|`ScrollBehavior`|([ResponsiveNavigationScrollBehavior](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveNavigationScrollBehavior.md))|Gets or sets how would ResponsiveNavigation react when It's scrolled out of screen.|attribute, static value|None|
|`ScrollSpyEnabled`|Boolean||attribute, static value, bindable|False|
|`ScrollSpyOffset`|Int32||attribute, static value|10|
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Theme`|([ResponsiveNavigationTheme](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveNavigationTheme.md))|Gets or sets color theme of the navbar. Use ColorDecorators to set text and background colors.|attribute, static value|Light|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic Usage

The `HeaderText` property specifies the text that will be placed in the logo section of the navbar. 

If the `HeaderLinkUrl` property is set, the header will be rendered as a hyperlink for that URL.

```DOTHTML
<bs:ResponsiveNavigation HeaderText="Header" 
                         HeaderLinkUrl="http://www.dotvvm.com">
  <bs:NavigationItem NavigateUrl="https://www.google.com/" 
                     Text="Google"
                     IsSelected="true" />
  <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/"
                     Text="W3 Schools"
                     Enabled="false" />
</bs:ResponsiveNavigation>
```

## Sample 2: Styling ResponsiveNavigation

If the `HeaderImageUrl` is set, the header section will render the image.
The `HeaderImageAltText` will set alt property of image and `HeaderImageTooltip` will set the title property.

The `Theme` property allows to switch between `Light` and `Dark` theme.

The `ScrollBehavior` property allows the specify how the navbar should behave when the page is scrolled - the options are `None`, `FixedTop`, `FixedBottom` or `StickyTop`.


```DOTHTML
<bs:ResponsiveNavigation 
        HeaderImageUrl="~/Images/person.png" 
        HeaderImageAltText="Alt text for image" 
        HeaderImageTooltip="tooltip text for image" 
        HeaderLinkUrl="http://www.dotvvm.com" 
        Theme="Dark" 
        ScrollBehavior="StickyTop">

    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" />
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" />
</bs:ResponsiveNavigation>
```

## Sample 3: Alignment

The items inside the `ResponsiveNavigation` can also be aligned to the left or right side by placing the items into the `LeftAlignedItems` and `RightAlignedItems` properties. 

```DOTHTML
<bs:ResponsiveNavigation HeaderText="Alignments">  
  <LeftAlignedItems>
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" />
  </LeftAlignedItems>
  <RightAlignedItems>
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" />
  </RightAlignedItems>
</bs:ResponsiveNavigation>
```

## Sample 4: DropDownButton and Form Controls in ResponsiveNavigation

Except of the `NavigationItem` controls, you can also use [Form](~/controls/bootstrap4/Form) and [DropDownButton](~/controls/bootstrap4/DropDownButton) controls inside the navigation bar.

You have to place them in the  `LeftAlignedItems` or `RightAlignedItems` elements.

There are some limitations of the Bootstrap navbar. For example, the `Form` control `Type` must be set to `Inline` mode.

```DOTHTML
<bs:ResponsiveNavigation>
  <LeftAlignedItems>
    <bs:NavigationItem NavigateUrl="https://www.google.com/" Text="Google" IsSelected="true" />
    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" Enabled="false" />
    
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
  </LeftAlignedItems>

  <RightAlignedItems>
    <bs:Form Type="Inline">
      <bs:FormGroup>
        <bs:TextBox Text="TEST" />
      </bs:FormGroup>
    </bs:Form>
  </RightAlignedItems>
</bs:ResponsiveNavigation>
```

## Sample 5: Responsiveness

It's possible to collapse the `ResponsiveNavigation` into a single button when the content cannot fit the screen. 

The `MaximumScreenSizeBeforeCollapse` specifies the maximum screen size in which the navbar should be collapsed. Default is `Medium`.

Optionally, you can set your own content of the collapsed button by placing in into the `CollapsedButtonTemplate` template. 
If the `CollapsedButtonTemplate` is not set, the standard button with three stripes will be rendered.

```DOTHTML
<bs:ResponsiveNavigation 
    HeaderText="If this menu cannot fit screen it will collapse to button." 
    MaximumScreenSizeBeforeCollapse="Small">
  <CollapseButtonTemplate>
      Menu Button
  </CollapseButtonTemplate>
  
  <bs:NavigationItem NavigateUrl="https://www.google.cz/" Text="Google" />
  <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" Text="W3 Schools" />
</bs:ResponsiveNavigation>
```

## Sample 6: ResponsiveNavigation Data-Binding

The `ResponsiveNavigation` can be also used with the `DataSource` property to generate the menu items from the collection.

The `TextBinding` property specifies which property of the collection items will be used as the text of the menu item.

The `NavigateUrlBinding` property specifies which property will be used as the URL of the hyperlink.

You can also use the `IsEnabledBinding` to specify which property controls whether the menu item is enabled or disabled.

Also, there is the `IsSelectedBinding` property which controls whether the menu item is active.

```DOTHTML
<bs:ResponsiveNavigation DataSource="{value: LinksDataSet}" 
                         IsEnabledBinding="{value: IsDisabled}" 
						 IsSelectedBinding="{value: IsSelected}"
					     TextBinding="{value: Text}" 
						 NavigateUrlBinding="{value: NavigateUrl}">
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

## Sample 7: Header Template

The `HeaderTemplate` can be used instead of specifying header properties (text, image source,...)  using ResponsiveNavigation properties.

The content of this property would be inserted into header link.

```DOTHTML
<bs:ResponsiveNavigation HeaderLinkUrl="https://www.google.com">
    <HeaderTemplate>
        Text inside header link.
    </HeaderTemplate>
</bs:ResponsiveNavigation>
```

