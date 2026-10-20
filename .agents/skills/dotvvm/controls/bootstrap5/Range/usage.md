# <dot:Range>
Renders the Bootstrap range form control.

<https://getbootstrap.com/docs/5.2/forms/range/#>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxValue`|Double|Gets or sets the end point of the scale.|attribute, static value, bindable|100|
|`MinValue`|Double|Gets or sets the start point of the scale.|attribute, static value, bindable|0|
|`SelectedValue`|Double|Gets or sets the value selected by the user.|attribute, static value, bindable|0|
|`Step`|Double|Gets or sets the size of the step which defines the difference between selectable values.|attribute, static value, bindable|1|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Gets or sets the command that triggers when the user finishes changing the value.|

## Sample 1: Basic Range

The `MinValue` and `MaxValue` properties specify the boundaries for selected values.

The `Step` property defines the difference between selectable values.

The `SelectedValue` property contains a binding to a viewmodel property with value selected in the range control.

```DOTHTML
<bs:Range MinValue="0" MaxValue="2000" Step="10" 
          SelectedValue="{value: Value}" />

{{value: Value}}
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public double Value { get; set; } = 1000;
}

```

## Sample 2: Range Changes

The `Changed` event occurs when the user changes the selected value.

The `Enabled` property can be used to enable and disable the control.

```DOTHTML
<bs:Range MinValue="0" MaxValue="2000" Step="10" 
          SelectedValue="{value: Value}"
          Changed="{command: ValueChanges = ValueChanges + 1}"
          Enabled="{value: Enabled}" />

<p>Value: {{value: Value}}</p>
<p>Number of changes: {{value: ValueChanges}}</p>

<p><bs:CheckBox Text="Allow changes" Checked="{value: Enabled}" /></p>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public double Value { get; set; } = 1000;
    public int ValueChanges { get; set; } = 0;
    public bool Enabled { get; set; } = true;
}

```

