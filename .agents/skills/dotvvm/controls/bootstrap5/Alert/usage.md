# <dot:Alert>
Displays contextual alert messages for users.

https://getbootstrap.com/docs/5.2/components/alerts/

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderContent`|List<DotvvmControl>|Gets or sets a custom template for the alert header.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for the alert header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsDismissed`|IValueBinding<Boolean>|Gets or sets a boolean binding whether the alert has been dismissed.|attribute, bindable||
|`IsDismissible`|Boolean|Gets or sets whether a close icon should be displayed in the top right corner of the alert.|attribute, static value|False|
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`Type`|([AlertType](../_enums/DotVVM.Bootstrap5.Controls.AlertType.md))|Gets or sets the type of the alert. Possible values are Primary, Secondary, Success, Danger, Warning, Info, Light and Dark.|attribute, static value, bindable|Primary|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Dismissed`|ICommandBinding|Gets or sets the command that will be triggered when the alert is dismissed.|

## Sample 1: Basic Alert

The Alert control has the `Type` property which you can use to set the color of the alert message.

```DOTHTML
<bs:Alert Type="Success">
  Alert: type Success
</bs:Alert>

<bs:Alert Type="Danger">
  Alert: type Danger
</bs:Alert>

<bs:Alert Type="Info">
  Alert: type Info
</bs:Alert>

<bs:Alert Type="Warning">
  Alert: type Warning
</bs:Alert>

<bs:Alert Type="{value: Type}" Text="Bindable type"/>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public AlertType Type { get; set; } = AlertType.Dark;
}

```

## Sample 2: Dismissible Alert

If you want to allow the user to hide the alert, use the `IsDismissible` property. When `IsDismissible` property is set to true, a close button will be rendered.

The `IsDismissed` property gets or sets if the alert is dismissed. You can use data-binding on it to determine whether the user has dismissed the alert or not.

The `Dismissed` event is called after the alert is dismissed.

```DOTHTML
<bs:Alert IsDismissible="true">
  Dismissable alert
</bs:Alert>

<bs:Alert IsDismissed="{value: Dismissed}" 
          IsDismissible="true"
          Dismissed="{command: AlertDismissed()}" 
          Text="Click the button" />

<dot:Button Text="Show/Hide" Click="{command: Dismiss()}"/>
<p>
    Dismissed: {{value: Dismissed}}
</p>
<p>{{value: Text}}</p>

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool Dismissed { get; set; } = false;

    public string Text { get; set; }

    public void AlertDismissed()
    {
        Text = "The alert was dismissed.";
    }

    public void Dismiss()
    {
        Dismissed = !Dismissed;
    }
}

```

## Sample 3: Common Usage

The typical use of the `Alert` control is to have two properties in the viewmodel (`AlertText` and `AlertType`) which are bound to the properties of the `Alert` control.

Notice that the properties are marked with the `Bind` attribute setting the direction to `ServerToClient`. That's because we don't need to send the property values
to the server when we are making a postback. We only need to send the new value to the client if the properties are changed.

We suggest to put the `AlertText` and `AlertType` properties into the viewmodel of the master page and create a method which does some kind of exception handling.
Then, you can use it on all places, in your application.

```DOTHTML
@viewModel Dotvvm.Samples.Alert.sample3.ViewModel, Dotvvm.Samples

<!-- the alert is somewhere in master page -->
<bs:Alert Text="{value: AlertText}" Type="{value: AlertType}" />

<!-- content page -->
<bs:Button Text="Do Something" Click="{command: DoSomething()}"/>
```

```CSHARP
public class ViewModel : MyViewModelBase
{
    
    public void DoSomething()
    {
        ExecuteWithAlert(() =>
        {
            // the action
        });
    }
}
```

```CSHARP
public class MyViewModelBase : DotvvmViewModelBase
{

    [Bind(Direction.ServerToClient)]
    public string AlertText { get; set; }

    [Bind(Direction.ServerToClient)]
    public AlertType AlertType { get; set; }


    /// <summary>
    /// Executes the specified action and sets the appropriate alert messages.
    /// </summary>
    protected void ExecuteWithAlert(Action actionToExecute, 
        string successText = "The operation was successful.", 
        string errorText = "Sorry, an unexpected error has occurred.")
    {
        try
        {
            // execute the action
            actionToExecute();

            AlertText = successText;
            AlertType = AlertType.Success;
        }
        catch (DotVVM.Framework.Hosting.DotvvmInterruptRequestExecutionException)
        {
            // this exception is used for redirecting - don't catch it
            throw;
        }
        catch (Exception)
        {
            AlertText = errorText;
            AlertType = AlertType.Danger;
        }
    }

}
```

## Sample 4: Text and Header Text

Alert containes two options for text. First option is property `Text` and the second is propery `HeaderText`. Both property are not required, but if users set both to null or empty string, than, by default, is alert hidden. User can override this behaviou by setting property `Visible`.

```DOTHTML
<bs:Alert Type="Success" Text="{value: AdvancedText}" HeaderText="{value: AdvancedHeader}" />

<dot:button Click="{command: AdvancedHeader = null}">Set Header to null </dot:button>
<dot:button Click="{command: AdvancedHeader = "Changed Advanced Header"}">Set Header to text </dot:button>
<dot:button Click="{command: AdvancedText = null}">Set Text to null </dot:button>
<dot:button Click="{command: AdvancedText = "Changed Advanced Text"}">Set Text to text </dot:button>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string? AdvancedHeader { get; set; } = "Advanced Header";
    public string? AdvancedText { get; set; } = "Advanced Text";
}
```

