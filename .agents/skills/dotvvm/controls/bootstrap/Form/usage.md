# <bs:Form>
Renders a Bootstrap form. Each form field should be placed inside the [FormGroup](~/controls/bootstrap/FormGroup).

<https://getbootstrap.com/docs/3.3/css/#forms>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LabelSizeLG`|Int32?|Gets or sets the LG size of the label area. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeMD`|Int32?|Gets or sets the MD size of the label area. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeSM`|Int32?|Gets or sets the SM size of the label area. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeXL`|Int32?|Gets or sets the XL size of the label area. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeXS`|Int32?|Gets or sets the XS size of the label area. This applies only to the Horizontal forms.|attribute, static value||
|`Type`|([FormType](../_enums/DotVVM.Framework.Controls.Bootstrap.FormType.md))|Gets or sets the type of the form - vertical, inline or horizontal.|attribute, static value|Vertical|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Form Controls

The `Form` is an easy to use control which uses the Bootstrap styles to render a form.

The `Type` property specifies the type of the form - _Vertical (default)_, _Inline_ or _Horizontal_.

Each form field is wrapped in the [FormGroup](~/controls/bootstrap/FormGroup) control.

```DOTHTML
<bs:Form>

    <bs:FormGroup LabelText="TextBox">
        <dot:TextBox Text="{value: Text}" />
        <!-- the "form-group" CSS class is added automatically to the TextBox control -->
    </bs:FormGroup>

    <bs:FormGroup LabelText="ComboBox">
        <dot:ComboBox DataSource="{value: Items}" SelectedValue="{value: Item}" />
        <!-- the "form-group" CSS class is added automatically to the ComboBox control -->
    </bs:FormGroup>

    <bs:FormGroup LabelText="CheckBox">
        <bs:CheckBox Checked="{value: Boolean1}" Text="Is Checked" />
        <!-- the IsInline property is set to true automatically inside the Form -->
    </bs:FormGroup>

    <bs:FormGroup LabelText="RadioButton">
        <bs:RadioButton Checked="{value: Boolean2}" CheckedValue="{value: true}" Text="Option 1" />
        <bs:RadioButton Checked="{value: Boolean2}" CheckedValue="{value: false}" Text="Option 2" />
        <!-- the IsInline property is set to true automatically inside the Form -->
    </bs:FormGroup>

</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Form.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public string[] Items => new[] { "one", "two", "three" };

        public string Item { get; set; } = "one";

        public bool Boolean1 { get; set; }

        public bool Boolean2 { get; set; }
    }
}
```

## Sample 2: Static Values

The `FormStaticValue` control is used to place the plain text next to a form label within a form.

```DOTHTML
<bs:Form Type="Vertical">
  <bs:FormGroup LabelText="E-mail Address">
    <bs:FormStaticValue>email@example.com</bs:FormStaticValue>
  </bs:FormGroup>
</bs:Form>
```

## Sample 3: Horizontal Form Label Sizing

If the form is in the **Horizontal** mode, the labels are placed next to the form fields. In this case, you have to specify how wide the 
labels should be. You can use the `LabelSizeXS`, `LabelSizeSM`, `LabelSizeMD`, `LabelSizeLG` and `LabelSizeXL` properties for this purpose.

If you have customized Bootstrap grid system to have different number of columns, use the `NumberOfColumns` property on the [Container](~/controls/bootstrap/Container) control.


```DOTHTML
<bs:Form Type="Horizontal" LabelSizeXS="2" LabelSizeLG="8">
  <bs:FormGroup LabelText="Label size would be different on different screen sizes">
    <bs:CheckBox Text="Simple Test 1" Inline="true" Checked="{value: CheckBox1Checked}" />
    <bs:CheckBox Text="Simple Test 2" Inline="true" Checked="{value: CheckBox2Checked}" />
    <bs:CheckBox Text="Simple Test 3" Inline="true" Checked="{value: CheckBox3Checked}" />
  </bs:FormGroup>
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Form.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool CheckBox1Checked { get; set; }
        public bool CheckBox2Checked { get; set; }
        public bool CheckBox3Checked { get; set; }

    }
}
```

