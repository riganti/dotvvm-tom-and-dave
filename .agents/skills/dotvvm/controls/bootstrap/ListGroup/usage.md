# <bs:ListGroup>
Renders a Bootstrap list group of items, links or buttons.

<https://getbootstrap.com/docs/3.3/components/#list-group>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BadgeBinding`|IValueBinding|Gets or sets a binding which defines the contents of the badge that will be created in each item.             Use this property in combination with the DataSource property.|attribute, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ColorBinding`|IValueBinding|Gets or sets a binding which defines color of each generated item.             Use this property in combination with the DataSource property.|attribute, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IListItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemType`|([ListGroupItemType](../_enums/DotVVM.Framework.Controls.Bootstrap.ListGroupItemType.md))|Gets or sets the type of the items.|attribute, static value, bindable|Default|
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Basic ListGroup

Each item inside the `ListGroup` is represented by the [ListGroupItem](~/controls/bootstrap/ListGroupItem) control.

Place the items inside the `ListGroup`.


```DOTHTML
<bs:ListGroup>
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

## Sample 2: ListGroup - Item type

The `ListGroup` control has the `ItemType` property which specified the type of list group items.

The following values are available:

* Default
* Button
* Link

```DOTHTML
<bs:ListGroup ItemType="Button">
  <bs:ListGroupItem Text="Item 1" />
  <bs:ListGroupItem Text="Item 2" Color="Default" />
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

The `DataSource` property can be used to generate the items from an *IEnumerable* in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `TextBinding`
* `BadgeBinding`
* `ColorBinding`
* `NavigateUrlBinding`
* `IsDisabledBinding`
* `IsSelectedBinding`
* `ClickBinding`

```DOTHTML
<bs:ListGroup ItemType="Link" 
              DataSource="{value: LinksDataSet}" 
              IsDisabledBinding="{value: IsDisabled}" 
              IsSelectedBinding="{value: IsSelected}" 
              TextBinding="{value: Text}" 
              BadgeBinding="{value: Badge}" 
              ColorBinding="{value: Color}" 
              NavigateUrlBinding="{value: NavigateUrl}" />
```

```CSHARP
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> LinksDataSet => new List<LinkItem>()
        {
            new LinkItem() { IsDisabled = false, IsSelected = false, NavigateUrl = "https://www.google.com/", Text = "Google", Badge = "1 References", Color = ContextualColor.Info },
            new LinkItem() { IsDisabled = false, IsSelected = false, NavigateUrl = "http://www.w3schools.com/html/", Text = "W3Schools", Badge = "8 References", Color = ContextualColor.Success },
            new LinkItem() { IsDisabled = false, IsSelected = true, NavigateUrl = "https://www.microsoft.com/en-us/", Text = "Microsoft", Badge = "3 References", Color = ContextualColor.Warning },
            new LinkItem() { IsDisabled = false, IsSelected = false, NavigateUrl = "https://github.com/riganti/dotvvm", Text = "DotVVM Github", Badge = "15 References", Color = ContextualColor.Danger }
        };
        
    }

    public class LinkItem
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDisabled { get; set; }
        public string Badge { get; set; }
        public ContextualColor Color { get; set; }

    }
}
```

## Sample 4: Data-binding

The `ClickBinding` property can be used when the list group contains the buttons.

```DOTHTML
<bs:ListGroup ItemType="Button" DataSource="{value: Values}" 
              TextBinding="{value: _this}" ClickBinding="{command: _parent.Select(_this)}" />

Selected item: {{value: SelectedValue}}

```

```CSHARP
using DotVVM.Framework.Controls.Bootstrap;
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

