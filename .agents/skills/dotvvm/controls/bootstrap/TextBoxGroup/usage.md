# <bs:TextBoxGroup>
Represents a group of Label and TextBox in the Form control.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
|`FormContent`|List<DotvvmControl>|Gets or sets the content of the form group.|inner element, static value, bindable, default property||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LabelTemplate`|ITemplate|Gets or sets the template of the label area. This property cannot be combined with the LabelText property.|inner element, static value||
|`LabelText`|String|Gets or sets the label text. This property cannot be combined with the LabelTemplate property.|attribute, static value, bindable||
|`RenderContentContainers`|Boolean|Gets or sets whether an additional container will be rendered around the content.|attribute, static value|True|
|`Text`|Object|Gets or sets the text in the TextBox.|attribute, static value, bindable||
|`Type`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))|Gets or sets the mode of the text field.|attribute, static value|Normal|
|`UpdateTextAfterKeydown`|Boolean|Gets or sets whether the viewmodel property will be updated after the key is pressed.             By default, the viewmodel is updated after the control loses its focus.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the control state is changed.|

## Sample 1: Basic Text Box Group

The `TextBoxGroup` control has the `LabelText` property for the label and the `Text` property for text inside the text field.

Both these properties can also be bound to properties in viewmodel.


```DOTHTML
<bs:Form>
    <bs:TextBoxGroup LabelText="Static label" Text="Static value" />

    <bs:TextBoxGroup LabelText="{value: LabelText}" Text="{value: ValueText}" />

    <bs:TextBoxGroup LabelText="No value" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TextBoxGroup.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LabelText { get; set; } = "Data-bound label";
        public string ValueText { get; set; } = "Data-bound value";
    }
}
```

## Sample 2: Text Box Group - Enabled and Visible

The `Enabled` property is used to enable / disable the `TextBoxGroup` control.

It is also possible to show / hide the `TextBoxGroup` control with the `Visible` property.

```DOTHTML
<bs:Form>
    <bs:TextBoxGroup LabelText="Label" Text="Enabled textbox" Enabled="true" />

    <bs:TextBoxGroup LabelText="Label" Text="Disabled textbox" Enabled="false" />

    <bs:TextBoxGroup LabelText="Label" Text="Visible textbox" Visible="{value: TrueValue}" />

    <bs:TextBoxGroup LabelText="Label" Text="Invisible textbox" Visible="{value: FalseValue}" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TextBoxGroup.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool TrueValue { get; set; } = true;
        public bool FalseValue { get; set; } = false;
    }
}
```

## Sample 3: Text Box Group - Format String

The content of TextBox can be formatted with the `FormatString` property if needed.

```DOTHTML
<bs:Form>
    <bs:TextBoxGroup LabelText="Formatting string" Text="{value: NumberValue}" FormatString="#0.00" />
</bs:Form>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TextBoxGroup.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double NumberValue { get; set; } = 123.456789;
    }
}
```

## Sample 4: Text Box Group - Type

The `Type` property is used to change the mode of the text field. Possible values are:

+ `Normal`
+ `Password`
+ `MultiLine`
+ `Telephone`
+ `Url`
+ `Email`
+ `Date`
+ `Time`
+ `Color`
+ `Search`
+ `Number`


```DOTHTML
<bs:Form>
    <bs:TextBoxGroup LabelText="Password box" Text="password" Type="Password" />

    <bs:TextBoxGroup LabelText="Numeric value" Text="0" />
</bs:Form>
```

## Sample 5: Text Box Group - UpdateTextAfterKeydown and Changed

If you need property bound to `Text` property to update after every pressed key just set the `UpdateTextAfterKeydown` property to *true*.

With the `Changed` property it is possible to bind to `onchange` event and perform specific actions when the value of text field changes.


```DOTHTML
<bs:Form>
    <bs:TextBoxGroup LabelText="Update test" Text="{value: UpdateTestText}" UpdateTextAfterKeydown="true" />

    <bs:TextBoxGroup LabelText="OnChanged test" Text="{value: ChangedTestText}" Changed="{command: Changed()}" />
</bs:Form>

<span>{{value: UpdateTestText}}</span>
<br />
<span>{{value: ChangedValue}}</span>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.TextBoxGroup.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string UpdateTestText { get; set; } = "Change this";
        public string ChangedValue { get; set; } = "Not changed";
        public string ChangedTestText { get; set; } = "text";

        public void Changed()
        {
            ChangedValue = "Changed to " + ChangedTestText;
        }
    }
}
```

