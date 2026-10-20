# <bs:ButtonGroup>
Renders a group of Bootstrap buttons.

<https://getbootstrap.com/docs/3.3/components/#btn-groups>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsJustified`|Boolean|Gets or sets whether the button group should justify to fill all available space in the horizontal direction.|attribute, static value|False|
|`IsVertical`|Boolean|Gets or sets whether the button group is rendered in the vertical mode.|attribute, static value|False|
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap.Size.md))|Gets or sets the size of the buttons in the button group.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: ButtonGroup Size

The `Size` property specifies how big the buttons will be. The available sizes are: `Large`, `Default`, `Small` and `ExtraSmall`.

Be sure to use the `<bs:Button>` instead of the `<dot:Button>` controls inside the button group. 

You can also use `<bs:DropDownButton>`, `<bs:CheckBox>` or `<bs:RadioButton>` inside.

```DOTHTML
<bs:ButtonGroup Size="ExtraSmall">
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

## Sample 2: Justified Buttons

Using the `IsJustified` property you can tell the `ButtonGroup` to use all the space available in the horizontal direction.

```DOTHTML
<bs:ButtonGroup IsJustified="true">
  <bs:Button Click="{command: DoSomething()}" Text="Button 1" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 2" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 3" />
  <bs:Button Click="{command: DoSomething()}" Text="Button 4" />
</bs:ButtonGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {

        public void DoSomething()
        {
        }
    }
}
```

## Sample 3: Vertical Buttons

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

## Sample 4: CheckBoxes and RadioButtons in the ButtonGroup

The `ButtonGroup` also supports [CheckBox](~/controls/bootstrap/CheckBox) and [RadioButton](~/controls/bootstrap/RadioButton).

Remember that Bootstrap doesn't support the `Size` and `IsVertical` modifiers when checkboxes or radio buttons are inside the button group.

Also make sure to use the `<bs:CheckBox>` and `<bs:RadioButton>` instead of the `<dot:CheckBox>` and `<dot:RadioButton>` controls. The builtin 
controls are not supported in the `ButtonGroup`.


```DOTHTML
<bs:ButtonGroup IsJustified="true">
  <bs:CheckBox Text="CheckBox 1" Checked="{value: Checked1}" />
  <bs:CheckBox Text="CheckBox 2" Checked="{value: Checked2}" />
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

## Sample 5: CheckBoxes in Repeater and ButtonGroup

You can combine the [CheckBox](~/controls/bootstrap/CheckBox)es and [RadioButton](~/controls/bootstrap/RadioButton)s with the [Repeater](~/controls/builtin/Repeater) in the `ButtonGroup` control.
Use the `CheckedItems` and `CheckedValue` properties to bind these checkboxes to a collection in the viewmodel.

Because we don't want the `Repeater` to render its wrapper `<div>` element, the `ButtonGroup` will switch the `RenderWrapperTag` property to `false` automatically.




```DOTHTML
<bs:ButtonGroup>
  <dot:Repeater DataSource="{value: CheckBoxes}">
    <ItemTemplate>
      <bs:CheckBox Text="{value: Text}" 
                   CheckedItems ="{value: _parent.Colors}" 
                   CheckedValue="{value: CheckedValue}" 
                   Changed="{command: _parent.UpdateSelectedColors()}"/>
    </ItemTemplate>
  </dot:Repeater>
</bs:ButtonGroup>

<p>{{value: SelectedColors}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ButtonGroup.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<CheckBox> CheckBoxes { get; set; }

        public string SelectedColors { get; set; }
        public override Task PreRender()
        {
            CheckBoxes = new List<CheckBox>();
            CheckBoxes = GetData();
            return base.PreRender();
        }
        public ViewModel()
        {
            Colors = new List<string>();
            Colors.Add("red");
            Colors.Add("green");
        }
        public List<string> Colors { get; set; }

        public void UpdateSelectedColors()
        {
            SelectedColors = string.Join(", ", Colors.Select(i => i.ToString()));
        }

        private List<CheckBox> GetData()
        {
            return new List<CheckBox>
            {
                new CheckBox()
                {
                    Text="CheckBox 1",
                    CheckedValue = "red"
                },
                new CheckBox()
                {
                    Text="CheckBox 2",
                    CheckedValue = "blue"
                },
                new CheckBox()
                {
                    Text="CheckBox 3",
                    CheckedValue = "green"
                }



            };
        }
    }

    public class CheckBox
    {
        public string Text { get; set; }
        public string CheckedValue { get; set; }



    }
}
```

