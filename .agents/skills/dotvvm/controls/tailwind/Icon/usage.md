# <t:Icon>
Renders a HeroIcon SVG. The `Icon` and `Type` properties support both static values and data binding.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Icon`|([HeroIcon](../_enums/DotVVM.Controls.Tailwind.Controls.HeroIcon.md))|The icon to render. Accepts both static values and value bindings ({value: ...}).|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Type`|([IconType](../_enums/DotVVM.Controls.Tailwind.IconType.md))|The visual style of the icon. Use Outline for the default stroked variant or Solid for the filled variant.|attribute, static value, bindable|Outline|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Static outline and solid icons

Shows several static icon names and both `Outline` and `Solid` icon styles.


```DOTHTML
<div class="space-y-4">
    <div class="flex items-center gap-4 text-primary-600">
        <t:Icon Icon="Home" Type="Outline" class="w-6 h-6" />
        <t:Icon Icon="Bell" Type="Outline" class="w-6 h-6" />
        <t:Icon Icon="EnvelopeOpen" Type="Outline" class="w-6 h-6" />
        <t:Icon Icon="Cog6Tooth" Type="Outline" class="w-6 h-6" />
    </div>

    <div class="flex items-center gap-4 text-primary-600">
        <t:Icon Icon="Home" Type="Solid" class="w-6 h-6" />
        <t:Icon Icon="Bell" Type="Solid" class="w-6 h-6" />
        <t:Icon Icon="EnvelopeOpen" Type="Solid" class="w-6 h-6" />
        <t:Icon Icon="Cog6Tooth" Type="Solid" class="w-6 h-6" />
    </div>
</div>

```

## Sample 2: Bindable icon and icon type

Binds both `Icon` and `Type`, which is useful when the icon name or style is selected dynamically at runtime.


```DOTHTML
<div class="max-w-md space-y-4">
    <div class="flex gap-3">
        <dot:ComboBox DataSource="{value: Icons}" SelectedValue="{value: SelectedIcon}" />
        <dot:ComboBox DataSource="{value: IconTypes}" SelectedValue="{value: SelectedIconType}" />
    </div>

    <div class="flex items-center gap-3 text-primary-600">
        <t:Icon Icon="{value: SelectedIcon}" Type="{value: SelectedIconType}" class="w-8 h-8" />
        <span>{{value: SelectedIcon}} ({{value: SelectedIconType}})</span>
    </div>
</div>

```

```CSHARP
using System;
using DotVVM.Controls.Tailwind;
using DotVVM.Controls.Tailwind.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Icon.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public HeroIcon[] Icons { get; set; } = Enum.GetValues<HeroIcon>();

        public IconType[] IconTypes { get; set; } = Enum.GetValues<IconType>();

        public HeroIcon SelectedIcon { get; set; } = HeroIcon.Sparkles;

        public IconType SelectedIconType { get; set; } = IconType.Outline;
    }
}

```

