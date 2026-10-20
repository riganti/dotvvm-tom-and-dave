# <bs:HelpText>
Renders a help text widget that can be linked to another control.

<https://getbootstrap.com/docs/3.3/css/#forms-help-text>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AssociatedControlID`|String|Gets or sets the ID of an associated control for this help text.|attribute, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: HelpText Usage

Use the `AssociatedControlID` property to specify the ID of the control which the help text is applied to.

This will ensure that assistive technologies, such as screen readers, will announce this help text when the user focuses or enters the control.

```DOTHTML
<bs:Form Type="Vertical">
  
    <bs:FormGroup LabelText="Email">
    <bs:FormStaticValue>email@example.com</bs:FormStaticValue>
  </bs:FormGroup>
  
  <bs:FormGroup LabelText="Input Password">
    <dot:TextBox ID="inputHelpBlock" Text="{value: Password}" Type="Password"/>
    <bs:HelpText ID="help" AssociatedControlID="inputHelpBlock">
      A simple help text for Input Password
    </bs:HelpText>
  </bs:FormGroup>

</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.HelpText.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Password { get; set; }
    }
}
```

