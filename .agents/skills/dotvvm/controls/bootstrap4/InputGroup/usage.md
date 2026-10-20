# <bs:InputGroup>
Renders a Bootstrap input group which decorates the [TextBox](~/controls/builtin/TextBox) with buttons or other controls on the side.

<https://getbootstrap.com/docs/4.3/components/input-group/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|List<IInputGroupContentItem>|Gets or sets the main content of the input group.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LeftTemplate`|List<IInputGroupSideItem>|Gets or sets the left side extension of the input group.|inner element, static value||
|`RightTemplate`|List<IInputGroupSideItem>|Gets or sets the right side extension of the input group.|inner element, static value||
|`Size`|([Size](../_enums/DotVVM.Framework.Controls.Bootstrap4.Size.md))|Gets or sets the size of the input group.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

* The `InputGroup` control has the `ContentTemplate` property which must contain [InputGroupTextBox](~/controls/bootstrap4/InputGroupTextBox) or [InputGroupComboBox](~/controls/bootstrap4/InputGroupComboBox) control.

It also has the `LeftTemplate` and `RightTemplate` properties that define the content on the left and right of the textbox. 

The following controls are supported in these templates:

* [InputGroupButton](~/controls/bootstrap4/InputGroupButton)
* [InputGroupCheckBox](~/controls/bootstrap4/InputGroupCheckBox) 
* [InputGroupDropDownButton](~/controls/bootstrap4/InputGroupDropDownButton)
* [InputGroupLinkButton](~/controls/bootstrap4/InputGroupLinkButton)
* [InputGroupLiteral](~/controls/bootstrap4/InputGroupLiteral)
* [InputGroupRadioButton](~/controls/bootstrap4/InputGroupRadioButton) 
* [InputGroupRouteLink](~/controls/bootstrap4/InputGroupRouteLink) 

There is also the `Size` property which can be set to `Large`, `Small` and `Default`.


```DOTHTML
<bs:InputGroup>
  <LeftTemplate>
    <bs:InputGroupButton Text="Button" Click="{command: UpdateText()}" />
  </LeftTemplate>
  <ContentTemplate>
    <bs:InputGroupTextBox Text="{value: Text}" />
  </ContentTemplate>
  <RightTemplate>
    <bs:InputGroupLiteral Text="Click the Button on the left." />
  </RightTemplate>
</bs:InputGroup>

<bs:InputGroup Size="Small">
  <LeftTemplate>
    <bs:InputGroupCheckBox Checked="{value: Checked}" Changed="{command: UpdateText2()}" />
  </LeftTemplate>
  <ContentTemplate>
    <bs:InputGroupComboBox SelectedValue="{value: Text2}" DataSource="{value: Values}" />
  </ContentTemplate>
  <RightTemplate>
    <bs:InputGroupLiteral Text="Click the CheckBox on the left." />
  </RightTemplate>
</bs:InputGroup>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Text { get; set; }
    public int Clicks { get; set; } = 0;
    

    public void UpdateText()
    {
        Clicks++;
        Text = "Button was clicked " + Clicks + 'x';
    }

    public bool Checked { get; set; }
    public string Text2 { get; set; } = "a";
    public string[] Values { get; set; } = new string[] { "a", "b", "c" };

    public void UpdateText2()
    {
        Text2 = "b";
    }
}
```

## Sample 2: Multiple Controls in the InputGroup

You can also place multiple controls in the `LeftTemplate` and `RightTemplate` properties.


```DOTHTML
<bs:InputGroup>
  <LeftTemplate>
    <bs:InputGroupRadioButton CheckedItem="{value: Color}" CheckedValue="r" Text="R" />
    <bs:InputGroupRadioButton CheckedItem="{value: Color}" CheckedValue="g" Text="G" />
    <bs:InputGroupRadioButton CheckedItem="{value: Color}" CheckedValue="b" Text="B" />
  </LeftTemplate>
  <ContentTemplate>
    <bs:InputGroupTextBox Text="{value: Color}"/>
  </ContentTemplate>
  <RightTemplate>
    <bs:InputGroupButton Text="Button 1" />
    <bs:InputGroupButton Text="Button 2" />
  </RightTemplate>
</bs:InputGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.InputGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Color { get; set; } = "g";
    }
}
```

