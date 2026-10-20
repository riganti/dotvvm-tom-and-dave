# <bs:ResponsiveTable>
Renders horizontal scrollbars for a table on small devices (under 768px).

<https://getbootstrap.com/docs/3.3/css/#tables-responsive>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic ResponsiveTable

To make the table responsive, just place the table inside the control.

```DOTHTML
<bs:ResponsiveTable>
  <h2>This is responsive table</h2>
  <bs:Table Style="Hover">
    <thead>
      <tr>
        <th>1</th>
        <th>2</th>
        <th>3</th>
        <th>4</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>Lorem</td>
        <td>Ipsum</td>
        <td>Dolor</td>
        <td>Sit</td>
      </tr>
      <tr>
        <td>Consectetur</td>
        <td>Adipiscing</td>
        <td>Elit</td>
        <td>Vivamus</td>
      </tr>
      <tr>
        <td>Vaucibus</td>
        <td>Leo</td>
        <td>Non</td>
        <td>Dignissim</td>
      </tr>
    </tbody>
  </bs:Table>
</bs:ResponsiveTable>
```

