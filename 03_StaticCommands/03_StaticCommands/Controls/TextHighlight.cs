using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace StaticCommands.Controls;

public class TextHighlight : CompositeControl
{
    public DotvvmControl GetContents(
        IValueBinding<string> text,
        IValueBinding<string?> highlightedText)
    {
        var group = new KnockoutBindingGroup()
        {
            { "text", this, text },
            { "highlightedText", this, highlightedText }
        };
        return new HtmlGenericControl("span")
            .SetAttribute("data-bind", "highlight: " + group);
    }

    protected override void OnPreRender(IDotvvmRequestContext context)
    {
        context.ResourceManager.AddRequiredResource("ko-highlight");
        base.OnPreRender(context);
    }

}

