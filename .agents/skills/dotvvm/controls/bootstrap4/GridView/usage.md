# <bs:GridView>
A Bootstrap extension for the [built-in GridView](~/controls/builtin/GridView) control which allows to apply Bootstrap table classes on the table.

<https://getbootstrap.com/docs/4.3/content/tables/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Border`|([BootstrapTableBorder](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapTableBorder.md))|Gets or sets the style of table border.|attribute, static value|Default|
|`Caption`|String|Gets or sets the caption of the GridView.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Columns`|List<GridViewColumn>|Gets or sets a collection of columns that will be placed inside the grid.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EditRowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each row in edit mode.|inner element, static value||
|`EmptyDataTemplate`|ITemplate|Gets or sets the template which will be displayed when the DataSource is empty.|inner element, static value, bindable||
|`FilterPlacement`|([GridViewFilterPlacement](../../builtin/_enums/DotVVM.Framework.Controls.GridViewFilterPlacement.md))|Gets or sets the place where the filters will be created.|attribute, static value, bindable|HeaderRow|
|`HasStripedRows`|Boolean|Gets or sets whether rows have alternating colors.|attribute, static value, bindable|False|
|`HeaderRowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on the header row.|inner element, static value||
|`HeaderTheme`|([BootstrapTableHeaderTheme](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapTableHeaderTheme.md))|Gets or sets the template color of the GridView header.|attribute, static value|Default|
|`HighlightRowOnHover`|Boolean|Gets or sets whether row should be highlighted on hover.|attribute, static value, bindable|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InlineEditing`|Boolean|Gets or sets whether the inline editing is allowed in the Grid. If so, you have to use a GridViewDataSet as the DataSource.|attribute, static value|False|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`MaximumScreenSizeBeforeScrollBarShows`|([ResponsiveBreakpoints](../_enums/DotVVM.Framework.Controls.Bootstrap4.ResponsiveBreakpoints.md))|Gets or sets the maximum screen size on which the horizontal scrollbar is still not visible.             Setting the property to None will cause the scrollbar to never appear.|attribute, static value|None|
|`RowDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each row which is not in the edit mode.|inner element, static value||
|`ShowHeaderWhenNoData`|Boolean|Gets or sets whether the header row should be displayed when the grid is empty.|attribute, static value|False|
|`Size`|([BootstrapTableSize](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapTableSize.md))|Gets or sets table size|attribute, static value|Default|
|`SortChanged`|Action<String>|Gets or sets the command that will be triggered when the user changed the sort order.|attribute, bindable||
|`TableTheme`|([BootstrapTableTheme](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapTableTheme.md))|Gets or sets the template color of the GridView.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be triggered when the GridView needs to load data (e.g. when the sort order has changed).             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

## Sample 1: Simple Bootstrap GridView

The usage is the same as the built-in [GridView](~/controls/builtin/GridView) control.

You can specify whether the table should have borders using the `Border` property - the values are `Default`, `None` or `All`.

```DOTHTML
<bs:GridView DataSource="{value: Customers}" Border="All">
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

## Sample 2: GridView Themes

The table body and header can use various color themes. Use `TableTheme` to set color the table. If you want to set color to header only than you `HeaderTheme`.

```DOTHTML
<bs:GridView DataSource="{value: Customers}" 
             TableTheme="Dark" HeaderTheme="Dark">
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

## Sample 3: Striped Rows and Highlighted Rows

The `HasStripedRows` property can make the rows to use dual colors.

The `HighlightRowOnHover` property will change the row color when the mouse cursor is over.

```DOTHTML
<bs:GridView DataSource="{value: Customers}" 
             HasStripedRows="true" HighlightRowOnHover="true">
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

## Sample 4: Responsive Table

The `MaximumScreenSizeBeforeScrollBarShows` property will maximum screen size on which the horizontal scrollbar is still not visible.  
Setting the property to None will cause the scrollbar to never appear.

Showing horizontal scrollbar will improve user experience when viewing wider tables on small screens.

```DOTHTML
<bs:GridView DataSource="{value: Customers}" 
             MaximumScreenSizeBeforeScrollBarShows="Medium">
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

## Sample 5: Table Size

The `Size` property allows to specify the size of the table - `Default` or `Small`.

```DOTHTML
<bs:GridView DataSource="{value: Customers}"  
             Size="Small">
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

## Sample 6: Table Border

The `Border` property allows to specify which borders would be drawn.
* `All` : Borders around each cell
* `Default` : Borders separating rows
* `None` : No borders

```DOTHTML
<bs:GridView DataSource="{value: Customers}" 
             Border="All" >
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

## Sample 7: Captions

The `Caption` serves as heading for entire table. It helps users with screen readers to better understand what the table contains.

```DOTHTML
<bs:GridView DataSource="{value: Customers}"  
             Caption="Customer table" >
  <Columns>
    <dot:GridViewTextColumn HeaderText="Id" ValueBinding="{value: CustomerId}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="True" />
    <dot:GridViewTextColumn HeaderText="Birth Date" ValueBinding="{value: BirthDate}" FormatString="g" AllowSorting="True" />
  </Columns>
</bs:GridView>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    private static IQueryable<CustomerData> FakeDb()
    {
        return new[]
        {
            new CustomerData() { CustomerId = 1, Name = "John Doe", BirthDate = DateTime.Parse("1976-04-01"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 2, Name = "John Deer", BirthDate = DateTime.Parse("1984-03-02"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 3, Name = "Johnny Walker", BirthDate = DateTime.Parse("1934-01-03"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 4, Name = "Jim Hacker", BirthDate = DateTime.Parse("1912-11-04"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 5, Name = "Joe E. Brown", BirthDate = DateTime.Parse("1947-09-05"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 6, Name = "Jim Harris", BirthDate = DateTime.Parse("1956-07-06"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 7, Name = "J. P. Morgan", BirthDate = DateTime.Parse("1969-05-07"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 8, Name = "J. R. Ewing", BirthDate = DateTime.Parse("1987-03-08"), Color = BootstrapColor.Warning },
            new CustomerData() { CustomerId = 9, Name = "Jeremy Clarkson", BirthDate = DateTime.Parse("1994-04-09"), Color = BootstrapColor.Danger },
            new CustomerData() { CustomerId = 10, Name = "Jenny Green", BirthDate = DateTime.Parse("1947-02-10"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 11, Name = "Joseph Blue", BirthDate = DateTime.Parse("1948-12-11"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 12, Name = "Jack Daniels", BirthDate = DateTime.Parse("1968-10-12"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 13, Name = "Jackie Chan", BirthDate = DateTime.Parse("1978-08-13"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 14, Name = "Jasper", BirthDate = DateTime.Parse("1934-06-14"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 15, Name = "Jumbo", BirthDate = DateTime.Parse("1965-06-15"), Color = BootstrapColor.Light },
            new CustomerData() { CustomerId = 16, Name = "Junkie Doodle", BirthDate = DateTime.Parse("1977-05-16"), Color = BootstrapColor.Light }
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

```

