using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace ComplexControls.Web.Controls;

public class SearchViewModel : DotvvmViewModelBase
{
    public List<string> Items {get; set;} = new List<string>
    {
        "Apple",
        "Banana",
        "Cherry",
        "Date",
        "Elderberry",
    };

    public string SearchText { get; set; } = string.Empty;
    public List<string> SearchResults { get; set; } = new List<string>();
    
    public async Task Search()
    {
        await Task.Delay(500); // Simulate a search operation

        SearchResults = Items.FindAll(item => item.Contains(SearchText, StringComparison.CurrentCultureIgnoreCase));
    }
}