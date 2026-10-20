# <bp:Window>
Creates a `div` element styled as a window that can be shown or hidden any time. 

The content behind the window remains unlocked and the window can be dragged freely to any place in the page.

*DotVVM Business Pack* includes also the [ModalDialog](~/controls/businesspack/ModalDialog) which can display a similar window but prevents the user to interact with the content behind the dialog.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowMove`|Boolean||attribute, static value, bindable|True|
|`AllowResize`|Boolean||attribute, static value|True|
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
|`Height`|String||attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InitialPositionBottom`|String||attribute, static value||
|`InitialPositionLeft`|String||attribute, static value||
|`InitialPositionRight`|String||attribute, static value||
|`InitialPositionTop`|String||attribute, static value||
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean||attribute, bindable|False|
|`MinHeight`|Int32?||attribute, static value||
|`MinWidth`|Int32?||attribute, static value||
|`ShowOverlay`|Boolean||attribute, static value|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String||attribute, static value, bindable||
|`WindowState`|WindowState||attribute, static value, bindable|Normal|

## Events
|Name|Type|Description|
|---|---|---|
|`Closed`|Command||
|`Displayed`|Command||

## Sample 1: Basic Usage

The content inside the `<bp:Window>` element is treated as a `ContentTemplate` property which specifies the main content of the window.

The `IsDisplayed` property is bound to the `bool` property in the viewmodel which controls whether the window is shown or hidden. When the user hides the window, the property is set to `false` automatically.


```DOTHTML
<bp:Window IsDisplayed="{value: IsWindowDisplayed}">
    <p>Display window content here.</p>
</bp:Window>

<bp:Button Text="Display Window"
           Click="{command: IsWindowDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
    }
}
```

## Sample 2: Header And Footer

The `HeaderText` can be used to specify the text in the window header. Alternatively, you can use the `HeaderTemplate` property to be able to use rich HTML content inside the window header.

The same applies to the `FooterText` and `FooterTemplate` properties which can be used to customize the window footer row.


```DOTHTML
<%-- Custom content with header and footer text --%>
<bp:Window HeaderText="This is header"
           FooterText="This is footer."
           IsDisplayed="{value: IsWindow1Displayed}">
    <p>Display window content here.</p>
</bp:Window>

<bp:Button Text="Show Window"
           Click="{command: IsWindow1Displayed = true}" />

<%-- Custom content with header and footer template --%>
<bp:Window IsDisplayed="{value: IsWindow2Displayed}" 
           CloseOnOutsideClick="true">
    <HeaderTemplate>
        <span>This is header</span>
        <bp:CloseDialogButton >
            Close
        </bp:CloseDialogButton>
    </HeaderTemplate>
    <ContentTemplate>
        <p>Display window content here.</p>
    </ContentTemplate>
    <FooterTemplate>
        <i>This is footer.</i>
    </FooterTemplate>
</bp:Window>

<bp:Button Text="Show templated Window"
           Click="{command: IsWindow2Displayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindow1Displayed { get; set; }
        public bool IsWindow2Displayed { get; set; }
    }
}
```

## Sample 3: Closing Window

By default, the window remains open until the user closes it.

The `CloseOnOutsideClick` can be used to make the window close when the user clicks anywhere outside it.

The `CloseOnEscape` can be used to make the window close when the user presses the Escape key.


```DOTHTML
<bp:Window IsDisplayed="{value: IsWindowDisplayed}"
           CloseOnEscape="false"
           CloseOnOutsideClick="false">
    <p>Display window content here.</p>
</bp:Window>

<bp:Button Text="Display Window"
           Click="{command: IsWindowDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
    }
}
```

## Sample 4: Window Size

The `Width` and `Height` properties can be used to specify fixed dimensions of the window. You can use any CSS units here - e.g. `400px`, `50%` etc.

To let the user resize the window, set the `AllowResize` property to `true`.

The `MinWidth` and `MinHeight` properties can restrict the minimum dimensions of the window. They are always in pixels.



```DOTHTML
<bp:Window IsDisplayed="{value: IsWindowDisplayed}"
           MinWidth="200" MinHeight="100"
           Width="300" Height="150"
           AllowResize="true">
    <p>Display window content here.</p>
</bp:Window>

<bp:Button Text="Display Window"
           Click="{command: IsWindowDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
    }
}
```

## Sample 5: Initial Position

The `InitialPositionLeft` and `InitialPositionTop` properties can specify the initial distance from the left and top border of the browser viewport. You can use any CSS value here - e.g. `200px`, `30%` or `5vh`.

The `AllowMove` property can be used to prevent the user from moving the window in the page. By default, the moving is allowed.

```DOTHTML
<bp:Window IsDisplayed="{value: IsWindowDisplayed}"
           InitialPositionLeft="50"
           InitialPositionTop="50"
           AllowMove="false">
    <p>Display window content here.</p>
</bp:Window>

<bp:Button Text="Display Window"
           Click="{command: IsWindowDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
    }
}
```

## Sample 6: Animations

The `AnimationDuration` property specifies the duration of the fade in and fade out effect. The value is in seconds.


```DOTHTML
<bp:Window IsDisplayed="{value: IsWindowDisplayed}"
           AnimationDuration="1"
           UseBackdrop="true">
    <p>Display window content here.</p>
</bp:Window>

<bp:Button Text="Display Window"
           Click="{command: IsWindowDisplayed = true}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
    }
}
```

## Sample 7: Window State

The `WindowState` property specifies whether the window is `Maximized`, or whether it is in the `Normal` state.

```DOTHTML
<bp:Window IsDisplayed="{value: IsWindowDisplayed}"
           WindowState="{value: State}">
    <p>Display window content here.</p>
    <p>Current state is: {{value: State}}</p>
</bp:Window>

<bp:Button Text="Display Window"
           Click="{command: IsWindowDisplayed = true}" />
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Window.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public bool IsWindowDisplayed { get; set; }
        public WindowState State { get; set; } = WindowState.Maximized;
    }
}
```

