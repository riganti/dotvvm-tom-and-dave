using DotVVM.Framework.Testing;
using ComplexControls.Web.Controls;

namespace ComplexControls.Tests.Controls;

public class CheckboxTests
{
    static readonly ControlTestHelper cth = new ControlTestHelper(config: config =>
    {
        config.Markup.AddCodeControls("cc", exampleControl: typeof(Icon));
    });

    public class TestViewModel
    {
        public bool IsChecked { get; set; } = false;
    }

    [Fact]
    public async Task Checkbox_RendersAsLabel()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" />
        """);
        Assert.NotNull(r.Html.QuerySelector("label"));
    }

    [Fact]
    public async Task Checkbox_RendersCheckboxInput()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" />
        """);
        Assert.NotNull(r.Html.QuerySelector("input[type=checkbox]"));
    }

    [Fact]
    public async Task Checkbox_WithText_RendersTextSpan()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" />
        """);
        Assert.NotNull(r.Html.QuerySelector("label > span"));
    }

    [Fact]
    public async Task Checkbox_WithoutText_NoTextSpan()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox IsChecked="{value: IsChecked}" />
        """);
        Assert.Null(r.Html.QuerySelector("label > span"));
    }

    [Fact]
    public async Task Checkbox_AlwaysRendersCheckIcon()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox IsChecked="{value: IsChecked}" />
        """);
        // visual box contains a checkbox-icon div with an svg inside
        Assert.NotNull(r.Html.QuerySelector("div.checkbox-icon svg"));
    }

    [Fact]
    public async Task Checkbox_PrimaryVariant_VisualBoxHasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" Variant="Primary" />
        """);
        var visualBox = r.Html.QuerySelector("div.relative");
        Assert.NotNull(visualBox);
        Assert.Contains("peer-checked:bg-blue-500", visualBox!.ClassList);
    }

    [Fact]
    public async Task Checkbox_DangerVariant_VisualBoxHasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" Variant="Danger" />
        """);
        var visualBox = r.Html.QuerySelector("div.relative");
        Assert.NotNull(visualBox);
        Assert.Contains("peer-checked:bg-red-500", visualBox!.ClassList);
    }

    [Fact]
    public async Task Checkbox_SuccessVariant_VisualBoxHasCorrectCssClasses()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" Variant="Success" />
        """);
        var visualBox = r.Html.QuerySelector("div.relative");
        Assert.NotNull(visualBox);
        Assert.Contains("peer-checked:bg-green-500", visualBox!.ClassList);
    }

    [Fact]
    public async Task Checkbox_CustomCheckIcon_RendersSpecifiedIcon()
    {
        var r = await cth.RunPage(typeof(TestViewModel), """
            <cc:Checkbox Text="Accept" IsChecked="{value: IsChecked}" CheckIconType="Check" />
        """);
        Assert.NotNull(r.Html.QuerySelector("div.checkbox-icon svg"));
    }
}
