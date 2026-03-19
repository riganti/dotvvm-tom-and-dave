using System;

namespace ComplexControls.Web.Controls;

public static class CommonControlMethods
{
    public static string GetButtonVariantClasses(Variant variant)
    {
        var baseClasses = "inline-flex items-center gap-2 px-4 py-2 rounded-md ";

        var variantClasses = variant switch
        {
            Variant.Primary => "bg-blue-500 hover:bg-blue-600 text-white",
            Variant.Secondary => "bg-gray-500 hover:bg-gray-600 text-white",
            Variant.Success => "bg-green-500 hover:bg-green-600 text-white",
            Variant.Danger => "bg-red-500 hover:bg-red-600 text-white",
            Variant.Warning => "bg-yellow-500 hover:bg-yellow-600 text-white",
            Variant.Info => "bg-cyan-500 hover:bg-cyan-600 text-white",
            Variant.Light => "bg-gray-200 hover:bg-gray-300 text-gray-800",
            Variant.Dark => "bg-gray-800 hover:bg-gray-900 text-white",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null)
        };

        return baseClasses + variantClasses;
    }
}