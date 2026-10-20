# <dot:TextBox>
Extends the built-in TextBox control to allow applying Bootstrap CSS classes.

<https://getbootstrap.com/docs/5.2/forms/form-control/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`FormatString`|String|Gets or sets a format of presentation of value to client.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`SelectAllOnFocus`|Boolean|Gets or sets whether all text inside the TextBox becomes selected when the element gets focused.|attribute, static value, bindable|False|
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the TextBox.|attribute, static value, bindable|Default|
|`Text`|Object|Gets or sets the text in the control.|attribute, static value, bindable||
|`Type`|([TextBoxType](../../builtin/_enums/DotVVM.Framework.Controls.TextBoxType.md))|Gets or sets the mode of the text field (input/textarea and its type attribute)|attribute, static value|Normal|
|`UpdateTextOnInput`|Boolean|Gets or sets whether the viewmodel property will be updated immediately after change.              By default, the viewmodel is updated after the control loses its focus.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command|Gets or sets the command that will be triggered when the onchange event is fired.|
|`TextInput`|Command|Gets or sets the command that will be triggered when the user is typing in the field.             Be careful when using this event - triggering frequent postbacks can make bad user experience. Consider using static commands or a throttling postback handler.|

## Sample 1: TextBox Sizing

Use the `Size` property to set the size of the TextBox.

```DOTHTML
<bs:TextBox Size="Small" Text="{value: Text}" />

<bs:TextBox Size="Default" Text="{value: Text}" />

<bs:TextBox Size="Large" Text="{value: Text}" />

```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.bootstrap5.TextBox.sample1
{
    public class ViewModel
    {
        public string Text { get; set; } = "DotVVM";
    }
}
```

## Sample 2: TextBox Type

Use the `Type` property to set the type of the TextBox.

```DOTHTML
<bs:TextBox Type="Normal" Text="Normal textbox"/>

<bs:TextBox Type="Password" Text="Password"/>

<bs:TextBox Type="Multiline" Text="Multiline textbox"/>

<bs:TextBox Type="Color" Text="Color textbox"/>

<bs:TextBox Type="Date" Text="Date textbox"/>

```

## Sample 3: TextBox Update Text on Input

Use `UpdateTextOnInput` to set wheter viewmodel property will be updated. Set True to update immediately or set False to update on focus loose.

```DOTHTML
<bs:TextBox  Text="{value: Text}"  UpdateTextOnInput="true" />

<bs:TextBox  Text="{value: Text}"  UpdateTextOnInput="false" />

<p>{{value: Text}}</p>

```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.bootstrap5.TextBox.sample1
{
    public class ViewModel
    {
        public string Text { get; set; } = "DotVVM";
    }
}
```

