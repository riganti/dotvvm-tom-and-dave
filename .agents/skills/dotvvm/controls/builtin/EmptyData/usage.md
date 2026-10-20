# <dot:EmptyData>
Allows to display content if and only if `DataSource` is empty or `null`. The property `EmptyDataTemplate` in the [Repeater](~/controls/builtin/Repeater) has similar behavior but the usage is limited only inside `Repeater`.

## Rendered output
The control renders the contents if and only if `DataSource` is empty or `null`. Optionally you can enable wrapper tag rendering using
the `RenderWrapperTag` property. The tag name can be changed using the `WrapperTagName` property. 

```DOTHTML
<div>
    <!-- If DataSource is empty or null content is rendered here -->
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

### Sample 1: Basic Usage

The `Customers` is a property of `List<Customer>` in the viewmodel.

The *EmptyData* content is displayed when `Customers` collection is empty or `null`.


```DOTHTML
<dot:EmptyData DataSource="{value: Customers}">
  <p class="error">No customers found</p>
</dot:EmptyData>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.EmptyData.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }


    public record Customer(int Id, string Name);
}

```

