namespace ComplexControls.Web.Pages.MarkupControls;

public class MarkupControlsViewModel : MasterPageViewModel
{
    public Address Address { get; set; } = new Address();

    public string UserName { get; set; } = "John Doe";
    public string UserEmail { get; set; } = "john.doe@example.com";
}

public class Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public bool IsHuman { get; set; }
}