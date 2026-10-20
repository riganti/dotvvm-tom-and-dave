# <bs:Breadcrumb>
Renders a Bootstrap breadcrumb navigation control with data-binding support.

<https://getbootstrap.com/docs/3.3/components/#breadcrumbs>

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
|`IsSelectedBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is selected or not.|attribute, bindable||
|`Items`|List<IListItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be navigated to when the item is clicked.|attribute, bindable||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: Static Breadcrumbs

You can place `<bs:ListItem>` elements inside the `Breadcrumbs` control. See the [ListItem documentation](ListItem).

```DOTHTML
<bs:Breadcrumb>
  <bs:ListItem NavigateUrl="https://www.google.com/"
               Text="Google"
               IsDisabled="true"/>

  <bs:ListItem NavigateUrl="http://www.w3schools.com/"
               Text="Wc3Schools"
               IsSelected="true"/>

  <bs:ListItem RouteName="MyRoute"
               Param-Id="{value: Test}"
               Text="Breadcrumb sample 1" />
</bs:Breadcrumb>

<p>Id from the route: {{value: Id}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Breadcrumb.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {

        public string Test { get; set; } = "15";

        public string Id { get; set; }

        public override Task Init()
        {
            if (Context.Parameters.ContainsKey("Id"))
            {
                Id = Convert.ToString(Context.Parameters["Id"]);
            }
            return base.Init();
        }
    }
}
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls.Bootstrap;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Breadcrumb.sample1
{
    public class Startup : IDotvvmStartup
    {
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBootstrapConfiguration();

            config.RouteTable.Add("MyRoute", "myRoute/{Id}", "Views/page.dothtml");
        }
    }
}
```

## Sample 2: Data-bound Breadcrumbs

If you want to data-bind the items inside the `Breadcrumbs` control, use the `DataSource` property. This property expects `IEnumerable`. 

Using the `TextBinding`, `NavigateUrlBinding`, `IsSelectedBinding` and `IsDisabledBinding`, you can declare how the generated items will look.
Bindings in these properties are evaluated for every collection item and set to the corresponding properties of the generated list items.

```DOTHTML
<bs:Breadcrumb DataSource="{value: Links}"
    IsDisabledBinding="{value: IsDisabled}"
    IsSelectedBinding="{value: IsSelected}"
    TextBinding="{value: Text}"
    NavigateUrlBinding="{value:  NavigateUrl}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Breadcrumb.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<LinkItem> Links { get; set; }

        private static IQueryable<LinkItem> GetData()
        {
            return new[]
            {
                new LinkItem()
                {
                    IsDisabled = true,
                    IsSelected = false,
                    NavigateUrl = "https://www.google.com/",
                    Text = "Google"
                },
                new LinkItem()
                {
                    IsDisabled = false,
                    IsSelected = false,
                    NavigateUrl = "http://www.w3schools.com/html/",
                    Text = "W3Schools"
                },
                new LinkItem()
                {
                    IsDisabled = false,
                    IsSelected = true,
                    NavigateUrl = "https://www.microsoft.com/en-us/",
                    Text = "Microsoft"
                },
                new LinkItem()
                {
                    IsDisabled = false,
                    IsSelected = false,
                    NavigateUrl = "https://github.com/riganti/dotvvm",
                    Text = "DotVVM Github"
                }
            }.AsQueryable();
        }

        public ViewModel()
        {
            Links = new List<LinkItem>(GetData());
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

