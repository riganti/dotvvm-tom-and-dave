# <bp:GridView>
This control is different from the built-in [GridView](~/controls/builtin/GridView) and is not derived from it.

The *Business Pack* `GridView` control is a advanced grid control with many features.

The *version 3.0* supports the following features (except of the features supported in the built-in GridView):

* Inline Insert row
* Column Hiding
* Column Reordering
* Column Resizing
* Row Reordering
* Customizable Filters
* Row Detail

The following features are planned to be added in the following releases:

* Grouping


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowColumnResizing`|Boolean||attribute, static value, bindable|False|
|`AllowInlineInsert`|Boolean||attribute, static value|False|
|`AllowReorderColumns`|Boolean||attribute, static value|False|
|`BooleanOperators`|List<IBooleanOperator>||inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CollectionOperators`|List<ICollectionOperator>||inner element, static value||
|`Columns`|List<GridViewColumn>||inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IBusinessPackDataSet||attribute, bindable||
|`DateTimeOperators`|List<IDateTimeOperator>||inner element, static value||
|`EditRowDecorators`|List<Decorator>||inner element, static value, bindable||
|`EmptyDataTemplate`|ITemplate||inner element, static value||
|`EnumOperators`|List<IEnumOperator>||inner element, static value||
|`FilterIcon`|IconBase||inner element, static value, bindable||
|`FilterInline`|Boolean||attribute, static value|False|
|`FilterPlacement`|GridViewFilterPlacement||attribute, static value|Popup|
|`FixedHeaderRow`|Boolean||attribute, static value|False|
|`FooterTemplate`|ITemplate||inner element, static value, bindable||
|`HeaderTemplate`|ITemplate||inner element, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InlineEditMode`|GridViewInlineEditMode||attribute, static value|Disabled|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InsertRowDecorators`|List<Decorator>||inner element, static value||
|`InsertRowPlacement`|GridViewInsertRowPlacement||attribute, static value|Top|
|`NumberOperators`|List<INumberOperator>||inner element, static value||
|`RowDecorators`|List<Decorator>||inner element, static value, bindable||
|`RowDetailTemplate`|ITemplate||inner element, static value, bindable||
|`RowHasDetailBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ShowTableWhenNoData`|Boolean||attribute, static value|False|
|`SortAscIcon`|IconBase||inner element, static value, bindable||
|`SortDescIcon`|IconBase||inner element, static value, bindable||
|`StringOperators`|List<IStringOperator>||inner element, static value||
|`UserSettings`|GridViewUserSettings||attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding||
|`UserSettingsChanged`|Command||

## Sample 1: Basic Usage

The `DataSource` property expects `BusinessPackDataSet<T>` object which contains all necessary information about the data presented by the control.

The `Columns` collection specifies all columns in the control.

The `HeaderText` property of the column defines the text displayed in the column header.

### Column Types

The `<bp:GridViewTextColumn>` renders a text, numeric or date values in the cell. The `Value` expression specifies the property to be rendered.
The `FormatString` property specifies the format of the value (for numeric and date columns).

The `<bp:GridViewTemplateColumn>` renders a specified template in the grid cell.



