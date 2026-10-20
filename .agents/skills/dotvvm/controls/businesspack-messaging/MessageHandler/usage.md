# <bp:MessageHandler>
Defines a handler for a client-side method call in the SignalR hub.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ConnectionId`|String|Gets or sets the ConnectionId of MessagingConnection to which this handler will be bound.             Use this method only if the MessageHandler is not placed in the MessagingConnection element.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MethodName`|String|Gets or sets the name of the hub method.|attribute, static value||

## Events
|Name|Type|Description|
|---|---|---|
|`Command`|ICommandBinding|Gets or sets the command that will be triggered when a hub method is called.             To access the parameters, please define the command as a lambda method - for example: (int number) => Value = Value + number|

## Sample 1: MessageHandler inside MessagingConnection

You can define handlers for individual methods inside the [MessagingConnection](./MessagingConnection) control. 

Use the `MethodName` property to specify the name of the method on the client hub   (case-sensitive).

The `Command` property defines the command which will be triggered when the client method is called from the server. 

> Make sure the command is a lambda function with correct argument types. DotVVM has no way of checking the type safety on this place. 

To send message in the hub, you can use the following code snippet (in the server-side code):

```CSHARP
public async Task SendMessage(IHubContext<ChatHub> chatHub, ChatMessageDTO message) 
{
    await chatHub.Clients.All.SendAsync("IncomingMessage", message);
}
```

```DOTHTML
<bp:MessagingConnection ServiceUrl="/hubs/Chat">

    <bp:MessageHandler MethodName="IncomingMessage" 
                       Command="{staticCommand: (ChatMessageDTO o) => Messages.Add(o)}" />

</bp:MessagingConnection>
```

```CSHARP
public class SampleViewModel : DotvvmViewModelBase
{
    public List<ChatMessageDTO> Messages { get; set; } = new();
}

public class ChatMessageDTO 
{
    public string Text { get; set; }
}
```

## Sample 1: MessageHandler inside MessagingConnection

Sometimes, the [MessagingConnection](./MessagingConnection) control is defined on some other place (for example in the master page), so it is not possible to place the `MessageHandler` inside.

You can define `ConnectionId` property on both `MessagingConnection` and `MessageHandler` controls which will bind these two controls together.


```DOTHTML
<bp:MessagingConnection ServiceUrl="/hubs/Chat" 
                        ConnectionId="Chat" />

...

<bp:MessageHandler MethodName="IncomingMessage" 
                   ConnectionId="Chat" 
                   Command="{staticCommand: (ChatMessageDTO o) => Messages.Add(o)}" />

```

```CSHARP
public class SampleViewModel : DotvvmViewModelBase
{
    public List<ChatMessageDTO> Messages { get; set; } = new();
}

public class ChatMessageDTO 
{
    public string Text { get; set; }
}
```

