# <bs:RadioButton>
Extends the builtin [RadioButton](~/controls/builtin/RadioButton) control with an option to set Bootstrap CSS classes and support of the [ButtonGroup](~/controls/bootstrap/ButtonGroup).

<https://getbootstrap.com/docs/3.3/css/#forms-controls>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`CheckedItem`|Object|Gets or sets the CheckedValue of the first RadioButton that is checked and bound to this collection.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked.             Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable|True|
|`GroupName`|String|Gets or sets an unique name of the radio button group.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InputCssClass`|String|Gets or sets a CSS class that will be appended on the rendered input element.|attribute, static value||
|`IsInline`|Boolean|Gets or sets whether there will be more radio buttons on the same line. When this property is true, the radio button gets the Boostrap "inline" CSS class.|attribute, static value|False|
|`ItemKeyBinding`|IValueBinding|Gets or sets a property that retrieves an unique key for the CheckedValue so it can be compared with objects in the CheckedItems collection. This property must be set if the value of the CheckedValue property is not a primitive type.|attribute, bindable||
|`LabelCssClass`|String|Gets or sets a CSS class that will be appended on the rendered label element.|attribute, static value||
|`Text`|String|Gets or sets the label text that is rendered next to the control.|attribute, static value, bindable||
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the Bootstrap color.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control check state is changed.|

## Sample 1: Inline RadioButtons

The `IsInline` property allows to render checkboxes on one row.

If the `RadioButton`s are placed inside the [ButtonGroup](~/controls/bootstrap/ButtonGroup) control, they are set to inline by default so you don't have to change anything.


```DOTHTML
<bs:RadioButton Text="RadioButton 1" GroupName="RadioButtons" 
                CheckedValue="RadioButton 1" CheckedItem="{value: Radio}" 
                Inline="true" />
<bs:RadioButton Text="RadioButton 2" GroupName="RadioButtons" 
                CheckedValue="RadioButton 2" CheckedItem="{value: Radio}"
                Inline="true" />
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.RadioButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Radio { get; set; }
    }
}

```

## Sample 2: RadioButton in ButtonGroup

You can change the color of the `RadioButton` using the `Type` property.

This property works only inside the [ButtonGroup](~/controls/bootstrap/ButtonGroup) control.  

```DOTHTML
<bs:ButtonGroup>
  <bs:RadioButton GroupName="RadioButtons" CheckedValue="RadioButton 1" 
                  CheckedItem="{value: Radio}" Text="RadioButton - Default" 
                  Type="Default" />
  <bs:RadioButton GroupName="RadioButtons" CheckedValue="RadioButton 2"  
                  CheckedItem="{value: Radio}" Text="RadioButton - Primary"  
                  Type="Primary" />
  <bs:RadioButton GroupName="RadioButtons" CheckedValue="RadioButton 3"  
                  CheckedItem="{value: Radio}" Text="RadioButton - Success"  
                  Type="Success" />
  <bs:RadioButton GroupName="RadioButtons" CheckedValue="RadioButton 4"  
                  CheckedItem="{value: Radio}" Text="RadioButton - Info"  
                  Type="Info" />
  <bs:RadioButton GroupName="RadioButtons" CheckedValue="RadioButton 4"  
                  CheckedItem="{value: Radio}" Text="RadioButton - Warning"  
                  Type="Warning" />
  <bs:RadioButton GroupName="RadioButtons" CheckedValue="RadioButton 4"  
                  CheckedItem="{value: Radio}" Text="RadioButton - Danger"  
                  Type="Danger" />
</bs:ButtonGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.RadioButton.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Radio { get; set; }
    }
}
```

