# <t:DataPager>
Inherits the built-in [DataPager](~/controls/builtin/DataPager) and applies the Tailwind pager styling. Use it with the same `GridViewDataSet` paging features as the built-in control.

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

## Sample 1: Paged GridView

The Tailwind `DataPager` uses the same `DataSet` binding as the built-in [DataPager](~/controls/builtin/DataPager). Bind it to the same `GridViewDataSet` as the `GridView` so both controls stay in sync.


```DOTHTML
<t:GridView DataSource="{value: People}">
    <Columns>
        <dot:GridViewTextColumn HeaderText="ID" ValueBinding="{value: Id}" />
        <dot:GridViewTextColumn HeaderText="Name" ValueBinding="{value: Name}" />
        <dot:GridViewTextColumn HeaderText="Department" ValueBinding="{value: Department}" />
    </Columns>
</t:GridView>

<t:DataPager DataSet="{value: People}" />

```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.DataPager.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public GridViewDataSet<PersonDto> People { get; set; } = new GridViewDataSet<PersonDto>()
        {
            PagingOptions = { PageSize = 4 }
        };

        public override Task PreRender()
        {
            if (People.IsRefreshRequired)
            {
                People.LoadFromQueryable(GetPeople().AsQueryable());
            }

            return base.PreRender();
        }

        private static List<PersonDto> GetPeople()
        {
            return new List<PersonDto>
            {
                new PersonDto { Id = 1, Name = "Alice Johnson", Department = "Engineering" },
                new PersonDto { Id = 2, Name = "Bob Smith", Department = "Design" },
                new PersonDto { Id = 3, Name = "Carol White", Department = "QA" },
                new PersonDto { Id = 4, Name = "David Brown", Department = "Product" },
                new PersonDto { Id = 5, Name = "Eva Green", Department = "Support" },
                new PersonDto { Id = 6, Name = "Frank Miller", Department = "Sales" },
                new PersonDto { Id = 7, Name = "Grace Lee", Department = "Finance" },
                new PersonDto { Id = 8, Name = "Henry Davis", Department = "Engineering" }
            };
        }
    }

    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }
    }
}

```

## Sample 2: Current Page Link and Enabled State

The Tailwind pager keeps the built-in `RenderLinkForCurrentPage` and `Enabled` properties. This sample renders the active page as a link and lets you disable the whole pager.


```DOTHTML
<t:DataPager DataSet="{value: People}" RenderLinkForCurrentPage="true" Enabled="{value: Enabled}" />

<t:CheckBox Text="Enabled" Checked="{value: Enabled}" />

```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.DataPager.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Enabled { get; set; } = true;

        public GridViewDataSet<PersonDto> People { get; set; } = new GridViewDataSet<PersonDto>()
        {
            PagingOptions = { PageSize = 4 }
        };

        public override Task PreRender()
        {
            if (People.IsRefreshRequired)
            {
                People.LoadFromQueryable(GetPeople().AsQueryable());
            }

            return base.PreRender();
        }

        private static List<PersonDto> GetPeople()
        {
            return new List<PersonDto>
            {
                new PersonDto { Id = 1, Name = "Alice Johnson" },
                new PersonDto { Id = 2, Name = "Bob Smith" },
                new PersonDto { Id = 3, Name = "Carol White" },
                new PersonDto { Id = 4, Name = "David Brown" },
                new PersonDto { Id = 5, Name = "Eva Green" },
                new PersonDto { Id = 6, Name = "Frank Miller" },
                new PersonDto { Id = 7, Name = "Grace Lee" },
                new PersonDto { Id = 8, Name = "Henry Davis" }
            };
        }
    }

    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

```