```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" HeaderText="ID" />
        <bp:GridViewTextColumn Value="{value: Name}" HeaderText="Name" />
        <bp:GridViewTextColumn Value="{value: BirthDate}" HeaderText="Birth Date"
                               FormatString="dd.MM.yyyy" />
        <bp:GridViewTemplateColumn>
            <ContentTemplate>
                <b>{{value: Orders}}</b>
            </ContentTemplate>
        </bp:GridViewTemplateColumn>
    </Columns>
</bp:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = { SortExpression = nameof(Customer.Id) }
        };

        public override Task PreRender()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample1
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 10: User Settings

The `UserSettings` property allows to persist the customizations that the user has made to the grid control. This property expects an object of type `GridViewUserSettings` which stores the widths and visibility of the individual columns.

This object can be JSON-serialized easily and stored in the database, file system or any other data store. When the user customizes anything in the grid, the changes are stored in this object.

### Identification of Grid Columns

Since the developer may change the order of the grid columns, add new columns or remove the existing ones, the `GridViewUserSettings` object doesn't work with column indexes, but uses column names. You can mark each column in the markup with an unique name that will be used in the user settings object. If you rename the property in the viewmodel, or move the column to another place in the grid, the user settings object won't break and will be able to identify the column.

You can provide the name using the `ColumnName` property. If the name is not specified, the GridView will try to determine the column name from the `Value` property. In case of the `GridViewTemplateColumn` which does not have the property, the column index will be used instead. 

> If you use the `UserSettings` property, make sure that at least all template columns have the `ColumnName` property set. Otherwise the user settings may break in the future when the columns are changed by the application developer.



```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             UserSettings="{value: UserSettings}">
    <Columns>
        <bp:GridViewTextColumn ColumnName="CustomerName"
                               Value="{value: Name}"
                               HeaderText="Name" />
        <bp:GridViewTextColumn ColumnName="CustomerOrders"
                               Value="{value: Orders}"
                               HeaderText="Orders" />
        <bp:GridViewTextColumn ColumnName="CustomerId"
                               Value="{value: Id}"
                               HeaderText="Customer ID" />
        <bp:GridViewTextColumn ColumnName="CustomerBirthdate"
                               Value="{value: BirthDate}"
                               FormatString="dd.MM.yyyy"
                               HeaderText="Birthdate" />
    </Columns>
