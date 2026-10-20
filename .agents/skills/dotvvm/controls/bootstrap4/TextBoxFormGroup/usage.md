# <bs:TextBoxFormGroup>
Represents a TextBox in FormGroup.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ControlID`|String|Gets or sets the ID of the main control inside the FormGroup to be associated with the label.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
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
|`SelectAllOnFocus`|Boolean|Gets or sets whether all text inside the TextBox becomes selected when the element gets focused.|attribute, static value, bindable|False|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of controls in the form group.|attribute, static value, bindable|Default|
|`Text`|Object|Gets or sets the text in the TextBox.|attribute, static value, bindable||
|`TextBoxType`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))|Gets or sets the mode of the text field.|attribute, static value|Normal|
|`Type`|([FormGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.FormGroupType.md))|Gets or sets the type of the form.|attribute, static value|Default|
|`UpdateTextOnInput`|Boolean|Gets or sets whether the viewmodel property will be updated after the key is pressed.              By default, the viewmodel is updated after the control loses its focus.|attribute, static value|False|
|`UsedControlIDList`|HashSet<String>||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the onchange event is fired.|

## Sample 1: Basic Text Box Form Group

The `TextBoxFormGroup` control has the `LabelText` property for the label and the `Text` property for text inside the text field.

Both these properties can also be bound to properties in viewmodel.


```DOTHTML
<bs:Form>
    <bs:TextBoxFormGroup LabelText="Static label" Text="Static value" />

    <bs:TextBoxFormGroup LabelText="{value: LabelText}" Text="{value: ValueText}" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.TextBoxFormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LabelText { get; set; } = "Bound label";
        public string ValueText { get; set; } = "Bound value";
    }
}
```

## Sample 2: Text Box Form Group - Enabled and Visible

The `Enabled` property is used to enable / disable the `TextBoxFormGroup` control.

It is also possible to show / hide the `TextBoxFormGroup` control with the `Visible` property.

```DOTHTML
<bs:Form>
    <bs:TextBoxFormGroup LabelText="Label" Text="Enabled textbox" Enabled="true" />

    <bs:TextBoxFormGroup LabelText="Label" Text="Disabled textbox" Enabled="false" />

    <bs:TextBoxFormGroup LabelText="Label" Text="Visible textbox" Visible="{value: TrueValue}" />

    <bs:TextBoxFormGroup LabelText="Label" Text="Invisible textbox" Visible="{value: FalseValue}" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.TextBoxFormGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool TrueValue { get; set; } = true;
        public bool FalseValue { get; set; } = false;
    }
}
```

## Sample 3: Text Box Form Group - Format String

The content of TextBox can be formatted with the `FormatString` property if needed.

```DOTHTML
<bs:Form>
    <bs:TextBoxFormGroup LabelText="Formatting string" Text="{value: NumberValue}" FormatString="#0.00" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.TextBoxFormGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double NumberValue { get; set; } = 123.456789;
    }
}
```

## Sample 4: Text Box Form Group - Type

The `TextBoxType` property is used to change the mode of the text field. Possible values are:

+ `Normal`
+ `Password`
+ `MultiLine`
+ `Telephone`
+ `Url`
+ `Email`
+ `Date`
+ `Time`
+ `Color`
+ `Search`
+ `Number`




```DOTHTML
<bs:Form>
    <bs:TextBoxFormGroup LabelText="Password box" Text="password" TextBoxType="Password" />
</bs:Form>    
```

## Sample 5: Text Box Form Group - UpdateTextOnInput and Changed

If you need property bound to `Text` property to update after every pressed key just set the `UpdateTextOnInput` property to *true*.

With the `Changed` property it is possible to bind to `onchange` event and perform specific actions when the value of text field changes.


```DOTHTML
<bs:Form>
    <bs:TextBoxFormGroup LabelText="Update test" Text="{value: UpdateTestText}" UpdateTextOnInput="true" />
    <span>{{value: UpdateTestText}}</span>

    <bs:TextBoxFormGroup LabelText="OnChanged test" Text="{value: ChangedTestText}" Changed="{command: Changed()}" />
    <span>{{value: ChangedValue}}</span>
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.TextBoxFormGroup.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string UpdateTestText { get; set; } = "Change this";
        public string ChangedValue { get; set; } = "Not changed";
        public string ChangedTestText { get; set; } = "text";

        public void Changed()
        {
            ChangedValue = "Changed to " + ChangedTestText;
        }
    }
}
```

