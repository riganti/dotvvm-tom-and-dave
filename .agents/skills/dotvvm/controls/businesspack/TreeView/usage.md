# <bp:TreeView>
Renders a hierarchical structure of items and allows to select one or more of them.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoCheckChildren`|Boolean||attribute, static value, bindable|True|
|`AutoFocus`|Boolean||attribute, static value|False|
|`CheckBoxMode`|CheckBoxMode||attribute, static value, bindable|Hidden|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CollapseIcon`|IconBase||inner element, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable||attribute, bindable||
|`EmptyDataTemplate`|ITemplate||inner element, static value||
|`ExpandIcon`|IconBase||inner element, static value, bindable||
|`ExpandOnChecked`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemChildrenBinding`|IValueBinding<IEnumerable<Object>>||attribute, bindable||
|`ItemHasChildrenBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemIsExpandedBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemKeyBinding`|IValueBinding||attribute, bindable||
|`ItemTemplate`|ITemplate||inner element, static value, default property||
|`ItemValueBinding`|IValueBinding||attribute, bindable||
|`SelectedValues`|IEnumerable||attribute, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||
|`LoadChildren`|ICommandBinding<TreeView+LoadChildrenFunc>||

## Sample 1: Basic Usage

The `DataSource` property specifies the collection of root items.

The `SelectedValues` property is bound to a collection with items that are selected.

The `ItemKeyBinding` defines a property which uniquely identifies the item and allows the `DataSource` and `SelectedValues` items to be compared.

The `ItemHasChildrenBinding` property defines an expression which determines whether the particular item has children.

The `ItemChildrenBinding` property specifies the collection of child items for a particular item. The children must be of the same type as the root items.

The contents inside the control are treated as the `ItemTemplate` which specifies a template for each item in the tree.


```DOTHTML
<bp:TreeView DataSource="{value: Files}"
             SelectedValues="{value: SelectedFiles}"
             ItemKeyBinding="{value: Name}"
             ItemHasChildrenBinding="{value: HasItems}"
             ItemChildrenBinding="{value: Items}">
    <p>{{value: Name}}</p>
</bp:TreeView>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<TreeItem> SelectedFiles { get; set; } = new List<TreeItem>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                Items = new List<TreeItem> {
                    new TreeItem {
                        Name = "Invoices",
                        Items = new List<TreeItem> {
                            new TreeItem { Name = "Invoice.pdf" }
                        }
                    },
                    new TreeItem { Name = "CV.pdf" }
                }
            },
            new TreeItem {
                Name = "Pictures",
                Items = new List<TreeItem> {
                    new TreeItem { Name = "dog.jpg" },
                    new TreeItem { Name = "cat.jpg" },
                    new TreeItem { Name = "horse.png" }
                }
            },
            new TreeItem { Name = "My Notes.txt" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample1
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems => Items?.Count > 0;
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    }
}
```

## Sample 2: Tree Item CheckBoxes

Using the `CheckBoxMode` property, you can display the checkboxes. The property has the following values:

* `Hidden` means that no checkboxes are displayed.
* `VisibleOnLeafs` means that the checkboxes are displayed for the items which don't have any children.
* `Visible` means that the checkboxes are displayed for all items in the tree.

By default, the control checks also the descendant items when an item is checked. The `AutoCheckChildren` property can be used to disable this feature.


```DOTHTML
<bp:TreeView DataSource="{value: Files}"
             SelectedValues="{value: SelectedFiles}"
             CheckBoxMode="VisibleOnLeafs"
             AutoCheckChildren="false"
             ItemHasChildrenBinding="{value: HasItems}"
             ItemChildrenBinding="{value: Items}"
             ItemKeyBinding="{value: Name}">
    <p>{{value: Name}}</p>
</bp:TreeView>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<TreeItem> SelectedFiles { get; set; } = new List<TreeItem>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                Items = new List<TreeItem> {
                    new TreeItem {
                        Name = "Invoices",
                        Items = new List<TreeItem> {
                            new TreeItem { Name = "Invoice.pdf" }
                        }
                    },
                    new TreeItem { Name = "CV.pdf" }
                }
            },
            new TreeItem {
                Name = "Pictures",
                Items = new List<TreeItem> {
                    new TreeItem { Name = "dog.jpg" },
                    new TreeItem { Name = "cat.jpg" },
                    new TreeItem { Name = "horse.png" }
                }
            },
            new TreeItem { Name = "My Notes.txt" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample2
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems => Items?.Count > 0;
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    }
}
```

## Sample 3: Changed Event

The `Changed` property specifies a command in the viewmodel which is triggered whenever the selection is changed.


```DOTHTML
<bp:TreeView DataSource="{value: Files}"
             SelectedValues="{value: SelectedFiles}"
             CheckBoxMode="VisibleOnLeafs"
             AutoCheckChildren="false"
             ItemHasChildrenBinding="{value: HasItems}"
             ItemChildrenBinding="{value: Items}"
             Changed="{command: SelectionChanged()}"
             ItemKeyBinding="{value: Name}">
    <p>{{value: Name}}</p>
</bp:TreeView>

