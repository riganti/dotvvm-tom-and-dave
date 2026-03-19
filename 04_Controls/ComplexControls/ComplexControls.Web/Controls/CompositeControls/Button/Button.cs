using System;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace ComplexControls.Web.Controls;

public class Button : CompositeControl
{
    public static DotvvmControl GetContents(
        HtmlCapability html,
        ValueOrBinding<string>? text,
        ICommandBinding? clickCommand,
        [DotvvmControlCapability("Icon")] IconCapability iconCapability,
        IconPlacement iconPlacement = IconPlacement.Left,
        Variant variant = Variant.Primary)
    {
        return new DotVVM.Framework.Controls.Button()
            .SetCapability(html)
            .SetProperty(b => b.Click, clickCommand)
            .AddCssClasses(CommonControlMethods.GetButtonVariantClasses(variant))
            .SetProperty(b => b.ButtonTagName, ButtonTagName.button)
            .AppendChildren(
                (iconCapability, iconPlacement) is ({ Type: not null}, IconPlacement.Left) 
                    ? Icon.GetContents(iconCapability)
                    : null,

                text.HasValue 
                    ? new Literal(text)
                    : null,

                (iconCapability, iconPlacement) is ({ Type: not null}, IconPlacement.Right) 
                    ? Icon.GetContents(iconCapability)
                    : null
                );
        
        

        //if (iconCapability.Type != null)
        //{
        //    if (iconPlacement == IconPlacement.Left)
        //    {
        //        var icon = Icon.GetContents(iconCapability);
        //        button.AppendChildren(icon);
        //    }

        //    if (text.HasValue)
        //    {
        //        var textSpan = new HtmlGenericControl("span");
        //        textSpan.SetProperty(HtmlGenericControl.InnerTextProperty, text);
        //        button.AppendChildren(textSpan);
        //    }

        //    if (iconPlacement == IconPlacement.Right)
        //    {
        //        var icon = Icon.GetContents(iconCapability);
        //        button.AppendChildren(icon);
        //    }
        //}
        //else
        //{
        //    button.SetProperty(DotVVM.Framework.Controls.Button.TextProperty, text);
        //}

        //return button;
    }
}
