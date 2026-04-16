using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotVVM.Framework.Controls;

namespace TailwindApp.Web.Pages;

public class CampaignItem
{
    public string Name { get; set; } = "";
    public string StatusText { get; set; } = "";
}

public class CampaignModel
{
    [Required]
    public string CampaignName { get; set; } = "Spring Creator Push";
    [Required]
    public string Budget { get; set; } = "$15,000";
    [Required]
    public string Goal { get; set; } = "Boost reel engagement";
}

public class CampaignsViewModel : MasterPageViewModel
{
    public CampaignModel CampaignModel { get; set; } = new CampaignModel();
    public bool ShowLaunchModal { get; set; }
    public bool IsCreating { get; set; }

    public string SelectedChannel { get; set; } = "All";
    public List<string> Channels { get; set; } = new() { "All", "Instagram", "TikTok", "LinkedIn", "YouTube" };

    public GridViewDataSet<CampaignItem> ActiveCampaigns { get; set; } = new()
    {
        Items = new List<CampaignItem>()
        {
            new CampaignItem { Name = "Spring Creator Push", StatusText = "Active" },
            new CampaignItem { Name = "Summer Sale", StatusText = "Active" },
            new CampaignItem { Name = "Holiday Promo", StatusText = "Active" }
        }
    };

    public CampaignsViewModel()
    {
        Title = "Campaigns";
    }

    public void CloseLaunchModal() { ShowLaunchModal = false; IsCreating = false; }

    public void CreateCampaign()
    {
        IsCreating = true;
    }

    public void FinishCreate()
    {
        IsCreating = false;
        ShowLaunchModal = false;
    }
}
