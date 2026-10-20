# <bs:DataPager>
Extends the builtin [DataPager](~/controls/builtin/DataPager) control to set up Bootstrap look of the control.

<https://getbootstrap.com/docs/4.3/components/pagination/>

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
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the data pager.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be triggered when the DataPager needs to load data (when navigating to different page).             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

## Sample 1: DataPager Sizing

Use the `Size` property to set the size of the pager.

```DOTHTML
<bs:GridView DataSource="{value: Customers}">
  <Columns>
    <dot:GridViewTextColumn ValueBinding="{value: Id}" HeaderText="ID" />
    <dot:GridViewTextColumn ValueBinding="{value: Name}" HeaderText="Name" />
  </Columns>
</bs:GridView>

<bs:DataPager DataSet="{value: Customers}" Size="Large" />
```

```CSHARP
using System;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DataPager.sample1
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

