# <t:Button>
Renders a styled button with semantic variants, sizes, icons, enabled state, commands, and optional submit behavior. Use inner content instead of `Text` when you need richer markup.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the button is interactive.|attribute, static value, bindable|True|
|`Icon`|([HeroIcon](../_enums/DotVVM.Controls.Tailwind.Controls.HeroIcon.md))|Gets or sets the optional icon displayed inside the button. It cannot be combined with template-based content.|attribute, static value, bindable||
|`IconPosition`|([IconPosition](../_enums/DotVVM.Controls.Tailwind.Controls.IconPosition.md))|Gets or sets whether the icon is rendered before or after the button text.|attribute, static value, bindable|Start|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsSubmitButton`|Boolean|Gets or sets whether the button is rendered with type="submit".|attribute, static value|False|
|`Size`|([ControlSize](../_enums/DotVVM.Controls.Tailwind.ControlSize.md))|Gets or sets the size variant of the button.|attribute, static value, bindable|Default|
|`Template`|ITemplate|Gets or sets the custom content rendered inside the button.|inner element, static value, default property||
|`Text`|String|Gets or sets the text displayed inside the button.|attribute, static value, bindable||
|`Type`|([ButtonType](../_enums/DotVVM.Controls.Tailwind.Controls.ButtonType.md))|Gets or sets the visual style variant of the button.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command executed when the button is clicked.|

## Sample 1: Button Types, Sizes, and Icons

Demonstrates all button types, size variants, icon support, click commands, and disabled state.

```DOTHTML

<div class="flex flex-col gap-6">
    <div class="flex gap-2 flex-wrap">
        <t:Button Type="Default" Text="Default" />
        <t:Button Type="Primary" Text="Primary" />
        <t:Button Type="Secondary" Text="Secondary" />
        <t:Button Type="Success" Text="Success" />
        <t:Button Type="Warning" Text="Warning" />
        <t:Button Type="Danger" Text="Danger" />
        <t:Button Type="Info" Text="Info" />
        <t:Button Type="Ghost" Text="Ghost" />
        <t:Button Type="Link" Text="Link" />
    </div>
    
    <div class="flex gap-2 flex-wrap items-center">
        <span class="text-sm font-semibold">Sizes:</span>
        <t:Button Type="Primary" Text="Small" Size="Small" />
        <t:Button Type="Primary" Text="Default" Size="Default" />
        <t:Button Type="Primary" Text="Large" Size="Large" />
        <t:Button Type="Primary" Text="Extra Large" Size="ExtraLarge" />
    </div>
</div>


```

## Click action

This sample demonstrates handling the `Click` command and updating a counter on the page.


```DOTHTML

<div class="flex flex-col gap-4">
    <div class="flex items-center gap-4">
        <t:Button Type="Primary" Text="Click me" Click="{command: IncrementClick()}" Size="Large" />
        <span class="text-lg font-semibold">Clicked: {{value: ClickCount}} times</span>
    </div>
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public int ClickCount { get; set; }

    public void IncrementClick()
    {
        ClickCount++;
    }
}

```

## Buttons with Icons

Demonstrates buttons with HeroIcons, showing both Start (default) and End icon positions.



```DOTHTML

<div class="flex gap-2 flex-wrap">
    <t:Button Type="Primary" Text="Add" Icon="Plus" />
    <t:Button Type="Danger" Text="Delete" Icon="Trash" />
    <t:Button Type="Default" Text="Filter" Icon="Funnel" />
    <t:Button Type="Success" Text="Save" Icon="Check" />
    <t:Button Type="Warning" Text="Download" Icon="ArrowDownTray" IconPosition="End" />
</div>


```

## Bindable Enabled State

Shows how to bind the Button's Enabled state to a checkbox property, allowing dynamic enable/disable.



```DOTHTML

<div class="flex flex-col gap-4">
    <div class="flex items-center gap-4">
        <t:CheckBoxFormField Checked="{value: IsButtonEnabled}" Text="Enable button" />
        <t:Button Type="Primary" Text="Toggle Me" Enabled="{value: IsButtonEnabled}" />
    </div>
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public bool IsButtonEnabled { get; set; } = true;
}


```

## Bindable Button Text

Demonstrates binding the Button's Text property to a TextBox input, allowing users to dynamically change the button label.



```DOTHTML

<div class="flex flex-col gap-4">
    <div class="flex items-center gap-4">
        <t:TextBoxFormField LabelText="Button text" Text="{value: ButtonText}" />
        <t:Button Type="Primary" Text="{value: ButtonText}" />
    </div>
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public string ButtonText { get; set; } = "Click me!";
}


```

## Submit and disabled buttons

Shows `IsSubmitButton` and `Enabled` on the same control. `IsSubmitButton="true"` changes the rendered HTML button type to `submit`, while `Enabled="false"` disables the button.


```DOTHTML

<div class="flex gap-2 flex-wrap items-center">
    <t:Button Type="Primary" Text="Submit" IsSubmitButton="true" />
    <t:Button Type="Default" Text="Regular button" />
    <t:Button Type="Primary" Text="Disabled submit" IsSubmitButton="true" Enabled="false" />
    <t:Button Type="Danger" Text="Disabled action" Enabled="false" />
</div>

```

