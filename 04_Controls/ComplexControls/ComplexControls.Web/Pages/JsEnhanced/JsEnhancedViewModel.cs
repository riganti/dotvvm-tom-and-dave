using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplexControls.Web.Pages.JsEnhanced;

public class JsEnhancedViewModel : MasterPageViewModel
{
    public List<string> Items { get; set; } = new List<string>();

    public override async Task PreRender()
    {
        if (!Context.IsPostBack)
        {
            // Load initial items
            for (int i = 1; i <= 50; i++)
            {
                Items.Add($"Item {i}");
            }
        }

        await base.PreRender();
    }

    public void LoadMoreItems()
    {
        int currentCount = Items.Count;
        for (int i = currentCount + 1; i <= currentCount + 20; i++)
        {
            Items.Add($"Item {i}");
        }
    }
}