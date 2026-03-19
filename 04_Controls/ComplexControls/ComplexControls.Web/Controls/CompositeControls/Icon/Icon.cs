using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace ComplexControls.Web.Controls;

[DotvvmControlCapability]
public sealed record IconCapability
{
    public IconType? Type { get; set; } = null;
    public bool HasBackgroundRing { get; set; } = false;
    public IconStyle Style { get; set; } = IconStyle.Solid;
    public Variant IconVariant { get; set; } = Variant.Primary;
    public Variant BackgroundRingVariant { get; set; } = Variant.Light;
}

public class Icon : CompositeControl
{
    public static DotvvmControl GetContents(
        IconCapability capability)
    {
        var svg = new HtmlGenericControl("svg");
        svg.AddAttribute("xmlns", "http://www.w3.org/2000/svg");
        svg.AddAttribute("viewBox", "0 0 24 24");
        svg.AddAttribute("fill", "currentColor");
        svg.AddAttribute("width", "24px");
        svg.AddAttribute("height", "24px");

        switch (capability.Type)
        {
            case IconType.Home:
                AddPath(svg, capability.Style, "M11.293 3.293a1 1 0 0 1 1.414 0l6 6 2 2a1 1 0 0 1-1.414 1.414L19 12.414V19a2 2 0 0 1-2 2h-3a1 1 0 0 1-1-1v-3h-2v3a1 1 0 0 1-1 1H7a2 2 0 0 1-2-2v-6.586l-.293.293a1 1 0 0 1-1.414-1.414l2-2 6-6Z");
                break;
            case IconType.Search:
                AddPath(svg, capability.Style, "M10 2a8 8 0 1 0 0 16 8 8 0 0 0 0-16Z");
                AddPath(svg, capability.Style, "M21.707 21.707a1 1 0 0 1-1.414 0l-3.5-3.5a1 1 0 0 1 1.414-1.414l3.5 3.5a1 1 0 0 1 0 1.414Z");
                break;
            case IconType.User:
                AddPath(svg, capability.Style, "M12 4a4 4 0 1 0 0 8 4 4 0 0 0 0-8Zm-2 9a4 4 0 0 0-4 4v1a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2v-1a4 4 0 0 0-4-4h-4Z");
                break;
            case IconType.Settings:
                AddPath(svg, capability.Style, "M9.586 2.586A2 2 0 0 1 11 2h2a2 2 0 0 1 2 2v.089l.473.196.063-.063a2.002 2.002 0 0 1 2.828 0l1.414 1.414a2 2 0 0 1 0 2.827l-.063.064.196.473H20a2 2 0 0 1 2 2v2a2 2 0 0 1-2 2h-.089l-.196.473.063.063a2.002 2.002 0 0 1 0 2.828l-1.414 1.414a2 2 0 0 1-2.828 0l-.063-.063-.473.196V20a2 2 0 0 1-2 2h-2a2 2 0 0 1-2-2v-.089l-.473-.196-.063.063a2.002 2.002 0 0 1-2.828 0l-1.414-1.414a2 2 0 0 1 0-2.827l.063-.064L4.089 15H4a2 2 0 0 1-2-2v-2a2 2 0 0 1 2-2h.09l.195-.473-.063-.063a2 2 0 0 1 0-2.828l1.414-1.414a2 2 0 0 1 2.827 0l.064.063L9 4.089V4a2 2 0 0 1 .586-1.414ZM8 12a4 4 0 1 1 8 0 4 4 0 0 1-8 0Z");
                break;
            case IconType.Check:
                AddPath(svg, capability.Style, "M5 11.917 9.724 16.5 19 7.5");
                break;
            case IconType.Cat:
                AddPath(svg, capability.Style, "M12 2c-1.5 0-2.5 1-3 2-.5-1-1.5-2-3-2-1 0-2 1-2 2.5 0 .5.5 1 1 1.5l-1 1c-.5.5-1 1.5-1 2.5v4c0 1 .5 2 1.5 2.5.5 1.5 2 2.5 3.5 2.5h6c1.5 0 3-1 3.5-2.5 1-.5 1.5-1.5 1.5-2.5v-4c0-1-.5-2-1-2.5l-1-1c.5-.5 1-1 1-1.5 0-1.5-1-2.5-2-2.5-1.5 0-2.5 1-3 2-.5-1-1.5-2-3-2Zm-3 7a1 1 0 1 1 0 2 1 1 0 0 1 0-2Zm6 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2Zm-5 5c0 1 1 2 2 2s2-1 2-2");
                break;

        }

        if (capability.HasBackgroundRing)
        {
            var ring = new HtmlGenericControl("div");
            ring.AddCssClass("inline-flex items-center justify-center rounded-full bg-gray-200 p-1");
            ApplySvgVariant(svg, capability.IconVariant);
            ring.AppendChildren(svg);
            ApplyRingVariant(ring, capability.BackgroundRingVariant);
            return ring;
        }
        else
        {
            ApplySvgVariant(svg, capability.IconVariant);
            return svg;
        }
    }

    private static void AddPath(HtmlGenericControl svg, IconStyle iconStyle, string d, string fillRule = "evenodd", string clipRule = "evenodd")
    {
        var path = new HtmlGenericControl("path");
        path.AddAttribute("d", d);
        path.AddAttribute("fill-rule", fillRule);
        path.AddAttribute("clip-rule", clipRule);
        if (iconStyle == IconStyle.Outline)
        {
            path.AddAttribute("stroke", "currentColor");
            path.AddAttribute("stroke-width", "2");
            path.AddAttribute("fill", "none");
        }
        else
        {
            path.AddAttribute("fill", "currentColor");
        }
        svg.Children.Add(path);
    }

    private static void ApplySvgVariant(HtmlGenericControl svg, Variant variant)
    {
        switch (variant)
        {
            case Variant.Primary:
                svg.AddCssClass("text-blue-500");
                break;
            case Variant.Secondary:
                svg.AddCssClass("text-gray-500");
                break;
            case Variant.Success:
                svg.AddCssClass("text-green-500");
                break;
            case Variant.Danger:
                svg.AddCssClass("text-red-500");
                break;
            case Variant.Warning:
                svg.AddCssClass("text-yellow-500");
                break;
            case Variant.Info:
                svg.AddCssClass("text-teal-500");
                break;
            case Variant.Light:
                svg.AddCssClass("text-gray-300");
                break;
            case Variant.Dark:
                svg.AddCssClass("text-gray-800");
                break;
        }
    }

    private static void ApplyRingVariant(HtmlGenericControl ring, Variant variant)
    {
        
        switch (variant)
        {
            case Variant.Primary:
                ring.AddCssClass("bg-blue-500");
                break;
            case Variant.Secondary:
                ring.AddCssClass("bg-gray-500");
                break;
            case Variant.Success:
                ring.AddCssClass("bg-green-500");
                break;
            case Variant.Danger:
                ring.AddCssClass("bg-red-500");
                break;
            case Variant.Warning:
                ring.AddCssClass("bg-yellow-500");
                break;
            case Variant.Info:
                ring.AddCssClass("bg-teal-500");
                break;
            case Variant.Light:
                ring.AddCssClass("bg-gray-300");
                break;
            case Variant.Dark:
                ring.AddCssClass("bg-gray-800");
                break;
        }
    }
}