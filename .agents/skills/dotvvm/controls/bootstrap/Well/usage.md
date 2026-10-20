# <bs:Well>
Renders the Bootstrap Well widget.

<https://getbootstrap.com/docs/3.3/components/#wells>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([WellType](../_enums/DotVVM.Framework.Controls.Bootstrap.WellType.md))|Gets or sets the type of the well.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Well Usage

Place the contents inside the `<bs:Well>` control.

To specify the size of the `Well`, you can use the `Type` property.

```DOTHTML
<bs:Well>
  Content of the well.
</bs:Well>

<bs:Well Type="Small">
  Small well.
</bs:Well>

<bs:Well Type="Large">
  Large well.
</bs:Well>
```

