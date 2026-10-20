# <dot:GridView>
A multi-purpose grid control with advanced binding, templating options and sorting support.

## Rendered output
The control renders a classic HTML table:

```DOTHTML
<table>
  <thead>
    <tr>
	  <th><a href="...">Id</a></th>
	  <th><a href="...">Customer Name</a></th>
	</tr>
  </thead>

  <tbody>
    <tr>
	  <td><span data-bind="..."></span></td>
	  <td><span data-bind="..."></span></td>
	</tr>
  </tbody>
</table>
```

In the [Client rendering mode](~/pages/concepts/server-side-rendering), only one row is rendered and the 
Knockout *foreach* binding is applied to the *tbody* element.

In the [Server rendering mode](~/pages/concepts/server-side-rendering), all rows are rendered on the server.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Columns`|List<GridViewColumn>|Gets or sets a collection of columns that will be placed inside the grid.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EditRowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each row in edit mode.|inner element, static value||
|`EmptyDataTemplate`|ITemplate|Gets or sets the template which will be displayed when the DataSource is empty.|inner element, static value, bindable||
|`FilterPlacement`|([GridViewFilterPlacement](../_enums/DotVVM.Framework.Controls.GridViewFilterPlacement.md))|Gets or sets the place where the filters will be created.|attribute, static value, bindable|HeaderRow|
|`HeaderRowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on the header row.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InlineEditing`|Boolean|Gets or sets whether the inline editing is allowed in the Grid. If so, you have to use a GridViewDataSet as the DataSource.|attribute, static value|False|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each row which is not in the edit mode.|inner element, static value||
|`ShowHeaderWhenNoData`|Boolean|Gets or sets whether the header row should be displayed when the grid is empty.|attribute, static value|False|
|`SortChanged`|Action<String>|Gets or sets the command that will be triggered when the user changed the sort order.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be triggered when the GridView needs to load data (e.g. when the sort order has changed).             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

## Sample 1: Basic GridView

The GridView has the `DataSource` property which expects either `IEnumerable` or `GridViewDataSet` objects.

Columns are defined by placing in the `Columns` collection.


```DOTHTML
<dot:GridView DataSource="{value: Customers}">
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" HeaderText="ID"/>
    <dot:GridViewTextColumn ValueBinding="{value: Name}" HeaderText="Name"/>
  </Columns>
</dot:GridView>
```

```CSHARP
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.sample1
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

        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>() { PagingOptions = { PageSize = 4} };

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

    public record Customer(int Id, string Name);
}

```

## Sample 2: GridViewTextColumn

Each column in the grid must be declared in the `<Columns></Columns>` collection. **GridViewTextColumn** displays the field as plain text.

&nbsp;

### Required Properties

The most important property is the `ValueBinding` which contains a binding which selects the property to display from the object.

You can customize the header cell using the `HeaderText` property, or the `HeaderTemplate` template.

&nbsp;

### Sorting

There is also a property `AllowSorting` which can be used to sort the column. If it is set to true, you can also use the `SortExpression` 
property to specify which column should be used for sorting. It is useful when the values in the column are e.g. 'lowest', 'normal' and 'highest' 
and you don't need to order them alphabetically, but you have another column with numeric representation of those values. In that case, you can use 
the name of such column as a `SortExpression`.

&nbsp;

### Styling

The `Width` property allows to set the width of the column. It is rendered as `style="width: XXX"` attribute on the `<th>` element in the table header.

You can specify `CssClass` to be applied on each table cell `<td>`. This property supports data-binding.

There is also the `HeaderCssClass` property that adds the specified CSS class to the `<th>` element in the table header.

&nbsp;

### Formatting

Use the `FormatString` property to specify the format of numbers or date-time values. Most of the .NET Framework format strings is supported.

```DOTHTML
<dot:GridView DataSource="{value: Customers}">
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" 
                            HeaderText="ID" 
                            CssClass="{value: Id % 2 == 0 ? 'alternate' : ''}"
                            HeaderCssClass="header"
                            Width="50px" />
    
    <dot:GridViewTextColumn ValueBinding="{value: Name}" 
                            CssClass="{value: Id % 2 == 0 ? 'alternate' : ''}" 
                            HeaderCssClass="header" 
                            AllowSorting="false">
      <HeaderTemplate>
        <img src="~/images/person.png"/> Person
      </HeaderTemplate>
    </dot:GridViewTextColumn>

    <dot:GridViewTextColumn ValueBinding="{value: Date}"
                        HeaderText="Date"
                        CssClass="{value: Id % 2 == 0 ? 'alternate' : ''}"
                        HeaderCssClass="header"
                        FormatString="d.M.yyyy"
                        Width="50px" />
    
  </Columns>
