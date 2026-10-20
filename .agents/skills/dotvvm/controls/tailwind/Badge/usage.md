# <t:Badge>
Displays a small highlighted label with semantic colors. The badge can render plain text or custom child content.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|Gets or sets the semantic color style of the badge.|attribute, static value, bindable|Default|
|`Content`|List<DotvvmControl>|Gets or sets the custom content rendered inside the badge.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Text`|String|Gets or sets the text displayed inside the badge.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Badge Colors and Dynamic Binding

Shows all available badge colors and a dynamically bound color.

```DOTHTML
<div class="flex gap-3 flex-wrap items-center">
    <t:Badge Color="Default" Text="Default" />
    <t:Badge Color="Primary" Text="Primary" />
    <t:Badge Color="Secondary" Text="Secondary" />
    <t:Badge Color="Success" Text="Success" />
    <t:Badge Color="Danger" Text="Danger" />
    <t:Badge Color="Warning" Text="Warning" />
    <t:Badge Color="Info" Text="Info" />
    <t:Badge Color="Dark" Text="Dark" />
    <t:Badge Color="Light" Text="Light" />
</div>


```

## Bindable badge color

Choose a color from the ComboBox and see the `Badge` change its color dynamically.


```DOTHTML
<div class="flex items-center gap-4">
    <div>
        <label class="text-sm font-semibold">Color:</label>
        <t:ComboBox DataSource="{value: AllBadgeColors}" SelectedValue="{value: SelectedBadgeColor}" class="mt-1" />
    </div>
    <t:Badge Color="{value: SelectedBadgeColor}" Text="Dynamic Color" />
</div>


```

```CSHARP
using DotVVM.Controls.Tailwind.Controls;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public TailwindColor SelectedBadgeColor { get; set; } = TailwindColor.Primary;
    public TailwindColor[] AllBadgeColors { get; set; } = System.Enum.GetValues<TailwindColor>();
}

```

## Badge with content and counters

Shows a badge bound to a numeric property and a badge with custom child content. Use `Text` for simple labels and inner content for richer markup.


```DOTHTML
<div class="flex flex-col gap-4">
    <div class="flex items-center gap-4">
        <span>Messages <t:Badge Color="Primary" Text="4" /></span>
        <span>Notifications <t:Badge Color="Danger" Text="{value: NotificationCount}" /></span>
        <t:Badge Color="Info">
            <strong>Beta</strong> preview
        </t:Badge>
    </div>
    <div class="flex gap-2">
        <t:Button Text="+" Click="{command: IncrementNotifications()}" Size="Small" />
        <t:Button Text="-" Click="{command: DecrementNotifications()}" Size="Small" />
        <t:Button Text="Reset" Click="{command: ResetNotifications()}" Size="Small" />
    </div>
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public int NotificationCount { get; set; } = 5;

    public void IncrementNotifications()
    {
        NotificationCount++;
    }

    public void DecrementNotifications()
    {
        if (NotificationCount > 0) NotificationCount--;
    }

    public void ResetNotifications()
    {
        NotificationCount = 0;
    }
}


```

