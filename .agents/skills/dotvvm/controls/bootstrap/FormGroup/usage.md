# <bs:FormGroup>
The `FormGroup` is used inside the [Form](~/controls/bootstrap/Form) control and renders a form field with a label.

<https://getbootstrap.com/docs/3.3/css/#forms>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FormContent`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area. This property cannot be combined with the LabelText property.|inner element, static value||
|`LabelText`|String|Gets or sets the label text. This property cannot be combined with the LabelTemplate property.|attribute, static value, bindable||
|`RenderContentContainers`|Boolean|Gets or sets whether an additional container will be rendered around the content.|attribute, static value|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: FormGroup Usage

Place any content inside the `FormGroup` control. 

The [TextBox](~/controls/builtin/TextBox) and [ComboBox](~/controls/builtin/ComboBox) controls will get the `class="form-control"` automatically 
so they'll get the default Bootstrap look.

If you use the [CheckBox](~/controls/bootstrap/CheckBox)es and [RadioButton](~/controls/bootstrap/RadioButton)s, make sure you use `<bs:CheckBox>` and `<bs:RadioButton>`
instead of `<dot:CheckBox>` and `<dot:RadioButton>` controls. Their `IsInline` property will be set automatically to **true** so they'll get the correct padding.

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
    <bs:CheckBox Checked="{value: IsChecked}" Text="Is checked?" />
    <!-- the IsInline property is set to true automatically inside the Form -->
  </bs:FormGroup>
  
  <bs:FormGroup LabelText="RadioButton">
    <bs:RadioButton Checked="{value: Radio}" CheckedValue="{value: true}" Text="Option 1" />
    <bs:RadioButton Checked="{value: Radio}" CheckedValue="{value: false}" Text="Option 2" />
    <!-- the IsInline property is set to true automatically inside the Form -->
  </bs:FormGroup>

</bs:Form>

Text: {{value: Text}} <br />
ComboBox: {{value: Item}} <br />
CheckBox: {{value: IsChecked}} <br />
RadioButton: {{value: Radio}} <br />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.FormGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public string[] Items => new[] { "one", "two", "three" };

        public string Item { get; set; } = "one";

        public bool IsChecked { get; set; }

        public bool Radio { get; set; }
    }
}
```

## Sample 2: FormGroup LabelTemplate

If you need custom content in the label, just use the `LabelTemplate` property instead of `LabelText`.

```DOTHTML
<bs:Form>
  <bs:FormGroup>
    <LabelTemplate>
      Your favorite colors
      <bs:Button Text="Send" Click="{command: DoSomething()}"></bs:Button>
    </LabelTemplate>
    <FormContent>
      <bs:CheckBox Text="Red" Checked="{value: Red}" IsInline="true" />
      <bs:CheckBox Text="Blue" Checked="{value: Blue}" IsInline="true" />
    </FormContent>
  </bs:FormGroup>
  <span>{{value: Text}}</span>
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.FormGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Red { get; set; } = false;
        public bool Blue { get; set; } = true;
        public string Text { get; set; }
        public void DoSomething()
        {
            if(Red && Blue)
            {
                Text = "You select two colors";
            }
            else
            {
                Text = "You select only one color";
            }
        }
    }
}
```

