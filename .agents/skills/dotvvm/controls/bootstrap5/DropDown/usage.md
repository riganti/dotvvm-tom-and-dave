# <dot:DropDown>
Renders a button with a dropdown menu with the data-binding support.

<https://getbootstrap.com/docs/5.2/components/dropdowns>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([DropAlignment](../_enums/DotVVM.Bootstrap5.Controls.DropAlignment.md))|Gets or sets to which side the dropdown items should be aligned.|attribute, static value|Start|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseBehavior`|([DropDownCloseBehavior](../_enums/DotVVM.Bootstrap5.Controls.DropDownCloseBehavior.md))|Gets or sets the dropdown closing behavior. Possible values are `Default`, `Inside`, `Outside` and `Manual`.|attribute, static value|Default|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the data source for the items in the dropdown menu.|attribute, bindable||
|`DropDirection`|([DropDirection](../_enums/DotVVM.Bootstrap5.Controls.DropDirection.md))|Gets or sets the direction in which the dropdown menu should open.|attribute, static value|DropDown|
|`Enabled`|Boolean|Gets or sets a button disabled state.|attribute, static value, bindable|True|
|`FontType`|([ButtonTextColor](../_enums/DotVVM.Bootstrap5.ButtonTextColor.md))|Gets or sets the font color for button toggle.|attribute, static value, bindable|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsCollapsed`|IValueBinding<Boolean>|Gets or sets whether the dropdown menu is collapsed or expanded.|attribute, bindable||
|`IsSplitButton`|Boolean|Gets or sets whether the dropdown button should be a split button.|attribute, static value|False|
|`ItemEnabled`|Boolean|Gets or sets whether the individual items in the dropdown menu should be enabled or disabled when DataSource is set.|attribute, static value, bindable|True|
|`ItemNavigateUrl`|String|Gets or sets the URL to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value, bindable||
|`ItemRouteName`|String|Gets or sets the route name to navigate to when an item in the dropdown menu is clicked when DataSource is set.|attribute, static value||
|`Items`|List<IDropDownItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemSelected`|Boolean|Gets or sets whether an individual item in the dropdown menu is selected when DataSource is set.|attribute, static value, bindable||
|`ItemTarget`|String||attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets the template to use for rendering each item in the dropdown menu when DataSource is set.|inner element, static value||
|`ItemText`|String|Gets or sets the text to display for each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`ItemUrlSuffix`|String|Gets or sets a suffix to append to the URL of each item in the dropdown menu when DataSource is set.|attribute, static value, bindable||
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the dropdown button toggle.|attribute, static value, bindable|Default|
|`SplitButtonMenuAlignment`|([SplitButtonMenuAlignment](../_enums/DotVVM.Bootstrap5.Controls.SplitButtonMenuAlignment.md))|Gets or sets whether the toggle menu should be displayed next to a button or next to an arrow.|attribute, static value|AlignWithArrow|
|`Text`|String|Gets or sets the text to display on the dropdown button.|attribute, static value, bindable||
|`ToggleType`|([DropDownType](../_enums/DotVVM.Bootstrap5.Controls.DropDownType.md))|Gets or sets the toggle type. Possible values are the `Button` or `Link`.|attribute, static value|Button|
|`Type`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the toggle button type.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets the toggle button visual style.|attribute, static value|SolidFill|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when the dropdown button is clicked.|
|`ItemClick`|ICommandBinding|Gets or sets the command that will be triggered when individual items in the dropdown menu are clicked and DataSource is set.|

## Sample 1: Basic Usage

The `Text` property specified the text on the button. Alternatively, you can use the `Content` property to create a custom dropdown button toggle. Additionally `ButtonType` property can change the toggle type to `Link`.

The `DropDirection` property can specify whether the menu drops up, down or to the side.

The `IsCollapsed` property indicates whether the menu is open or not. You can also use it in data-binding.

Place `<bs:DropDownItem>` controls inside the `<bs:DropDown>` control and use their `NavigateUrl` property to specify the link URL. 
You can place them inside the `<Items>` element, however it is not required because the `Items` is the default property of `DropDown`.

```DOTHTML
<bs:DropDown Text="Very Simple Dropdown">
    <bs:DropDownItem NavigateUrl="https://www.google.com/">
      Google
    </bs:DropDownItem>
    <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm" Text="DotVVM" />
</bs:DropDown>

<bs:DropDown ButtonType="Link" >
  <Content>
    <bs:Icon Type="Calendar" />
    <strong>Simple Dropdown</strong>
    with custom toggle
  </Content>
  <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
    Google
  </bs:DropDownItem>
  <bs:DropDownSeparator />
  <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownItem>
</bs:DropDown>

<bs:DropDown Text="Drop up Button" DropDirection="DropUp">
  <bs:DropDownItem NavigateUrl="https://www.google.com/">
      Google is a <strong>search engine</strong>
  </bs:DropDownItem>
  <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownItem>
</bs:DropDown>


<p>IsCollapsed: {{value: Collapsed}}</p>
<bs:DropDown IsCollapsed="{value: Collapsed}" Text="Collapse test">
  <bs:DropDownItem NavigateUrl="https://www.google.com">Google</bs:DropDownItem>
</bs:DropDown>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DropDown.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Collapsed { get; set; }
    }
}
```

## Sample 2: DropDownItem, DropDownSeparator and DropDownHeader

The `DropDownItem` control has a `Text` property that specifies plain text inside a control. Alternatively, you can place something inside the `DropDownItem` to render custom content.
You can disable the menu item with the `Enabled` property and set the selected state with the `Selected` property.
With a `Click` property, a custom action can be specified after clicking on the `DropDownItem` control.
Navigation to a specific URL can be set with a`NavigateUrl` property. Alternatively, you can use `RouteName` property to navigate to a specific DotVVM page.

