# <bs:ModalDialog>
Renders a modal dialog popup displayed on top of the current page using Bootstrap Modal widget.

<https://getbootstrap.com/docs/3.3/javascript/#modals>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the dialog content.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets the contents of the dialog footer.|inner element, static value||
|`HeaderTagName`|String|Gets or sets tag which wraps the value of the HeaderText property.              This property cannot be used together with the HeaderTemplate property.|attribute, static value||
|`HeaderTemplate`|ITemplate|Gets or sets the content of the dialog header. This property cannot be used together with the HeaderText property.|inner element, static value||
|`HeaderText`|String|Gets or sets the text in the dialog header. If you need to customize the dialog header, use the HeaderTemplate property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean|Gets or sets whether the dialog is currently displayed or not. Use data-binding on this property to show and hide the dialog.|attribute, bindable|False|
|`Size`|([ModalSize](../_enums/DotVVM.Framework.Controls.Bootstrap.ModalSize.md))|Gets or sets the size of the dialog.|attribute, static value|Normal|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`ZIndex`|Int32|Gets or sets z-index value of the ModalDialog control.|attribute, static value|2000|

## Sample 1: Basic Usage

The `ModalDialog` control has the `HeaderText` property which sets the title of the popup. 

By default, the dialog title is rendered as `<h4>` header, but you can adjust it using the `HeaderTagName` property.
If you need to customize the header using your own HTML content, use the  `HeaderTemplate` property instead.

The contents of the dialog are specified using the `ContentTemplate` property. This is the only required property.

The button row can be customized using the `FooterTemplate` property. 


The `ModalDialog` can be displayed or hidden using the `IsDisplayed` property. Just bind it to a `bool` property in the viewmodel and set it to `true` or `false`. 


```DOTHTML
<bs:Button Text="Open Dialog" Type="Primary" Click="{command: OpenDialog()}" />

<bs:ModalDialog IsDisplayed="{value: Displayed}">
  <HeaderTemplate>
    My Dialog
    <bs:CloseButton/>
  </HeaderTemplate>
  <ContentTemplate>
    This is the contents of the dialog.
  </ContentTemplate>
</bs:ModalDialog>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ModalDialog.sample2
{
    public class ViewModel
    {
        public bool Displayed { get; set; } = false;

        public void OpenDialog() 
        {
            Displayed = true;
        }
    }
}
```

## Sample 2: ModalDialog Sizing and Static Commands

You can use the [static commands](~/pages/concepts/respond-to-user-actions/static-commands) to control the `IsDisplayed` property.

No communication with the server is required in this mode because you only work with the viewmodel property.

```DOTHTML
<bs:Button Text="Open Dialog" Click="{staticCommand: Displayed = true}" />

<bs:ModalDialog HeaderText="My Dialog" 
    IsDisplayed="{value: Displayed}" 
	Size="Small">
	<ContentTemplate>
		This is the dialog.
	</ContentTemplate>
	<FooterTemplate>
		<bs:Button Text="Close Dialog" Click="{staticCommand: Displayed = false}" />
	</FooterTemplate>
</bs:ModalDialog>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ModalDialog.sample2
{
    public class ViewModel
    {
        public bool Displayed { get; set; } = false;
    }
}
```

