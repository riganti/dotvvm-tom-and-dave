# <dot:ModalDialog>
Renders a modal dialog popup displayed on top of the current page using Bootstrap Modal widget.

<https://getbootstrap.com/docs/5.2/components/modal/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AddCloseButton`|Boolean|Gets or sets whether the close button should be added to the dialog header.|attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseOnBackdropClick`|Boolean|Gets or sets whether the dialog should be closed when the user clicks outside.|attribute, static value|True|
|`CloseOnEscape`|Boolean|Gets or sets whether the dialog should be closed when the user presses the Escape key.|attribute, static value|True|
|`Content`|List<DotvvmControl>|Gets or sets the dialog content.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EnableAnimation`|Boolean|Gets or sets whether modal dialog should use fade animation.|attribute, static value|True|
|`FooterTemplate`|ITemplate|Gets or sets a custom template for modal footer.|inner element, static value||
|`FooterText`|String|Gets or sets a plain text for modal footer.|attribute, static value, bindable||
|`HeaderTagName`|String|Gets or sets tag which wraps the value of the HeaderText property. This property cannot be used together with the HeaderTemplate property.|attribute, static value|h4|
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for modal header.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for modal header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsDisplayed`|Boolean|Gets or sets whether the dialog is currently displayed or not. Use data-binding on this property to show and hide the dialog.|attribute, static value, bindable|False|
|`ScrollableContent`|Boolean|Gets or sets whether the inner content of modal dialog is scrollable.|attribute, static value, bindable|False|
|`Size`|([ModalSize](../_enums/DotVVM.Bootstrap5.Controls.ModalSize.md))|Gets or sets the size of the dialog.|attribute, static value|Normal|
|`UseBackdrop`|Boolean|Gets or sets whether the dialog should use backdrop.|attribute, static value|True|
|`VerticalAlignment`|([ModalVerticalAlignment](../_enums/DotVVM.Bootstrap5.Controls.ModalVerticalAlignment.md))|Gets or sets the vertical alignment of the dialog.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Zindex`|Int32|Gets or sets z-index value of the ModalDialog control.|attribute, static value|2000|

## Sample 1: Basic Usage

The `ModalDialog` control has the `HeaderText` property which sets the title of the popup.

By default, the dialog title is rendered as `<h4>` header, but you can adjust it using the `HeaderTagName` property. If you need to customize the header using your own HTML content, use the `HeaderTemplate` property instead.

The contents of the dialog are specified using the `ContentTemplate` property. This is the only required property.

The button row can be customized using the `FooterTemplate` property.

The `ModalDialog` can be displayed or hidden using the `IsDisplayed` property. Just bind it to a `bool` property in the viewmodel and set it to `true` or `false`.

Closing the dialog by clicking outside of it or by pressing the Escape key will set the `IsDisplayed` property to `false`.

```DOTHTML
<bs:Button Text="Open Dialog" Click="{staticCommand: Displayed = true}" />

<bs:ModalDialog HeaderText="Title" IsDisplayed="{value: Displayed}">
    <Content>
        <span>Modal Body</span>
    </Content>
    <FooterTemplate>
        <span>Footer</span>
    </FooterTemplate>
</bs:ModalDialog>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap5.ModalDialog.sample1
{
    public class ViewModel
    {
         public bool Displayed { get; set; } = false;
    }
}
```

## Sample 2: ModalDialog Closing

Control `ModalDialog` contains `closeOnBackdropClick` and `closeOnEscape` properties which allows to specify whether the dialog should be closed by clicking outside of it or by pressing the Escape key. Both properties are set to true by default.

If `AddCloseButton` is set to `true`, the `CloseButton` control will be added to the modal dialog header.

```DOTHTML
<bs:Button Text="Open Dialog" Click="{staticCommand: Displayed = true}" />

<bs:ModalDialog AddCloseButton="true" IsDisplayed="{value: Displayed}" FooterText="Footer" CloseOnBackdropClick="false">
    <HeaderTemplate>
        <span>Header</span>
    </HeaderTemplate>
    <Content>
        <span>Modal Body</span>
    </Content>
</bs:ModalDialog>

```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap5.ModalDialog.sample1
{
    public class ViewModel
    {
         public bool Displayed { get; set; } = false;
    }
}
```

## Sample 3: ModalDialog Sizing and Styles

The `Size` property allows to define the size of the modal dialog - `Small`, `Normal`, `Large` and `ExtraLarge`.

If the modal dialog lays over other elements in the page, you may want to modify the `ZIndex` property.

The `UseBackdrop` indicates whether the modal backdrop should be rendered under the modal dialog.

The `ScrollableContent` sets whether the modal dialog content would be vertically scrollable.

```DOTHTML
    <bs:Button Text="Open Dialog" Click="{staticCommand: Displayed = true}" />

    <bs:ModalDialog IsDisplayed="{value: Displayed}" ScrollableContent="true" UseBackdrop="true" Size="XLarge" ZIndex="2150">
        <HeaderTemplate>
            <span>Header</span>
        </HeaderTemplate>
        <Content>
            <span>Modal Body</span>
        </Content>
        <FooterTemplate>
            <span>Footer</span>
        </FooterTemplate>
    </bs:ModalDialog>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap5.ModalDialog.sample1
{
    public class ViewModel
    {
         public bool Displayed { get; set; } = false;
    }
}
```

