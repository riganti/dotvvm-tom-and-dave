# <dot:HierarchyRepeater>
Repeats a template for each item in the `DataSource` collection and for each child item specified using the `ItemChildrenBinding`


## Rendered output
The `LevelWrapperTagName` property specifies which HTML tag should wrap each collection, while `ItemWrapperTagName` specifies which HTML tag should wrap each item (including its children).
Both properties are optional and if not specified, no wrapper is added (Knockout [virtual elements](https://knockoutjs.com/documentation/custom-bindings-for-virtual-elements.html) are used instead).

The entire repeater is also wrapped in `WrapperTagName`, unless `RenderWrapperTag=false` is specified. This property defaults to `div`.

The generated HTML differs in Server and Client `RenderSettings.Mode`s. Server mode does not include the client-side template, and thus the hierarchy will not update if new elements are added. Server-rebdered HTML has the following structure:

```html
<div>
    <ul>
        <li>
            [template 1]
            <ul>
                <li>
                    [template 1.1]
                    <!-- empty level tags (<ul></ul>) are not included -->
                </li>
            </ul>
        </li>
        <li>
            [template 2]
        </li>
    </ul>
</div>
```

Client-side rendering will result in the same hierarchy of DOM elements. Only the wrapper tag (`div`) and first level (`ul`) are rendered server-side, the rest is handled using a knockout `template` binding.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyDataTemplate`|ITemplate|Gets or sets the template which will be displayed when the data source is empty.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemChildrenBinding`|IStaticValueBinding<IEnumerable<Object>>|Gets or sets the binding which retrieves children of a data item.|attribute, bindable||
|`ItemID`|String||attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets the template for each HierarchyRepeater item.|inner element, static value, default property||
|`ItemVisible`|Boolean||attribute, static value, bindable|True|
|`ItemWrapperTagName`|String||attribute, static value||
|`LevelID`|String||attribute, static value, bindable||
|`LevelVisible`|Boolean||attribute, static value, bindable|True|
|`LevelWrapperTagName`|String||attribute, static value||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the HierarchyRepeaterLevel.|attribute, static value|div|

## Sample 1: Basic HierarchyRepeater

The `DataSource` points to a collection of `PageViewModel`s. The `ItemChildrenBinding` property is a nested collection of pages on the `PageViewModel` type.

Inside the `ItemTemplate`, you can use **_this** to access the current data item. Note that **_parent** is the data context of the HierarchyRepeater, not the parent hierarchical item.


```DOTHTML
<dot:HierarchyRepeater DataSource={value: Pages}
                       ItemChildrenBinding={value: ChildPages}
                       LevelWrapperTagName="ul"
                       LevelClass="level"
                       ItemWrapperTagName="li"
                       ItemClass="item">
    <a href={value: Link}>{{value: Title}}</a>
</dot:HierarchyRepeater>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public PageViewModel[] Pages { get; set; } = {
            new PageViewModel("Products", "/products", new PageViewModel[] {
                new PageViewModel("Bootstrap", "/products/bootstrap-for-dotvvm", new PageViewModel[0]),
                new PageViewModel("Bussiness Pack", "/products/dotvvm-business-pack", new PageViewModel[] {
                    new PageViewModel("Documentation", "/docs/latest/pages/business-pack/getting-started", new PageViewModel[0])
                }),
            }),
            new PageViewModel("Forum", "https://forum.dotvvm.com", new PageViewModel[0]),
            new PageViewModel("About", "/about", new PageViewModel[0]),
        };
    }

    public record PageViewModel(string Title, string Link, PageViewModel[] ChildPages);
}

```

