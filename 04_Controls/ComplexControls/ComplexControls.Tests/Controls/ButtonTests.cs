using DotVVM.Framework.Testing;
using ComplexControls.Web.Controls;

namespace ComplexControls.Tests.Controls;

public class ButtonTests
{
    static readonly ControlTestHelper cth = new ControlTestHelper(config: config =>
    {
        config.Markup.AddCodeControls("cc", exampleControl: typeof(Icon));
    });

    public class TestViewModel
    {
        public void TestCommand() { }
    }

    [Fact]
    public async Task Button_RendersAsButtonElement()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} />
        """);
        Assert.NotNull(r.Html.QuerySelector("button"));
    }

    [Fact]
    public async Task Button_TextOnly_NoSpanWrapper()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} />
        """);
        // Without an icon, the button text is set directly (no span wrapper)
        Assert.Null(r.Html.QuerySelector("button span"));
    }

    [Fact]
    public async Task Button_PrimaryVariant_HasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} Variant="Primary" />
        """);
        var button = r.Html.QuerySelector("button");
        Assert.NotNull(button);
        Assert.Contains("bg-blue-500", button!.ClassList);
    }

    [Fact]
    public async Task Button_DangerVariant_HasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} Variant="Danger" />
        """);
        var button = r.Html.QuerySelector("button");
        Assert.NotNull(button);
        Assert.Contains("bg-red-500", button!.ClassList);
    }

    [Fact]
    public async Task Button_SuccessVariant_HasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} Variant="Success" />
        """);
        var button = r.Html.QuerySelector("button");
        Assert.NotNull(button);
        Assert.Contains("bg-green-500", button!.ClassList);
    }

    [Fact]
    public async Task Button_WithIconLeft_RendersIconThenText()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} IconType="Home" IconPlacement="Left" />
        """);
        var button = r.Html.QuerySelector("button");
        Assert.NotNull(button);
        Assert.Equal("svg", button!.Children[0].TagName.ToLower());
        Assert.Equal("span", button.Children[1].TagName.ToLower());
    }

    [Fact]
    public async Task Button_WithIconRight_RendersTextThenIcon()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} IconType="Home" IconPlacement="Right" />
        """);
        var button = r.Html.QuerySelector("button");
        Assert.NotNull(button);
        Assert.Equal("span", button!.Children[0].TagName.ToLower());
        Assert.Equal("svg", button.Children[1].TagName.ToLower());
    }

    [Fact]
    public async Task Button_WithIcon_RendersTextInsideSpan()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Button Text="Click me" ClickCommand={command: TestCommand()} IconType="Home" IconPlacement="Left" />
        """);
        var span = r.Html.QuerySelector("button span");
        Assert.NotNull(span);
    }
}
