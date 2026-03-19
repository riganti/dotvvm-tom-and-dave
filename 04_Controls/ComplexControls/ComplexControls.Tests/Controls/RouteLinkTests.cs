using DotVVM.Framework.Testing;
using ComplexControls.Web.Controls;

namespace ComplexControls.Tests.Controls;

public class RouteLinkTests
{
    static readonly ControlTestHelper cth = new ControlTestHelper(config: config =>
    {
        config.Markup.AddCodeControls("cc", exampleControl: typeof(Icon));
        config.RouteTable.Add("Default", "", "Pages/Basic/Basic.dothtml");
    });

    public class TestViewModel { }

    [Fact]
    public async Task RouteLink_RendersAsAnchorElement()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" />
        """);
        Assert.NotNull(r.Html.QuerySelector("a"));
    }

    [Fact]
    public async Task RouteLink_PrimaryVariant_HasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" Variant="Primary" />
        """);
        var link = r.Html.QuerySelector("a");
        Assert.NotNull(link);
        Assert.Contains("bg-blue-500", link!.ClassList);
    }

    [Fact]
    public async Task RouteLink_DangerVariant_HasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" Variant="Danger" />
        """);
        var link = r.Html.QuerySelector("a");
        Assert.NotNull(link);
        Assert.Contains("bg-red-500", link!.ClassList);
    }

    [Fact]
    public async Task RouteLink_TextOnly_NoSpanWrapper()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" />
        """);
        // Without an icon, text is set directly via the Text property (no span wrapper)
        Assert.Null(r.Html.QuerySelector("a span"));
    }

    [Fact]
    public async Task RouteLink_WithIconLeft_RendersIconThenText()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" IconType="Home" IconPlacement="Left" />
        """);
        var link = r.Html.QuerySelector("a");
        Assert.NotNull(link);
        Assert.Equal("svg", link!.Children[0].TagName.ToLower());
        Assert.Equal("span", link.Children[1].TagName.ToLower());
    }

    [Fact]
    public async Task RouteLink_WithIconRight_RendersTextThenIcon()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" IconType="Home" IconPlacement="Right" />
        """);
        var link = r.Html.QuerySelector("a");
        Assert.NotNull(link);
        Assert.Equal("span", link!.Children[0].TagName.ToLower());
        Assert.Equal("svg", link.Children[1].TagName.ToLower());
    }

    [Fact]
    public async Task RouteLink_WithIcon_RendersTextInsideSpan()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:RouteLink Text="Go Home" RouteName="Default" IconType="Home" IconPlacement="Left" />
        """);
        Assert.NotNull(r.Html.QuerySelector("a span"));
    }
}
