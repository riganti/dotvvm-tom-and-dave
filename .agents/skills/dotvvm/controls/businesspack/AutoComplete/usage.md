# <bp:AutoComplete>
Renders a `TextBox` control with the auto-complete feature. 

You can use this control to let the user select values from a pre-defined collection, or let him to enter his own.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IEnumerable||attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTemplate`|ITemplate||inner element, static value, default property||
|`ItemTextBinding`|IValueBinding<String>||attribute, bindable||
|`LoadItems`|AutoComplete+LoadItemsFunc||attribute, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|String||attribute, bindable||
|`Type`|AutoCompleteType||attribute, static value|Text|
|`UpdateTextOnInput`|Boolean||attribute, static value, bindable|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

Bind the `DataSource` property to a collection of strings. 

The `Text` property will contain the text entered or selected by the user.

The `Placeholder` specifies the text displayed when the `Text` is empty.

```DOTHTML
<bp:AutoComplete Text="{value: City}"
                 DataSource="{value: Suggestions}"
                 Placeholder="City" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string City { get; set; }

        public IEnumerable<string> Suggestions { get; set; } = new List<string> {
            "Atlantic City",
            "Boston",
            "Chicago",
            "Dallas",
            "New York",
            "Washington D.C.",
            "Miami",
            "San Francisco"
        };
    }
}
```

## Sample 2: Working with Objects

When the `DataSource` collection is bound to a collection of objects, you may use the `ItemTextBinding` to specify from which property to extract text when an object is selected from the list of suggestions.

To display custom content in the list items, you can use the `ItemTemplate` property to declare a custom template for the list items.

```DOTHTML
<bp:AutoComplete Text="{value: Country}"
                 DataSource="{value: Countries}"
                 ItemTextBinding="{value: Name}"
                 Placeholder="Country">
    <ItemTemplate>
        <span>{{value: Id}}. {{value: Name}}</span>
    </ItemTemplate>
</bp:AutoComplete>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Country { get; set; }

        public List<Country> Countries { get; set; } = new List<Country> {
            new Country { Id = 1, Name = "Atlantic City" },
            new Country { Id = 2, Name = "Boston" },
            new Country { Id = 3, Name = "Chicago"},
            new Country { Id = 4, Name = "Dallas"},
            new Country { Id = 5, Name = "New York"},
            new Country { Id = 6, Name = "Washington D.C."},
            new Country { Id = 7, Name = "Miami"},
            new Country { Id = 8, Name = "San Francisco"}
        };
    }
}
```

```CSHARP
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample2
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
```

## Sample 3: Changed Event

The `Changed` event can be used to trigger a command in the viewmodel when the value in the control changes. It is triggered when the control loses its focus provided the value has been changed. 

```DOTHTML
<bp:AutoComplete Text="{value: City}"
                 DataSource="{value: Suggestions}"
                 UpdateTextOnInput="false"
                 Changed="{command: CityChanged()}" />

<p>City {{value: City}} has been changed {{value: CityChangeCount}} times.</p>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.AutoComplete.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string City { get; set; }

        public int CityChangeCount { get; set; }

        public IEnumerable<string> Suggestions { get; set; } = new List<string> {
            "Atlantic City",
            "Boston",
            "Chicago",
            "Dallas",
            "New York",
            "Washington D.C.",
            "Miami",
            "San Francisco"
        };

        public void CityChanged() => CityChangeCount++;
    }
}
```

