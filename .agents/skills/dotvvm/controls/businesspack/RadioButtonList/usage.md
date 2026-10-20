# <bp:RadioButtonList>
Renders a list of [RadioButton](~/controls/businesspack/RadioButton) controls and lets the user to select a single value.
The selected value can be set or retrieved using the `SelectedValue` property of the control.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable||attribute, bindable||
|`EmptyDataTemplate`|ITemplate||inner element, static value||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`GroupName`|String||attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemEnabledBinding`|IValueBinding<Boolean?>||attribute, bindable||
|`ItemKeyBinding`|IValueBinding||attribute, bindable||
|`ItemTemplate`|ITemplate||inner element, static value, default property||
|`ItemTextBinding`|IValueBinding<String>||attribute, bindable||
|`ItemValueBinding`|IValueBinding||attribute, bindable||
|`SelectedValue`|Object||attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding||

## Sample 1: Basic Usage

The `DataSource` property specifies a collection of strings. For each item in the collection, a radio button is created.

The `SelectedValue` property is bound to a property which contains the item from the `DataSource` collection which was selected in the control. The data-binding works in both ways, so you can either read, or modify the property in the viewmodel and the changes will get synchronized with the control.


```DOTHTML
<bp:RadioButtonList DataSource="{value: Countries}"
                    SelectedValue="{value: SelectedCountry}" />

<p>Selected country: {{value: SelectedCountry}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public string SelectedCountry { get; set; }
    }
}
```

## Sample 2: Working with Objects

When the `DataSource` collection is bound to a collection of objects, you may use the `ItemTextBinding` to specify which property of the object in the collection will be displayed as a text of a particular radio button.

The `SelectedValue` will still contain the object from the `DataSource` collection which is selected. 

In order to allow the control to uniquely identify these objects, you need to use the `ItemKeyBinding` property to define a property which can work as a key. The key must be unique for all items in the collection, otherwise the control will not work properly.

```DOTHTML
<bp:RadioButtonList DataSource="{value: Countries}"
                    SelectedValue="{value: SelectedCountry}"
                    ItemKeyBinding="{value: Id}"
                    ItemTextBinding="{value: Name}" />

<p>Selected country: {{value: SelectedCountry.Name}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public Country SelectedCountry { get; set; }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample2
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
<bp:RadioButtonList DataSource="{value: Countries}"
                    SelectedValue="{value: SelectedCountryName}"
                    ItemKeyBinding="{value: Id}"
                    ItemValueBinding="{value: Name}"
                    ItemTextBinding="{value: Name}" />

<p>Selected country: {{value: SelectedCountryName}}</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public string SelectedCountryName { get; set; }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample3
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

The `Changed` event specifies the command in the viewmodel that is triggered whenever the user changes the value in the control.


```DOTHTML
<bp:RadioButtonList DataSource="{value: Countries}"
                    SelectedValue="{value: SelectedCountry}"
                    Changed="{command: SelectionChanged()}" />

<p>You've changed country {{value: CountryChangeCount}} times.</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int CountryChangeCount { get; set; }

        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public string SelectedCountry { get; set; }

        public void SelectionChanged()
        {
            CountryChangeCount++;
        }
    }
}
```

## Sample 5: Radio Button Groups

The `GroupName` property is used to distinguish between groups of radio buttons that belong together. If you need two independent `RadioButtonList` controls, you need to give each one a different `GroupName`.


```DOTHTML
<bp:RadioButtonList DataSource="{value: Countries}"
                    SelectedValue="{value: SelectedCountry}"
                    GroupName="CountriesGroup" />

<bp:RadioButtonList DataSource="{value: FavoriteColors}"
                    SelectedValue="{value: SelectedColor}"
                    GroupName="ColorsGroup" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<string> Countries { get; set; } = new List<string> {
            "Czech Republic", "Slovakia", "United States"
        };

        public string SelectedCountry { get; set; }


        public List<string> FavoriteColors { get; set; } = new List<string> {
            "red", "green", "blue", "yellow", "white", "black"
        };

        public string SelectedColor { get; set; }
    }
}
```

## Sample 6: Disabling Radio Buttons

If you need to disable some of the radio buttons, you can use the `ItemEnabledBinding` to define which radio buttons will be enabled and which will not. By default, all radio buttons are enabled.

The `Enabled` property on the control takes the precedence before the `ItemEnabledBinding`.


```DOTHTML
<bp:RadioButtonList DataSource="{value: Countries}"
                    SelectedValue="{value: SelectedCountry}"
                    ItemKeyBinding="{value: Id}"
                    ItemTextBinding="{value: Name}"
                    ItemEnabledBinding="{value: IsEnabled}"
                    Enabled="{value: IsControlEnabled}" />

<br />
<bp:CheckBox Checked="{value: IsControlEnabled}"
             Text="Enable control" />

<br />
<bp:CheckBox Checked="{value: Countries[2].IsEnabled}"
             Text="Enable United States" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsControlEnabled { get; set; }
        public bool IsItemEnabled { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic" },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States", IsEnabled = false }
        };

        public Country SelectedCountry { get; set; }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample6
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
<bp:RadioButtonList DataSource="{value: Countries}"
                 SelectedValue="{value: SelectedCountry}"
                 ItemTextBinding="{value: Name}"
                 ItemKeyBinding="{value: Id}">
    <EmptyDataTemplate>
        You must fill the DataSource before you can select country.
    </EmptyDataTemplate>
    <ItemTemplate>
        <span>{{value: Id}}. {{value: Name}}</span>
    </ItemTemplate>
</bp:RadioButtonList>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Czech Republic", IsChecked = true },
            new Country { Id = 2, Name = "Slovakia" },
            new Country { Id = 3, Name = "United States" }
        };

        public Country SelectedCountry { get; set; }
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.RadioButtonList.sample7
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