</bp:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample10
{
    public class ViewModel : DotvvmViewModelBase
    {
        public GridViewUserSettings UserSettings { get; set; } = new GridViewUserSettings {
                ColumnsSettings = new List<GridViewColumnSettings> {
                    new GridViewColumnSettings {
                        ColumnName = "CustomerId",
                        DisplayOrder = 0,
                        Width = 50
                    },
                    new GridViewColumnSettings {
                        ColumnName = "CustomerName",
                        DisplayOrder = 1,
                        Width = 400
                    },
                    new GridViewColumnSettings {
                        ColumnName = "CustomerBirthdate",
                        DisplayOrder = 2
                    },
                    new GridViewColumnSettings {
                        ColumnName = "CustomerOrders",
                        DisplayOrder = 3
                    }
                }
            };
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer> {
                PagingOptions = {
                    PageSize = 10
                }
            };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var numbers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return numbers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample10
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 11: Server Rendering

The control supports also the server-side rendering. In this mode, many functions cannot work since the control is rendered directly in the HTML output.

The server rendering can be turned on using the `RenderSettings.Mode` property. 

This helps especially the search engines to index the contents of the page. Additionally, the server rendering might make the grid load faster in the browser if there are hundreds of rows or more.

You can read more in the [Server-Side HTML Generation and SEO](~/pages/concepts/server-side-rendering) chapter.

```DOTHTML
<bp:GridView RenderSettings.Mode="Server"
             DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" 
                               HeaderText="Customer ID" />
        <bp:GridViewTextColumn Value="{value: Name}" 
                               HeaderText="Name" />
        <bp:GridViewTextColumn Value="{value: BirthDate}"
                               FormatString="dd.MM.yyyy"
                               HeaderText="Birthdate"/>
        <bp:GridViewTemplateColumn HeaderText="# of orders">
            <ContentTemplate>
                <b>{{value: Orders}}</b>
            </ContentTemplate>
        </bp:GridViewTemplateColumn>
    </Columns>
</bp:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample11
{
    public class ViewModel : DotvvmViewModelBase
    {
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>() {
                PagingOptions = {
                    PageSize = 10
                }};

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var numbers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return numbers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample11
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 12: Filtering

By default, filtering is not enabled on any column.

The filtering option can be turned on using the `AllowFiltering` property.

To customize where the filters appear, you can use the `FilterPlacement` property with values `Popup`, `HeaderRow`, `SeparateHeaderRow` and `SeparateFooterRow`. The default value is `Popup`.

If you want to define your custom template for filtering, you can specify the `FilterTemplate` inner element to provide a custom filter UI on every column. Even if the `FilterTemplate` is provided, it's still necessary set `AllowFiltering` to `true`.

In the viewmodel class, you can access filters by `FilteringOptions` property on your `BusinessPackDataSet` object. This property stores all currently used filters on `GridView`.

The `LoadFromQueryable` method will apply the filters on the `IQueryable` automatically. If you load the dataset with your own logic, you'll need to inspect the `FilteringOptions` and build the query appropriately. 


```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             FilterPlacement="SeparateHeaderRow">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name"
                               AllowFiltering />
        <bp:GridViewTextColumn Value="{value: Orders}"
                               HeaderText="Orders"
                               AllowFiltering>
            <FilterTemplate>
                <bp:TextBox Text="{value: _root.OrderFilter}"
                            Changed="{command: _root.OnOrderFilterChanged()}" />
            </FilterTemplate>
        </bp:GridViewTextColumn>
        <bp:GridViewTextColumn Value="{value: Id}"
                               HeaderText="Customer ID"
                               AllowFiltering />
        <bp:GridViewDateTimeColumn Value="{value: BirthDate}"
                                   FormatString="dd.MM.yyyy"
                                   HeaderText="Birthdate"
                                   AllowFiltering="false" />
    </Columns>
</bp:GridView>
```

```CSHARP
using DotVVM.BusinessPack.Controls;
public class ViewModel : DotvvmViewModelBase
{
    public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>
        {
            PagingOptions = { PageSize = 10 }
        };
    
    
    public string OrderFilter { get; set; }

    public override Task PreRender()
    {
        // you can initialize default filters
        if (!Context.IsPostBack) 
        {
            Customers.FilteringOptions = new FilteringOptions()
            {
                FilterGroup = new FilterGroup()
                {
                    Filters = new List<FilterBase>()
                    {                        
                        new FilterCondition() { FieldName = "Name", Operator = FilterOperatorType.Contains, Value = "1" }
                    },
                    Logic = FilterLogicType.And
                }
            };
        }
        
        // refresh data
        if (Customers.IsRefreshRequired)
        {
            Customers.LoadFromQueryable(GetQueryable(15));
        }

        return base.PreRender();
    }

    public void OnOrderFilterChanged()
    {
        // do your logic
        Customers.RequestRefresh();
    }

    private IQueryable<Customer> GetQueryable(int size)
    {
        var numbers = new List<Customer>();
        for (var i = 0; i < size; i++)
        {
            numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
        }
        return numbers.AsQueryable();
    }
}
```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample10
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 13: Filtering - Operators

You can specify what filtering operators should be supported for specific types.

These operators can be limited for the whole `GridView` or for a specific column. Both `GridView` and all column types have properties `BooleanOperators`, `NumberOperators`, `StringOperators`, `EnumOperators` and `CollectionOperators`, each of these will change filtering operators based on the type of the property.

Business Pack comes with a predefined set of operators for each of the operator types. They can be specified in markup with the `op` prefix. You can also specify `DisplayName` for each operator in order provide better description from the business perspective.

Possible operators for each type are:
- `StringOperators` - `EqualOperator`, `NotEqualOperator`, `StartsWithOperator`, `EndsWithOperator`, `ContainsOperator`
- `NumberOperators` - `EqualOperator`, `NotEqualOperator`, `GreaterThanOperator`, `GreaterThanOrEqualOperator`, `LessThanOperator`, `LessThanOrEqualOperator`
- `BooleanOperators` - `TrueOperator`, `FalseOperator`
- `EnumOperators` - `EqualOperator`, `NotEqualOperator`
- `CollectionOperators`- `ContainsOperator`

If your type supports null values you can also use `NullOperator` and `NotNullOperator`.

> Please note that if there are multiple `GridView` controls with the same data source, you need to make sure that the same column has the same set of allowed filters in each `GridView`. The shared data source means that the `FilteringOptions` are shared as well. Therefore, if you activate a filter on one of the grids, the same filter should be applied to all of them.

```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             FilterPlacement="SeparateHeaderRow">
    <!-- This will only allow Starts with and Ends with operators on all columns with string values in them. -->
    <StringOperators>
        <op:StartsWithOperator DisplayName="Starts with" />
        <op:EndsWithOperator DisplayName="Ends with" />
    </StringOperators>
    <!-- This will only allow filtering by true value on all columns with boolean values. -->
    <BooleanOperators>
        <op:TrueOperator DisplayName="Is true" />
    </BooleanOperators>
    <Columns>
        <!-- This column will use filtering operators specified in the GridView StringOperators collection -->
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name"
                               AllowFiltering />
        
        <!-- This column will use filtering operators specified in its own StringOperators collection  -->
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name with only Contains operator"
                               AllowFiltering>
            <StringOperators>
                <op:ContainsOperator DisplayName="Contains" />
            </StringOperators>
        </bp:GridViewTextColumn>

        <!-- This columns will use default filtering operators from the NumberOperators collection  -->
        <bp:GridViewTextColumn Value="{value: Orders}"
                               HeaderText="Number of orders"
                               AllowFiltering />

        <!-- This column will use filtering operators specified in the GridView BooleanOperators collection -->
        <bp:GridViewCheckBoxColumn Value="{value: HasPremiumSupport}"
                                   HeaderText="Has premium support"
                                   AllowFiltering  />
    </Columns>
</bp:GridView>
```

```CSHARP
using DotVVM.BusinessPack.Controls;

public class ViewModel : DotvvmViewModelBase
{
    public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>
        {
            PagingOptions = { PageSize = 10 }
        };

    public override Task PreRender()
    {
        if (Customers.IsRefreshRequired)
        {
            Customers.LoadFromQueryable(GetQueryable(15));
        }

        return base.PreRender();
    }

    public void OnOrderFilterChanged()
    {
        // do your logic
    }

    private IQueryable<Customer> GetQueryable(int size)
    {
        var numbers = new List<Customer>();
        for (var i = 0; i < size; i++)
        {
            numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
        }
        return numbers.AsQueryable();
    }
}
```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample13
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
        public bool HasPremiumSupport { get; set; }
    }
}
```

## Sample 14: Row Selection

`GridView` supports row selection via adding a special column `GridViewRowSelectColumn`. This column will render checkbox in each row, which will allow your users to select rows via ticking this checkbox.

The `SelectedRows` property is bound to the property which contains list of selected rows from the `DataSource` collection. 

To make `SelectedRows` contains only value of a specific property from `DataSource` object (like the `Id` property of the selected objects), you may use the `ItemValueBinding` property.

```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
            <bp:GridViewRowSelectColumn SelectedRows="{value: SelectedCustomerIds}" 
                                        ItemValueBinding="{value: Id}" />
            <bp:GridViewTextColumn Value="{value: Id}" 
                                   HeaderText="ID" />
            <bp:GridViewTextColumn Value="{value: Name}" 
                                   HeaderText="Name" />
            <bp:GridViewTextColumn Value="{value: BirthDate}" 
                                   HeaderText="BirthDate" />
    </Columns>
</bp:GridView>
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>
        {
            PagingOptions = { PageSize = 10 }
        };

    public List<int> SelectedCustomerIds { get; set; } = new List<int>();

    public override Task PreRender()
    {
        if (Customers.IsRefreshRequired)
        {
            Customers.LoadFromQueryable(GetQueryable(15));
        }

        return base.PreRender();
    }

    private IQueryable<Customer> GetQueryable(int size)
    {
        var numbers = new List<Customer>();
        for (var i = 0; i < size; i++)
        {
            numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
        }
        return numbers.AsQueryable();
    }
}
```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample13
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
        public bool HasPremiumSupport { get; set; }
    }
}
```

## Sample 2: Grid Headers

When the `DataSource` is empty, the grid will not appear at all by default. The `ShowTableWhenNoData` property can be used to make the grid header visible even if there are no data.

The `HeaderCssClass` property of the column sets the CSS class to the column header cell.

To place custom content in the header cell, you can use the `HeaderTemplate` property.

```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             ShowTableWhenNoData="true">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}"
                               HeaderText="Customer ID" />
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderCssClass="gridview-header-highlight">
            <HeaderTemplate>
                <i>Name</i>
            </HeaderTemplate>
        </bp:GridViewTextColumn>
    </Columns>
