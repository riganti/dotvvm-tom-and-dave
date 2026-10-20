# <bs:Alert>
Displays contextual feedback messages for users.

<https://getbootstrap.com/docs/3.3/javascript/#alerts>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDismissed`|Boolean|Gets or sets whether the alert has been dismissed by the user.|attribute, static value, bindable|False|
|`IsDismissible`|Boolean|Gets or sets whether a close icon should be displayed in the top right corner of the alert.|attribute, static value|False|
|`Text`|String|Gets or sets the text of the alert.|attribute, static value, bindable||
|`Type`|([AlertType](../_enums/DotVVM.Framework.Controls.Bootstrap.AlertType.md))|Gets or sets the type of the alert.|attribute, static value, bindable|Success|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Dismissed`|Action|Gets or sets the command that will be triggered when the alert is dismissed.|

## Sample 1: Basic Alert

The Alert control has the `Type` property which you can use to set the color of the alert message.

If you want to allow the user to hide the alert, use the `IsDismissible` property.

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
```

## Sample 2: Dismissible Alert

If you want to allow the user to hide the alert, use the `IsDismissible` property.
When `IsDismissible` property is set to true the close button will be rendered.

The `IsDismissed` property gets or sets if the Alert is dismissed.

The `Dismissed` event is called after the Alert is Dismissed.

```DOTHTML
<bs:Alert IsDismissible="true">
  Dismissable alert
</bs:Alert>

<bs:Alert IsDismissed="{value: Dismissed}" Dismissed="{command: AlertDismissed()}" Text="Click the button" />
<dot:Button Text="Show/Hide" Click="{command: Dismiss()}"/>
Dismissed: {{value: Dismissed}} <br/>
{{value: Text}}

```

```CSHARP
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Hosting;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool Dismissed { get; set; } = false;
        public string Text { get; set; }

        public void AlertDismissed()
        {
            Text = "Alert was hidden.";
        }

        public void Dismiss()
        {
            Dismissed = !Dismissed;
        }
    }
    
}
```

## Sample 3: Common Usage

The typical use of the `Alert` control is to have 2 properties in the viewmodel (`AlertText` and `AlertType`) which are bound to the properties of the `Alert` control.

Notice that the properties are marked with the `Bind` attribute setting the direction to `ServerToClient`. That's because we don't need to send the property values
to the server when we are making a postback. We only need to send the new value to the client if the properties are changed.


We suggest to put the `AlertText` and `AlertType` properties into the base viewmodel class and create a method which does this kind of exception handling.
Then, you can use it on all places, in your application.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample3.ViewModel, DotvvmWeb

<bs:Alert Text="{value: AlertText}" Type="{value: AlertType}" />

<bs:Button Text="Do Something" Click="{command: DoSomething()}"/>
```

```CSHARP
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Hosting;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample3
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls.Bootstrap;
using DotVVM.Framework.Hosting;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Alert.sample3
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
                // execute the action
                actionToExecute();

                AlertText = successText;
                AlertType = AlertType.Success;
            }
            catch (DotvvmInterruptRequestExecutionException)
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
}
```

