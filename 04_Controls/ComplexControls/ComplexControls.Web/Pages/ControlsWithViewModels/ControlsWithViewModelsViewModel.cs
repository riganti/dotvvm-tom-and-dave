using ComplexControls.Web.Controls;

namespace ComplexControls.Web.Pages.ControlsWithViewModels;

public class ControlsWithViewModelsViewModel : MasterPageViewModel
{
    public SearchViewModel SearchViewModel { get; set; } = new SearchViewModel();
}