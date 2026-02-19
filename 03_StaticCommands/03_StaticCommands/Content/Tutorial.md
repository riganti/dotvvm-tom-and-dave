# Tutorial: Building with DotVVM

## Step 1: Create Your ViewModel

Start by creating a view model that inherits from `DotvvmViewModelBase`:

```csharp
public class MyViewModel : DotvvmViewModelBase
{
    public string Message { get; set; } = "Hello, World!";
}
```

## Step 2: Create Your View

Create a `.dothtml` file with your markup:

```html
@viewModel MyApp.ViewModels.MyViewModel
<h1>{{value: Message}}</h1>
```

## Step 3: Add Interactivity

Use commands to handle user interactions:

```html
<dot:Button Text="Click Me" Click="{command: HandleClick()}" />
```

## Step 4: Test Your Application

Run your application and see it in action!

Happy coding!
