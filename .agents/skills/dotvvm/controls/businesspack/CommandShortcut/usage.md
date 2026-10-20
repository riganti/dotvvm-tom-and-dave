# <bp:CommandShortcut>
An invisible control which allows to trigger a command in the viewmodel for a key shortcut.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alt`|Boolean||attribute, static value, bindable|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Ctrl`|Boolean||attribute, static value, bindable|False|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Key`|ShortcutKeys||attribute, static value, bindable|0|
|`Shift`|Boolean||attribute, static value, bindable|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Command`|Command||

## Sample 1: Basic Usage

Use the `Ctrl`, `Shift` and `Alt` properties to specify modifiers for the shortcut, and use the `Key` property to specify the shortcut key.

The `Command` property specifies a command in the viewmodel which is triggered when the key combination is hit.


```DOTHTML
<p>Press CTRL + Shift + S to Save</p>
<bp:CommandShortcut Ctrl="true"
                    Shift="true"
                    Alt="false"
                    Key="S"
                    Command="{command: Save()}" />

<p>Last save: {{value: LastSave}}</p>
```

```CSHARP
using System;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.CommandShortcut.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string LastSave { get; set; } = "Not saved yet.";

        public void Save()
        {
            LastSave = DateTime.Now.ToString("HH:MM:ss");
        }
    }
}
```

