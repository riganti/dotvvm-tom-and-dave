# <bp:MultiSelect>
The *Business Pack* `MultiSelect` control is a text field which suggests items to select and supports multiple selected items.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowNewItems`|Boolean||attribute, static value, bindable|False|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable||attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemEnabledBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemKeyBinding`|IValueBinding||attribute, bindable||
|`ItemTemplate`|ITemplate||inner element, static value, default property||
|`ItemTextBinding`|IValueBinding<String>||attribute, bindable||
|`ItemValueBinding`|IValueBinding||attribute, bindable||
|`LoadItems`|MultiSelect+LoadItemsFunc||attribute, bindable||
|`LoadItemsMode`|LoadItemsMode||attribute, static value, bindable|Merge|
|`Placeholder`|String||attribute, static value, bindable||
|`SelectedValues`|IEnumerable||attribute, bindable||
|`SelectedValueTemplate`|ITemplate||inner element, static value||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`UnselectIcon`|IconBase||inner element, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WarnWhenValueNotInDataSource`|Boolean||attribute, static value|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||
|`NewItemAdded`|Command||

## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. When the user starts interacting with the control, a list of items made from this collection will appear.

The `SelectedValues` property is bound to a collection which contains all items that are selected. The data-binding works in both ways, so you can either read, or modify the collection in the viewmodel and the selected values in the control will get synchronized to reflect the changes.

The `Placeholder` specifies the text displayed when the `Text` is empty.

```DOTHTML
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                Placeholder="Select multiple countries" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample1
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
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                ItemTextBinding="{value: Name}"
                ItemKeyBinding="{value: Id}"
                Placeholder="Select multiple countries" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample2
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

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample2
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
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                ItemValueBinding="{value: Id}"
                ItemTextBinding="{value: Name}"
                Placeholder="Select multiple countries"
                Changed="{command: PrintSummary()}" />

<p>Selected Countries: {{value: Summary}}</p>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public List<int> SelectedCountries { get; set; } = new List<int>();
        public string Summary { get; set; }

        public void PrintSummary()
        {
            Summary = string.Join(", ", SelectedCountries.Select(c => c.ToString()));
        }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample3
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

## Sample 4: Item Templates

To display custom content in the list items, you can use the `ItemTemplate` property to declare a custom template for the list items. 


```DOTHTML
<bp:MultiSelect DataSource="{value: Cities}"
                SelectedValues="{value: SelectedCities}"
                ItemKeyBinding="{value: Id}"
                ItemTextBinding="{value: Name}"
                Placeholder="Select multiple cities">
    <ItemTemplate>
        <span>{{value: Name}}, {{value: Country}}</span>
    </ItemTemplate>
</bp:MultiSelect>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Prague", Country = "Czech Republic" },
            new City { Id = 2, Name = "Bratislava", Country = "Slovakia" }
        };

        public List<City> SelectedCities { get; set; } = new List<City>();
    }
}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample4
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
```

## Sample 5: Changed Event

The `Changed` event is triggered whenever the selection changes.


```DOTHTML
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                Placeholder="Select multiple countries"
                Changed="{command: SelectionChanged()}" />

<p>You've selected {{value: SelectedCountriesCount}} countries.</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample5
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

## Sample 6: New Items

To allow entering a custom value which is not present in the `DataSource` collection, you can use the `AllowNewItems` property. 

The `Text` property contains the exact value the user entered in the text field.

This feature can be used only when the `DataSource` collection contains `string` values.

```DOTHTML
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                AllowNewItems="true"
                Placeholder="Select or type multiple countries" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample6
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

## Sample 7: Server Search

The `LoadItems` property can specify a command in the viewmodel which will return new items based on what the user types in the control.
Typically, this method is used with the [Static Command](~/pages/concepts/respond-to-user-actions/static-commands) and the method should return a list of items,
and you need to use the value of the `Text` property as an argument to the viewmodel method.

The method in the viewmodel performs the search and returns a collection of items. These items are either added to existing items in the `DataSource` collection or they replace the existing items. It depends on the `LoadItemsMode` property.

If you use the static command, don't forget to decorate the method with the `AllowStaticCommand` attribute.

> In the future versions of DotVVM, there are plans to enhance the server search functionality with more features (e.g. REST API integration). 

```DOTHTML
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                Text="{value: Text}"
                LoadItems="{staticCommand: LoadCountries(Text)}"
                Placeholder="Search and select multiple countries" />
```

```CSHARP
using System.Collections;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }
        public List<string> Countries { get; set; } = new List<string>();
        public List<string> SelectedCountries { get; set; } = new List<string>();

        [AllowStaticCommand]
        public IEnumerable LoadCountries(string searchText)
        {
            return new List<string> {
                $"{searchText} 1", $"{searchText} 2", $"{searchText} 3"
            };
        }
    }
}
```

## Sample 8: Item Keys

The `ItemKeyBinding` property must be used when the `SelectedValue` is not a primitive type (like `string`, `int` etc.), or when the `ItemValueBinding` is not specified.
This property helps the control to uniquely identify the selected object.

```DOTHTML
<bp:MultiSelect DataSource="{value: Cities}"
                SelectedValues="{value: SelectedCities}"
                ItemKeyBinding="{value: Id}"
                ItemTextBinding="{value: Name}"
                Placeholder="Select multiple cities">
    <ItemTemplate>
        <span>{{value: Name}}, {{value: Country}}</span>
    </ItemTemplate>
</bp:MultiSelect>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample8
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Salt Lake City", Country = "Utah" },
            new City { Id = 2, Name = "Wichita", Country = "Kansas" },
            new City { Id = 3, Name = "Atlanta", Country = "Georgia" }
        };

        public List<City> SelectedCities { get; set; } = new List<City>();
    }
}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample8
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
```

## Sample 9: Customizing Icons

The icon used by the control can be customized using the following inner elements:

* `UnselectIcon` represents an icon that allows the user to deselect items. The default is `Close` icon.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:MultiSelect DataSource="{value: Countries}"
                SelectedValues="{value: SelectedCountries}"
                Placeholder="Select multiple countries" >
    <UnselectIcon>
        <bp:Icon Icon="Minus"></bp:Icon>
    </UnselectIcon>
</bp:MultiSelect>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MultiSelect.sample9
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

