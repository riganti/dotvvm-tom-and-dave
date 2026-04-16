using DotVVM.Framework.ViewModel;

namespace TailwindApp.Web.Pages;
public class MasterPageViewModel : DotvvmViewModelBase
{
    public string Title { get; set; } = "Overview";

    public string UserInitials { get; set; } = "AC";
}