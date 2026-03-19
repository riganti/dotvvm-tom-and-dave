using System;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.HelperNamespace;
using DotVVM.Framework.Controls;

namespace ComplexControls.Web.Controls;

public class Checkbox : CompositeControl
{
    public static DotvvmControl GetContents(
        ValueOrBinding<string>? text,
        ValueOrBinding<bool>? isChecked,
        [DotvvmControlCapability("CheckIcon")]
        IconCapability checkedIconCapability,
        ICommandBinding? checkedChangedCommand = null,
        Variant variant = Variant.Primary)
    {
        var checkbox = new DotVVM.Framework.Controls.CheckBox();
        checkbox.SetProperty(DotVVM.Framework.Controls.CheckBox.CheckedProperty, isChecked);
        checkbox.SetProperty(DotVVM.Framework.Controls.CheckBox.ChangedProperty, checkedChangedCommand);
        checkbox.AddCssClasses("peer sr-only");

        var checkIcon = new HtmlGenericControl("div");
        checkIcon.AddCssClasses("checkbox-icon absolute text-white pointer-events-none opacity-0");
       
        if (checkedIconCapability.Type != null)
        {
            var icon = Icon.GetContents(checkedIconCapability);
            checkIcon.AppendChildren(icon);
        }
        else
        {
            var icon = Icon.GetContents(new IconCapability 
            { 
                Type = IconType.Check, 
                IconVariant = Variant.Dark, 
                Style = IconStyle.Outline 
            });

            checkIcon.AppendChildren(icon);
        }

        var visualBox = new HtmlGenericControl("div");
        visualBox.AddCssClasses($"relative flex items-center justify-center w-6 h-6 bg-gray-800 border-2 border-gray-600 rounded peer-checked:[&>.checkbox-icon]:opacity-100");
        ApplyVariant(visualBox, variant);
        visualBox.AppendChildren(checkIcon);

        var label = new HtmlGenericControl("label")
            .AddCssClass("inline-flex items-center gap-2 cursor-pointer");

        label.AppendChildren(new DotvvmControl[] { checkbox, visualBox });

        if (text.HasValue)
        {
            var textSpan = new HtmlGenericControl("span");
            textSpan.SetProperty(HtmlGenericControl.InnerTextProperty, text);
            label.AppendChildren(textSpan);
        }

        return label;
    }

    private static void ApplyVariant(HtmlGenericControl wrapper, Variant variant)
    {
        switch (variant)
        {
            case Variant.Primary:
                wrapper.AddCssClasses("peer-checked:bg-blue-500 peer-checked:border-blue-600");
                break;
            case Variant.Secondary:
                wrapper.AddCssClasses("peer-checked:bg-gray-500 peer-checked:border-gray-600");
                break;
            case Variant.Success:
                wrapper.AddCssClasses("peer-checked:bg-green-500 peer-checked:border-green-600");
                break;
            case Variant.Danger:
                wrapper.AddCssClasses("peer-checked:bg-red-500 peer-checked:border-red-600");
                break;
            case Variant.Warning:
                wrapper.AddCssClasses("peer-checked:bg-yellow-500 peer-checked:border-yellow-600");
                break;
            case Variant.Info:
                wrapper.AddCssClasses("peer-checked:bg-teal-500 peer-checked:border-teal-600");
                break;
            case Variant.Light:
                wrapper.AddCssClasses("peer-checked:bg-gray-300 peer-checked:border-gray-400");
                break;
            case Variant.Dark:
                wrapper.AddCssClasses("peer-checked:bg-gray-800 peer-checked:border-gray-900");
                break;
        }
    }
}