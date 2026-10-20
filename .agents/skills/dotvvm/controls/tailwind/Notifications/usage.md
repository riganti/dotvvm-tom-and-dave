# <t:Notifications>
Renders a toast notification container that watches a bound `Items` collection and displays notifications using the selected alignment and timeout.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([NotificationAlignment](../_enums/DotVVM.Controls.Tailwind.NotificationAlignment.md))|Controls which corner of the viewport the notification container is anchored to.|attribute, static value|BottomRight|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseTimeout`|Int32|Optional auto-close timeout in milliseconds. Use 0 to keep notifications visible until the user closes them.|attribute, static value|0|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Items`|IValueBinding<IList<NotificationData>>|A value binding to the collection of notifications to display. Newly added items are rendered as toast messages.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Auto-closing notifications

Binds the required `Items` collection and uses `CloseTimeout` with `Alignment="BottomRight"`.


```DOTHTML
<div class="flex flex-wrap gap-2">
    <t:Button Type="Success" Text="Show success" Click="{command: ShowSuccess()}" />
    <t:Button Type="Danger" Text="Show error" Click="{command: ShowError()}" />
    <t:Button Type="Info" Text="Show info" Click="{command: ShowInfo()}" />
    <t:Button Type="Warning" Text="Show warning" Click="{command: ShowWarning()}" />
</div>

<t:Notifications Items="{value: Notifications}" CloseTimeout="4000" Alignment="BottomRight" />

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Controls.Tailwind;
using DotVVM.Controls.Tailwind.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Notifications.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<NotificationData> Notifications { get; set; } = new();

        public void ShowSuccess()
        {
            Notifications.Add(new NotificationData { Type = NotificationType.Success, Text = "The record was saved." });
        }

        public void ShowError()
        {
            Notifications.Add(new NotificationData { Type = NotificationType.Danger, Text = "The record could not be saved." });
        }

        public void ShowInfo()
        {
            Notifications.Add(new NotificationData { Type = NotificationType.Info, Text = "Background synchronization has started." });
        }

        public void ShowWarning()
        {
            Notifications.Add(new NotificationData { Type = NotificationType.Warning, Text = "Your session will expire soon." });
        }
    }
}

```

## Sample 2: Persistent notifications in a different corner

Uses `Alignment="TopLeft"` and leaves `CloseTimeout` at its default value of `0`, so notifications stay visible until the user closes them.


```DOTHTML
<div class="flex gap-2">
    <t:Button Type="Info" Text="Show reminder" Click="{command: ShowReminder()}" />
    <t:Button Type="Warning" Text="Show warning" Click="{command: ShowPersistentWarning()}" />
</div>

<t:Notifications Items="{value: PersistentNotifications}" Alignment="TopLeft" />

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Controls.Tailwind;
using DotVVM.Controls.Tailwind.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Notifications.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<NotificationData> PersistentNotifications { get; set; } = new();

        public void ShowReminder()
        {
            PersistentNotifications.Add(new NotificationData { Type = NotificationType.Info, Text = "Remember to review the draft before publishing." });
        }

        public void ShowPersistentWarning()
        {
            PersistentNotifications.Add(new NotificationData { Type = NotificationType.Warning, Text = "Manual confirmation is required for this action." });
        }
    }
}

```