</dot:GridView>
```

```CSHARP
using System;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.sample2
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

        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>() { PagingOptions = { PageSize = 4} };

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
    
    public record Customer(int Id, string Name);
}

```

## Sample 3: GridViewTemplateColumn

**GridViewTemplateColumn** allows to render custom content inside the table cell.

&nbsp;

### Required Properties

The most important property is the `ContentTemplate` which defines the content of each table cell.

You can also customize the header cell using the `HeaderText` property, or the `HeaderTemplate` template.

&nbsp;

The sorting and styling properties are the same as in the `GridViewTextColumn`.


```DOTHTML
<dot:GridView DataSource="{value: Customers}">
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" HeaderText="ID" />
    <dot:GridViewTemplateColumn HeaderText="Avatar">
      <ContentTemplate>
        <img src="{value: '../images/' + Id + '.png'}" 
             alt="{value: Name}" style="height: 40px"/>
      </ContentTemplate>
    </dot:GridViewTemplateColumn>
  </Columns>
</dot:GridView>

```

```CSHARP
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.sample3
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

        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>() { PagingOptions = { PageSize = 4} };

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

    public record Customer(int Id, string Name);
}

```

## Sample 4: Binding to a Collection

You don't have to use *GridViewDataSet*s if you don't want. Use a normal .NET collection as the `DataSource`. 

If the user wants to sort, there is the `SortChanged` command which fires when the user clicks the column header.

Notice that the method is on the main viewmodel object has parameters, however the command doesn't specify them, it is just `{command: Sort}`. 
That's because the `SortChanged` event expects a _delegate_ to a command, not a command itself. You can distinguish between standard events
and event delegates by the type in the **Events** table. 

If the type is **Command**, it is a standard command. If the type is **Command Delegate**, it is a delegate command.

The Sort method in the viewmodel accepts one parameter of **string**.

```DOTHTML
<dot:GridView DataSource="{value: Customers}" SortChanged="{command: Sort}">
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" 
                            HeaderText="ID" AllowSorting="true" />
    
    <dot:GridViewTextColumn ValueBinding="{value: Name}" 
                            HeaderText="Name" AllowSorting="true"/>
  </Columns>
</dot:GridView>
```

```CSHARP
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<Customer> FakeDb()
        {
            return new[]
            {
                new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"),new Customer(2,"Raine Damian"),
                new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred")
            }.AsQueryable();
        }

        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>() { PagingOptions = { PageSize = 4 } };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                var queryable = FakeDb();
                Customers.LoadFromQueryable(queryable);
            }
            return base.PreRender();
        }

        public void Sort(string column)
        {
            Customers.SortingOptions.SetSortExpression(column);
        }
    }

    public record Customer(int Id, string Name);
}

```

## Sample 5: RowDecorators and CellDecorators

Sometimes you need the rows in the grid to be clickable, or the cells to have some specific color. 

That's why the **GridView** can use *decorators* for table rows and cells.
A *decorator* can add various attributes to the element it decorates.

The `<dot:Decorator>` control will pass all its attributes and event handlers on the decorated element.

There are the following types of collections on `GridView` and decorate the `<tr>` elements:

* `RowDecorators` apply on all data-rows except for those that are in the edit mode (if inline editing is enabled).
* `EditRowDecorators` apply on the currently edited row (if inline editing is enabled).
* `HeaderRowDecorators` apply on the header row only.

The `GridViewColumn` and its descendants allow to specify the following decorators to decorate the `<td>` or `<th>` elements:

* `CellDecorators` apply on all cells except for those that are in the edit mode (if inline editing is enabled).
* `EditCellDecorators` apply on the cell in the row is in the edit mode (if inline editing is enabled).
* `HeaderCellDecorators` apply on the cell in the header row only.


```DOTHTML
<dot:GridView DataSource="{value: Customers}">
  <RowDecorators>
    <dot:Decorator Events.Click="{command: _parent.RowClicked(Id)}"
                   class="clickable"/>
  </RowDecorators>
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" 
                            HeaderText="ID" />
    <dot:GridViewTextColumn ValueBinding="{value: Name}" 
                            HeaderText="Name">
      <CellDecorators>
        <dot:Decorator class-name-too-long="{value: Name.Length > 14}" />
      </CellDecorators>
    </dot:GridViewTextColumn>
  </Columns>
