# <bp:ComboBox>
This control is different from the built-in [ComboBox](~/controls/builtin/ComboBox) and is not derived from it.

The *Business Pack* `ComboBox` control is a text field which suggests items to select. It can perform server search, use custom templates for the suggested items and let the user to add his own values which are not present in the `DataSource` collection.

The *Business Pack* includes a similar control called [DropDownList](~/controls/businesspack/DropDownList) which is not a text field and cannot be typed into, however the user can also select items from a list which appears after clicking into the control.

If you need to select multiple values, you can use the [MultiSelect](~/controls/businesspack/MultiSelect).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowNewItems`|Boolean||attribute, static value, bindable|False|
|`AllowUnselect`|Boolean||attribute, static value, bindable|True|
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
|`LoadItems`|ComboBox+LoadItemsFunc||attribute, bindable||
|`LoadItemsMode`|LoadItemsMode||attribute, static value, bindable|Merge|
|`Placeholder`|String||attribute, static value, bindable||
|`SelectedValue`|Object||attribute, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|String||attribute, bindable||
|`ToggleIcon`|IconBase||inner element, static value, bindable||
|`UnselectIcon`|IconBase||inner element, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. For each item in the collection, a list item is created.

The `SelectedValue` property is bound to a property which contains the item from the `DataSource` collection which was selected in the control. The data-binding works in both ways, so you can either read, or modify the property in the viewmodel and the control will get synchronized to reflect the changes.


```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountry}"
             Placeholder="Please select Country" />

<p>Selected Country: {{value: SelectedCountry}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedCountry { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };
    }
}
```

## Sample 2: Working with Objects

When the `DataSource` collection is bound to a collection of objects, you may use the `ItemTextBinding` to specify, which property of the object in the collection will be displayed as a text of a particular list item.

The `SelectedValue` will still contain the object from the `DataSource` collection which is selected. 

In order to allow the control to uniquely identify these objects, you need to use the `ItemKeyBinding` property to define a property which can work as a key. The key must be unique for all items in the collection, otherwise the control will not work properly.

The `Placeholder` property specifies the text which is displayed when no value is selected.

```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountry}"
             ItemTextBinding="{value: Name}"
             ItemKeyBinding="{value: Id}"
             Placeholder="Please select Country" />

