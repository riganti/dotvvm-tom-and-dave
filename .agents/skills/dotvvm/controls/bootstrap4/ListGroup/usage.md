# <bs:ListGroup>
Renders a Bootstrap list group of items, links or buttons.

<https://getbootstrap.com/docs/4.3/components/list-group/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BadgeBinding`|Badge|Gets or sets a binding which defines the contents of the badge that will be created in each item.             Use this property in combination with the DataSource property.|inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ColorBinding`|IValueBinding|Gets or sets a binding which defines color of each generated item.             Use this property in combination with the DataSource property.|attribute, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsFlush`|Boolean|Gets or sets whether to remove some borders and rounded corners to render list group items edge-to-edge in a parent container.|attribute, static value, bindable|False|
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IListGroupItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`ItemType`|([ListGroupItemType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ListGroupItemType.md))|Gets or sets the type of the items.|attribute, static value|Default|
|`MaximumScreenSizeBeforeChangeToVertical`|([ResponsiveBreakpoints](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveBreakpoints.md))|Gets or sets the maximum screen size before the ListGroup will change to vertical mode.             If set to None than the ListGroup will never change to vertical.|attribute, static value|None|
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`ScrollSpyEnabled`|Boolean||attribute, static value, bindable|False|
|`ScrollSpyOffset`|Int32||attribute, static value|10|
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Type`|([ListGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ListGroupType.md))|Gets or sets the type of ListGroup.             e.g. Vertical, Horizontal|attribute, static value|Vertical|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic ListGroup

Each item inside the `ListGroup` is represented by the [ListGroupItem](~/controls/bootstrap4/ListGroupItem) control.

Place the items inside the `ListGroup`.


```DOTHTML
<bs:ListGroup>
  <bs:ListGroupItem Text="{value: Text}" />
  <bs:ListGroupItem Text="Item 2" />
  <bs:ListGroupItem Text="Item 3" />
  <bs:ListGroupItem>
    <h3>Custom content</h3>
    <p>Custom list item content</p>
  </bs:ListGroupItem>
</bs:ListGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "Data-bound text of the item.";
    }
}
```

## Sample 2: ListGroup - Item types

The `ListGroup` control has the `ItemType` property which specified the type of list group items - `Default`, `Link` and `Button`.

```DOTHTML
<bs:ListGroup ItemType="Button">
  <bs:ListGroupItem Text="Item 1" />
  <bs:ListGroupItem Text="Item 2" Color="Primary" />
  <bs:ListGroupItem Text="Item 3" Color="Info" />
  <bs:ListGroupItem Text="{value: Text}" Color="Success" />
  <bs:ListGroupItem Text="Item 5" Color="Warning" />
  <bs:ListGroupItem Text="Item 6" Color="Danger" />
</bs:ListGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "This is sample text.";
    }
}
```

## Sample 3: Data-binding

The `DataSource` property can be used to generate the items from an `IEnumerable` in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `TextBinding` specifies the property of the collection elements to be used as list item text.
* `ColorBinding` specifies the property of the collection elements to be used as list item color.
* `NavigateUrlBinding` specifies the property of the collection elements to be used as list item link URL.
* `IsEnabledBinding` specifies the property of the collection elements indicating whether the list item is enabled or not.
* `IsSelectedBinding` specifies the property of the collection elements indicating whether the list item is active or not.
* `ClickBinding` specifies a command in the viewmodel to be called when the list item is clicked.

```DOTHTML
<bs:ListGroup ItemType="Link" 
              DataSource="{value: LinksDataSet}" 
              IsEnabledBinding="{value: IsEnabled}" 
              IsSelectedBinding="{value: IsSelected}" 
              TextBinding="{value: Text}" 
              ColorBinding="{value: Color}" 
              NavigateUrlBinding="{value: NavigateUrl}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<LinkItem> LinksDataSet => new List<LinkItem>()
    {
        new LinkItem() { IsEnabled = true, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google", Color = BootstrapColor.Info },
        new LinkItem() { IsEnabled = true, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools", Color = BootstrapColor.Success },
        new LinkItem() { IsEnabled = true, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft", Color = BootstrapColor.Warning },
        new LinkItem() { IsEnabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github", Color = BootstrapColor.Danger }
    };
    
}

public class LinkItem
{
    public string Text { get; set; }
    public string NavigateUrl { get; set; }
    public bool IsSelected { get; set; }
    public bool IsEnabled { get; set; }
    public BootstrapColor Color { get; set; }

}
```

## Sample 4: Data-binding

The `ClickBinding` property can be used when the list group contains the buttons.

```DOTHTML
<bs:ListGroup ItemType="Button" 
              DataSource="{value: Values}" 
              TextBinding="{value: _this}" 
              ClickBinding="{command: _parent.Select(_this)}" />

Selected item: {{value: SelectedValue}}

```

```CSHARP
using DotVVM.Framework.Controls.Bootstrap4;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Values => new List<string>() { "one", "two", "three" };

        public string SelectedValue { get; set; }
        
        
        public void Select(string value)
        {
            SelectedValue = value;
        }
    }
    
}
```

## Sample 5: Badges

The list items can contain [Badge](~/controls/bootstrap4/Badge) controls. Use the `Badge` inner element property to specify the badge contents.

```DOTHTML
<bs:ListGroup>
  <bs:ListGroupItem Text="{value: Text}">
    <Badge>
      <bs:Badge>10</bs:Badge>
    </Badge>
  </bs:ListGroupItem>
  <bs:ListGroupItem Text="Item 2">
    <Badge>
      <bs:Badge>2</bs:Badge>
    </Badge>
  </bs:ListGroupItem>
</bs:ListGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "Data-bound text of the item.";
    }
}
```

## Sample 6: Flush mode

The `IsFlush` property can be used to render the list group without borders to render the list group items edge-to-edge in a parent container.

**Flush mode cannot be combined with horizontal `ListGroup`**

```DOTHTML
<bs:ListGroup IsFlush="true">
  <bs:ListGroupItem Text="{value: Text}" />
  <bs:ListGroupItem Text="Item 2" />
  <bs:ListGroupItem Text="Item 3" />
  <bs:ListGroupItem Text="Item 4" />
</bs:ListGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "Data-bound text of the item.";
    }
}
```

## Sample 7: Type and responsibility

The `Type` property controls whether the ListGroup would be `Horizontal` or `Vertical`.

When using `Horizontal` ListGroup, than we can also use `MaximumScreenSizeBeforeChangeToVertical` to set when the ListGroup should change from `Horizontal` to `Vertical`.  
If set to `None` than the ListGroup will never change to `Vertical`.

```DOTHTML
<bs:ListGroup Type="Horizontal" MaximumScreenSizeBeforeChangeToVertical="Medium" >
  <bs:ListGroupItem Text="{value: Text}" />
  <bs:ListGroupItem Text="Item 2" />
  <bs:ListGroupItem Text="Item 3" />
  <bs:ListGroupItem Text="Item 4" />
</bs:ListGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; } = "Data-bound text of the item.";
    }
}
```

