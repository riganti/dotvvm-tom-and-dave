# <bs:Label>
Extends the builtin [Literal](~/controls/builtin/Literal) control and allows to apply the Bootstrap classes. 

<https://getbootstrap.com/docs/3.3/components/#labels>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FormatString`|String||attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Text`|Object||attribute, static value, bindable||
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the Bootstrap color.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Label Types

The `Type` property affects which color will be used on the label.

The available types are:

* Default
* Primary
* Success
* Info
* Warning
* Danger

```DOTHTML
<bs:Label Text="Label-Default"/>
<bs:Label Text="Label-Primary" Type="Primary"/>
<bs:Label Text="Label-Success" Type="Success"/>
<bs:Label Text="Label-Info" Type="Info"/>
<bs:Label Text="Label-Warning" Type="Warning"/>
<bs:Label Text="Label-Danger" Type="Danger"/>
```