<p>Selected Country: {{value: SelectedCountry.Name}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Country SelectedCountry { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample2
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

To make the `SelectedValue` property contain only a value of a specific property from the `DataSource` object (like the `Id` property of the selected object), you may use the `ItemValueBinding` property.

The `SelectedValue` property will then contain only the value of the property specified in the `ItemValueBinding`. Provided the values of the properties used as a value are unique, you don't need to specify the `ItemKeyBinding` property.

> The `ItemKeyBinding` property is required only when the control cannot compare the objects in the `DataSource` collection with the object in the `SelectedValue` property. If the `ItemValueBinding` is set and makes the `SelectedValue` property use a primitive type that can be compared, the `ItemKeyBinding` property is not needed. Similarly, if the `DataSource` collection contains only primitive values (`string`, `int` etc.), the `ItemKeyBinding` property is not necessary. 


```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountryId}"
             ItemTextBinding="{value: Name}"
             ItemValueBinding="{value: Id}"
             Placeholder="Please select Country" />

<p>Selected Country ID: {{value: SelectedCountryId}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int? SelectedCountryId { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample3
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
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountryId}"
             ItemValueBinding="{value: Id}"
             ItemTextBinding="{value: Name}"
             Placeholder="Please select Country">
    <ItemTemplate>
        <span>{{value: Id}}. {{value: Name}}</span>
    </ItemTemplate>
</bp:ComboBox>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int? SelectedCountryId { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample4
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

## Sample 5: Changed Event

The `Changed` event specifies the command in the viewmodel that is triggered whenever the user changes the value in the control.


```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountry}"
             ItemTextBinding="{value: Name}"
             ItemKeyBinding="{value: Id}"
             Placeholder="Please select Country"
             Changed="{command: CountryChanged()}" />

<bp:ComboBox DataSource="{value: Cities}"
             SelectedValue="{value: SelectedCity}"
             Placeholder="Please select City" />

<p>You've selected: {{value: SelectedCity}}, {{value: SelectedCountry.Name}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Country SelectedCountry { get; set; }
        public string SelectedCity { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", Cities = new List<string> { "Praha", "Brno" } },
            new Country { Id = 2, Name = "Slovakia", Cities = new List<string> { "Bratislava", "Košice" } },
            new Country { Id = 3, Name = "United States", Cities = new List<string> { "Washington", "New York" } }
        };

        public List<string> Cities { get; set; } = new List<string>();

        public void CountryChanged()
        {
            SelectedCity = null;
            Cities = SelectedCountry?.Cities ?? new List<string>();
        }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample5
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

## Sample 6: New Items

To allow entering a custom value which is not present in the `DataSource` collection, you can use the `AllowNewItems` property. 

The `Text` property contains the exact value the user entered in the text field.

This feature can be used only when the `DataSource` collection contains `string` values.

```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             Text="{value: TypedCountry}"
             SelectedValue="{value: SelectedCountry}"
             AllowNewItems="true"
             Placeholder="Please select or type Country" />

<p>Selected Country: {{value: SelectedCountry ?? TypedCountry}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedCountry { get; set; }

        public string TypedCountry { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };
    }
}
```

## Sample 7: Server Search

The `LoadItems` property can specify a command in the viewmodel which will return new items based on what the user types in the control.
Typically, this method is used with the [Static Command](~/pages/concepts/respond-to-user-actions/static-commands) and the method should return a list of items,
and the value of methods `text` parameter is based on the text user typed into the search field.

The method in the viewmodel performs the search and returns a collection of items. These items are either added to existing items in the `DataSource` collection or they replace the existing items. It depends on the `LoadItemsMode` property.

If you use the static command, don't forget to decorate the method with the `AllowStaticCommand` attribute.

> In the future versions of DotVVM, there are plans to enhance the server search functionality with more features (e.g. REST API integration).

```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountry}"
             ItemTextBinding="{value: Name}"
             ItemKeyBinding="{value: Name}"
             LoadItems="{staticCommand: LoadCountries(text)}"
             Placeholder="Please select Country" />

<p>Selected Country: {{value: SelectedCountry.Name}}</p>
```

```CSHARP
using System.Collections;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public Country SelectedCountry { get; set; }

        public List<Country> Countries { get; set; } = new List<Country>();

        [AllowStaticCommand]
        public IEnumerable<Country> LoadCountries(string text)
        {
            yield return new Country
            {
                Name = text
            };
        }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample7
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

## Sample 8: Item Keys

The `ItemKeyBinding` property must be used when the `SelectedValue` is not a primitive type (like `string`, `int` etc.).
This property helps the control to uniquely identify the selected object.

```DOTHTML
<bp:ComboBox DataSource="{value: Cities}"
             SelectedValue="{value: SelectedCity}"
             ItemTextBinding="{value: Name}"
             ItemKeyBinding="{value: Id}"
             Placeholder="Select city">
    <ItemTemplate>
        <span>{{value: Name}}, {{value: Country}}</span>
    </ItemTemplate>
</bp:ComboBox>

<p>Selected City: {{value: SelectedCity.Name}}, {{value: SelectedCity.Country}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample8
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<City> Cities { get; set; } = new List<City> {
            new City { Id = 1, Name = "Praha", Country = "Czech Republic" },
            new City { Id = 2, Name = "Bratislava", Country = "Slovakia" },
            new City { Id = 3, Name = "Austin", Country = "Texas" }
        };

        public City SelectedCity { get; set; }
    }
}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample8
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

The icons used by the control can be customized using the following inner elements:

* `ToggleIcon` represents an icon that opens the popup with list of available items. The default is `ChevronDown` icon.

* `UnselectIcon` represents an icon that allows the user to deselect the item. The default is `Close` icon.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:ComboBox DataSource="{value: Countries}"
             SelectedValue="{value: SelectedCountry}"
             Placeholder="Please select Country" >
    <ToggleIcon>
        <bp:Icon Icon="ChevronDown"></bp:Icon>
    </ToggleIcon>
    <UnselectIcon>
        <bp:Icon Icon="Close"></bp:Icon>
    </UnselectIcon>
</bp:ComboBox>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ComboBox.sample9
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string SelectedCountry { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };
    }
}

```

