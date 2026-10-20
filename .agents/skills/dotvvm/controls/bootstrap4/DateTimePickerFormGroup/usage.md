# <bs:DateTimePickerFormGroup>
Represents a [DateTimePicker](~/controls/bootstrap4/DateTimePicker) in [FormGroup](~/controls/bootstrap4/FormGroup).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ControlID`|String|Gets or sets the ID of the main control inside the FormGroup to be associated with the label.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the control is enabled.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets format string that will be used to display the date.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LabelSize`|Int32?|Gets or sets the size of size the label area for all screen sizes. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeLG`|Int32?|Gets or sets the size of the label area large screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeMD`|Int32?|Gets or sets the size of the label area for medium screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeSM`|Int32?|Gets or sets the size of the label area small screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeXL`|Int32?|Gets or sets the size of the label area for extra large screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area. This property cannot be combined with the LabelText property.|inner element, static value||
|`LabelText`|String|Gets or sets the label text. This property cannot be combined with the LabelTemplate property.|attribute, static value, bindable||
|`Mode`|DateTimePickerType?|Gets or sets whether you want the user to pick only date, only time, or both date and time.|attribute, static value|DateTime|
|`SelectedDate`|DateTime?|Gets or sets the date selected in the control.|attribute, bindable||
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of controls in the form group.|attribute, static value, bindable|Default|
|`Type`|([FormGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.FormGroupType.md))|Gets or sets the type of the form.|attribute, static value|Default|
|`UsedControlIDList`|HashSet<String>||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control text is changed.|

## Sample 1: Basic Usage

The `DateTimePickerFormGroup` control has the `SelectedDate` property for storing the datetime the user has selected.
It needs to be bound to a property in the viewmodel.

The `LabelText` property is used to set the label of the `DateTimePickerFormGroup` control.

It is possible with the `Mode` property to change what you want the user to pick. 
Possible values are `Date` for only date, `Time` for only time and `DateTime` for both date and time.

```DOTHTML
<bs:Form>
    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" LabelText="Pick a date" Mode="Date" />

    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" LabelText="Pick a datetime" Mode="DateTime" />

    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" LabelText="Pick a time" Mode="Time" />
</bs:Form>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.DateTimePickerFormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; } = new DateTime(1993, 10, 7, 10, 30, 0);
    }
}

```

## Sample 2: Other properties

It is also possible to change format of displayed datetime with the `FormatString` property.

To show / hide the `DateTimePickerFormGroup` control use the `Visible` property.

```DOTHTML
<bs:Form>
    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" FormatString="d" LabelText="Pick a date" />

    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" FormatString="g" LabelText="Pick a date" />

    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" FormatString="H:mm:ss" LabelText="Pick a date" />

    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" LabelText="Pick a date" Visible="{value: True}" />

    <bs:DateTimePickerFormGroup SelectedDate="{value: Date}" LabelText="Pick a date" Visible="{value: False}" />
</bs:Form>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.DateTimePickerFormGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public DateTime? Date { get; set; } = new DateTime(1993, 10, 7, 10, 30, 0);
        public bool True { get; set; } = true;
        public bool False { get; set; } = false;
    }
}

```

