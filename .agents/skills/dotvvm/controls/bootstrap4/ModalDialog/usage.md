# <bs:ModalDialog>
Renders a modal dialog popup displayed on top of the current page using Bootstrap Modal widget.

<https://getbootstrap.com/docs/4.3/components/modal/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AddCloseButton`|Boolean|Gets or sets whether the close button should be added to the dialog header.|attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseOnBackdropClick`|Boolean|Gets or sets whether the dialog should be closed when the user clicks outside.|attribute, static value|True|
|`CloseOnEscape`|Boolean|Gets or sets whether the dialog should be closed when the user presses the Escape key.|attribute, static value|True|
|`ContentTemplate`|ITemplate|Gets or sets the dialog content.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EnableAnimation`|Boolean|Gets or sets whether modal dialog should use fade animation.|attribute, static value|True|
|`FooterTemplate`|ITemplate|Gets or sets the contents of the dialog footer.|inner element, static value||
|`HeaderTagName`|String|Gets or sets tag which wraps the value of the HeaderText property.             This property cannot be used together with the HeaderTemplate property.|attribute, static value|h4|
|`HeaderTemplate`|ITemplate|Gets or sets the content of the dialog header. This property cannot be used together with the HeaderText property.|inner element, static value||
|`HeaderText`|String|Gets or sets the text in the dialog header. If you need to customize the dialog header, use the HeaderTemplate property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean|Gets or sets whether the dialog is currently displayed or not. Use data-binding on this property to show and hide the dialog.|attribute, bindable|False|
|`ScrollableContent`|Boolean|Gets or sets whether the inner content of modal dialog is scrollable.|attribute, static value, bindable|False|
|`Size`|([ModalSize](../_enums/DotVVM.Framework.Controls.Bootstrap4.ModalSize.md))|Gets or sets the size of the dialog.|attribute, static value|Normal|
|`UseBackdrop`|Boolean|Gets or sets whether the backdrop should be displayed under the modal dialog.|attribute, static value|True|
|`VerticalAlignment`|([ModalVerticalAlignment](../_enums/DotVVM.Framework.Controls.Bootstrap4.ModalVerticalAlignment.md))|Gets or sets the vertical alignment of the dialog.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`ZIndex`|Int32|Gets or sets z-index value of the ModalDialog control.|attribute, static value|2000|

## Sample 1: Basic Usage

The `ModalDialog` control has the `HeaderText` property which sets the title of the popup. 

By default, the dialog title is rendered as `<h4>` header, but you can adjust it using the `HeaderTagName` property.
If you need to customize the header using your own HTML content, use the  `HeaderTemplate` property instead.

The contents of the dialog are specified using the `ContentTemplate` property. This is the only required property.

The button row can be customized using the `FooterTemplate` property. 


The `ModalDialog` can be displayed or hidden using the `IsDisplayed` property. Just bind it to a `bool` property in the viewmodel and set it to `true` or `false`. 

Closing the dialog by clicking outside of it or by pressing the Escape key will set the `IsDisplayed` property to `false`.


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

## Sample 2: ModalDialog Static Commands

You can use a [Static Command](~/pages/concepts/respond-to-user-actions/static-commands) to control the `IsDisplayed` property.

No communication with the server is required in this mode because you only work with the viewmodel property.

```DOTHTML
<bs:Button Text="Open Dialog" Click="{staticCommand: Displayed = true}" />

<bs:ModalDialog HeaderText="My Dialog" 
                IsDisplayed="{value: Displayed}">
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

## Sample 3: ModalDialog Sizing and Styles

The `Size` property allows to define the size of the modal dialog - `Small`, `Normal`, `Large` and `ExtraLarge` .

If the modal dialog lays over other elements in the page, you may want to modify the `ZIndex` property.

The `UseBackdrop` indicates whether the modal backdrop should be rendered under the modal dialog.

The `ScrollableContent` sets whether the modal dialog content would be vertically scrollable.

The `CloseOnBackdropClick` or `CloseOnEscape` properties allows to specify whether the dialog should be closed by clicking outside of it or by pressing the Escape key.

If `AddCloseButton` is set to `true`, the [CloseButton](~/controls/bootstrap4/CloseButton) control will be added to the modal dialog header.

```DOTHTML
<bs:Button Text="Open Dialog" Click="{staticCommand: Displayed = true}" />

<bs:ModalDialog HeaderText="My Dialog" 
                IsDisplayed="{value: Displayed}"
				Size="Small"
				AddCloseButton="true"
				CloseOnEscape="false"
				CloseOnBackdropClick="false"
				UseBackdrop="false"
				ScrollableContent="true" >
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

