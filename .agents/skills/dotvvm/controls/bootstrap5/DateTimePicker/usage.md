# <dot:DateTimePicker>
Renders an input control which lets the user either to type the date/time value, or select it from a calendar popup.

> In contrast to [Bootstrap for DotVVM](https://www.dotvvm.com/products/bootstrap-for-dotvvm) **3** and **4** where the control was a custom JavaScript-based implementation of the date/time picker experience, starting from version **5** the control is just a styled `<input type="datetime-local" />`.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the control is enabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxDate`|DateTime|Gets or sets a maximal date that can be selected.|attribute, static value, bindable||
|`MinDate`|DateTime|Gets or sets a minimal date that can be selected.|attribute, static value, bindable||
|`SelectedDate`|DateTime?|Gets or sets the date selected.|attribute, static value, bindable||
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the calendar input.|attribute, static value, bindable||
|`Title`|String|Gets or sets the title attribute value.|attribute, static value, bindable||
|`Type`|([DateTimePickerType](../_enums/DotVVM.Bootstrap5.Controls.DateTimePickerType.md))|Gets or sets the value type used in the picker.|attribute, static value|DateTime|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|ICommandBinding|Gets or sets the command that will be triggered when the control text is changed.|
|`TextInput`|ICommandBinding|Gets or sets the command that will be triggered when the user is typing in the field. Be careful when using this event - triggering frequent postbacks can make bad user experience. Consider using static commands or a throttling postback handler.|

## Sample 1: Basic Usage

Use the `Value` property to get or set the selected date.

The control shares some properties with a [TextBox](~/controls/bootstrap5/TextBox). You can change its size with a `Size` property and change the state with the `Enabled` property. Additionally, you can set a command when the input changes with the `TextInput` property.

Since the control is just a styled HTML `input` element, the culture of the calendar and the first day of week is specified by the browser configuration, not by the request culture on the server.

```DOTHTML
<bs:DateTimePicker SelectedDate="{value: SelectedValue}"
                   MinDate="{value: MinValue}"
                   MaxDate="{value: MaxValue}"
                   Size="{value: Size}"
                   Changed="{staticCommand: Counter = Counter+1}" />

<p>Date changed <b>{{value: Counter}}</b> times!</p>
<dot:Button Click="{command: ChangeSize()}">Change Size</dot:Button>
```

```CSHARP

public class ViewModel : DotvvmViewModelBase
{
    public Size Size { get; set; } = Size.Small;
    public DateTime SelectedValue { get; set; } = DateTime.UtcNow;
    public DateTime MinValue { get; set; } = DateTime.UtcNow.AddDays(-3);
    public DateTime MaxValue { get; set; } = DateTime.UtcNow.AddDays(3);
    public int Counter { get; set; } = 0;
    
    public ViewModel()
    {
    }

    public void ChangeSize()
    {
        if (Size == Size.Small)
        {
            Size = Size.Default;
        }
        else if (Size == Size.Default)
        {
            Size = Size.Large;
        }
        else if (Size == Size.Large)
        {
            Size = Size.Small;
        }
    }
}

```

