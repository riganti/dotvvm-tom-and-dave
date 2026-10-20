# <dot:FormControlComboBox>
A special version of the [ComboBox](~/controls/bootstrap5/ComboBox) control that can be used in [Form](~/controls/bootstrap5/ComboBox).

See [ComboBox](~/controls/bootstrap5/ComboBox) for more info on how to use this control.

<https://getbootstrap.com/docs/5.2/forms/form-control>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ControlSizeAll`|String|Gets or sets the size of the control for all screen sizes.|attribute, static value||
|`ControlSizeLarge`|String|Gets or sets the size of the control for large screen sizes.|attribute, static value||
|`ControlSizeMedium`|String|Gets or sets the size of the control for medium screen sizes.|attribute, static value||
|`ControlSizeSmall`|String|Gets or sets the size of the control for small screen sizes.|attribute, static value||
|`ControlSizeXLarge`|String|Gets or sets the size of the control for extra large screen sizes.|attribute, static value||
|`ControlSizeXXLarge`|String|Gets or sets the size of the control for extra extra large screen sizes.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, static value, bindable||
|`EmptyItemText`|String|Text displayed when no value is selected.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable||
|`FormControlCssClass`|String|Gets or sets the CSS class to apply to the form control element.|attribute, static value||
|`FormControlType`|FormControlType?|Gets or sets the available form control type.|attribute, static value||
|`HelpContent`|List<DotvvmControl>|Gets or sets a custom template for for the help text. Cannot be combined with a `HelpText` property.|inner element, static value||
|`HelpText`|String|Gets or sets a plain text for the help text. Cannot be combined with a `HelpContent` property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`LabelContent`|List<DotvvmControl>|Gets or sets a custom template for for the control label. Cannot be combined with a `LabelText` property.|inner element, static value||
|`LabelSizeAll`|String|Gets or sets the size of the label for all screen sizes.|attribute, static value||
|`LabelSizeLarge`|String|Gets or sets the size of the label for large screen sizes.|attribute, static value||
|`LabelSizeMedium`|String|Gets or sets the size of the label for medium screen sizes.|attribute, static value||
|`LabelSizeSmall`|String|Gets or sets the size of the label for small screen sizes.|attribute, static value||
|`LabelSizeXLarge`|String|Gets or sets the size of the label for extra large screen sizes.|attribute, static value||
|`LabelSizeXXLarge`|String|Gets or sets the size of the label for extra extra large screen sizes.|attribute, static value||
|`LabelText`|String|Gets or sets a plain text for the control label. Cannot be combined with a `LabelContent` property.|attribute, static value, bindable||
|`LabelType`|LabelType?|Gets or sets the label type. Possible values are `Default` and `Floating`.|attribute, static value||
|`Layout`|FormControlLayout?|Gets or sets the form control layout. Possible values are `Default`, `Horizontal` and `Grid`.|attribute, static value||
|`RenderLabel`|Boolean?|Gets or sets whether the label is rendered.|attribute, static value||
|`SelectedValue`|IValueBinding<Object>|Gets or sets the value of the selected item.|attribute, bindable||
|`SelectMenuSize`|Int32|Gets or sets the size of the options menu.|attribute, static value, bindable||
|`Size`|Size?|Gets or sets the size of the label and form control elements.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|ICommandBinding|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Basic Usage

```DOTHTML
<bs:FormControlComboBox IsMultiple="true" 
                        DataSource="{value: Strings}" 
                        SelectedValue="{value: SelectedString}" 
                        LabelText="Basic" 
                        OptionCount="3" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<string> Strings { get; set; } = new List<string> { "one", "two", "three" };
    public string SelectedString { get; set; }
}
```