</bp:GridView>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool ShowHeaderWhenNoData { get; set; } 
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = { SortExpression = nameof(Customer.Id) }
        };

        public override Task PreRender()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}" });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample2
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 3: Grid Footer

By default, the grid doesn't render any footer.

If any of the columns specifies its `FooterTemplate` property, the footer row will appear.

The `FooterTemplate` property of the control can be used to render an additional footer row for the entire table.


```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" HeaderText="ID" />
        <bp:GridViewTextColumn Value="{value: Name}" HeaderText="Name" />
        <bp:GridViewTextColumn Value="{value: Orders}" HeaderText="Orders" 
                               FooterCssClass="gridview-footer">
            <FooterTemplate>
                <p>Total orders: {{value: TotalOrders}}</p>
            </FooterTemplate>
        </bp:GridViewTextColumn>
    </Columns>
</bp:GridView>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int TotalOrders => Customers.Items.Sum(c => c.Orders);

        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = { SortExpression = nameof(Customer.Id) }
        };
        
        public override Task PreRender()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample3
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 4: Sorting

By default, the sorting is not enabled on any column. You can use the `AllowSorting` property to enable it.

The columns which have the `Value`, will sort using the specified expression by default. If the column doesn't have this property (e. g. `GridViewTemplateColumn`), or if you need to use another property to define the order of the rows, you can use the `SortExpression` property. This property takes precedence over the `Value`.

To customize the icons for sorting, you can use the `SortAscendingHeaderCssClass` and `SortDescendingHeaderCssClass` properties which specify the CSS class to be added to the header of the column which is used for the searching.

You can also set these properties on the `GridView` control instead of declaring them for each column separately, using `GridViewColumn.SortAscendingHeaderCssClass="value"`.


```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}"
                               HeaderText="Id"
                               AllowSorting="true"
                               SortAscendingHeaderCssClass="sort-asc-custom"
                               SortDescendingHeaderCssClass="sort-desc-custom" />
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name"
                               AllowSorting="true"
                               SortExpression="LastName" />
        <bp:GridViewTextColumn Value="{value: Orders}"
                               HeaderText="Orders"
                               AllowSorting="true" />
    </Columns>
