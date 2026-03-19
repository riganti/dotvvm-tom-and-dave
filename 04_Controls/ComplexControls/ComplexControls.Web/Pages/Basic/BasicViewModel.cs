using ComplexControls.Web.Pages;

namespace ComplexControls.Web.ViewModels;
public class BasicViewModel : MasterPageViewModel
{
    public string Title { get; set; }
    public bool IsChecked1 { get; set; }
    public bool IsChecked2 { get; set; }

    public BasicViewModel()
    {
        Title = "Hello from DotVVM!";
    }

    public void ClickButton()
    {
        Title = "You clicked the button!";
    }

    public void ClickCheckbox1()
    {
        Title = IsChecked1 ? "Checkbox is checked!" : "Checkbox is unchecked!";
    }

    public void ClickCheckbox2()
    {
        Title = IsChecked2 ? "Checkbox is checked!" : "Checkbox is unchecked!";
    }
}