<p>You've selected: {{value: Summary}}</p>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Summary { get; set; }
        public List<TreeItem> SelectedFiles { get; set; } = new List<TreeItem>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                Items = new List<TreeItem> {
                    new TreeItem {
                        Name = "Invoices",
                        Items = new List<TreeItem> {
                            new TreeItem { Name = "Invoice.pdf" }
                        }
                    },
                    new TreeItem { Name = "CV.pdf" }
                }
            },
            new TreeItem {
                Name = "Pictures",
                Items = new List<TreeItem> {
                    new TreeItem { Name = "dog.jpg" },
                    new TreeItem { Name = "cat.jpg" },
                    new TreeItem { Name = "horse.png" }
                }
            },
            new TreeItem { Name = "My Notes.txt" }
        };

        public void SelectionChanged()
        {
            Summary = string.Join(",", SelectedFiles.Select(f => "[" + f.Name + "]"));
        }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample3
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems => Items?.Count > 0;
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    }
}
```

## Sample 4: Working With Objects

To make the `SelectedValues` property contain only some values from the `DataSource` objects (like the `Id` property of the object), you may use the `ItemValueBinding` property.

The `SelectedValues` will then contain only the values of the properties specified in the `ItemValueBinding`. Provided the values of the properties used as a value are unique, you don't need to specify the `ItemKeyBinding` property.

> The `ItemKeyBinding` property is required when the control cannot compare the objects in the `DataSource` collection with the objects in the `SelectedValues`. If the `ItemValueBinding` is set and makes the `SelectedValues` collection use primitive types that can be compared, the `ItemKeyBinding` property is not needed. Similarly, if the `DataSource` collection contains only primitive values (`string`, `int` etc.), the `ItemKeyBinding` property is not necessary.

Use the `ItemIsExpandedBinding` binding to control whether nodes are collapsed or expanded. It may be useful in combination with the `LoadChildren` command.

```DOTHTML
<bp:TreeView DataSource="{value: Files}"
             SelectedValues="{value: SelectedFileNames}"
             ItemValueBinding="{value: Name}"
             CheckBoxMode="VisibleOnLeafs"
             AutoCheckChildren="false"
             ItemIsExpandedBinding="{value: IsExpanded}"
             ItemHasChildrenBinding="{value: HasItems}"
             ItemChildrenBinding="{value: Items}"
             ItemKeyBinding="{value: Name}">
    <p>{{value: Name}}</p>
</bp:TreeView>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> SelectedFileNames { get; set; } = new List<string>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                IsExpanded = true,
                Items = new List<TreeItem> {
                    new TreeItem {
                        Name = "Invoices",
                        Items = new List<TreeItem> {
                            new TreeItem { Name = "Invoice.pdf" }
                        }
                    },
                    new TreeItem { Name = "CV.pdf" }
                }
            },
            new TreeItem {
                Name = "Pictures",
                Items = new List<TreeItem> {
                    new TreeItem { Name = "dog.jpg" },
                    new TreeItem { Name = "cat.jpg" },
                    new TreeItem { Name = "horse.png" }
                }
            },
            new TreeItem { Name = "My Notes.txt" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample4
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems => Items?.Count > 0;
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
        public bool IsExpanded { get; set; }
    }
}
```

## Sample 5: Icons

The icons used by the control can be customized using the following inner elements:

* `ExpandIcon` represents an icon of toggle button that expand data. The default is `Plus` icon.

* `CollapseIcon` represents an icon of toggle button that collapse data. The default is `Minus` icon.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:TreeView DataSource="{value: Files}"
             SelectedValues="{value: SelectedFiles}"
             ItemKeyBinding="{value: Name}"
             ItemHasChildrenBinding="{value: HasItems}"
             ItemChildrenBinding="{value: Items}">
    <ExpandIcon>
        <bp:Icon Icon="ChevronDown"></bp:Icon>
    </ExpandIcon>
    <CollapseIcon>
        <bp:Icon Icon="ChevronUp"></bp:Icon>
    </CollapseIcon>

    <span>{{value: Name}}</span>
</bp:TreeView>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<TreeItem> SelectedFiles { get; set; } = new List<TreeItem>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                Items = new List<TreeItem> {
                    new TreeItem {
                        Name = "Invoices",
                        Items = new List<TreeItem> {
                            new TreeItem { Name = "Invoice.pdf" }
                        }
                    },
                    new TreeItem { Name = "CV.pdf" }
                }
            },
            new TreeItem {
                Name = "Pictures",
                Items = new List<TreeItem> {
                    new TreeItem { Name = "dog.jpg" },
                    new TreeItem { Name = "cat.jpg" },
                    new TreeItem { Name = "horse.png" }
                }
            },
            new TreeItem { Name = "My Notes.txt" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample5
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems => Items?.Count > 0;
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    }
}
```

## Sample 6: Lazy loading of children

The `LoadChildren` command is there to dynamically load children of items being expanded. It receives an item and should return a collection of it's descendants. You can return as many child levels as you want.

```DOTHTML
<bp:TreeView DataSource="{value: Files}"
             SelectedValues="{value: SelectedFiles}"
             ItemKeyBinding="{value: Name}" 
             ItemHasChildrenBinding="{value: HasItems}"
             ItemChildrenBinding="{value: Items}" 
             LoadChildren="{staticCommand: _parent.LoadChildren(_this)}">
    <span>{{value: Name}}</span>
</bp:TreeView>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<TreeItem> SelectedFiles { get; set; } = new List<TreeItem>();

        public List<TreeItem> Files { get; set; } = new List<TreeItem> {
            new TreeItem {
                Name = "Documents",
                HasItems = true // LoadChildren is called when HasItems is true and Items are empty
            }
        };

        [AllowStaticCommand]
        public IEnumerable<TreeItem> LoadChildren(TreeItem parent)
        {
            yield return new TreeItem {
                Name = "Invoices",
                HasItems = true,
                Items = new List<TreeItem> {
                    new TreeItem { Name = "Invoice.pdf" }
                }
            };
        }
    }
}

```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.TreeView.sample6
{
    public class TreeItem
    {
        public string Name { get; set; }
        public bool HasItems { get; set; }
        public List<TreeItem> Items { get; set; } = new List<TreeItem>();
    }
}
```