</bp:GridView>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = { SortExpression = nameof(Customer.Id) }
        };

        public override Task PreRender()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample4
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 5: Paging

The paging relies on the [DataPager](~/controls/businesspack/DataPager) control and the use of the `BusinessPackDataSet<T>` object.

```DOTHTML
<bp:GridView DataSource="{value: Customers}">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" HeaderText="ID" />
        <bp:GridViewTextColumn Value="{value: Name}" HeaderText="Name" />
        <bp:GridViewTextColumn Value="{value: BirthDate}" HeaderText="Birth Date" 
                               FormatString="dd.MM.yyyy" />
        <bp:GridViewTextColumn Value="{value: Orders}" HeaderText="Orders" />
    </Columns>
</bp:GridView>

<bp:DataPager DataSet="{value: Customers}" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        private const int defaultPageSize = 5;

        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            PagingOptions = { PageSize = defaultPageSize },
            SortingOptions =  {SortExpression = nameof(Customer.Id) }
        };

        public override Task PreRender()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }
            return base.PreRender();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample5
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 6: Inline Editing

Enum `InlineEditMode` specifies whether the user will be able to edit rows directly in the grid. To enable editing set the value to `SingleRow`.

Every column has the `AllowEditing` property which specifies whether the particular column can be edited or not.

The columns also have the `EditTemplate` property which can be used to define a custom edit template for the cell.

The object that is currently being edited, is found by the `Customers.RowEditOptions.EditRowId` property which contains its primary key. The name of the property that is the primary key is set in `Customers.RowEditOptions.PrimaryKeyPropertyName`.

Validation on the editable row can be enabled by setting `BusinessPack.AllowAutoValidation` on the `<bp:GridView`. This property automatically sets `Validator.Value` on all BusinessPack form controls.


```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             InlineEditMode="SingleRow">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}"
                               HeaderText="ID"
                               AllowEditing="false" />
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name" />
        <bp:GridViewTemplateColumn HeaderText="Birthdate">
            <ContentTemplate>
                <dot:Literal Text="{value: BirthDate}"
                             FormatString="dd.MM.yyyy" />
            </ContentTemplate>
            <EditTemplate>
                <bp:DateTimePicker SelectedDateTime="{value: BirthDate}"
                                   FormatString="dd.MM.yyyy"
                                   Mode="Date" />
            </EditTemplate>
        </bp:GridViewTemplateColumn>
        <bp:GridViewTextColumn HeaderText="Orders" Value="{value: Orders}" />
        <bp:GridViewTemplateColumn>
            <ContentTemplate>
                <dot:Button Text="Edit" Click="{command: _parent.EditCustomer(_this)}"/>
            </ContentTemplate>
            <EditTemplate>
                <dot:Button Text="Save" Click="{command: _parent.UpdateCustomer(_this)}"/>
                <dot:Button Text="Cancel" Click="{command: _parent.CancelEditCustomer()}"/>
            </EditTemplate>
        </bp:GridViewTemplateColumn>
    </Columns>
