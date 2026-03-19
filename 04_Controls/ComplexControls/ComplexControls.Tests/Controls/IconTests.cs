using DotVVM.Framework.Testing;
using ComplexControls.Web.Controls;

namespace ComplexControls.Tests.Controls;

public class IconTests
{
    static readonly ControlTestHelper cth = new ControlTestHelper(config: config =>
    {
        config.Markup.AddCodeControls("cc", exampleControl: typeof(Icon));
    });

    public class TestViewModel { }

    [Fact]
    public async Task Icon_RendersAsSvgElement()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" />
        """);
        Assert.NotNull(r.Html.QuerySelector("svg"));
    }

    [Fact]
    public async Task Icon_SolidStyle_PathsHaveFill()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" Style="Solid" />
        """);
        var path = r.Html.QuerySelector("svg > path");
        Assert.NotNull(path);
        Assert.Equal("currentColor", path!.GetAttribute("fill"));
    }

    [Fact]
    public async Task Icon_OutlineStyle_PathsHaveStroke()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" Style="Outline" />
        """);
        var path = r.Html.QuerySelector("svg > path");
        Assert.NotNull(path);
        Assert.Equal("currentColor", path!.GetAttribute("stroke"));
    }

    [Fact]
    public async Task Icon_WithBackgroundRing_SvgIsWrappedInDiv()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" HasBackgoundRing="true" />
        """);
        Assert.NotNull(r.Html.QuerySelector("div svg"));
    }

    [Fact]
    public async Task Icon_PrimaryVariant_HasCorrectCssClass()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" IconVariant="Primary" />
        """);
        var svg = r.Html.QuerySelector("svg");
        Assert.NotNull(svg);
        Assert.Contains("text-blue-500", svg!.ClassList);
    }

    [Fact]
    public async Task Icon_DangerVariant_HasCorrectCssClass()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" IconVariant="Danger" />
        """);
        var svg = r.Html.QuerySelector("svg");
        Assert.NotNull(svg);
        Assert.Contains("text-red-500", svg!.ClassList);
    }

    [Fact]
    public async Task Icon_CheckType_RendersPath()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Check" />
        """);
        Assert.NotNull(r.Html.QuerySelector("svg > path"));
    }

    [Fact]
    public async Task Icon_BackgroundRing_RingDivHasRoundedFullClass()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Icon Type="Home" HasBackgoundRing="true" />
        """);
        var ring = r.Html.QuerySelector("div");
        Assert.NotNull(ring);
        Assert.Contains("rounded-full", ring!.ClassList);
    }
}
