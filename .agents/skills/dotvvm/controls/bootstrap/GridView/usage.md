# <bs:GridView>
A Bootstrap extension for the [built-in GridView](~/controls/builtin/GridView) control which allows to apply Bootstrap table classes on the table.

<https://getbootstrap.com/docs/3.3/css/#tables>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Columns`|List<GridViewColumn>|Gets or sets a collection of columns that will be placed inside the grid.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EditRowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each row in edit mode.|inner element, static value||
|`EmptyDataTemplate`|ITemplate|Gets or sets the template which will be displayed when the DataSource is empty.|inner element, static value, bindable||
|`FilterPlacement`|([GridViewFilterPlacement](../../builtin/_enums/DotVVM.Framework.Controls.GridViewFilterPlacement.md))|Gets or sets the place where the filters will be created.|attribute, static value, bindable|HeaderRow|
|`HeaderRowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on the header row.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InlineEditing`|Boolean|Gets or sets whether the inline editing is allowed in the Grid. If so, you have to use a GridViewDataSet as the DataSource.|attribute, static value|False|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each row which is not in the edit mode.|inner element, static value||
|`ShowHeaderWhenNoData`|Boolean|Gets or sets whether the header row should be displayed when the grid is empty.|attribute, static value|False|
|`SortChanged`|Action<String>|Gets or sets the command that will be triggered when the user changed the sort order.|attribute, bindable||
|`Type`|([TableType](../_enums/DotVVM.Framework.Controls.Bootstrap.TableType.md))|Gets or sets the style of the table.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be triggered when the GridView needs to load data (e.g. when the sort order has changed).             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

## Sample 1: Simple Bootstrap GridView

The usage is the same as the built-in [GridView](~/controls/builtin/GridView) control.

The only extension is the `Type` property which applies a Bootstrap CSS class to the table.

```DOTHTML
<bs:GridView DataSource="{value: Customers}" Type="Bordered">
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls;
using System.Threading.Tasks;
using DotVVM.Framework.Controls.Bootstrap;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.BootstrapGridView.sample1
{

    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<CustomerData> FakeDb()
        {
            return new[]
            {
                new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
                new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
                new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
                new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
                new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Default }
            }.AsQueryable();
        }

        public GridViewDataSet<CustomerData> Customers { get; set; } = new GridViewDataSet<CustomerData>() { PagingOptions = { PageSize = 4} };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                var queryable = FakeDb();
                Customers.LoadFromQueryable(queryable);
            }
            return base.PreRender();
        }
    }

    public class CustomerData
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public BootstrapColor Color { get; set; }
    }
}

```

## Sample 2: GridView with Color Decorator

Sometimes, you need to apply some color to specific row.

**Bootstrap for DotVVM** includes several decorators you can use to add CSS classes. 
The `ColorDecorator` can apply one of the Bootstrap colors to the row. 

```DOTHTML
<bs:GridView DataSource="{value: Customers}" Type="Default">
  <RowDecorators>
    <bs:ColorDecorator Color="{value: Color}"></bs:ColorDecorator>
  </RowDecorators>
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.Controls;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.BootstrapGridView.sample2
{

    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<CustomerData> FakeDb()
        {
            return new[]
            {
                new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
                new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
                new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
                new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
                new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Default },
                new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Default }
            }.AsQueryable();
        }

        public GridViewDataSet<CustomerData> Customers { get; set; } = new GridViewDataSet<CustomerData>() { PagingOptions = { PageSize = 4} };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                var queryable = FakeDb();
                Customers.LoadFromQueryable(queryable);
            }
            return base.PreRender();
        }
    }

    public class CustomerData
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public BootstrapColor Color { get; set; }
    }
}

```