</bp:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEditing { get; set; }
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = { SortExpression = nameof(Customer.Id) }, 
            RowEditOptions = { PrimaryKeyPropertyName = nameof(Customer.Id), EditRowId = -1 }
        };

        public override Task PreRender()
        {
            if(Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }
            return base.PreRender();
        }

        public void EditCustomer(Customer customer)
        {
            Customers.RowEditOptions.EditRowId = customer.Id;
            IsEditing = true;
        }

        public void UpdateCustomer(Customer customer)
        {
            // Submit customer changes to your database..
            CancelEdit();
        }

        private void CancelEdit()
        {
            Customers.RowEditOptions.EditRowId = -1;
            IsEditing = false;
        }

        public void CancelEditCustomer()
        {
            CancelEdit();
            Customers.RequestRefresh();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample6
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 7: Inline Inserting

The `InlineInsertMode` property can be used to enable the inline insert feature on the grid. This feature adds an additional editable row to the table that can be used to add new items.

The `InlineInsertRowPlacement` property specifies whether the row is placed on the `Top` or the `Bottom` of the table.

In the column, you can then specify the `InsertTemplate` to provide a custom template for a cell in the insert row.

If you need to combine the inline insert with inline edit, you can provide both templates, or set only the `EditTemplate`. If the `InsertTemplate` is not set, the `EditTemplate` will be used.

```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             AllowInlineInsert="true"
             InsertRowPlacement="Bottom">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}"
                               HeaderText="ID"
                               AllowEditing="false" />

        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name" />

        <bp:GridViewDateTimeColumn Value="{value: BirthDate}"
                                   HeaderText="Birthdate"
                                   FormatString="dd.MM.yyyy"/>

        <bp:GridViewTemplateColumn HeaderText="Orders">
            <ContentTemplate>
                <dot:Literal Text="{value: Orders}" />
            </ContentTemplate>
        </bp:GridViewTemplateColumn>

    </Columns>
</bp:GridView>

<br />
<bp:Button Text="Add row"
           Click="{command: InsertNewCustomer()}"
           Visible="{value: !IsInserting}" />
<bp:Button Text="Save"
           Type="Success"
           Click="{command: SaveNewCustomer()}"
           Visible="{value: IsInserting}" />
<bp:Button Text="Cancel"
           Type="Danger"
           Click="{command: CancelInsertNewCustomer()}"
           Visible="{value: IsInserting}" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string NewCustomerName { get; set; }
        public DateTime NewCustomerBirthday { get; set; } = DateTime.Now;
        public bool IsInserting { get; set; }
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>
        {
            PagingOptions = {
                    PageSize = 10
                },
            RowEditOptions = new RowEditOptions
            {
                PrimaryKeyPropertyName = nameof(Customer.Id),
                EditRowId = -1
            }
        };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        public void InsertNewCustomer()
        {
            Customers.RowInsertOptions.InsertedRow = new Customer
            {
                Id = Customers.Items.Max(c => c.Id) + 1,
                Name = NewCustomerName,
                BirthDate = NewCustomerBirthday,
                Orders = 0
            };
            IsInserting = true;
        }

        public void CancelInsertNewCustomer()
        {
            Customers.RowInsertOptions.InsertedRow = null;
            IsInserting = false;
        }

        public void SaveNewCustomer()
        {
            // Save inserted item to database
            Customers.Items.Add(Customers.RowInsertOptions.InsertedRow);
            CancelInsertNewCustomer();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var numbers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return numbers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample7
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

## Sample 8: Advanced Column Types

There are several columns which use various *Business Pack* controls in the insert and edit mode:

* the `GridViewComboBoxColumn` renders a [ComboBox](~/controls/businesspack/ComboBox) control.

* The `GridViewCheckBoxColumn` renders a [CheckBox](~/controls/businesspack/CheckBox) control.

The properties of the column have the same names and meaning like the properties of the control inside the cell.

```DOTHTML
<bp:GridView DataSource="{value: Orders}"
             InlineEditMode="SingleRow">
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}"
                               HeaderText="Order ID" />

        <bp:GridViewComboBoxColumn Value="{value: DeliveryType}"
                                   DataSource="{value: DeliveryTypes}"
                                   HeaderText="Delivery type" />

        <bp:GridViewTemplateColumn HeaderText="Date">
            <ContentTemplate>
                <dot:Literal Text="{value: CreatedDate}"
                             FormatString="dd.MM.yyyy hh:mm" />
            </ContentTemplate>
            <EditTemplate>
                <bp:DateTimePicker SelectedDateTime="{value: CreatedDate}"
                                   FormatString="dd.MM.yyyy hh:mm"
                                   Mode="DateTime" />
            </EditTemplate>
        </bp:GridViewTemplateColumn>

        <bp:GridViewCheckBoxColumn Value="{value: IsPaid}"
                                   HeaderText="Is Paid?" />
        <bp:GridViewTemplateColumn>
            <ContentTemplate>
                <bp:Button Text="Edit"
                           Click="{command: _parent.Orders.RowEditOptions.EditRowId = Id}" />
            </ContentTemplate>
            <EditTemplate>
                <dot:Button Text="Save" Click="{command: _parent.UpdateOrder(_this)}" />
                <dot:Button Text="Cancel" Click="{command: _parent.CancelEditOrder()}" />
            </EditTemplate>
        </bp:GridViewTemplateColumn>
    </Columns>