</dot:GridView>

<p>Last clicked row: {{value: ClickedRowId}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.Sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Customer[] Customers { get; set; } = {
            new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"),new Customer(2,"Raine Emmerson Damian III"),
            new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred")
        };

        public string ClickedRowId { get; set; }

        public void RowClicked(int id)
        {
            ClickedRowId = id.ToString();
        }

    }
    
    public record Customer(int Id, string Name);
}

```

## Sample 6: Inline Editing

The `InlineEditing` property enables the row editing mode in the `GridView` control.

You have to do the following things to make the inline editing work:

* Bind the `GridView` control to the `GridViewDataSet<T>`, binding to simple collections is not supported in the inline-editing mode.

* Set the `PrimaryKeyPropertyName` on the data set to a name of the column having unique values in each row. Typically you need to 
    place the primary key column name in this property (Id, CustomerId etc.). It should be a value that works with the === operator
    in Javascript, so we recommend to use integer, string or Guid values.

* If you want to edit some row, set the `EditedRowId` on the `GridViewDataSet` to the value of the primary key of the row. The row will 
    become editable. If you want to exit from the edit mode, set the `EditedRowId` to `null`.

* If you want to make some column read-only, set its `IsEditable` property to `false`.

* If you don't want to use the default `GridViewTextColumn`, which renders a [Literal](~/controls/builtin/Literal) in the read-only 
    mode and the [TextBox](~/controls/builtin/TextBox) in the edit mode, use the `GridViewTemplateColumn` and use its `EditTemplate` 
    to specify how the cell will look like when in the edit mode.



If you use the `RowDecorators` property (see Sample 5), they are applied only to normal rows. If you need to apply a decorator to edit-mode rows,
use the `EditRowDecorators` property. 

```DOTHTML
<dot:GridView DataSource="{value: Customers}" InlineEditing="true">
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" 
                            HeaderText="ID" 
                            IsEditable="false" />
    
    <dot:GridViewTextColumn ValueBinding="{value: Name}" 
                            HeaderText="Name" />

    <dot:GridViewTemplateColumn AllowSorting="false">
      <ContentTemplate>
        <dot:Button Text="Edit" Click="{command: _parent.Edit(_this)}" />
      </ContentTemplate>
      <EditTemplate>
        <dot:Button Text="Save" Click="{command: _parent.Update(_this)}" />
        <dot:Button Text="Cancel" Click="{command: _parent.CancelEdit()}" />
      </EditTemplate>
    </dot:GridViewTemplateColumn>
  
  </Columns>
</dot:GridView>
```

```CSHARP
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.GridView.Sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        private static IQueryable<Customer> FakeDb()
        {
            return new[]
            {
                new Customer(0, "Dani Michele"), new Customer(1, "Elissa Malone"), new Customer(2,"Raine Damian"),
                new Customer(3, "Gerrard Petra"), new Customer(4, "Clement Ernie"), new Customer(5, "Rod Fred")
            }.AsQueryable();
        }

        public GridViewDataSet<Customer> Customers { get; set; } = new GridViewDataSet<Customer>() { RowEditOptions = { PrimaryKeyPropertyName = "Id" } };

        public void Edit(Customer customer)
        {
            Customers.RowEditOptions.EditRowId = customer.Id;
        }

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                var queryable = FakeDb();
                Customers.LoadFromQueryable(queryable);
            }
            return base.PreRender();
        }

        public void Update(Customer customer)
        {
            // TODO: save changes to the database
            Customers.RowEditOptions.EditRowId = null;

            // uncomment this line - it's here only for the sample to work without database
            //Customers.RequestRefresh();
        }

        public void CancelEdit()
        {
            Customers.RowEditOptions.EditRowId = null;

            // Refresh GridView items
            Customers.RequestRefresh();
        }
    }

    public record Customer(int Id, string Name);
}

```

