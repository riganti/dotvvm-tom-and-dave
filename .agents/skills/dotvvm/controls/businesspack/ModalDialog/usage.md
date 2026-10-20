# <bp:ModalDialog>
Creates a `div` element styled as a modal dialog that can be shown or hidden at any time. 

When the dialog is displayed, the content behind it is covered by a semi-transparent backdrop and thus cannot be interacted with.

The *Business Pack* includes also the [Window](~/controls/businesspack/Window) which can display a similar window but keeps the content behind unlocked.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseOnEscape`|Boolean||attribute, static value|True|
|`CloseOnOutsideClick`|Boolean||attribute, static value|True|
|`ContentTemplate`|ITemplate||inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DeathZoneSize`|Int32||attribute, static value, bindable|0|
|`DisableFooterStyle`|Boolean||attribute, static value, bindable|False|
|`DisableHeaderStyle`|Boolean||attribute, static value, bindable|False|
|`FooterTemplate`|ITemplate||inner element, static value||
|`FooterText`|String||attribute, static value, bindable||
|`HeaderTemplate`|ITemplate||inner element, static value||
|`HeaderText`|String||attribute, static value, bindable||
|`HeightRequest`|Int32||attribute, static value, bindable|0|
|`HorizontalAlignment`|HorizontalAlignment||attribute, static value, bindable|Center|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean||attribute, bindable|False|
|`ShowOverlay`|Boolean||attribute, static value|True|
|`VerticalAlignment`|VerticalAlignment||attribute, static value, bindable|Top|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WidthRequest`|Int32||attribute, static value, bindable|0|

## Events
|Name|Type|Description|
|---|---|---|
|`Closed`|Command||
|`Displayed`|Command||

## Sample 1: Basic Usage

The content inside the `<bp:ModalDialog>` element is treated as a `ContentTemplate` property which specifies the main content of the dialog.

The `IsDisplayed` property is bound to the `bool` property in the viewmodel which controls whether the dialog is shown or hidden. When the user hides the dialog, the property is set to `false` automatically.


```DOTHTML
<bp:ModalDialog IsDisplayed="{value: IsModalDisplayed}">
    <p>Hello!</p>
</bp:ModalDialog>
<bp:Button Text="Show Modal Dialog"
           Click="{command: IsModalDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ModalDialog.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsModalDisplayed { get; set; }
    }
}
```

## Sample 2: Header And Footer

The `HeaderText` can be used to specify the text in the dialog header. Alternatively, you can use the `HeaderTemplate` property to be able to use any HTML content inside the dialog header.

The same applies to the `FooterText` and `FooterTemplate` properties which can be used to customize the dialog footer row.


```DOTHTML
<%-- Custom content with header and footer text --%>
<bp:ModalDialog HeaderText="This is header"
                FooterText="This is footer."
                IsDisplayed="{value: IsModal1Displayed}">
    <p>Display modal dialog content here.</p>
</bp:ModalDialog>
<bp:Button Text="Show Modal Dialog"
           Click="{command: IsModal1Displayed = true}" />

<%-- Custom content with header and footer template --%>
<bp:ModalDialog IsDisplayed="{value: IsModal2Displayed}">
    <HeaderTemplate>
        <h3>This is header</h3>
    </HeaderTemplate>
    <ContentTemplate>
        <p>Display modal dialog content here.</p>
    </ContentTemplate>
    <FooterTemplate>
        <i>This is footer.</i>
    </FooterTemplate>
</bp:ModalDialog>
<bp:Button Text="Show templated Modal Dialog"
           Click="{command: IsModal2Displayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ModalDialog.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsModal1Displayed { get; set; }
        public bool IsModal2Displayed { get; set; }
    }
}
```

## Sample 3: Closing Dialog

By default, the dialog can be closed when the user clicks outside it.

The `CloseOnOutsideClick` can be used to disable this behavior. If it is set to `false`, the dialog will stay open when the user clicks anywhere outside it.


```DOTHTML
<bp:ModalDialog IsDisplayed="{value: IsModalDisplayed}"
                CloseOnOutsideClick="false">
    <p>Now you cannot click outside of the dialog to close it.</p>
</bp:ModalDialog>
<bp:Button Text="Show Modal"
           Click="{command: IsModalDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ModalDialog.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsModalDisplayed { get; set; }
    }
}
```

## Sample 4: Dialog Size

The `WidthRequest` and `HeightRequest` properties can be used to specify requested dimensions of the dialog (in pixels). If the screen is smaller than the requested size, the dialog will take all available space.

You can fine-tune dialog sizing on various screen sizes using CSS.

```DOTHTML
<bp:ModalDialog IsDisplayed="{value: IsCustomSizeModalVisible}"
                WidthRequest="800"
                HeightRequest="300">
    <p>I have custom size.</p>
</bp:ModalDialog>

<bp:Button Text="Show Modal Dialog with custom size"
           Click="{command: IsCustomSizeModalVisible = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ModalDialog.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsCustomSizeModalVisible { get; set; }
        public bool IsResizableModalVisible { get; set; }
    }
}
```

