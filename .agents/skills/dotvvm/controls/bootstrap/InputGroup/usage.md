# <bs:InputGroup>
Renders a Bootstrap input group which decorates the [TextBox](~/controls/builtin/TextBox) with buttons or other controls on the side.

<https://getbootstrap.com/docs/3.3/components/#input-groups>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the main content of the input group.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LeftTemplate`|ITemplate|Gets or sets the left side extension of the input group.|inner element, static value||
|`RightTemplate`|ITemplate|Gets or sets the right side extension of the input group.|inner element, static value||
|`Size`|([InputGroupSize](../_enums/DotVVM.Framework.Controls.Bootstrap.InputGroupSize.md))|Gets or sets the size of the button.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

* The `InputGroup` control has the `ContentTemplate` property which must contain a [TextBox](~/controls/builtin/TextBox) control.

It also has the `LeftTemplate` and `RightTemplate` properties that define the content on the left and right of the textbox.

The following types of content are supported in these templates:

* Text content or single HTML inline element (e.g. `<span>`)
* [Button](~/controls/bootstrap/Button)
* [DropDownButton](~/controls/bootstrap/DropDownButton)
* [CheckBox](~/controls/bootstrap/CheckBox) 
* [RadioButton](~/controls/bootstrap/RadioButton) 
* [GlyphIcon](~/controls/bootstrap/GlyphIcon) 

There is also the `Size` property which can be set to `Large`, `Small` and `Default`.


```DOTHTML
<bs:InputGroup>
  <LeftTemplate>
    <bs:Button Text="Button" Click="{command: UpdateText()}" />
  </LeftTemplate>
  <ContentTemplate>
    <dot:TextBox Text="{value: Text}" />
  </ContentTemplate>
  <RightTemplate>
    <span>Click the Button on the left.</span>
  </RightTemplate>
</bs:InputGroup>

<bs:InputGroup Size="Small">
  <LeftTemplate>
    <!-- to make the CheckBox look nice, use IsInline="true" -->
    <bs:CheckBox Checked="{value: Checked}" Changed="{command: UpdateText2()}" IsInline="true" />
  </LeftTemplate>
  <ContentTemplate>
    <dot:TextBox Text="{value: Text2}" />
  </ContentTemplate>
  <RightTemplate>
    <span>Click the CheckBox on the left.</span>
  </RightTemplate>
</bs:InputGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.InputGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }
        public int Clicks { get; set; } = 0;
        

        public void UpdateText()
        {
            Clicks++;
            Text = "Button was clicked " + Clicks + 'x';
        }

        public string Text2 { get; set; }
        public bool Checked { get; set; }

        public void UpdateText2()
        {
            Text2 = "Checkbox was " + (Checked ? "checked" : "unchecked");
        }
    }
}
```

## Sample 2: Multiple Controls in the InputGroup

You can also place multiple controls in the `LeftTemplate` and `RightTemplate` properties, e.g. [RadioButton](~/controls/bootstrap/RadioButton)s or a combination of 
[Button](~/controls/bootstrap/Button)s and [DropDownButton](~/controls/bootstrap/DropDownButton)s.


```DOTHTML
<bs:InputGroup>
  <LeftTemplate>
    <dot:RadioButton CheckedItem="{value: Color}" CheckedValue="r" Text="R" />
    <dot:RadioButton CheckedItem="{value: Color}" CheckedValue="g" Text="G" />
    <dot:RadioButton CheckedItem="{value: Color}" CheckedValue="b" Text="B" />
  </LeftTemplate>
  <ContentTemplate>
    <dot:TextBox Text="{value: Color}"/>
  </ContentTemplate>
  <RightTemplate>
    <bs:Button Text="Button 1" />
    <bs:Button Text="Button 2" />
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

