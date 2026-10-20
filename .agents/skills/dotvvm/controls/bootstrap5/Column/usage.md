# <dot:Column>
Renders a Bootstrap column. This control should be a direct child of [Row](~/controls/bootstrap5/Row) control.

https://getbootstrap.com/docs/5.2/layout/grid/

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`OffsetAll`|String|Gets or sets the row offset CSS class for all screens.|attribute, static value, bindable||
|`OffsetLarge`|String|Gets or sets the row offset CSS class for a large screen.|attribute, static value, bindable||
|`OffsetMedium`|String|Gets or sets the row offset CSS class for a medium screen.|attribute, static value, bindable||
|`OffsetSmall`|String|Gets or sets the row offset CSS class for a small screen.|attribute, static value, bindable||
|`OffsetXLarge`|String|Gets or sets the row offset CSS class for a very large screen.|attribute, static value, bindable||
|`OffsetXXLarge`|String|Gets or sets the row offset CSS class for the largest screen.|attribute, static value, bindable||
|`SizeAll`|String|Gets or sets the row size CSS class for all screens.|attribute, static value, bindable||
|`SizeLarge`|String|Gets or sets the row size CSS class for a large screen.|attribute, static value, bindable||
|`SizeMedium`|String|Gets or sets the row size CSS class for a medium screen.|attribute, static value, bindable||
|`SizeSmall`|String|Gets or sets the row size CSS class for a small screen.|attribute, static value, bindable||
|`SizeXLarge`|String|Gets or sets the row size CSS class for a very large screen.|attribute, static value, bindable||
|`SizeXXLarge`|String|Gets or sets the row size CSS class for the largest screen.|attribute, static value, bindable||
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`VerticalAlignment`|([VerticalAlignment](../_enums/DotVVM.Bootstrap5.VerticalAlignment.md))|Gets or sets the vertical alignment CSS class. Possible values are Start (align-self-start), Center (align-self -center), End (align-self-end).|attribute, static value|None|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Column Sizes 

You can specify the size of the column in the Bootstrap grid units (12 units per row by default) using the `SizeAll` property. 

To override the value for particular screen sizes, use the `SizeSmall`, `SizeMedium`, `SizeLarge`, `SizeXLarge` and `SizeXLarge` properties.

If you want to use natural width of column content, than use value `auto` for Size property.

If you don't specify the size of the column, Bootstrap will distribute the space equally.

See [Bootstrap Grid documentation](https://getbootstrap.com/docs/5.2/layout/grid/#auto-layout-columns) for more details.

```DOTHTML
<bs:Column SizeAll="5">
            Size 5
</bs:Column>
<bs:Column SizeSmall="5">
    SizeSM 5
</bs:Column>
<bs:Column SizeMedium="5">
    SizeMD 5
</bs:Column>
<bs:Column SizeLarge="5">
    SizeLG 5
</bs:Column>
<bs:Column SizeXLarge="5">
    SizeXL 5
</bs:Column>
<bs:Column SizeXXLarge="5">
    SizeXXL 5
</bs:Column>
<bs:Column SizeAll="auto">
    Size auto
</bs:Column>
```

## Sample 2: Column Offsets

To shift the column to the right, use the `OffsetAll` property - it specifies the number of columns to be skipped.

To override the value for a particular screen size, use `OffsetSmall`, `OffsetMedium`, `OffsetLarge`, `OffsetXLarge` and `OffsetXXLarge` properties.


```DOTHTML
<bs:Column OffsetAll="5">
    Offset 5
</bs:Column>
<bs:Column OffsetSmall="5">
    OffsetSM 5
</bs:Column>
<bs:Column OffsetMedium="5">
    OffsetMD 5
</bs:Column>
<bs:Column OffsetLarge="5">
    OffsetLG 5
</bs:Column>
<bs:Column OffsetXLarge="5">
    OffsetXL 5
</bs:Column>
<bs:Column OffsetXXLarge="5">
    OffsetXXL 5
</bs:Column>
```

## Sample 3: Column Ordering

To specify explicit column order, use the `OrderAll` property.

To override the value for a particular screen size, use `OrderSmall`, `OrderMedium`, `OrderLarge`, `OrderXLarge` and `OrderXXLarge` properties.

Includes support for `1` through `5` across all six screen sizes. There are also responsive `first` and `last` values that set position of column to first or last position.

```DOTHTML
<bs:Row>
    <bs:Column Flex.OrderAll="5">
        Order 5
    </bs:Column>
    <bs:Column Flex.OrderSmall="5">
        OrderSM 5
    </bs:Column>
    <bs:Column Flex.OrderMedium="5">
        OrderMD 5
    </bs:Column>
    <bs:Column Flex.OrderLarge="5">
        OrderLG 5
    </bs:Column>
    <bs:Column Flex.OrderXLarge="5">
        OrderXL 5
    </bs:Column>
    <bs:Column Flex.OrderXXLarge="5">
        OrderXXL 5
    </bs:Column>
    <bs:Column Flex.OrderAll="last">
        Order Last
    </bs:Column>
    <bs:Column Flex.OrderAll="first">
        Order First
    </bs:Column>
</bs:row>
```

## Sample 4: Vertical Alignment

The `VerticalAlignment` property to align the column vertically within the row.

* `None` aligns the columns by default.
* `Start` aligns the columns to the top.
* `Center` aligns the columns to the middle.
* `End` aligns the columns to the bottom.



```DOTHTML
<bs:Row Flex.AlignItemsAll="Center" style="height:75px;border-style:solid">
    <bs:Column>
        some normal text
    </bs:Column>
    <bs:Column>
        some very cool text
    </bs:Column>
</bs:Row>
<bs:Row Flex.AlignItemsAll="End" style="height:75px;border-style:solid">
    <bs:Column>
        some normal text
    </bs:Column>
    <bs:Column>
        some very cool text
    </bs:Column>
</bs:Row>

```

