# Code Examples

## Example 1: Data Binding

```csharp
public class PersonViewModel : DotvvmViewModelBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
```

## Example 2: Collections

```csharp
public class ProductListViewModel : DotvvmViewModelBase
{
    public List<Product> Products { get; set; }
    
    public void LoadProducts()
    {
        Products = productService.GetAll();
    }
}
```

## Example 3: Validation

```csharp
public class FormViewModel : DotvvmViewModelBase
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
}
```

Try these examples in your own projects!
