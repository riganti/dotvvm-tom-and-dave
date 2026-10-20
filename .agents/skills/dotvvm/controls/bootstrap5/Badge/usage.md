# <dot:Badge>
Renders a Bootstrap badge component.

<https://getbootstrap.com/docs/5.2/components/badge/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content inside the badge.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Type`|([BadgeColor](../_enums/DotVVM.Bootstrap5.Controls.BadgeColor.md))|Gets or sets the Bootstrap color of the badge.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([BadgeVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.BadgeVisualStyle.md))|Gets or sets the visual style of the badge.|attribute, static value|Default|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when the badge is clicked.|

## Sample 1: Basic Badge

Place the contents of the `Badge` inside the control, or use the `Text` property.

The `Type` property specifies the color category of the badge.

You can use the `VisualStyle` to specify, whether the badge should have a normal shape, or whether it should be rendered as a pill.

```DOTHTML
<bs:Badge Text="100"/>

<bs:Badge>
  <h1>9000+</h1>
</bs:Badge>

<bs:Badge Type="Primary" VisualStyle="Pill" />

```

## Sample 2: Badge in a Button

If you need to use the `Badge` inside the button, don't forget to set the `ButtonTagName` to `Button`.

Otherwise, the button would be rendered as `<input type="button">` which supports only a text values.

```DOTHTML
<bs:Button Click="{command: Increment()}" ButtonTagName="button">
  Number of clicks: <bs:Badge Text="{value: Clicks}"/>
</bs:Button>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public int Clicks { get; set; } = 0;

    public void Increment()
    {
        Clicks++;
    }
}

```

## Sample 3: Badge as Link or Button

The `Badge` control can work as a button.

* The `Click` event can be used to invoke a command in the viewmodel.

```DOTHTML
<bs:Badge Text="{value: Clicks + ' clicks'}" 
            Click="{command: Increment()}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public int Clicks { get; set; } = 0;

    public void Increment()
    {
        Clicks++;
    }
}

```

