# <bp:MessagingConnection>
Establishes a connection to a SignalR hub and allows specifying handlers for client-side hub methods.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ConnectionId`|String|Gets or sets a unique ID of the connection. You can use this ID in _messaging.GetConnection() method in static commands, or to assign stand-alone MessageHandlers to this connection.             Make sure that the connection ID is unique in the page.             If the property value is not specified, the ID will be generated automatically.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsConnected`|Boolean|Gets or sets whether the hub is connected.|attribute, bindable|False|
|`MessageHandlers`|List<MessageHandler>|Gets or sets a collection of message handlers. Use this collection to specify handlers for various hub methods.|inner element, static value, bindable, default property||
|`ReconnectAttempts`|Int32|Gets or sets the maximum number of attempts to reconnect to the hub.|attribute, static value|30|
|`ReconnectTimeout`|Int32|Gets or sets the timeout in seconds for establishing the connection to the hub.|attribute, static value|30|
|`ServiceUrl`|String|Gets or sets the URL of the SignalR hub.|attribute, static value, bindable||
|`TryReconnect`|Boolean|Gets or sets whether the control should try to reconnect when the connection is lost.|attribute, static value|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Connected`|ICommandBinding|Gets or sets a command that will be triggered when the connection is established.|
|`Disconnected`|ICommandBinding|Gets or sets a command that will be triggered when the hub connection is lost and will not be retried (when TryReconnect is false or when the number of attempts reached the value of the ReconnectAttempts property).|
|`Error`|ICommandBinding|Gets or sets a command that will be triggered when a communication error occurs.|
|`Reconnecting`|ICommandBinding|Gets or sets a command that will be triggered when the hub connection is lost and will be retried.|

## Sample 1: Basic connection

To establish a connection to a SignalR hub, place the `MessagingConnection` control in the page and specify the URL of the hub.

You can use the `IsConnected` property to detect whether the connection is active or not.

You can define one or more [MessageHandler](./MessageHandler) controls to run commands when  methods are called on the hub.

The `MessageHandler` controls can be defined:

* Inside this `MessagingConnection` control. See [MessageHandler - Sample 1](./MessageHandler#sample1)] for more info.

* Outside this control. In this case, you need to set the `ConnectionId` property on both `MessagingConnection` and `MessageHandler` controls to the same value. See [MessageHandler - Sample 2](./MessageHandler#sample2)] for more info.


```DOTHTML
<bp:MessagingConnection ServiceUrl="/hubs/Chat" 
                        IsConnected="{value: IsConnected}">
    ...
</bp:MessagingConnection>
```

```CSHARP
public class SampleViewModel : DotvvmViewModelBase
{
    public bool IsConnected { get; set; }
}
```

## Sample 2: Connection events

To handle various connection lifecycle events, you can bind to the `Connected` and `Disconnected` events, and also to `Reconnecting` and `Reconnected` events.

The `Error` event will be triggered whenever there is an error (connecting to the hub, sending a message). Since any error means that the connection is broken, this event is typically accompanied by one of the other events. 

> It is recommended to use [static commands](~/pages/concepts/respond-to-user-actions/static-commands) since the events may be fired in a quick sequence.

```DOTHTML
<bp:MessagingConnection ServiceUrl="/hubs/Chat" 
                        Connected="{staticCommand: Events.Add("Connected")}" 
                        Disconnected="{staticCommand: Events.Add("Disconnected")}" 
                        Reconnecting="{staticCommand: Events.Add("Reconnecting")}" 
                        Reconnected="{staticCommand: Events.Add("Reconnected")}" 
                        Error="{staticCommand: Events.Add("Error")}"> 
    ...
</bp:MessagingConnection>
```

```CSHARP
public class SampleViewModel : DotvvmViewModelBase
{
    public List<string> Events { get; set; } = new();
}
```

## Sample 3: Reconnect settings

The `MessagingConnection` control has the `TryReconnect` property which specifies whether the control should try to reconnect automatically when the connection is lost.

The `ReconnectTimeout` property specifies the number of seconds after which the reconnect will be performed (default is 30 seconds). 

The `ReconnectAttempts` property can be used to restrict the number of attempts for reconnection (default is 30 attempts, 0 means that the reconnects will be attempted infinitely).

```DOTHTML
<bp:MessagingConnection ServiceUrl="/hubs/Chat" 
                        TryReconnect="true" 
                        ReconnectAttempts="0" 
                        ReconnectTimeout="5"> 
    ...
</bp:MessagingConnection>
```

## Sample 4: Send messages to the hub

You can call hub methods on the server by using the `_messaging` variable in the [static commands](~/pages/concepts/respond-to-user-actions/static-commands) bindings.

In order to reference the connection which you want to send the message, you need to set the `ConnectionId` of the `MessagingConnection` control to some value. Then, you can use this id in the binding.

```DOTHTML
<bp:MessagingConnection ServiceUrl="/hubs/Chat" 
                        ConnectionId="Chat">
    <bp:MessageHandler MethodName="IncomingMessage" 
                       Command="{staticCommand: (ChatMessageDTO o) => Messages.Add(o)}" />
</bp:MessagingConnection>

<dot:Repeater DataSource="{value: Messages}" WrapperTagName="ul"> 
    <li>{{value: Author}}: {{value: Text}}</li>
</dot:Repeater>

<form>
    <dot:TextBox Text="{value: AutorName}" />: 
    <dot:TextBox Text="{value: NewMessage}" /> 
    <dot:Button Text="Send" 
                IsSubmitButton="true" 
                Click="{staticCommand: _messaging.GetConnection("Chat").InvokeAsync("SendMessage", AuthorName, NewMessage)}" />
</form>
```

```CSHARP
public class SampleViewModel : DotvvmViewModelBase
{
    public List<ChatMessageDTO> Messages { get; set; } = new();

    public string AutorName { get; set; } = "user";

    public string NewMessage { get; set; }
}

public class ChatMessageDTO 
{
    public string Text { get; set; }
    public string Author { get; set; }
}
```

```CSHARP
public class ChatHub : Hub 
{

    public async Task SendMessage(string autor, string text) 
    {
        await this.Clients.AllExcept(Context.ConnectionId)
            .SendAsync("IncomingMessage", new ChatMessageDTO() { Author = author, Text = text });
    }

}
```

