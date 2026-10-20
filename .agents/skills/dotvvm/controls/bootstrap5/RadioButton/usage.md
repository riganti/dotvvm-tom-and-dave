# <dot:RadioButton>
Extends the builtin [RadioButton](~/controls/builtin/RadioButton) control with Bootstrap CSS styles.

If you want to use this control inside [ButtonGroup](~/controls/bootstrap5/ButtonGroup), use [ButtonGroupRadioButton](~/controls/bootstrap5/ButtonGroupRadioButton) instead.

<https://getbootstrap.com/docs/5.2/forms/checks-radios>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ButtonFontType`|([ButtonTextColor](../_enums/DotVVM.Bootstrap5.ButtonTextColor.md))|Gets or sets the font color. Use this property in combination with a `Button` radio button visual style.|attribute, static value, bindable|Default|
|`ButtonSize`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the button size. Use this property in combination with a `Button` radio button visual style.|attribute, static value, bindable|Default|
|`ButtonType`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the button type. Use this property in combination with a `Button` radio button visual style.|attribute, static value, bindable|Primary|
|`ButtonVisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets the button visual style. Use this property in combination with a `Button` radio button visual style.|attribute, static value|SolidFill|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, static value, bindable||
|`CheckedItem`|IValueBinding<Object>|Gets or sets the checked item. Use this property in combination with the CheckedValue property.|attribute, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked. Use this property in combination with the CheckedItem property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable||
|`GroupName`|String|Gets or sets a unique name of the radio button group.|attribute, static value, bindable||
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

## Sample 1: Inline RadioButtons

The `IsInline` property allows to render checkboxes on one row.

Use the `RenderLabel` property to set whether the label should be rendered. 
If not set, the label will be rendered only when needed.

```DOTHTML
<bs:RadioButton Text="RadioButton 1" GroupName="RadioButtons" 
                CheckedValue="RadioButton 1" CheckedItem="{value: Radio}" 
                IsInline="true" />
<bs:RadioButton Text="RadioButton 2" GroupName="RadioButtons" 
                CheckedValue="RadioButton 2" CheckedItem="{value: Radio}"
                IsInline="true" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string Radio { get; set; }
}
```

## Sample 2: RadioButton VisualStyle

Except the `Default` radio button visual style, there are `Switch` and `Button` visual styles.

```DOTHTML
<h2>Button type</h2>
<bs:RadioButton CheckedValue="{value: true}" Checked="{value: Checked}" Text="Primary" VisualStyle="Button" ButtonType="Primary" IsInline="true" />
<bs:RadioButton CheckedValue="{value: false}" Checked="{value: Checked}" Text="Secondary" VisualStyle="Button" ButtonType="Secondary" IsInline="true" />
<bs:RadioButton CheckedValue="{value: false}" Checked="{value: Checked}" Text="Danger" VisualStyle="Button" ButtonType="Danger" IsInline="true" />
{{value: Checked}}
<hr/>

<h2>Switch type</h2>
<bs:RadioButton GroupName="RadioButton" VisualStyle="Switch" CheckedValue="true" Text="Switch RadioButton"/>
<hr/>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool Checked { get; set; }
}
```

