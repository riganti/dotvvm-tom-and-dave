# <bs:Row>
Renders a Bootstrap row.

<https://getbootstrap.com/docs/4.3/layout/grid/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([RowType](../_enums/DotVVM.Framework.Controls.Bootstrap4.RowType.md))|Gets or sets whether this is a normal row or a row inside form.|attribute, static value|Default|
|`UseGutters`|Boolean|Gets or sets whether the row has gutters.|attribute, static value|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Row with Columns

The row can contain one or more [Column](~/controls/bootstrap4/Column) controls.

```DOTHTML
<bs:Row>
  <bs:Column style="background-color: blue; color: white">
    Column 1
  </bs:Column>
  <bs:Column style="background-color: red; color: white">
    Column 2
  </bs:Column>
</bs:Row>

```

## Sample 2: Gutters

By default, columns in Bootstrap rows use gutters to preserve space between them. The gutters can be disabled by the `UseGutters` property.

```DOTHTML
<bs:Row UseGutters="false">
  <bs:Column style="background-color: blue; color: white">
    Column 1
  </bs:Column>
  <bs:Column style="background-color: red; color: white">
    Column 2
  </bs:Column>
</bs:Row>

```

## Sample 3: Horizontal Alignment

The `JustifyContent` property allows to specify horizontal alignment for all screen sizes. 

There are also `JustifyContentSM`, `JustifyContentMD`, `JustifyContentLG` and `JustifyContentXL` to specify the behavior for particular screen sizes.

* `Start` aligns the columns to the left.
* `Center` aligns the columns to the middle.
* `End` aligns the columns to the right.
* `Around` distributes the remaining space equally around every column.
* `Between` distributes the remaining space equally in the gaps between columns.

See the diagram in [Bootstrap Grid documentation](<https://getbootstrap.com/docs/4.3/layout/grid/#horizontal-alignment>).



```DOTHTML
<bs:Row JustifyContentMD="Start" JustifyContentMD="Center">
  <bs:Column style="background-color: blue; color: white">
    Column 1
  </bs:Column>
  <bs:Column style="background-color: red; color: white">
    Column 2
  </bs:Column>
</bs:Row>

```

## Sample 4: Vertical Alignment

The `AlignItems` property allows to specify vertical alignment of the columns in the row.

* `Start` aligns the columns to the top.
* `Center` aligns the columns to the middle.
* `End` aligns the columns to the bottom.



```DOTHTML
<bs:Row AlignItems="Center">
  <bs:Column style="background-color: blue; color: white">
    Column 1
  </bs:Column>
  <bs:Column style="background-color: red; color: white">
    Column 2
  </bs:Column>
</bs:Row>

```

