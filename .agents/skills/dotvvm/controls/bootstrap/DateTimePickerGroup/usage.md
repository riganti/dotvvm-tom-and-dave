# <bs:DateTimePickerGroup>
Represents a group of Label and DateTimePicker in the Form control.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
|`FormContent`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area. This property cannot be combined with the LabelText property.|inner element, static value||
|`LabelText`|String|Gets or sets the label text. This property cannot be combined with the LabelTemplate property.|attribute, static value, bindable||
|`Mode`|DateTimePickerType?|Gets or sets whether you want the user to pick only date, only time, or both date and time.|attribute, static value|DateTime|
|`RenderContentContainers`|Boolean|Gets or sets whether an additional container will be rendered around the content.|attribute, static value|True|
|`SelectedDate`|DateTime?|Gets or sets the date selected in the control.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The `DateTimePickerGroup` control has the `SelectedDate` property for storing the datetime the user has selected.
It needs to be bound to a property in the viewmodel.

The `LabelText` property is used to set the label of the `DateTimePickerGroup` control.

It is possible with the `Mode` property to change what you want the user to pick. 
Possible values are `Date` for only date, `Time` for only time and `DateTime` for both date and time.

```DOTHTML
<bs:Form>
    <bs:DateTimePickerGroup SelectedDate="{value: Date}" LabelText="Pick a date" Mode="Date" />

    <bs:DateTimePickerGroup SelectedDate="{value: Date}" LabelText="Pick a datetime" Mode="DateTime" />

    <bs:DateTimePickerGroup SelectedDate="{value: Date}" LabelText="Pick a time" Mode="Time" />
</bs:Form>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DateTimePickerGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; } = new DateTime(1993, 10, 7, 10, 30, 0);
    }
}

```

## Sample 2: Other properties

It is also possible to change format of displayed datetime with the `FormatString` property.

To show / hide the `DateTimePickerGroup` control use the `Visible` property.

```DOTHTML
<bs:Form>
    <bs:DateTimePickerGroup SelectedDate="{value: Date}" FormatString="d" LabelText="Pick a date" />

    <bs:DateTimePickerGroup SelectedDate="{value: Date}" FormatString="g" LabelText="Pick a date" />

    <bs:DateTimePickerGroup SelectedDate="{value: Date}" FormatString="H:mm:ss" LabelText="Pick a date" />

    <bs:DateTimePickerGroup SelectedDate="{value: Date}" LabelText="Pick a date" Visible="{value: True}" />

    <bs:DateTimePickerGroup SelectedDate="{value: Date}" LabelText="Pick a date" Visible="{value: False}" />
</bs:Form>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.DateTimePickerGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; } = new DateTime(1993, 10, 7, 10, 30, 0);
        public bool True { get; set; } = true;
        public bool False { get; set; } = false;
    }
}

```

