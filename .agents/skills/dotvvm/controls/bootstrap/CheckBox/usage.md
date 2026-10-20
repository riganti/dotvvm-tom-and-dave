# <bs:CheckBox>
Extends the builtin [CheckBox](~/controls/builtin/CheckBox) control with an option to set Bootstrap CSS classes and support of the [ButtonGroup](~/controls/bootstrap/ButtonGroup). 

<https://getbootstrap.com/docs/3.3/css/#forms-controls>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Checked`|Boolean?|Gets or sets whether the control is checked.|attribute, bindable||
|`CheckedItems`|IEnumerable|Gets or sets a collection of values of all checked checkboxes. Use this property in combination with the CheckedValue property.|attribute, static value, bindable||
|`CheckedValue`|Object|Gets or sets the value that will be used as a result when the control is checked.             Use this property in combination with the CheckedItem or CheckedItems property.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DisableIndeterminate`|Boolean|When set to true, `null` in the Checked property will be treated as `false`, instead of marking the checkbox as indeterminate|attribute, static value, bindable|False|
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be clicked on.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`InputCssClass`|String|Gets or sets a CSS class that will be appended on the rendered input element.|attribute, static value||
|`IsInline`|Boolean|Gets or sets whether there will be more checkboxes on the same line. When this property is true, the checkbox gets the Boostrap "inline" CSS class.|attribute, static value, bindable|False|
|`ItemKeyBinding`|IValueBinding|Gets or sets a property that retrieves an unique key for the CheckedValue so it can be compared with objects in the CheckedItems collection. This property must be set if the value of the CheckedValue property is not a primitive type.|attribute, bindable||
|`LabelCssClass`|String|Gets or sets a CSS class that will be appended on the rendered label element.|attribute, static value||
|`Text`|String|Gets or sets the label text that is rendered next to the control.|attribute, static value, bindable||
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap.BootstrapColor.md))|Gets or sets the Bootstrap color.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control check state is changed.|

## Sample 1: Inline CheckBoxes

The `IsInline` property allows to render checkboxes on one row.

If the `CheckBox`es are placed inside the [ButtonGroup](~/controls/bootstrap/ButtonGroup) control, they are set to inline by default so you don't have to change anything.

```DOTHTML
<bs:CheckBox Text="CheckBox 1" Checked="{value: Checked1}" IsInline="true" />
<bs:CheckBox Text="CheckBox 2" Checked="{value: Checked2}" IsInline="true"/>

<p>CheckBox 1: {{value: Checked1}}</p>
<p>CheckBox 2: {{value: Checked2}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.CheckBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Checked1 { get; set; }
        public bool Checked2 { get; set; }
    }
}
```

## Sample 2: CheckBox in ButtonGroup

You can change the color of the `CheckBox` using the `Type` property.

This property works only inside the [ButtonGroup](~/controls/bootstrap/ButtonGroup) control.  

```DOTHTML
<bs:ButtonGroup>
  <bs:CheckBox Checked="{value: Checked1}" Text="CheckBox - Primary" Type="Primary" />
</bs:ButtonGroup>
<bs:ButtonGroup>
  <bs:CheckBox Checked="{value: Checked2}" Text="CheckBox - Success" Type="Success" />
</bs:ButtonGroup>
<bs:ButtonGroup>
  <bs:CheckBox Checked="{value: Checked3}" Text="CheckBox - Info" Type="Info" />
</bs:ButtonGroup>
<bs:ButtonGroup>
  <bs:CheckBox Checked="{value: Checked4}" Text="CheckBox - Warning" Type="Warning" />
</bs:ButtonGroup>
<bs:ButtonGroup>
  <bs:CheckBox Checked="{value: Checked5}" Text="CheckBox - Danger" Type="Danger" />
</bs:ButtonGroup>

<p>CheckBox - Primary: {{value: Checked1}}</p>
<p>CheckBox - Success: {{value: Checked2}}</p>
<p>CheckBox - Info: {{value: Checked3}}</p>
<p>CheckBox - Warning: {{value: Checked4}}</p>
<p>CheckBox - Danger: {{value: Checked5}}</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.CheckBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Checked1 { get; set; }
        public bool Checked2 { get; set; }
        public bool Checked3 { get; set; }
        public bool Checked4 { get; set; }
        public bool Checked5 { get; set; }
    }
}
```

