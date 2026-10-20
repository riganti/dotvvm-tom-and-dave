# <bs:Form>
Renders a Bootstrap form. Each form field is wrapped in the [FormGroup](~/controls/bootstrap/FormGroup) control.

<https://getbootstrap.com/docs/4.3/components/forms/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LabelSize`|Int32?|Gets or sets the size of the label area in child form groups on all screen sizes. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeLG`|Int32?|Gets or sets the size of the label area in child form groups on large screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeMD`|Int32?|Gets or sets the size of the label area in child form groups on medium screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeSM`|Int32?|Gets or sets the size of the label area in child form groups on small screen. This applies only to the Horizontal forms.|attribute, static value||
|`LabelSizeXL`|Int32?|Gets or sets the size of the label area in child form groups on extra large screen. This applies only to the Horizontal forms.|attribute, static value||
|`NumberOfColumns`|Int32|Gets or sets the number of form grid columns.|attribute, static value|12|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of controls in the form.|attribute, static value, bindable|Default|
|`Type`|([FormType](../_enums/DotVVM.Framework.Controls.Bootstrap4.FormType.md))|Gets or sets the type of the form.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Form Controls

The `Form` is an easy to use control which uses the Bootstrap styles to render a form.

The `Type` property specifies the layout of the form - `Default`, `Horizontal` or `Inline`.

```DOTHTML
<bs:Form Type="Default">
              
  <bs:FormGroup LabelText="TextBox">
    <bs:TextBox Text="{value: Text}" />
  </bs:FormGroup>
  
  <bs:FormGroup LabelText="ComboBox">
    <bs:ComboBox DataSource="{value: Items}" SelectedValue="{value: Item}" />
  </bs:FormGroup>
    
  <bs:FormGroup LabelText="CheckBox">
    <bs:CheckBox Checked="{value: Boolean1}" IsInline="true" />
  </bs:FormGroup>
  
  <bs:FormGroup LabelText="RadioButton">
    <bs:RadioButton Checked="{value: Boolean2}" CheckedValue="{value: true}" IsInline="true" Text="yes" />
    <bs:RadioButton Checked="{value: Boolean2}" CheckedValue="{value: false}" IsInline="true" Text="no" />
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

## Sample 2: Horizontal Form Label Sizing

If the form is in the `Horizontal` mode, the labels are placed next to the form fields. 

In this case, you have to specify how wide the labels should be (how many columns they will occupy). You can use the `LabelSize` to provide a default size for all screens, and use `LabelSizeSM`, `LabelSizeMD`, `LabelSizeLG` and `LabelSizeXL` properties to override the label width for a particular screen size.

If you have customized Bootstrap grid system to have different number of columns, use the `NumberOfColumns` property on the [Container](~/controls/bootstrap/Container) control.


```DOTHTML
<bs:Form Type="Horizontal" LabelSizeXS="2" LabelSizeLG="8">
  <bs:FormGroup LabelText="Label size would be different on different screen sizes">
    <bs:CheckBox Text="Simple Test 1" Checked="{value: CheckBox1Checked}" />
    <bs:CheckBox Text="Simple Test 2" Checked="{value: CheckBox2Checked}" />
    <bs:CheckBox Text="Simple Test 3" Checked="{value: CheckBox3Checked}" />
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

