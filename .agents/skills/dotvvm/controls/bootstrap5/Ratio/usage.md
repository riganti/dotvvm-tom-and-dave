# <dot:Ratio>
Renders the Bootstrap ratio control.

<https://getbootstrap.com/docs/5.2/helpers/ratio>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the inner content for the Ratio control.|inner element, static value, default property||
|`CustomRatio`|Double|Gets or sets a custom percentage ratio. This property cannot be combined with RatioType.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`RatioType`|([RatioTypes](../_enums/DotVVM.Bootstrap5.Controls.RatioTypes.md))|Gets or sets the predefined ratio type. Possible values are `Ratio1x1`, `Ratio4x3`, `Ratio16x9` and `Ratio21x9`.|attribute, static value, bindable||
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic or custom Ratio

Wrap the element with the `Ratio` control, which maintains your chosen aspect ratio. 
Some most common ratio classes are provided with the `RatioTypes` enum and could be set with the `RatioType` property.

With the `CustomRatio` property, a custom percentage ratio can be set.

```DOTHTML
<bs:Ratio RatioType="Ratio1x1">
    <iframe src="https://youtu.be/dQw4w9WgXcQ" />
</bs:Ratio>

<%-- Custom 50% ratio --%>
<bs:Ratio CustomRatio="50">
    <iframe src="https://youtu.be/dQw4w9WgXcQ" />
</bs:Ratio>


```

