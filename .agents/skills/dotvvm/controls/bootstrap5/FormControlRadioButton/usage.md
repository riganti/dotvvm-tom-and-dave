# <dot:FormControlRadioButton>
A special version of the [RadioButton](~/controls/bootstrap5/RadioButton) control that can be used in [Form](~/controls/bootstrap5/Form).

See [RadioButton](~/controls/bootstrap5/RadioButton) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/form-control>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<RadioButton>|Gets or sets a collection of RadioButton controls, that are validated together.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`FormControlCssClass`|String|Gets or sets the CSS class to apply to the form control element.|attribute, static value||
|`HelpContent`|List<DotvvmControl>|Gets or sets a custom template for for the help text. Cannot be combined with a `HelpText` property.|inner element, static value||
|`HelpText`|String|Gets or sets a plain text for the help text. Cannot be combined with a `HelpContent` property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

```DOTHTML
<bs:FormControlRadioButton HelpText="Help Text">
    <bs:RadioButton ID="r" CheckedItem="{value: Color}" CheckedValue="r" Text="R" />
    <bs:RadioButton ID="g" CheckedItem="{value: Color}" CheckedValue="g" Text="G" />
    <bs:RadioButton ID="b" CheckedItem="{value: Color}" CheckedValue="b" Text="B" />
</bs:FormControlRadioButton>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Color { get; set; }
}
```

