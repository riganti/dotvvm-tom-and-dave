# <bs:DropDownButton>
Renders a button with a drop-down menu with the data-binding support.

<https://getbootstrap.com/docs/3.3/components/#dropdowns>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonTemplate`|ITemplate|Gets or sets the button template.|inner element, static value||
|`ButtonType`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the color of the button.|attribute, static value, bindable|Default|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`DropDownType`|([DropDownType](../_enums/DotVVM.Framework.Controls.Bootstrap.DropDownType.md))|Gets or sets the drop-down style of the button.|attribute, static value|DropDown|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsCollapsed`|Boolean|Gets or sets whether the button is collapsed or not.|attribute, static value, bindable|True|
|`IsDisabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IListItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`Text`|String|Gets or sets the button text.|attribute, static value, bindable||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Type`|([DropDownButtonType](../_enums/DotVVM.Framework.Controls.Bootstrap.DropDownButtonType.md))|Gets or sets the type of the button.|attribute, static value|Button|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic Usage

The `Text` property specified the text on the button. Alternatively, you can use the `ButtonTemplate` property.

The `Type` property can specify whether the menu drops up or down.

The `IsCollapsed` property indicates whether the menu is open or not. You can also use it in data-binding.

Place `<bs:DropDownButtonItem>` controls inside the `<bs:DropDownButton>` control and use their `NavigateUrl` property to specify the link URL. 
You can place them inside the `<Items>` element, however it is not required because the `Items` is the default property of `DropDownButton`.

Because the class `DropDownButtonItem` inherits from the [ListItem](~/controls/bootstrap/ListItem), please refer to the `ListItem` documentation for more information.



```DOTHTML
<bs:DropDownButton Text="Very Simple Dropdown">
  <Items>
    <bs:DropDownButtonItem NavigateUrl="https://www.google.com/">
      Google
    </bs:DropDownButtonItem>
    <bs:DropDownButtonItem NavigateUrl="https://github.com/riganti/dotvvm" Text="DotVVM" />
  </Items>
</bs:DropDownButton>

<bs:DropDownButton Text="Drop up Button" DropDownType="DropUp">
  <bs:DropDownButtonItem NavigateUrl="https://www.google.com/">
    <ButtonTemplate>
      Google is a <strong>search engine</strong>
    </ButtonTemplate>
  </bs:DropDownButtonItem>
  <bs:DropDownButtonItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownButtonItem>
</bs:DropDownButton>

<p>IsCollapsed: {{value: Collapsed}}</p>
<bs:DropDownButton IsCollapsed="{value: Collapsed}" Text="Collapse test">
  <bs:DropDownButtonItem NavigateUrl="https://www.google.com">Google</bs:DropDownButtonItem>
</bs:DropDownButton>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DropDownButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Collapsed { get; set; }
    }
}
```

## Sample 2: Advanced Dropdown

The `DropDownButtonItem` control has the `IsDisabled` property which you can use to disable the menu item.

You can separate dropdown menu items using the `bs:DropDownButtonSeparator` control. You can also use the the `bs:DropDownButtonHeader` to specify a non-clickable title for a group of buttons.

The `ButtonType` property is used to apply Bootstrap styles to DropDownButton. If you need to place a custom content on the button and not just text, use the `ButtonTemplate`.

```DOTHTML
<bs:DropDownButton Text="Very Simple Dropdown with Headers" ButtonType="Success" >
  <bs:DropDownButtonHeader>Item 1</bs:DropDownButtonHeader>
  <bs:DropDownButtonItem NavigateUrl="https://www.google.com/">
    Google
  </bs:DropDownButtonItem>
  <bs:DropDownButtonHeader>Item 2</bs:DropDownButtonHeader>
  <bs:DropDownButtonItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownButtonItem>
</bs:DropDownButton>

<bs:DropDownButton>
  <ButtonTemplate>
    Very <strong>Simple Dropdown</strong> with separator and disabled value
  </ButtonTemplate>

  <bs:DropDownButtonItem NavigateUrl="https://www.google.com/" IsDisabled="true">
    Google
  </bs:DropDownButtonItem>
  <bs:DropDownButtonSeparator/>
  <bs:DropDownButtonItem NavigateUrl="https://github.com/riganti/dotvvm">
    DotVVM
  </bs:DropDownButtonItem>
</bs:DropDownButton>

```

## Sample 3: DropDownButton Data-binding

You can also load the dropdown button items from a collection in the viewmodel using the `DataSource` property.

You have to specify the `TextBinding` which points to an appropriate property of the collection item. The URL of the item is specified using the `NavigateUrlBinding` property.

You can also use the `IsDisabledBinding` and `IsSelectedBinding` to specify which properties of the collection item declare the selected or disabled state of the button. 
The same logic applies to the `ClickBinding` property - use it if you want the buttons to invoke a command on the viewmodel.


```DOTHTML
<bs:DropDownButton Text="Dropdown Created From Data Source!"
                   DataSource="{value: LinksDataSet}"
                   IsDisabledBinding="{value: IsDisabled}"
                   IsSelectedBinding="{value: IsSelected}"
                   TextBinding="{value: Text}"
                   NavigateUrlBinding="{value: NavigateUrl}">
</bs:DropDownButton>

```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DropDownButton.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> LinksDataSet { get; set; }

        private static IQueryable<LinkItem> GetData()
        {
            return new[]
            {
                new LinkItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google"},
                new LinkItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools"},
                new LinkItem() {  IsDisabled = false, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft"},
                new LinkItem() {  IsDisabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github"}
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
        public bool IsDisabled { get; set; }

    }
}
```

