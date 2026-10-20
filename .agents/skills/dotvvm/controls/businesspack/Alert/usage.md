# <bp:Alert>
Renders an alert message of a specified type. It can be used to indicate errors, warnings, info or success messages.

The user can dismiss it by clicking an icon. The alert can be also hidden after a specified timeout.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowDismiss`|Boolean||attribute, static value, bindable|False|
|`AutoHideTimeout`|Double||attribute, static value, bindable|0|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate||inner element, static value, bindable, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DisableContentStyle`|Boolean||attribute, static value, bindable|False|
|`DismissIcon`|IconBase||inner element, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsDisplayed`|Boolean||attribute, bindable|True|
|`ShowDefaultIcon`|Boolean||attribute, static value, bindable|True|
|`Text`|String||attribute, static value, bindable||
|`Type`|AlertType||attribute, static value, bindable|Success|
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Dismissed`|Command||

## Sample 1: Alert Types

The `Type` of the alert can be `Success`, `Info`, `Warning` and `Danger`. An icon symbolizing the alert type is displayed on the left side by default. You can set the `ShowDefaultIcon` property to `false` if you want to hide the default icons.

Use the `Text` property to specify the text. Alternatively, you can place any content inside the `Alert` control.

```DOTHTML
<bp:Alert Type="Success" Text="Plain text success alert" />

<bp:Alert Type="Danger" ShowDefaultIcon="false">
    Danger alert with <a href="#">hyperlinks</a>
    <br />
    and custom content
</bp:Alert>
```

## Sample 2: Dismiss

The `AllowDismiss` property will add an icon to the right side of the alert, allowing the user to hide the alert. The `Dismissed` command is triggered when the alert is hidden by user.

The `DismissIcon` can be used to specify custom dismiss icon.

You can also use the `AutoHideTimeout` property  to hide the alert automatically after being displayed for specified number of seconds. The `Dismissed` command is not triggered in this case.

```DOTHTML
<bp:Alert Type="Warning"
          AllowDismiss="true"
          Dismissed="{command: Dismissed()}"
          Text="This alert can be dismissed." />

<bp:Alert Type="Danger"
          AllowDismiss="true"
          Text="This alert can be dismissed and uses a custom dismiss icon.">
    <DismissIcon>
        <bp:Icon Icon="Trash" />
    </DismissIcon>
</bp:Alert>
          
<bp:Alert Type="Info"
          AutoHideTimeout="5"
          Text="This alert will hide automatically." />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public void Dismissed()
        {
            // handle the dismissed command
        }
    }
}
```

## Sample 3: Display State

You can use the `IsDisplayed` property to determine or specify, whether the alert is displayed.

If you set this property to `true`, the alert will be displayed. When the alert is hidden, the property will be switched to `false`.

If the `IsDisplayed` property is not set, the alert is displayed whenever the `Text` is not `null` or empty.

```DOTHTML
<bp:Alert Type="Warning"
          IsDisplayed="{value: IsDisplayed}"
          AllowDismiss="true"
          Text="Warning" />

<bp:Alert Type="Danger"
          AllowDismiss="true"
          Text="{value: ErrorMessage}" />

<bp:CheckBox Text="Is warning displayed"
             Checked="{value: IsDisplayed}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsDisplayed { get; set; }

        public string ErrorMessage { get; set; }
    }
}
```

## Sample 4: Common Usage

The typical use of the `Alert` control is to have 2 properties in the viewmodel (`AlertText` and `AlertType`) which are bound to the properties of the `Alert` control.

Notice that the properties are marked with the `Bind` attribute setting the direction to `ServerToClient`. That's because we don't need to send the property values to the server when we are making a postback. We only need to send the new value to the client if the properties are changed.

We suggest to put the `AlertText` and `AlertType` properties into the base viewmodel class and create a method which does this kind of exception handling. Then you can use it on all places in your application.

```DOTHTML
<bp:Alert Text="{value: AlertText}" Type="{value: AlertType}" />

<bp:Button Text="Do Something" Click="{command: DoSomething()}" />
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample4
{
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
    
}
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.BusinessPack.Controls;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Alert.sample4
{
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
                actionToExecute();

                AlertText = successText;
                AlertType = AlertType.Success;
            }
            catch (Exception ex) when (!(ex is DotvvmInterruptRequestExecutionException))
            {
                AlertText = errorText;
                AlertType = AlertType.Danger;
            }
        }
    }
}
```

