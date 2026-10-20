# <bs:Toast>
Toast is a component designed to display push notifications we know from various mobile and desktop operating systems.

<https://getbootstrap.com/docs/4.3/components/toasts/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AddCloseButton`|Boolean|Gets or sets whether the close button will be added to the header.|attribute, static value|True|
|`Animation`|([ToastAnimation](../_enums/DotVVM.Framework.Controls.Bootstrap4.ToastAnimation.md))|Gets or sets which animation will be used. Animation can be also disable by setting animation to None.|attribute, static value|Fade|
|`AutoHideDelay`|Double?|Gets or sets how many seconds it will take before the toast closes.             When set to null than the toast will never close automatically.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the content of the toast.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the content of the header.|inner element, static value||
|`HeaderText`|String|Gets or sets the header text.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean|Gets or sets whether the Toast is displayed.|attribute, static value, bindable|False|
|`Text`|String|Gets or sets the inner text of the toast.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`OnHide`|Command|Triggers when the Toast is hidden.|
|`OnShow`|Command|Triggers when the Toast is shown.|

## Sample 1: Basic Toast

The header content of `Toast` can be set be one of two ways: using the `HeaderText` property or using `HeaderTemplate`.  

The main content can be set using `Text` or `ContentTemplate`.  

It's not required to provide both header and content, but at least one is needed.

Showing and hiding the toast can be using the `IsDisplayed` property.

```DOTHTML
<bs:Toast IsDisplayed="{value: Displayed}" HeaderText="Header" >
    <ContentTemplate>
        Content
    </ContentTemplate>
</bs:Toast>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Toast.sample1
{
    public class ViewModel
    {
        public bool Displayed { get; set; } = true;
    }
}
```

## Sample 2: Animation

The default animation used by `Toast` during showing and hiding is *fade*.  

This can be changed using the `Animation` property.

```DOTHTML
<bs:Toast IsDisplayed="{value: Displayed}" Text="Content" Animation="None" />
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
        public bool Displayed { get; set; } = true;
    }
}
```

## Sample 3: Hiding

The default way for hiding `Toast` is the [CloseButton](~/controls/bootstrap4/CloseButton) which is automatically created in header.

You can remove the default [CloseButton](~/controls/bootstrap4/CloseButton) by setting `AddCloseButton` to *false*.

An alternative way for hiding the `Toast` is by setting the `AutoHideDelay` property. The delay is in seconds.

```DOTHTML
<bs:Toast IsDisplayed="{value: Displayed}" Text="Content" AutoHideDelay="3" AddCloseButton="false" />

<bs:Button Text="Show / Hide with delay" Click="{staticCommand: Displayed = !Displayed}" />
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

## Sample 4: Callbacks

You can use `OnShow` and `OnHide` commands to perform some actions when the toast changes its state.

```DOTHTML
<bs:Toast IsDisplayed="{value: Displayed}" OnShow="{command: Shown()}" OnHide="{command: Hidden()}">
    <HeaderTemplate>
        Header
    </HeaderTemplate>
    <ContentTemplate>
        Content
    </ContentTemplate>
</bs:Toast>

<bs:Button Text="Show" Click="{staticCommand: Displayed = true}" />

<pre>{{value: Log}}</pre>
```

```CSHARP
public class ViewModel
{
    public bool Displayed { get; set; } = false;

    public string Log { get; set; }

    public void Shown()
    {
        Log += "shown\r\n";
    }

    public void Hidden()
    {
        Log += "hidden\r\n";
    }
}
```

