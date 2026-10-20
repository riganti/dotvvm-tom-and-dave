# <bs:ComboBoxFormGroup>
Represents a [ComboBox](~/controls/bootstrap4/ComboBox) in [FormGroup](~/controls/bootstrap4/FormGroup).

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ControlID`|String|Gets or sets the ID of the main control inside the FormGroup to be associated with the label.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyItemText`|String|Text displayed when no value is selected.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormControlStyle`|([BootstrapFormStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapFormStyle.md))|Gets or sets the Bootstrap form style of the control.|attribute, static value|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemTitleBinding`|IValueBinding|The expression of DataSource item that will be placed into HTML title attribute.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`LabelSize`|Int32?|Gets or sets the size of size the label area for all screen sizes. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeLG`|Int32?|Gets or sets the size of the label area large screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeMD`|Int32?|Gets or sets the size of the label area for medium screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeSM`|Int32?|Gets or sets the size of the label area small screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeXL`|Int32?|Gets or sets the size of the label area for extra large screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area. This property cannot be combined with the LabelText property.|inner element, static value||
|`LabelText`|String|Gets or sets the label text. This property cannot be combined with the LabelTemplate property.|attribute, static value, bindable||
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of controls in the form group.|attribute, static value, bindable|Default|
|`Type`|([FormGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.FormGroupType.md))|Gets or sets the type of the form.|attribute, static value|Default|
|`UsedControlIDList`|HashSet<String>||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Form Group properties

ComboBoxFormGroup is just wrapper around [ComboBox](~/controls/bootstrap4/ComboBox) inside [FormGroup](~/controls/bootstrap4/FormGroup), so you can use any of the properties of the FormGroup and ComboBox to configure desired behavior.

For example you can use the `Label` property to set the Label of the FormGroup.


```DOTHTML
<bs:Form>
    <bs:ComboBoxFormGroup DataSource="{value: Fruits}"  SelectedValue="{value: SelectedFruit}" LabelText="Fruits" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap4.ComboBoxFormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "Orange" };

        public string SelectedFruit { get; set; }
    }
}
```

