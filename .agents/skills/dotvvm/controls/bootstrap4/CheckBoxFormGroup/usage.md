# <bs:CheckBoxFormGroup>
Represents a [CheckBox](~/controls/bootstrap4/CheckBox) in [FormGroup](~/controls/bootstrap4/FormGroup).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, bindable|False|
|`CheckedItems`|IEnumerable|Gets or sets a collection of values of all checked checkboxes. Use this property in combination with the CheckedValue property.|attribute, static value, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked.             Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ControlID`|String|Gets or sets the ID of the main control inside the FormGroup to be associated with the label.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable|True|
|`FormControlStyle`|([CheckboxStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.CheckboxStyle.md))|Gets or sets whether the control should use default or custom style.|attribute, static value|Default|
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
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of controls in the form group.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the label text that is rendered next to the checkbox.|attribute, static value, bindable||
|`Type`|([FormGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.FormGroupType.md))|Gets or sets the type of the form.|attribute, static value|Default|
|`UsedControlIDList`|HashSet<String>||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control check state is changed.|

## Sample 1: Form Group properties

CheckBoxFormGroup is just wrapper around [CheckBox](~/controls/bootstrap4/CheckBox) inside [FormGroup](~/controls/bootstrap4/FormGroup), so you can use any of the properties of the FormGroup and CheckBox to configure desired behavior.

For example you can use the `Label` property to set the Label of the FormGroup.


```DOTHTML
<bs:Form>
    <bs:CheckBoxFormGroup Checked="{value: Value}" Text="Check me out" LabelText="Label" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.CheckBoxFormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    { 
        public bool Value { get; set; }
    }
}
```

