# <dot:FormControlCheckBox>
A special version of the [CheckBox](~/controls/bootstrap5/CheckBox) control that can be used in [Form](~/controls/bootstrap5/Form).

See [CheckBox](~/controls/bootstrap5/CheckBox) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/form-control>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonFontType`|([ButtonTextColor](../_enums/DotVVM.Bootstrap5.ButtonTextColor.md))|Gets or sets the font color. Use this property in combination with a `Button` checkbox visual style.|attribute, static value, bindable|Default|
|`ButtonSize`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the button size. Use this property in combination with a `Button` checkbox visual style.|attribute, static value, bindable|Default|
|`ButtonType`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the button type. Use this property in combination with a `Button` checkbox visual style.|attribute, static value, bindable|Primary|
|`ButtonVisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets the button visual style. Use this property in combination with a `Button` checkbox visual style.|attribute, static value|SolidFill|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, static value, bindable||
|`CheckedItems`|IValueBinding<IEnumerable>|Gets or sets the collection of checked items. Use this property in combination with the CheckedValue property.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked. Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets a single CheckBox control, that is validated.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable||
|`FormControlCssClass`|String|Gets or sets the CSS class to apply to the form control element.|attribute, static value||
|`HelpContent`|List<DotvvmControl>|Gets or sets a custom template for for the help text. Cannot be combined with a `HelpText` property.|inner element, static value||
|`HelpText`|String|Gets or sets a plain text for the help text. Cannot be combined with a `HelpContent` property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsInline`|Boolean|Gets or sets whether the control should be rendered on the same horizontal row.|attribute, static value|False|
|`IsReversed`|Boolean|Gets or sets whether the control should be put on the opposite side of the page.|attribute, static value, bindable|False|
|`RenderLabel`|Boolean|Gets or sets whether the label will be rendered. If set to null than the label will be rendered if needed.|attribute, static value|True|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([CheckBoxVisualStyle](../_enums/DotVVM.Bootstrap5.Enums.CheckBoxVisualStyle.md))|Gets or sets the radio button visual style. Possible values are `Default`, `Switch`, `Button`.|attribute, static value|Default|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Gets or sets the command that will be triggered when the control check state is changed.|

## Sample 1: Basic Usage


```DOTHTML
<bs:FormControlCheckBox HelpText="Let us know if you like potatoes" Text="I like potatoes" VisualStyle="Switch" Checked="{value: Value}" />

<bs:FormControlCheckBox Text="Check this" VisualStyle="Default" CheckedValue="1" CheckedItems="{value: ResultItems}" />

<bs:Button Text="Validate" Click="{command: Validate()}" />
```

```CSHARP
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class ViewModel : DotvvmViewModelBase, IValidatableObject
{
    public bool Value { get; set; }

    public List<string> ResultItems { get; set; } = new List<string>();

    public void Validate()
    {

    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Value)
        {
            yield return new ValidationResult($"Value must be true.", new[] { nameof(Value) });
        }

        if (!ResultItems.Any())
        {
            yield return new ValidationResult($"At least one checkbox must be checked", new[] { nameof(ResultItems) });
        }
    }
}
```

