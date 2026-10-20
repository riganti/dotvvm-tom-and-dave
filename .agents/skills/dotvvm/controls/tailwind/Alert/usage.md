# <t:Alert>
Renders contextual alert messages with semantic styles, optional headers, and dismiss support. The alert body can use plain text or custom child content.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets custom alert body content.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the custom content rendered in the alert header.|inner element, static value||
|`HeaderText`|String|Gets or sets the text displayed in the alert header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsDismissed`|Boolean|Controls whether a dismissible alert is currently hidden.|attribute, static value, bindable||
|`IsDismissible`|Boolean|Determines whether the alert renders a close button.|attribute, static value|False|
|`Text`|String|Gets or sets the alert message text.|attribute, static value, bindable||
|`Type`|([AlertType](../_enums/DotVVM.Controls.Tailwind.Controls.AlertType.md))|Selects the visual style of the alert.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Dismissed`|ICommandBinding|Command invoked when the close button is clicked.|

## Basic Alert

Shows a simple default alert with text message.


```DOTHTML
<t:Alert Text="This is a basic alert." />

```

## Alert types

Shows all available alert visual types: Default, Primary, Info, Success, Warning and Danger. Use these to communicate different levels of importance to the user.


```DOTHTML
<div class="flex flex-col gap-4">
    <t:Alert Type="Default" Text="Default alert" />
    <t:Alert Type="Primary" Text="This is a primary alert — check it out!" />
    <t:Alert Type="Info" Text="This is an info alert — check it out!" />
    <t:Alert Type="Success" Text="This is a success alert — check it out!" />
    <t:Alert Type="Warning" Text="This is a warning alert — check it out!" />
    <t:Alert Type="Danger" Text="This is a danger alert — check it out!" />
</div>


```

## Dismissible alert

An alert configured with `IsDismissible="true"`. The sample shows how to dismiss the alert and reset it via a button.


```DOTHTML
<div class="flex flex-col gap-4">
    <t:Alert Type="Info" Text="Click the × to dismiss this alert." IsDismissible="true" IsDismissed="{value: AlertDismissed}" Dismissed="{command: DismissAlert()}" />
    <t:Button Text="Reset" Click="{command: ResetAlert()}" Size="Small" />
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public bool AlertDismissed { get; set; } = false;

    public void DismissAlert()
    {
        AlertDismissed = true;
    }

    public void ResetAlert()
    {
        AlertDismissed = false;
    }
}

```

## Bindable alert type and text

Shows how to bind the `Type` of the alert to a ViewModel property and how to bind the alert `Text` to a TextBox value. Use the small buttons to change the alert type.


```DOTHTML
<div class="flex flex-col gap-4">
    <t:Alert Type="{value: SelectedAlertType}" Text="This alert type is bound to a property." />
    <div class="flex gap-2 flex-wrap">
        <t:Button Text="Default" Click="{command: SetAlertType(0)}" Size="Small" />
        <t:Button Text="Primary" Click="{command: SetAlertType(5)}" Size="Small" />
        <t:Button Text="Success" Click="{command: SetAlertType(1)}" Size="Small" />
        <t:Button Text="Info" Click="{command: SetAlertType(4)}" Size="Small" />
        <t:Button Text="Warning" Click="{command: SetAlertType(2)}" Size="Small" />
        <t:Button Text="Danger" Click="{command: SetAlertType(3)}" Size="Small" />
    </div>
</div>


```

```CSHARP
using DotVVM.Controls.Tailwind.Controls;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public AlertType SelectedAlertType { get; set; } = AlertType.Info;


    public void SetAlertType(int typeValue)
    {
        SelectedAlertType = (AlertType)typeValue;
    }
}

```

## Bindable Alert Text

Demonstrates binding the alert message text to a viewmodel property, allowing dynamic updates through a text input field.



```DOTHTML
<div class="flex flex-col gap-4">
    <t:Alert Type="Info" Text="{value: AlertMessage}" />
    <dot:TextBox Text="{value: AlertMessage}" placeholder="Type a message..." class="p-2 border border-gray-300 rounded-md" />
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public string AlertMessage { get; set; } = "This message can be edited!";
}


```

## Alert with Custom Content

Demonstrates using custom HTML and DotVVM controls inside the alert body instead of the Text property.



```DOTHTML
<div class="flex flex-col gap-4">
    <t:Alert Type="Success">
        <strong>Great success!</strong> This content is placed inside the alert tags instead of using the Text property.
    </t:Alert>
    <t:Alert Type="Warning">
        You can use <em>any HTML</em> or <strong>DotVVM controls</strong> inside the alert body.
    </t:Alert>
</div>


```

