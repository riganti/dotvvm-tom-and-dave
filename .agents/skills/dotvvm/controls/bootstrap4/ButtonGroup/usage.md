# <bs:ButtonGroup>
Renders a group of Bootstrap buttons. The group can be used separately, or within a [ButtonToolbar](~/controls/bootstrap4/ButtonToolbar) control.

<https://getbootstrap.com/docs/4.3/components/button-group/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnabledBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is disabled or not.|attribute, bindable||
|`IsVertical`|Boolean|Gets or sets whether the button group is rendered in the vertical mode.|attribute, static value|False|
|`Items`|List<IButtonGroupItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContentTemplate`|ITemplate|Gets or sets the template for contents of the generated items when using the DataSource property.|inner element, static value||
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the buttons in the button group.|attribute, static value|Default|
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`TypeBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the Type of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyleBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the VisualStyle of the item.|attribute, bindable||

## Events
|Name|Type|Description|
|---|---|---|
|`ClickBinding`|ICommandBinding|Gets or sets a binding which defines a click action for button items.|

## Sample 1: ButtonGroup Size

The `Size` property specifies the sizing of the buttons. The available sizes are: `Default`, `Small` and `Large`.

Be sure to use the `<bs:Button>` instead of the `<dot:Button>` controls inside the button group. 

You can also use `<bs:DropDownButton>`, `<bs:ButtonGroupCheckBox>` or `<bs:ButtonGroupRadioButton>` inside.

```DOTHTML
<bs:ButtonGroup Size="Large">
  <bs:Button Click="{command: DoSomething()}" Text="Button 1" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 2" />
  
  <bs:DropDownButton Text="Dropdown">
    <Items>
      <bs:DropDownButtonItem NavigateUrl="https://www.google.com">
        Google
      </bs:DropDownButtonItem>
      <bs:DropDownButtonItem NavigateUrl="https://www.youtube.com">
        Youtube
      </bs:DropDownButtonItem>
    </Items>
  </bs:DropDownButton>
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
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {

        public bool Checked1 { get; set; }

        public bool Checked2 { get; set; }
    }
}
```