</bp:GridView>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample8
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEditing { get; set; }
        public BusinessPackDataSet<Order> Orders { get; set; } = new BusinessPackDataSet<Order> {
                PagingOptions = {
                    PageSize = 10
                },
                RowEditOptions = new RowEditOptions {
                    PrimaryKeyPropertyName = nameof(Order.Id),
                    EditRowId = -1
                }
            };
        public List<string> DeliveryTypes { get; set; } = new List<string> { "Post office", "Home" };

        public override Task PreRender()
        {
            if (Orders.IsRefreshRequired)
            {
                Orders.LoadFromQueryable(GetQueryable(15));
            }

            return base.PreRender();
        }

        public void EditOrder(Order order)
        {
            Orders.RowEditOptions.EditRowId = order.Id;
            IsEditing = true;
        }

        public void UpdateOrder(Order order)
        {
            // Submit customer changes to your database..
            CancelEdit();
        }

        private void CancelEdit()
        {
            Orders.RowEditOptions.EditRowId = -1;
            IsEditing = false;
        }

        public void CancelEditOrder()
        {
            CancelEdit();
            Orders.RequestRefresh();
        }

        private IQueryable<Order> GetQueryable(int size)
        {
            var numbers = new List<Order>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Order { Id = i + 1, DeliveryType = DeliveryTypes[(i + 1) % 2], IsPaid = (i + 1) % 2 == 0, CreatedDate = DateTime.Now.AddDays(-i) });
            }
            return numbers.AsQueryable();
        }

    }
}

