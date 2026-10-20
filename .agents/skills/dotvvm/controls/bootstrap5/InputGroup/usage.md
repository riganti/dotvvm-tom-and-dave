# <dot:InputGroup>
Renders a Bootstrap input group that can contain different types of input group child controls.

<https://getbootstrap.com/docs/5.2/forms/input-group/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<IInputGroupItem>|Gets or sets the inner elements containing only RouteLink, Button, LinkButton, InputGroupDropDown, InputGroupRadioButton, TextBox, ComboBox, InputGroupCheckBox and InputGroupLiteral controls.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the input sizes for all elements inside the InputGroup control.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The `InputGroup` control can contain any number of input group child controls.

The following controls are supported inside `InputGroup`:

* [TextBox](~/controls/bootstrap5/TextBox)
* [ComboBox](~/controls/bootstrap5/ComboBox)
* [Button](~/controls/bootstrap5/Button)
* [LinkButton](~/controls/bootstrap5/LinkButton)
* [RouteLink](~/controls/bootstrap5/RouteLink)
* [InputGroupCheckBox](~/controls/bootstrap5/InputGroupCheckBox)
* [InputGroupDropDown](~/controls/bootstrap5/InputGroupDropDown)
* [InputGroupLiteral](~/controls/bootstrap5/InputGroupLiteral)
* [InputGroupRadioButton](~/controls/bootstrap5/InputGroupRadioButton)

There is also the `Size` property which can be set to `Large`, `Small` and `Default`.


```DOTHTML
<bs:InputGroup>
  <bs:InputGroupCheckBox Stype="Swith" Checked="{value: true}" />

  <bs:InputGroupRadioButton id='1' Text='RadioButton 1' GroupName='RadioButtons'
                            CheckedValue='RadioButton 1' CheckedItem="{value: Text}" />
  <bs:InputGroupRadioButton id='2' Text='RadioButton 2' GroupName='RadioButtons'
                            CheckedValue='RadioButton 2' CheckedItem="{value: Text}" />
  <bs:InputGroupLiteral Text={value: Text} />

  <bs:ComboBox DataSource="{value: ComboBoxDataSource}"
               SelectedValue="{value: SelectedValue}"
               ItemTextBinding="{value: Text}"
               ItemValueBinding="{value: Value}"
               ItemTitleBinding="{value: Title}" />

  <bs:InputGroupDropDown IsSplitButton="true" Text='Drop Split Button'>
      <bs:DropDownItem Text='Text'>
      </bs:DropDownItem>
      <bs:DropDownItem Text='Text'>
      </bs:DropDownItem>
  </bs:InputGroupDropDown>

  <bs:TextBox Text="{value: Text}" />

  <bs:InputGroupDropDown DataSource="{value: ItemDataSet}"
                               ItemText="{value: Text}"
                               VisualStyle="Outline"
                               Type="Danger" Text="Right Dropdown"
                               data-ui="right" />

  <bs:Button VisualStyle="Outline" Type="Warning" Text="Test Link Button" />
  <bs:LinkButton Text="Test Link Button" />
  <bs:RouteLink RouteName="Default" Text="RouteLink" />

</bs:InputGroup>

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool RadioButtonValue { get; set; }
    public string Text { get; set; } = "Text";
    public bool Checked { get; set; } = false;
    public ButtonType Type { get; set; } = ButtonType.Warning;
    public int SelectedValue { get; set; }

    public List<ListItem> ComboBoxDataSource { get; set; } = new()
    {
        new() { Value = 1, Text = "Too long text", Title = "Nice title" },
        new() { Value = 2, Text = "Text", Title = "Even nicer title" }
    };

    public List<ListItem> ItemDataSet { get; set; } = new()
    {
        new() { Text = "Page One", ParamId = 0, Enabled = true, IsSelected = true, NavigateUrl = "https://www.google.com/" },
        new() { Text = "Page Two", ParamId = 1, NavigateUrl = "https://www.dotvvm.com/" },
        new() { Text = "Page Three", ParamId = 3, Enabled = false, NavigateUrl = "https://www.riganti.cz/" }
    };

    
    public class ListItem
    {
        public int Value { get; set; }
        public int ParamId { get; set; }
        public bool Enabled { get; set; }
        public bool IsSelected { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string NavigateUrl { get; set; }
    }
}
```

