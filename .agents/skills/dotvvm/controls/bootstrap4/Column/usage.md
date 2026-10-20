# <bs:Column>
Renders a Bootstrap column. This control should be a direct child of [Row](~/controls/bootstrap4/Row) control.

<https://getbootstrap.com/docs/4.3/layout/grid/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Offset`|String|Gets or sets the offset of the column for all screen sizes.|attribute, static value||
|`OffsetLG`|String|Gets or sets the offset of the column for large screen.|attribute, static value||
|`OffsetMD`|String|Gets or sets the offset of the column for medium screen.|attribute, static value||
|`OffsetSM`|String|Gets or sets the offset of the column for small screen.|attribute, static value||
|`OffsetXL`|String|Gets or sets the offset of the column for extra large screen.|attribute, static value||
|`Size`|String|Gets or sets the horizontal size of the column for all screen sizes.|attribute, static value||
|`SizeLG`|String|Gets or sets the horizontal size of the column for large screen.|attribute, static value||
|`SizeMD`|String|Gets or sets the horizontal size of the column for medium screen.|attribute, static value||
|`SizeSM`|String|Gets or sets the horizontal size of the column for small screen.|attribute, static value||
|`SizeXL`|String|Gets or sets the horizontal size of the column for extra large screen.|attribute, static value||
|`VerticalAlignment`|([VerticalAlignment](../_enums/DotVVM.Framework.Controls.Bootstrap4.VerticalAlignment.md))|Gets or sets of the vertical alignment of this column within the row.|attribute, static value|None|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Column Sizes 

You can specify the size of the column in the Bootstrap grid units (12 units per row by default) using the `Size` property. 

To override the value for particular screen sizes, use the `SizeSM`, `SizeMD`, `SizeLG` and `SizeXL` properties.

If you don't specify the size of the column, Bootstrap will distribute the space equally.

<!-- TODO: auto-width columns -->

<!-- TODO: sample with auto-width columns -->

See [Bootstrap Grid documentation](https://getbootstrap.com/docs/4.3/layout/grid/#auto-layout-columns) for more details.

```DOTHTML
<bs:Row>
    <bs:Column Size="4" SizeLG="10" style="background-color: red; color: white">
        Default = 4/12 | LG = 10/12
    </bs:Column>
    <bs:Column Size="8" SizeLG="2" style="background-color: blue; color: white">
        Default = 8/12 | LG = 2/12
    </bs:Column>
</bs:Row>

```

## Sample 2: Column Offsets

To shift the column to the right, use the `Offset` property - it specifies the number of columns to be skipped.

To override the value for a particular screen size, use `OffsetSM`, `OffsetMD`, `OffsetLG` and `OffsetXL` properties.

<!-- TODO: sample -->

```DOTHTML
<bs:Column SizeXS="7" SizeLG="2" style="background-color: blue; color: white">
    no offset
</bs:Column>
<bs:Column SizeXS="5" OffsetLG="4" SizeLG="6" style="background-color: red; color: white">
    offset = 4 for the large screen
</bs:Column>
```

## Sample 3: Column Ordering

To specify explicit column order, use the `Order` property.

To override the value for a particular screen size, use `OrderSM`, `OrderMD`, `OrderLG` and `OrderXL` properties.

<!-- TODO: sample -->



```DOTHTML
<bs:Row>
    <bs:Column FlexDecorator.OrderLG="last" Size="4" style="background-color: blue; color: white">
        First
    </bs:Column>
    <bs:Column FlexDecorator.OrderLG="2" FlexDecorator.Order="last" Size="4" style="background-color: red; color: white">
        Second
    </bs:Column>
    <bs:Column FlexDecorator.OrderLG="first" FlexDecorator.Order="2" Size="4" style="background-color: green; color: white">
        Third
    </bs:Column>
</bs:Row>
```

## Sample 4: Vertical Alignment

You can use the `AlignSelf` property to align the column vertically within the row.

* `Start` aligns the columns to the top.
* `Center` aligns the columns to the middle.
* `End` aligns the columns to the bottom.

<!-- TODO: sample -->



```DOTHTML
<bs:Row>
  <bs:Column AlignSelf="Start" style="background-color: blue; color: white">
    Column 1
  </bs:Column>
  <bs:Column AlignSelf="Center" style="background-color: red; color: white">
    Column 2
  </bs:Column>
</bs:Row>

```

