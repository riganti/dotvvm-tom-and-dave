# <dot:ButtonGroup>
Renders a group of Bootstrap buttons. The group can be used separately or within a [ButtonToolbar](~/controls/bootstrap5/ButtonToolbar) control.

<https://getbootstrap.com/docs/5.2/components/button-group/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemEnabled`|Boolean|Gets or sets whether the button group item is enabled when DataSource is set.|attribute, static value, bindable|True|
|`Items`|List<IBootstrapButton>|Gets or sets the items inside the control.|inner element, static value, default property||
|`ItemText`|String|Gets or sets the button group item text when DataSource is set.|attribute, static value, bindable||
|`ItemType`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the button group item type when DataSource is set.|attribute, static value, bindable|Primary|
|`ItemVisualStyle`|ButtonVisualStyle?|Gets or sets the button group item visual style when DataSource is set.|attribute, static value|SolidFill|
|`Orientation`|([ButtonGroupOrientation](../_enums/DotVVM.Bootstrap5.Controls.ButtonGroupOrientation.md))|Gets or sets the button group orientation.|attribute, static value|Horizontal|
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the button sizes for all buttons inside the ButtonGroup control.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command that will be triggered when a button group item is clicked. The DataSource must be set.|

## Sample 1: Basic Usage

The `ButtonGroup` control can contain any number of `ButtonGroup` child controls.

The following controls are supported inside `ButtonGroup`:

* [Button](~/controls/bootstrap5/Button)
* [DropDown](~/controls/bootstrap5/DropDown)
* [ButtonGroupCheckBox](~/controls/bootstrap5/ButtonGroupCheckBox)
* [ButtonGroupRadioButton](~/controls/bootstrap5/ButtonGroupRadioButton)

The `Size` property specifies the sizing of the buttons. The available sizes are: `Default`, `Small` and `Large`.

Be sure to use the `<bs:Button>` instead of the `<dot:Button>` controls inside the button group. 

```DOTHTML
<bs:ButtonGroup Size="Large">
  <bs:Button Click="{command: DoSomething()}" Text="Button 1" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 2" />
  
  <bs:DropDown Text="Dropdown">
    <Items>
      <bs:DropDownItem NavigateUrl="https://www.google.com">
        Google
      </bs:DropDownItem>
      <bs:DropDownItem NavigateUrl="https://www.youtube.com">
        Youtube
      </bs:DropDownItem>
    </Items>
  </bs:DropDown>
</bs:ButtonGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {

        public void DoSomething()
        {
        }
    }
}
```

## Sample 2: Vertical Buttons

The `IsVertical` property switches the `ButtonGroup` control into the vertical mode.

```DOTHTML
<bs:ButtonGroup IsVertical="true">
  <bs:Button Click="{command: DoSomething()}" Text="Button 1" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 2" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 3" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 4" />
</bs:ButtonGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {

        public void DoSomething()
        {
        }
    }
}
```

## Sample 3: CheckBoxes and RadioButtons in the ButtonGroup

The `ButtonGroup` also supports [ButtonGroupCheckBox](~/controls/bootstrap/CheckBox) and [ButtonGroupRadioButton](~/controls/bootstrap/RadioButton).

Make sure you are using `<bs:ButtonGroupCheckBox>` and `<bs:ButtonGroupRadioButton>` instead of classic or Bootstrap `CheckBox` and `RadioButton` controls. 


```DOTHTML
<bs:ButtonGroup>
  <bs:ButtonGroupCheckBox Text="CheckBox 1" Checked="{value: Checked1}" />
  <bs:ButtonGroupCheckBox Text="CheckBox 2" Checked="{value: Checked2}" />
</bs:ButtonGroup>

<p>CheckBox 1:{{value: Checked1}}</p>
<p>CheckBox 2:{{value: Checked2}}</p>


<bs:ButtonGroup>
  <bs:ButtonGroupRadioButton CheckedValue="1" CheckedItem="{value: Result}" Text="RadioButton 1" />
  <bs:ButtonGroupRadioButton CheckedValue="2" CheckedItem="{value: Result}" Text="RadioButton 2" />
</bs:ButtonGroup>

<p>RadioButton Result:{{value: Result}}</p>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {

        public bool Checked1 { get; set; }

        public bool Checked2 { get; set; }

        public string Result { get; set; } = "2";
    }
}
```

## Sample 4: ButtonGroup with DataSource

The `DataSource` property can be used to generate the items from an `IEnumerable` in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `ItemEnabled` specifies the property of the collection elements to be used that sets whether the button group item is enabled
* `ItemText` specifies the text in the button item
* `ItemType` specifies the button type
* `ItemVisualStyle` specifies the button visualStyle
* `ItemClick` specifies the property command that will be triggered when a button is clicked

```DOTHTML

<bs:ButtonGroup DataSource="{value: Buttons}"
                ItemClick="{command: Action()}"
                ItemText="{value: Text}"
                ItemType="{value: Color}"
                ItemVisualStyle="OutLine"/>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<ButtonDto> Buttons { get; set; }

    public override Task Init()
    {
        Buttons = new List<ButtonDto>() { new ButtonDto(), new ButtonDto(), new ButtonDto(), new ButtonDto() };
        return base.Init();
    }
}

public class ButtonDto
{
    public string Text { get; set; } = "Button";
    public ButtonType Color { get; set; } = ButtonType.Danger;
    public ButtonVisualStyle Style { get; set; } = ButtonVisualStyle.OutLine;

    public void Action()
    {
        Text = "CHANGED1";
        Color = ButtonType.Success;
        Style = ButtonVisualStyle.SolidFill;
    }
}
```

