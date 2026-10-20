# <dot:Form>
The `Form` control is used to represent a form with `FormControl` controls inside it.

<https://getbootstrap.com/docs/5.2/forms/overview/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>||inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemControlSizeAll`|String|Gets or sets the size of the control for all screen sizes.|attribute, static value||
|`ItemControlSizeLarge`|String|Gets or sets the size of the control for large screen sizes.|attribute, static value||
|`ItemControlSizeMedium`|String|Gets or sets the size of the control for medium screen sizes.|attribute, static value||
|`ItemControlSizeSmall`|String|Gets or sets the size of the control for small screen sizes.|attribute, static value||
|`ItemControlSizeXLarge`|String|Gets or sets the size of the control for extra large screen sizes.|attribute, static value||
|`ItemControlSizeXXLarge`|String|Gets or sets the size of the control for extra extra large screen sizes.|attribute, static value||
|`ItemFormControlCssClass`|String|Gets or sets the CSS class to apply to the form control element.|attribute, static value||
|`ItemFormControlType`|FormControlType?|Gets or sets the available form control type.|attribute, static value||
|`ItemHelpContent`|List<DotvvmControl>|Gets or sets a custom template for for the help text. Cannot be combined with a `HelpText` property.|inner element, static value||
|`ItemHelpText`|String|Gets or sets a plain text for the help text. Cannot be combined with a `HelpContent` property.|attribute, static value, bindable||
|`ItemLabelContent`|List<DotvvmControl>|Gets or sets a custom template for for the control label. Cannot be combined with a `LabelText` property.|inner element, static value||
|`ItemLabelSizeAll`|String|Gets or sets the size of the label for all screen sizes.|attribute, static value||
|`ItemLabelSizeLarge`|String|Gets or sets the size of the label for large screen sizes.|attribute, static value||
|`ItemLabelSizeMedium`|String|Gets or sets the size of the label for medium screen sizes.|attribute, static value||
|`ItemLabelSizeSmall`|String|Gets or sets the size of the label for small screen sizes.|attribute, static value||
|`ItemLabelSizeXLarge`|String|Gets or sets the size of the label for extra large screen sizes.|attribute, static value||
|`ItemLabelSizeXXLarge`|String|Gets or sets the size of the label for extra extra large screen sizes.|attribute, static value||
|`ItemLabelText`|String|Gets or sets a plain text for the control label. Cannot be combined with a `LabelContent` property.|attribute, static value, bindable||
|`ItemLabelType`|LabelType?|Gets or sets the label type. Possible values are `Default` and `Floating`.|attribute, static value||
|`ItemLayout`|FormControlLayout?|Gets or sets the form control layout. Possible values are `Default`, `Horizontal` and `Grid`.|attribute, static value||
|`ItemRenderLabel`|Boolean?|Gets or sets whether the label is rendered.|attribute, static value||
|`ItemSize`|Size?|Gets or sets the size of the label and form control elements.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Using inside a Form

The `FormControl` control and a `Form` control could be used together to avoid unnecessary code.

Every `FormControl` property has a representation of a `Form` control with an `Item` prefix (e.g., ItemFormControlType, ItemLayout, ItemLabelType...). All property values are propagated to every `FormControl` control inside a `Form` control. 

The properties specified on a `FormControl` control directly override the property propagated by a `Form` control.

>To avoid adding the `FormControlType` property to every `FormControl`, multiple `FormControls` could be wrapped with a `Form` and an `ItemFormControlType` property set to `FormControl`.

```DOTHTML
<bs:Form ItemFormControlType="FormControl" ItemLayout="Grid">
    <bs:FormControl LabelText="Custom FormControl text">
        <dot:Button>Dotvvm Button</dot:Button>
    </bs:FormControl>
    <%--This FormControl is horizontal!--%>
    <bs:FormControl Layout="Horizontal" LabelText="Custom FormControl text">
        <dot:Button>Dotvvm Button</dot:Button>
    </bs:FormControl>
</bs:Form>
```

