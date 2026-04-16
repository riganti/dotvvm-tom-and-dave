using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TailwindApp.Web.Pages;

public class PostCard
{
    public DateTime Date { get; set; }
    public string Text { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public List<string> Platforms { get; set; } = new List<string>();
    public int Likes { get; set; }
    public int Shares { get; set; }
    public int Reposts { get; set; }
}

public class OverviewViewModel : MasterPageViewModel
{
    public bool ShowGoalModal { get; set; }
    public int SelectedTimeRange { get; set; } = 1;

    public List<PostCard> PostCards { get; set; } = new List<PostCard>();

    public List<PostCard> PostCards1 { get; set; } = new List<PostCard>()
    {
        new PostCard
        {
            Date = new DateTime(2025, 1, 12),
            Text = "Wow! Dotvvm is really nice!",
            ImageUrl = "https://picsum.photos/seed/test1/500/300",
            Likes = 55,
            Shares = 150,
            Reposts = 55,
            Platforms = { "Instagram", "Facebook", "Twitter" }
        },
        new PostCard
        {
            Date = new DateTime(2025, 1, 10),
            Text = "DotVVM + Tailwind",
            ImageUrl = "https://picsum.photos/seed/test2/500/300",
            Likes = 45,
            Shares = 50,
            Reposts = 15,
            Platforms = { "Instagram", "Facebook" }
        },
        new PostCard
        {
            Date = new DateTime(2025, 6, 18),
            Text = "DotVVM Was Here",
            ImageUrl = "https://picsum.photos/seed/test3/500/300",
            Likes = 3,
            Shares = 4,
            Reposts = 8,
            Platforms = { "Facebook", "Twitter" }
        },
    };

    public List<PostCard> PostCards2 { get; set; } = new List<PostCard>()
    {
        new PostCard
        {
            Date = new DateTime(2024, 1, 12),
            Text = "Dotvvm!",
            ImageUrl = "https://picsum.photos/seed/test4/500/300",
            Likes = 550,
            Shares = 1500,
            Reposts = 550,
            Platforms = { "Facebook" }
        },
        new PostCard
        {
            Date = new DateTime(2025, 1, 10),
            Text = "DotVVM + Tailwind",
            ImageUrl = "https://picsum.photos/seed/test5/500/300",
            Likes = 45,
            Shares = 50,
            Reposts = 15,
            Platforms = { "Instagram", "Facebook" }
        },
        new PostCard
        {
            Date = new DateTime(2025, 6, 18),
            Text = "DotVVM Was Here",
            ImageUrl = "https://picsum.photos/seed/test6/500/300",
            Likes = 2,
            Shares = 6,
            Reposts = 1,
            Platforms = { "Facebook", "Twitter" }
        },
    };

    public List<PostCard> PostCards3 { get; set; } = new List<PostCard>()
    {
        new PostCard
        {
            Date = new DateTime(2022, 1, 12),
            Text = "Dotvvm is really nice!",
            ImageUrl = "https://picsum.photos/seed/test7/500/300",
            Likes = 5500,
            Shares = 1500,
            Reposts = 550,
            Platforms = { "Instagram", "Facebook", "Twitter" }
        },
        new PostCard
        {
            Date = new DateTime(2021, 1, 10),
            Text = "DotVVM + Bootstrap!",
            ImageUrl = "https://picsum.photos/seed/test8/500/300",
            Likes = 450,
            Shares = 540,
            Reposts = 105,
            Platforms = { "Instagram", "Facebook" }
        },
        new PostCard
        {
            Date = new DateTime(2020, 6, 18),
            Text = "DotVVM Is Here",
            ImageUrl = "https://picsum.photos/seed/test9/500/300",
            Likes = 30,
            Shares = 14,
            Reposts = 58,
            Platforms = { "Facebook", "Twitter" }
        },
    };

    public OverviewViewModel()
    {
        Title = "Overview";
    }

    public override async Task PreRender()
    {
        if (!Context.IsPostBack)
        {
            PostCards = PostCards1;
        }
        await base.PreRender();
    }

    public void SwitchTimeRange(int range)
    {
        Thread.Sleep(500); // Simulate loading time

        PostCards = range switch
        {
            0 => PostCards1,
            1 => PostCards2,
            2 => PostCards3,
            _ => throw new NotImplementedException()
        };
    }
}
