# <t:ComboBox>
The Tailwind `ComboBox` uses the same API as the built-in [ComboBox](~/controls/builtin/ComboBox) and only adds Tailwind styling. Use `ComboBoxFormField` for labeled form layouts.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyItemText`|String|Text displayed when no value is selected.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemTitleBinding`|IValueBinding|The expression of DataSource item that will be placed into html title attribute.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Styled ComboBox

The Tailwind `ComboBox` keeps the built-in `ComboBox` API, so all binding patterns from the [built-in ComboBox documentation](~/controls/builtin/ComboBox) apply here as well. This sample shows the Tailwind styling with `DataSource`, item bindings, `Enabled`, and `SelectionChanged`.


```DOTHTML
<div class="space-y-3 max-w-md">
    <t:CheckBox Text="Enable ComboBox" Checked="{value: IsEnabled}" />

    <t:ComboBox DataSource="{value: Countries}"
                SelectedValue="{value: SelectedCountry}"
                ItemTextBinding="{value: Name}"
                ItemValueBinding="{value: Code}"
                EmptyItemText="-- choose a country --"
                Enabled="{value: IsEnabled}"
                SelectionChanged="{command: IncrementChanges()}" />
</div>

<p>Selected country: <strong>{{value: SelectedCountry ?? "(none)"}}</strong></p>
<p><code>SelectionChanged</code> command count: <strong>{{value: ChangeCount}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ComboBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Country> Countries { get; set; } =
        [
            new() { Code = "cz", Name = "Czech Republic" },
            new() { Code = "de", Name = "Germany" },
            new() { Code = "us", Name = "United States" }
        ];

        public string? SelectedCountry { get; set; } = "cz";

        public bool IsEnabled { get; set; } = true;

        public int ChangeCount { get; set; }

        public void IncrementChanges()
        {
            ChangeCount++;
        }
    }

    public class Country
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}

```

