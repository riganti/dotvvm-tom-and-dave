# Documentation

## Project Overview

This project demonstrates the use of static commands in DotVVM.

### What are Static Commands?

Static commands are a special type of command in DotVVM that execute on the client side without making a full round trip to the server.

### Benefits

- **Performance**: Faster execution since no server round trip is needed
- **Offline capability**: Can work without server connection
- **Better UX**: Instant feedback to user actions

### Usage

```csharp
<dot:Button Text="Click Me" Click="{staticCommand: SomeMethod()}" />
```

## Learn More

Visit [DotVVM.com](https://www.dotvvm.com) for more information.
