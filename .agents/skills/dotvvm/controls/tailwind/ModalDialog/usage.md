# <t:ModalDialog>
Renders a modal dialog based on the native `<dialog>` element with bindable open state, header and footer regions, and size options.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Required template for the main body of the dialog.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Custom footer content template; use instead of FooterText for rich markup (e.g. action buttons).|inner element, static value||
|`FooterText`|String|Plain-text string displayed in the dialog footer.|attribute, static value, bindable||
|`HeaderTemplate`|ITemplate|Custom header content template; use instead of HeaderText for rich markup.|inner element, static value||
|`HeaderText`|String|Plain-text string displayed as the dialog heading.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsOpen`|Boolean|Controls whether the dialog is currently open. Bind to a boolean property on the view model.|attribute, static value, bindable|False|
|`Size`|([ModalSize](../_enums/DotVVM.Controls.Tailwind.ModalSize.md))|Controls the width of the dialog. The default value renders the standard modal width.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Header text with footer actions

Uses `HeaderText`, `ContentTemplate`, `FooterTemplate`, and `Size` for a confirmation dialog with interactive buttons.


```DOTHTML
<t:Button Type="Primary" Text="Open confirmation" Click="{command: OpenDialog()}" />
<p class="mt-3 text-sm">Last action: {{value: Result}}</p>

<t:ModalDialog IsOpen="{value: IsDialogOpen}" HeaderText="Delete report" Size="Large">
    <ContentTemplate>
        <p>This action removes the selected report from the dashboard.</p>
    </ContentTemplate>
    <FooterTemplate>
        <div class="flex gap-3 justify-end">
            <t:Button Type="Default" Text="Cancel" Click="{command: CloseDialog()}" />
            <t:Button Type="Danger" Text="Delete" Click="{command: ConfirmDelete()}" />
        </div>
    </FooterTemplate>
</t:ModalDialog>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ModalDialog.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsDialogOpen { get; set; }

        public string Result { get; set; } = "Nothing deleted yet.";

        public void OpenDialog()
        {
            IsDialogOpen = true;
        }

        public void CloseDialog()
        {
            IsDialogOpen = false;
            Result = "Deletion canceled.";
        }

        public void ConfirmDelete()
        {
            IsDialogOpen = false;
            Result = "Report deleted.";
        }
    }
}

```

## Sample 2: Custom header and footer templates

Uses `HeaderTemplate` and `FooterTemplate` when the dialog needs richer markup than plain text.


```DOTHTML
<t:Button Type="Default" Text="Open settings" Click="{command: ToggleSettings()}" />
<p class="mt-3 text-sm">{{value: SaveStatus}}</p>

<t:ModalDialog IsOpen="{value: IsSettingsOpen}">
    <HeaderTemplate>
        <div class="flex items-center gap-2">
            <t:Icon Icon="Cog6Tooth" Type="Outline" class="w-6 h-6 text-primary-600" />
            <h2>Workspace settings</h2>
        </div>
    </HeaderTemplate>
    <ContentTemplate>
        <p class="mb-3">Current owner: <strong>{{value: UserName}}</strong></p>
        <p>Template regions let you combine icons, headings, and custom action layouts.</p>
    </ContentTemplate>
    <FooterTemplate>
        <div class="flex gap-3 justify-end">
            <t:Button Type="Default" Text="Close" Click="{command: ToggleSettings()}" />
            <t:Button Type="Primary" Text="Save" Click="{command: SaveSettings()}" />
        </div>
    </FooterTemplate>
</t:ModalDialog>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ModalDialog.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsSettingsOpen { get; set; }

        public string UserName { get; set; } = "Jane Doe";

        public string SaveStatus { get; set; } = "No changes saved.";

        public void ToggleSettings()
        {
            IsSettingsOpen = !IsSettingsOpen;
        }

        public void SaveSettings()
        {
            IsSettingsOpen = false;
            SaveStatus = "Settings saved.";
        }
    }
}

```

## Sample 3: Full-screen dialog with footer text

Uses `FooterText` for static footer copy and `Size="FullScreen"` for a dialog that needs more space.


```DOTHTML
<t:Button Type="Default" Text="Open release notes" Click="{command: ToggleReleaseNotes()}" />

<t:ModalDialog IsOpen="{value: IsReleaseNotesOpen}" HeaderText="Release notes" FooterText="Press Esc or use the buttons in the body to close this dialog." Size="FullScreen">
    <ContentTemplate>
        <div class="space-y-3">
            <p>This sample uses the full-screen size for long-form content.</p>
            <ul class="list-disc pl-6">
                <li>New app layout shell</li>
                <li>Updated icon binding support</li>
                <li>Improved timeline responsiveness</li>
            </ul>
            <t:Button Type="Primary" Text="Close" Click="{command: ToggleReleaseNotes()}" />
        </div>
    </ContentTemplate>
</t:ModalDialog>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.ModalDialog.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsReleaseNotesOpen { get; set; }

        public void ToggleReleaseNotes()
        {
            IsReleaseNotesOpen = !IsReleaseNotesOpen;
        }
    }
}

```

