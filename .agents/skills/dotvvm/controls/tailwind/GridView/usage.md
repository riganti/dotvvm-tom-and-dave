# <t:GridView>
Inherits the built-in [GridView](~/controls/builtin/GridView) and applies the Tailwind table styling. All columns, sorting, paging, templates, and empty-state features work the same as on the built-in control.

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
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be triggered when the GridView needs to load data (e.g. when the sort order has changed).             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

## Sample 1: Sorting and Template Columns

The Tailwind `GridView` uses the same API as the built-in [GridView](~/controls/builtin/GridView). This sample shows sortable text columns, a template column, and an empty-data template.

```DOTHTML
<t:GridView DataSource="{value: Customers}">
    <Columns>
        <dot:GridViewTextColumn HeaderText="ID" ValueBinding="{value: Id}" AllowSorting="true" SortExpression="Id" />
        <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" AllowSorting="true" SortExpression="Name" />
        <dot:GridViewTextColumn HeaderText="Department" ValueBinding="{value: Department}" AllowSorting="true" SortExpression="Department" />
        <dot:GridViewTemplateColumn HeaderText="Actions">
            <ContentTemplate>
                <t:Button Type="Primary" Text="Select" Click="{command: _root.SelectCustomer(_this)}" />
            </ContentTemplate>
        </dot:GridViewTemplateColumn>
    </Columns>
    <EmptyDataTemplate>
        <p>No customers are available.</p>
    </EmptyDataTemplate>
</t:GridView>

<p>Selected customer: {{value: SelectedCustomerName}}</p>

```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.GridView.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedCustomerName { get; set; } = "(none)";

        public GridViewDataSet<CustomerDto> Customers { get; set; } = new GridViewDataSet<CustomerDto>()
        {
            PagingOptions = { PageSize = 4 },
            SortingOptions = { SortExpression = nameof(CustomerDto.Name) }
        };

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetCustomers().AsQueryable());
            }

            return base.PreRender();
        }

        public void SelectCustomer(CustomerDto customer)
        {
            SelectedCustomerName = customer.Name;
        }

        private static List<CustomerDto> GetCustomers()
        {
            return new List<CustomerDto>
            {
                new CustomerDto { Id = 1, Name = "Alice Johnson", Department = "Engineering" },
                new CustomerDto { Id = 2, Name = "Bob Smith", Department = "Design" },
                new CustomerDto { Id = 3, Name = "Carol White", Department = "QA" },
                new CustomerDto { Id = 4, Name = "David Brown", Department = "Product" },
                new CustomerDto { Id = 5, Name = "Eva Green", Department = "Support" },
                new CustomerDto { Id = 6, Name = "Frank Miller", Department = "Sales" }
            };
        }
    }

    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }
    }
}

```

