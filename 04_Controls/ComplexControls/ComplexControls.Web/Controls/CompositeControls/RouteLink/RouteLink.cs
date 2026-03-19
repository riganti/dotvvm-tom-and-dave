using System;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace ComplexControls.Web.Controls;

public class RouteLink : CompositeControl
{
    public static DotvvmControl GetContents(
        ValueOrBinding<string>? text,
        RouteLinkCapability routeLinkCapability,
        IconPlacement iconPlacement = IconPlacement.Left,
        Variant variant = Variant.Primary,
        [DotvvmControlCapability("Icon")]
        IconCapability? iconCapability = null)
    {
        var routeLink = new DotVVM.Framework.Controls.RouteLink();
        routeLink.SetCapability(routeLinkCapability);
        routeLink.AddCssClasses(CommonControlMethods.GetButtonVariantClasses(variant));

        if(iconCapability?.Type != null)
        {
                if(iconPlacement == IconPlacement.Left)
                {
                    var icon = Icon.GetContents(iconCapability);
                    routeLink.AppendChildren(icon);
                }

                if (text.HasValue)
                {    
                    var textSpan = new HtmlGenericControl("span");
                    textSpan.SetProperty(HtmlGenericControl.InnerTextProperty, text);
                    routeLink.AppendChildren(textSpan);
                }

                if(iconPlacement == IconPlacement.Right)
                {
                    var icon = Icon.GetContents(iconCapability);
                    routeLink.AppendChildren(icon);
                }
        }
        else
        {
            routeLink.SetProperty(DotVVM.Framework.Controls.RouteLink.TextProperty, text);
        }

        return routeLink;
    }
}