You can separate dropdown menu items using the `bs:DropDownSeparator` control. You can also use the `bs:DropDownHeader` to specify a non-clickable title for a group of buttons. `bs:DropDownHeader` also allows you to add custom content.

```DOTHTML
<bs:DropDown Text="Dropdown with Headers">
  <bs:DropDownHeader>Item 1</bs:DropDownHeader>
  <bs:DropDownItem NavigateUrl="https://www.google.com/">
    Google
  </bs:DropDownItem>
  <bs:DropDownHeader>Item 2</bs:DropDownHeader>
  <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownItem>
</bs:DropDown>

<bs:DropDown>
  <Content>
    Very <strong>Simple Dropdown</strong> with separator and disabled value
  </Content>
  <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
    Google
  </bs:DropDownItem>
  <bs:DropDownSeparator/>
  <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownItem>
</bs:DropDown>
```

## Sample 3: DropDown with DataSource

You can also load the dropdown button items from a collection in the viewmodel using the `DataSource` property.

Induvidual item properties could be specified with as a binding which points to an appropriate property of the collection item. All item properties have an `Item-` prefix (`ItemEnabled`, `ItemIsSelected`, `ItemClick`, `ItemText`, `ItemTemplate`...).

```DOTHTML
<bs:DropDown Text="Dropdown Created From Data Source!"
                   DataSource="{value: LinksDataSet}"
                   ItemEnabled="{value: Enabled}"
                   ItemSelected="{value: IsSelected}"
                   ItemText="{value: Text}"
                   ItemNavigateUrl="{value: NavigateUrl}">
</bs:DropDown>

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<LinkItem> LinksDataSet { get; set; }

    private static IQueryable<LinkItem> GetData()
    {
        return new[]
        {
            new LinkItem() {  Enabled = true, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google"},
            new LinkItem() {  Enabled = true, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools"},
            new LinkItem() {  Enabled = true, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft"},
            new LinkItem() {  Enabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github"}
        }.AsQueryable();
    }

    public ViewModel()
    {
        LinksDataSet = new List<LinkItem>();
        foreach (LinkItem l in GetData())
        {
            LinksDataSet.Add(l);
        }
    }


}
public class LinkItem
{
    public string Text { get; set; }
    public string NavigateUrl { get; set; }
    public bool IsSelected { get; set; }
    public bool Enabled { get; set; }

}
```

## Sample 3: Further customizations

You can use standard button properties (`VisualStyle`, `Type`, `Size`) to get the right button look.

To create a special type of `DropDown` control, use the `IsSpitButton` property. In combination with `SetParentReference`, the dropdown menu is displayed next to the button element.

```DOTHTML
<bs:DropDown Text="Dropdown Created From Data Source!"
                   IsSplitButton="True"
                   VisualStyle="Outline"
                   Type="Success"
                   DataSource="{value: LinksDataSet}"
                   ItemEnabled="{value: Enabled}"
                   ItemSelected="{value: IsSelected}"
                   ItemText="{value: Text}"
                   ItemNavigateUrl="{value: NavigateUrl}">
</bs:DropDown>

<bs:DropDown Text="Button Dropdown" ButtonType="Button" DropdownBackground="Dark">
    <bs:DropDownItem Text="Item1" />
    <bs:DropDownItem Text="Item1" />
    <bs:DropDownItem Text="Item1" />
</bs:DropDown>

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<LinkItem> LinksDataSet { get; set; }

    private static IQueryable<LinkItem> GetData()
    {
        return new[]
        {
            new LinkItem() {  Enabled = true, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google"},
            new LinkItem() {  Enabled = true, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools"},
            new LinkItem() {  Enabled = true, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft"},
            new LinkItem() {  Enabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github"}
        }.AsQueryable();
    }

    public ViewModel()
    {
        LinksDataSet = new List<LinkItem>();
        foreach (LinkItem l in GetData())
        {
            LinksDataSet.Add(l);
        }
    }


}
public class LinkItem
{
    public string Text { get; set; }
    public string NavigateUrl { get; set; }
    public bool IsSelected { get; set; }
    public bool Enabled { get; set; }

}
```

## Sample 3: dropdown close behavior

You can specify the dropdown menu close `CloseBehavior`:
* `Default` - the dropdown menu is closed when some item is selected, or the user clicks outside
* `Inside` - the dropdown menu is not closed after clicking on the item but closes when the user clicks outside
* `Outside` - the dropdown menu is not closed when the user clicks outside but closes after clicking on the item
* `Manual` - the dropdown menu is not closed when the user clicks outside or after clicking on the item


```DOTHTML
<bs:DropDown Text="Default close behavior">
    <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
        Google
    </bs:DropDownItem>
    <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
        DotVVM
    </bs:DropDownItem>
</bs:DropDown>
<bs:DropDown Text="Inside close behavior" CloseBehavior="Inside">
    <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
        Google
    </bs:DropDownItem>
    <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
        DotVVM
    </bs:DropDownItem>
</bs:DropDown>
<bs:DropDown Text="Outside close behavior" CloseBehavior="Outside">
    <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
        Google
    </bs:DropDownItem>
    <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
        DotVVM
    </bs:DropDownItem>
</bs:DropDown>
<bs:DropDown Text="Manual close behavior" CloseBehavior="Manual">
    <bs:DropDownItem NavigateUrl="https://www.google.com/" Enabled="false">
        Google
    </bs:DropDownItem>
    <bs:DropDownItem NavigateUrl="https://github.com/riganti/dotvvm">
        DotVVM
    </bs:DropDownItem>
</bs:DropDown>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool Collapsed { get; set; }
}
```

