# <bp:DataPager>
Inherits the built-in [DataPager](~/controls/builtin/DataPager) control with a *DotVVM Business Pack* visual style.

Used in cooperation with a [GridView](~/controls/businesspack/GridView), [Repeater](~/controls/builtin/Repeater) or a similar control, the `DataPager` can render the buttons which allow the user to browse a large collection of records using pages.

The `DataPager` requires a `GridViewDataSet` object in the viewmodel. This object keeps track of the page size, current page number, and also holds
the data of the current page. It can also be used as a `DataSource` in `GridView`, `Repeater` or similar controls.

## Rendered output
This control renders an unordered list with hyperlinks in list items.

The First, Previous, Next and Last link contents can be templated using the `FirstPageTemplate`, `PreviousPageTemplate`, `NextPageTemplate` and `LastPageTemplate` properties.

```DOTHTML
<ul>
  <li><a href="...">&raquo;&raquo;</a></li>
  <li><a href="...">&raquo;</a></li>
  
  <li><a href="...">1</a></li>
  <li><a href="...">2</a></li>
  <li>3</li>
  <li><a href="...">4</a></li>
  <li><a href="...">5</a></li>

  <li><a href="...">&laquo;</a></li>
  <li><a href="...">&laquo;&laquo;</a></li>
</ul>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ActiveItemCssClass`|String|Gets or sets the CSS class to be applied to the currently active page number.|attribute, static value|active|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSet`|IPageableGridViewDataSet<IPagingOptions>|Gets or sets the GridViewDataSet object in the viewmodel.|attribute, bindable||
|`DisabledItemCssClass`|String|Gets or sets the CSS class that to be applied to the disabled items.|attribute, static value|disabled|
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FirstPageTemplate`|ITemplate|Gets or sets the template of the button which moves the user to the first page.|inner element, static value||
|`HideWhenOnlyOnePage`|Boolean|Gets or sets whether the pager should hide automatically when there is only one page of results. Must not be set to true when using the Visible property.|attribute, static value|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LastPageTemplate`|ITemplate|Gets or sets the template of the button which moves the user to the last page.|inner element, static value||
|`LinkID`|String||attribute, static value, bindable||
|`LinkVisible`|Boolean||attribute, static value, bindable|True|
|`ListItemID`|String||attribute, static value, bindable||
|`ListItemVisible`|Boolean||attribute, static value, bindable|True|
|`NextPageTemplate`|ITemplate|Gets or sets the template of the button which moves the user to the next page.|inner element, static value||
|`PageNumberTemplate`|ITemplate|Gets or sets the template of the button which moves the user to the numbered page.|inner element, static value||
|`PreviousPageTemplate`|ITemplate|Gets or sets the template of the button which moves the user to the previous page.|inner element, static value||
|`RenderLinkForCurrentPage`|Boolean|Gets or sets whether a hyperlink should be rendered for the current page number. If set to false, only a plain text is rendered.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be triggered when the DataPager needs to load data (when navigating to different page).             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

## Sample 1: Basic Usage

The `Customers` is a property of `IGridViewDataSet` in the viewmodel.

The `DataPager` and the `GridView` controls must be bound to the same `GridViewDataSet` object.


```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" HeaderText="ID" />
        <bp:GridViewTextColumn Value="{value: Name}" HeaderText="Name" />
    </Columns>
</bp:GridView>

<bp:DataPager DataSet="{value: Customers}" class="pager" />
```

```CSHARP
using System;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DataPager.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<Customer> FakeDb()
        {
            return new[]
            {
                new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"), new Customer(2, "Raine Damian"),
                new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred"),
                new Customer(6, "Oliver Carr"), new Customer(7, "Jackson James"), new Customer(8, "Dexter Nicholson"),
                new Customer(9, "Jamie Rees"), new Customer(10, "Jackson Ross"), new Customer(11, "Alonso Sims"),
                new Customer(12, "Zander Britt"), new Customer(13, "Isaias Ford"), new Customer(14, "Braden Huffman"),
                new Customer(15, "Frederick Simpson"), new Customer(16, "Charlie Andrews"), new Customer(17, "Reuben Byrne")
            }.AsQueryable();
        }


        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            PagingOptions = {
                    PageSize = 10
                }
        };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(FakeDb());
            }

            return base.PreRender();
        }
    }
}

```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.DataPager.sample1
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer() 
        {
        }

        public Customer(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}

```

## Sample 2: Templating the DataPager

You can specify your own button templates to specify custom content for the pager buttons:

`FirstPageTemplate` 
`LastPageTemplate` 
`NextPageTemplate`
`PreviousPageTemplate`

Also, using the `RenderLinkForCurrentPage` you can define whether the current page button will be a hyperlink (`<a href="...">`) or just plain text.


```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" HeaderText="ID" />
        <bp:GridViewTextColumn Value="{value: Name}" HeaderText="Name" />
    </Columns>
</bp:GridView>

<bp:DataPager DataSet="{value: Customers}" RenderLinkForCurrentPage="true">
    <FirstPageTemplate>
        <span>First</span>
    </FirstPageTemplate>
    <LastPageTemplate>
        <span>Last</span>
    </LastPageTemplate>
    <NextPageTemplate>Next</NextPageTemplate>
    <PreviousPageTemplate>Previous</PreviousPageTemplate>
</bp:DataPager>
```

```CSHARP
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.DataPager.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<Customer> FakeDb()
        {
            return new[]
            {
                new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"), new Customer(2, "Raine Damian"),
                new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred"),
                new Customer(6, "Oliver Carr"), new Customer(7, "Jackson James"), new Customer(8, "Dexter Nicholson"),
                new Customer(9, "Jamie Rees"), new Customer(10, "Jackson Ross"), new Customer(11, "Alonso Sims"),
                new Customer(12, "Zander Britt"), new Customer(13, "Isaias Ford"), new Customer(14, "Braden Huffman"),
                new Customer(15, "Frederick Simpson"), new Customer(16, "Charlie Andrews"), new Customer(17, "Reuben Byrne")
            }.AsQueryable();
        }


        public BusinessPackDataSet<Customer> Customers { get; set; } =new BusinessPackDataSet<Customer>() {
                PagingOptions = {
                    PageSize = 10
                }
            };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(FakeDb());
            }

            return base.PreRender();
        }

    }
}

```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.DataPager.sample2
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer() 
        {
        }

        public Customer(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}

```

