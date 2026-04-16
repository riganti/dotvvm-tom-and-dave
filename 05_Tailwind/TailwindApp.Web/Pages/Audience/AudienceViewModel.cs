using System.Collections.Generic;

namespace TailwindApp.Web.Pages;

public class Persona
{
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Initials { get; set; } = "";
}

public class Region
{
    public string Name { get; set; } = "";
    public string Followers { get; set; } = "";
    public string Growth { get; set; } = "";
    public string TopChannel { get; set; } = "";
}

public class AudienceViewModel : MasterPageViewModel
{
    public string SelectedPlatform { get; set; } = "All";
    public List<string> Platforms { get; set; } = new() { "All", "Instagram", "Facebook", "Twitter" };

    public List<Persona> Personas { get; set; } = new()
    {
        new() { Name = "Jordan Miles", Role = "UGC creator", Initials = "JM" },
        new() { Name = "Sara Khan", Role = "Growth marketer", Initials = "SK" },
        new() { Name = "Theo Lane", Role = "Brand strategist", Initials = "TL" },
        new() { Name = "Maya Chen", Role = "Content director", Initials = "MC" },
        new() { Name = "Alex Rivera", Role = "Community manager", Initials = "AR" },
    };

    public List<Region> Regions { get; set; } = new()
    {
        new() { Name = "North America", Followers = "54K", Growth = "+12%", TopChannel = "Instagram" },
        new() { Name = "Europe", Followers = "31K", Growth = "+8%", TopChannel = "LinkedIn" },
        new() { Name = "Asia Pacific", Followers = "24K", Growth = "+19%", TopChannel = "TikTok" },
        new() { Name = "Latin America", Followers = "12K", Growth = "+15%", TopChannel = "Instagram" },
        new() { Name = "Middle East", Followers = "7K", Growth = "+22%", TopChannel = "TikTok" },
    };

    public AudienceViewModel()
    {
        Title = "Audience";
    }
}
