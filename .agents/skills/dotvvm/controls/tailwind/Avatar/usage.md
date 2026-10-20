# <t:Avatar>
Displays a user avatar using an image or initials. Use `Size` to switch between the built-in avatar sizes.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AltText`|String|Gets or sets the alternative text for the avatar image.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrl`|String|Gets or sets the URL of the avatar image.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Initials`|String|Gets or sets the fallback initials displayed when no image is provided.|attribute, static value, bindable||
|`Size`|([ControlSize](../_enums/DotVVM.Controls.Tailwind.ControlSize.md))|Gets or sets the visual size of the avatar.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Avatar with Initials and Image

Shows avatars using initials and image URLs in Small, Default, and Large sizes.

```DOTHTML
<div class="flex flex-col gap-6">
    <div class="flex items-center gap-4">
        <h3 class="text-sm font-semibold">Avatar Types:</h3>
        <t:Avatar ImageUrl="https://i.pravatar.cc/150?img=3" AltText="User photo" />
        <t:Avatar Initials="JS" />
        <t:Avatar />
    </div>
    
    <div class="flex items-center gap-4">
        <h3 class="text-sm font-semibold">Avatar Sizes:</h3>
        <t:Avatar Initials="AB" Size="Small" />
        <t:Avatar Initials="CD" Size="Default" />
        <t:Avatar Initials="EF" Size="Large" />
        <t:Avatar Initials="XL" Size="ExtraLarge" />
    </div>
</div>


```

## Dynamic avatar image and bindable initials

This sample demonstrates how to bind the avatar image URL and alt text, change the avatar size via a ComboBox and bind initials from a TextBox.


```DOTHTML
<div class="flex flex-col gap-6">
    <div class="flex items-center gap-4">
        <div>
            <label class="text-sm font-semibold">Initials:</label>
            <t:TextBox Text="{value: InitialsText}" class="mt-1 p-2 border border-gray-300 rounded-md" />
        </div>
        <t:Avatar Initials="{value: InitialsText}" />
    </div>
    
    <div class="flex items-center gap-4">
        <div>
            <label class="text-sm font-semibold">Size:</label>
            <t:ComboBox DataSource="{value: AllSizes}" SelectedValue="{value: SelectedSize}" class="mt-1" />
        </div>
        <t:Avatar Initials="JS" Size="{value: SelectedSize}" />
    </div>
</div>


```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public string DynamicImageUrl { get; set; } = "https://i.pravatar.cc/150?img=2";
    public string DynamicAltText { get; set; } = "User avatar";
    public ControlSize SelectedSize { get; set; } = ControlSize.Default;
    public ControlSize[] AllSizes { get; set; } = (ControlSize[])Enum.GetValues(typeof(ControlSize));
    public string InitialsText { get; set; } = "AB";
}

```

