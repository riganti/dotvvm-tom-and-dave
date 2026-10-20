# <bs:Column>
Renders a Bootstrap Column. Use this control inside the Row.
<https://getbootstrap.com/docs/3.3/css/#grid>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`OffsetLG`|Int32?|Gets or sets the offset of the column in the LG mode.|attribute, static value||
|`OffsetMD`|Int32?|Gets or sets the offset of the column in the MD mode.|attribute, static value||
|`OffsetSM`|Int32?|Gets or sets the offset of the column in the SM mode.|attribute, static value||
|`OffsetXL`|Int32?|Gets or sets the offset of the column in the XL mode.|attribute, static value||
|`OffsetXS`|Int32?|Gets or sets the offset of the column in the XS mode.|attribute, static value||
|`SizeLG`|Int32?|Gets or sets the horizontal size of the column in the LG mode.|attribute, static value||
|`SizeMD`|Int32?|Gets or sets the horizontal size of the column in the MD mode.|attribute, static value||
|`SizeSM`|Int32?|Gets or sets the horizontal size of the column in the SM mode.|attribute, static value||
|`SizeXL`|Int32?|Gets or sets the horizontal size of the column in the XL mode.|attribute, static value||
|`SizeXS`|Int32?|Gets or sets the horizontal size of the column in the XS mode.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Column Sizes 

You can specify the size of the Column (in the Bootstrap grid system) for each screen size by setting the following properties:  

* `SizeXS`
* `SizeSM`
* `SizeMD` 
* `SizeLG`
* `SizeXL`

```DOTHTML
<bs:Column SizeXS="4" SizeLG="10" style="background-color: red; color: white">
    XS = 4/12 | LG = 10/12
</bs:Column>
<bs:Column SizeXS="8" SizeLG="2" style="background-color: blue; color: white">
    XS = 8/12 | LG = 2/12
</bs:Column>

```

## Sample 2: Column Offsets

To shift the column to the right use the following properties:  

* `OffsetXS`
* `OffsetSM`
* `OffsetMD`
* `OffsetLG`
* `OffsetXL`

```DOTHTML
<bs:Column SizeXS="7" SizeLG="2" style="background-color: blue; color: white">
    no offset
</bs:Column>
<bs:Column SizeXS="5" OffsetLG="4" SizeLG="6" style="background-color: red; color: white">
    offset = 4 for the large screen
</bs:Column>
```

