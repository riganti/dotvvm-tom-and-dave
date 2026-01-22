using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace MultipleFormValidation.Components;

public class ValidationCounter : CompositeControl
{
    public DotvvmControl GetContents(
        string pathPrefix)
    {
        return new HtmlGenericControl("span")
            .AddCssClasses("badge", "bg-danger")
            .AddAttribute("data-bind", "validation-counter: " + KnockoutHelper.MakeStringLiteral(pathPrefix));
    }

    protected override void OnPreRender(IDotvvmRequestContext context)
    {
        context.ResourceManager.AddRequiredResource("validation-counter");
        base.OnPreRender(context);
    }
}