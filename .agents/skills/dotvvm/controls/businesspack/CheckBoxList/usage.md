# <bp:CheckBoxList>
Renders a list of [CheckBox](~/controls/businesspack/CheckBox) controls and lets the user to select multiple values.
The values are stored in a collection bound to the `SelectedValues` property of the control.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable||attribute, bindable||
|`EmptyDataTemplate`|ITemplate||inner element, static value||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemCheckedBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemEnabledBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemKeyBinding`|IValueBinding||attribute, bindable||
|`ItemTemplate`|ITemplate||inner element, static value, default property||
|`ItemTextBinding`|IValueBinding<String>||attribute, bindable||
|`ItemValueBinding`|IValueBinding||attribute, bindable||
|`SelectedValues`|IEnumerable||attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding||

## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. For each item in the collection, a checkbox will be created.

The `SelectedValues` property is bound to a collection which contains all values of checkboxes that are checked. The data-binding works in both ways, so you can either read, or modify the collection in the viewmodel and the checkbox states will be synchronized to reflect changes made to the collection.


```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 SelectedValues="{value: SelectedCountries}" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public List<string> SelectedCountries { get; set; } = new List<string>();
    }
}
```

## Sample 2: Working with Objects

When the `DataSource` collection is bound to a collection of objects, you may use the `ItemTextBinding` to specify, which property of the object in the collection will be displayed as a text of a particular checkbox control.

The `SelectedValues` will contain the objects from the `DataSource` collection which are checked. 

In order to allow the control to uniquely identify these objects, you need to use the `ItemKeyBinding` property to define a property which can work as a key. The key must be unique for all items in the collection, otherwise the control will not work properly.

```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 SelectedValues="{value: SelectedCountries}"
                 ItemTextBinding="{value: Name}"
                 ItemKeyBinding="{value: Id}" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<Country> SelectedCountries { get; set; } = new List<Country>();
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample2
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public bool IsEnabled { get; set; } = true;
        public bool IsChecked { get; set; }
    }
}
```

## Sample 3: Working with Objects 2

To make the `SelectedValues` property contain only some values from the `DataSource` objects (like the `Id` property of the object), you may use the `ItemValueBinding` property.

The `SelectedValues` will then contain only the values of the properties specified in the `ItemValueBinding`. Provided the values of the properties used as a value are unique, you don't need to specify the `ItemKeyBinding` property.

> The `ItemKeyBinding` property is required only when the control cannot compare the objects in the `DataSource` collection with the objects in the `SelectedValues`. If the `ItemValueBinding` is set and makes the `SelectedValues` collection use primitive types that can be compared, the `ItemKeyBinding` property is not needed. Similarly, if the `DataSource` collection contains only primitive values (`string`, `int` etc.), the `ItemKeyBinding` property is not necessary. 


```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 SelectedValues="{value: SelectedCountryIds}"
                 ItemValueBinding="{value: Id}"
                 ItemTextBinding="{value: Name}"/>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<int> SelectedCountryIds { get; set; } = new List<int>();
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample3
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public bool IsEnabled { get; set; } = true;
        public bool IsChecked { get; set; }
    }
}
```

## Sample 4: Changed Event

The `Changed` event is triggered whenever the selection changes.


```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 SelectedValues="{value: SelectedCountries}"
                 Changed="{command: SelectionChanged()}" />

<p>You've selected {{value: SelectedCountriesCount}} countries.</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int SelectedCountriesCount { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public List<string> SelectedCountries { get; set; } = new List<string>();

        public void SelectionChanged()
        {
            SelectedCountriesCount = SelectedCountries.Count;
        }
    }
}
```

## Sample 5: Disabling CheckBoxes

If you need to disable some of the checkboxes, you can use the `ItemEnabledBinding` to determine which checkboxes will be enabled and which will not. By default, all checkboxes are enabled and can be checked or unchecked freely.

The `Enabled` property on the control takes the precedence before the `ItemEnabledBinding`.


```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 SelectedValues="{value: SelectedCountries}"
                 ItemKeyBinding="{value: Id}"
                 ItemTextBinding="{value: Name}"
                 ItemEnabledBinding="{value: IsEnabled}" />

<br />
<bp:CheckBox Checked="{value: Countries[2].IsEnabled}"
             Text="Enable United States" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States", IsEnabled = false }
        };

        public List<Country> SelectedCountries { get; set; } = new List<Country>();
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample5
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public bool IsEnabled { get; set; } = true;
        public bool IsChecked { get; set; }
    }
}
```

## Sample 6: In-place Checked Property

If you do not need to have a second collection with the items that are checked, you can make the control to store the state of the individual items in the items of the `DataSource` collection. 

Let's assume that the `DataSource` collection items have the `IsChecked` property. We can have this property set to `true` or `false` based on the checkbox state, using the `ItemCheckedBinding` property.


```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 ItemCheckedBinding="{value: IsChecked}"
                 ItemTextBinding="{value: Name}"
                 ItemKeyBinding="{value: Id}" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", IsChecked = true },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample6
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public bool IsEnabled { get; set; } = true;
        public bool IsChecked { get; set; }
    }
}
```

## Sample 7: Templates

To display custom content in the control, you can use the `ItemTemplate` property to declare a custom template for the data source items.

You can also use the `EmptyDataTemplate` when you want to display contents when the `DataSource` is empty.

```DOTHTML
<bp:CheckBoxList DataSource="{value: Countries}"
                 ItemCheckedBinding="{value: IsChecked}"
                 ItemTextBinding="{value: Name}"
                 ItemKeyBinding="{value: Id}">
    <ItemTemplate>
        <span>{{value: Id}}. {{value: Name}}</span>
    </ItemTemplate>
</bp:CheckBoxList>

<br />

<bp:CheckBoxList DataSource="{value: SelectedCountries}"
                 ItemCheckedBinding="{value: IsChecked}"
                 ItemTextBinding="{value: Name}"
                 ItemKeyBinding="{value: Id}">
    <EmptyDataTemplate>
        You must fill the DataSource before you can select countries.
    </EmptyDataTemplate>
</bp:CheckBoxList>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", IsChecked = true },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<Country> SelectedCountries { get; set; } = new List<Country>();
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CheckBoxList.sample7
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Cities { get; set; } = new List<string>();
        public bool IsEnabled { get; set; } = true;
        public bool IsChecked { get; set; }
    }
}
```

