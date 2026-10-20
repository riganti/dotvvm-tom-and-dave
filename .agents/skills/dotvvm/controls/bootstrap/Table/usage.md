# <bs:Table>
Renders a HTML table with an option to specify the Bootstrap styles.

<https://getbootstrap.com/docs/3.3/css/#tables>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([TableType](../_enums/DotVVM.Framework.Controls.Bootstrap.TableType.md))|Gets or sets the type of the Bootstrap table.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Table

The `Table` control has the `Type` property which selects the Bootstrap table style.

```DOTHTML
<bs:Table Type="Bordered">
  <thead>
    <tr>
      <th>1</th>
      <th>2</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>Lorem</td>
      <td>Ipsum</td>
    </tr>
  </tbody>
</bs:Table>
```