```

```CSHARP
using System;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample8
{
    public class Order
    {
        public int Id { get; set; }
        public string DeliveryType { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
```

## Sample 9: Row Decorators

The `RowDecorators` property can specify decorators that are applied to individual grid rows. The decorator can add properties or event handlers to the `<tr>` element rendered by the grid.

For the rows in the edit mode, the `EditRowDecorators` are used instead of the default decorator collection.

Similarly, for the rows in the insert mode, the `InsertRowDecorators` are used.


```DOTHTML
<bp:GridView DataSource="{value: Customers}"
             InlineEditMode="SingleRow">
    <RowDecorators>
        <%-- Set different css class for even and odd rows --%>
        <dot:Decorator class="{value: Id % 2 == 0 ? 'even-row' : 'odd-row'}" />
        <%-- Set background color warning for customer without any orders --%>
        <dot:Decorator style="{value: Orders == 0 ? 'background-color: palevioletred !important;' : ''}" />
    </RowDecorators>
    <EditRowDecorators>
        <%-- Set css class for edit row scenario --%>
        <dot:Decorator class="edit-row" />
    </EditRowDecorators>
    <Columns>
        <bp:GridViewTextColumn Value="{value: Id}" 
                               HeaderText="Customer ID" />
        <bp:GridViewTextColumn Value="{value: Name}"
                               HeaderText="Name" />
        <bp:GridViewTextColumn Value="{value: Orders}" 
                               HeaderText="# of orders" />
        <bp:GridViewTemplateColumn>
            <ContentTemplate>
                <bp:Button Text="Edit"
                           Click="{command: _parent.Customers.RowEditOptions.EditRowId = Id}" />
            </ContentTemplate>
            <EditTemplate>
                <dot:Button Text="Save" Click="{command: _parent.UpdateCustomer(_this)}" />
                <dot:Button Text="Cancel" Click="{command: _parent.CancelEditCustomer()}" />
            </EditTemplate>
        </bp:GridViewTemplateColumn>
    </Columns>
</bp:GridView>

<style type="text/css">
    .even-row {
        background-color: aquamarine !important;
    }

    .odd-row {
        background-color: azure !important;
    }

    .edit-row {
        background-color: yellow !important;
    }
</style>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample9
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsEditing { get; set; }
        public BusinessPackDataSet<Customer> Customers { get; set; } = new BusinessPackDataSet<Customer>()
        {
            SortingOptions = { SortExpression = nameof(Customer.Id) },
            RowEditOptions = { PrimaryKeyPropertyName = nameof(Customer.Id), EditRowId = -1 }
        };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }
            return base.PreRender();
        }

        public void EditCustomer(Customer customer)
        {
            Customers.RowEditOptions.EditRowId = customer.Id;
            IsEditing = true;
        }

        public void UpdateCustomer(Customer customer)
        {
            // Submit customer changes to your database..
            CancelEdit();
        }

        private void CancelEdit()
        {
            Customers.RowEditOptions.EditRowId = -1;
            IsEditing = false;
        }

        public void CancelEditCustomer()
        {
            CancelEdit();
            Customers.RequestRefresh();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var customers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                customers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return customers.AsQueryable();
        }
    }
}

```

```CSHARP
using System;
using System.Linq;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample9
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName => !string.IsNullOrWhiteSpace(Name) ? Name.Split(' ').LastOrDefault() : "";
        public DateTime BirthDate { get; set; }
        public int Orders { get; set; }
    }
}
```

