# <dot:Row>
Represents a row in Bootstrap grid system.

https://getbootstrap.com/docs/5.2/layout/grid/

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ColumnNumberAll`|String|Gets or sets the number of columns in the row for all screens.|attribute, static value, bindable||
|`ColumnNumberLarge`|String|Gets or sets the number of columns in the row for a large screen.|attribute, static value, bindable||
|`ColumnNumberMedium`|String|Gets or sets the number of columns in the row for a medium screen.|attribute, static value, bindable||
|`ColumnNumberSmall`|String|Gets or sets the number of columns in the row for a small screen.|attribute, static value, bindable||
|`ColumnNumberXLarge`|String|Gets or sets the number of columns in the row for a very large screen.|attribute, static value, bindable||
|`ColumnNumberXXLarge`|String|Gets or sets the number of columns in the row for the largest screen.|attribute, static value, bindable||
|`Content`|List<DotvvmControl>|Gets or sets the content inside the row.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HorizontalGutterAll`|String|Gets or sets the horizontal gutter size for all screens.|attribute, static value, bindable||
|`HorizontalGutterLarge`|String|Gets or sets the horizontal gutter size for a large screen.|attribute, static value, bindable||
|`HorizontalGutterMedium`|String|Gets or sets the horizontal gutter size for a medium screen.|attribute, static value, bindable||
|`HorizontalGutterSmall`|String|Gets or sets the horizontal gutter size for a small screen.|attribute, static value, bindable||
|`HorizontalGutterXLarge`|String|Gets or sets the horizontal gutter size for a very large screen.|attribute, static value, bindable||
|`HorizontalGutterXXLarge`|String|Gets or sets the horizontal gutter size for the largest screen.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`VerticalGutterAll`|String|Gets or sets the vertical gutter size for all screens.|attribute, static value, bindable||
|`VerticalGutterLarge`|String|Gets or sets the vertical gutter size for a large screen.|attribute, static value, bindable||
|`VerticalGutterMedium`|String|Gets or sets the vertical gutter size for a medium screen.|attribute, static value, bindable||
|`VerticalGutterSmall`|String|Gets or sets the vertical gutter size for a small screen.|attribute, static value, bindable||
|`VerticalGutterXLarge`|String|Gets or sets the vertical gutter size for a very large screen.|attribute, static value, bindable||
|`VerticalGutterXXLarge`|String|Gets or sets the vertical gutter size for the largest screen.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Row with Columns

The row can contain one or more [Column](~/controls/bootstrap5/Column) controls.

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

By default, columns in Bootstrap rows use gutters to preserve space between them. The gutters can be disabled by the `{prefix}Gutter{suffix}` property, where suffix can be `All`, `Small`, `Medium`, `Large`, `XLarge` or `XXLarge` based on window size and prefix can be `Horizontal` or `Vertical` for gutter direction.

```DOTHTML
<bs:Row HorizontalGutterSmall="0" HorizontalGutterMedium="1" HorizontalGutterLarge="3" HorizontalGutterXLarge="4" HorizontalGutterXXLarge="5" ColumnNumberAll="2">
    <bs:Column>
        Column 1
    </bs:Column>
    <bs:Column>
        Column 2
    </bs:Column>
    <bs:Column>
        Column 3
    </bs:Column>
    <bs:Column>
        Column 4
    </bs:Column>
</bs:Row>
```

## Sample 3: Justify content (Horizontal Alignment)

Use `Flex.JustifyContentAll` property on flexbox containers to change the alignment of flex items on the main axis for all screen sizes.

There are also `Flex.JustifyContentSmall`, `Flex.JustifyContentMedium`, `Flex.JustifyContentLarge`, `Flex.JustifyContentXLarge` and `Flex.JustifyContentXXLarge` to specify the behavior for particular screen sizes.

* `None` aligns the columns by defaultt.
* `Start` aligns the columns to the left.
* `Center` aligns the columns to the middle.
* `End` aligns the columns to the right.
* `Around` distributes the remaining space equally in the gaps between columns. Items have a half-size space on either end.
* `Between` distributes the remaining space equally in the gaps between columns. The first item is flush with the start, the last is flush with the end.
* `Evenly` distributes the remaining space equally in the gaps between columns. Items have equal space around them.


See the diagram in [Bootstrap Grid documentation](<https://getbootstrap.com/docs/5.2/utilities/flex/#justify-content>).



```DOTHTML
<bs:Row Flex.JustifyContentMedium="Center" style="border-style:dashed">
    <bs:Column style="border-style:solid">
        Column 1
    </bs:Column>
    <bs:Column style="border-style:solid">
        Column 2
    </bs:Column>
</bs:Row>
<bs:Row Flex.JustifyContentAll="Between" style="border-style:dashed">
    <bs:Column style="border-style:solid">
        Column 1
    </bs:Column>
    <bs:Column style="border-style:solid">
        Column 2
    </bs:Column>
</bs:Row>

```

## Sample 4: Vertical Alignment

The `AlignItems` property allows to specify vertical alignment of the columns in the row.

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

## Sample 5: Column Number

The `ColumnNumber` property allows to specify number of the columns in the row based on the window size.



```DOTHTML
    <bs:Row ColumnNumberSmall="1" ColumnNumberMedium="5" ColumnNumberLarge="3" ColumnNumberXLarge="4" ColumnNumberXXLarge="2">
        <bs:Column>
            Column 1
        </bs:Column>
        <bs:Column>
            Column 2
        </bs:Column>
        <bs:Column>
            Column 3
        </bs:Column>
        <bs:Column>
            Column 4
        </bs:Column>
        <bs:Column>
            Column 5
        </bs:Column>
        <bs:Column>
            Column 6
        </bs:Column>
        <bs:Column>
            Column 7
        </bs:Column>
        <bs:Column>
            Column 8
        </bs:Column>
        <bs:Column>
            Column 9
        </bs:Column>
    </bs:Row>

```

