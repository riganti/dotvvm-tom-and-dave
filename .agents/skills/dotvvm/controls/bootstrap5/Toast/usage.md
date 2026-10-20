# <dot:Toast>
Toast is a component designed to display push notifications we know from various mobile and desktop operating systems.

<https://getbootstrap.com/docs/5.2/components/toasts/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AddCloseButton`|Boolean|Gets or sets the whether the close button will be added. The CloseButton component can be used to achieve the same behavior.|attribute, static value|True|
|`Animation`|([ToastAnimation](../_enums/DotVVM.Bootstrap5.Controls.ToastAnimation.md))|Gets or sets which animation will be used. Animation can be also disabled by setting animation to None.|attribute, static value|Fade|
|`AutoHideDelay`|Int32?|Gets or sets how many miliseconds it will take before the toast closes. When set to null than the toast will never close automatically.|attribute, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([ToastColor](../_enums/DotVVM.Bootstrap5.Controls.ToastColor.md))|Gets or sets the color of the toast.|attribute, static value, bindable|None|
|`Content`|List<DotvvmControl>|Gets or sets the content placed inside the control.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the content inside the toast header.|inner element, static value||
|`HeaderText`|String|Gets or sets a single text inside the toast header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsDisplayed`|Boolean|Gets or sets whether the Toast is displayed.|attribute, static value, bindable||
|`Text`|String|Gets or sets the text inside the control.|attribute, static value, bindable||
|`TextColor`|([ToastTextColor](../_enums/DotVVM.Bootstrap5.ToastTextColor.md))|Gets or sets the font color of the toast.|attribute, static value, bindable|None|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Hidden`|ICommandBinding|Triggers when the Toast is hidden.|
|`Shown`|ICommandBinding|Triggers when the Toast is shown.|

## Sample 1: Basic Toast

The header content of `Toast` can be set be one of two ways: using the `HeaderText` property or using `HeaderTemplate`.  

The main content can be set using `Text` or `ContentTemplate`.  This property is required, so it must be set.

Showing and hiding the toast can be using the `IsDisplayed` property.

```DOTHTML
<bs:Toast IsDisplayed="{value: Displayed}" HeaderText="Header" >
    <ContentTemplate>
        Content
    </ContentTemplate>
</bs:Toast>
```

```CSHARP
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
<bs:Toast IsDisplayed="{value: Displayed}" Text="None Animation" Animation="None" />

<bs:Toast IsDisplayed="{value: Displayed}" Text="Fade Animation" Animation="Fade" />
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Toast.sample1
{
    public class ViewModel
    {
        public bool Displayed { get; set; } = true;
    }
}
```

## Sample 3: Hiding

The default way for hiding `Toast` is the [CloseButton](~/controls/bootstrap5/CloseButton) which is automatically created in header.

You can remove the default [CloseButton](~/controls/bootstrap5/CloseButton) by setting `AddCloseButton` to *false*.

An alternative way for hiding the `Toast` is by setting the `AutoHideDelay` property. The delay is in miliseconds.

```DOTHTML
<bs:Toast IsDisplayed="{value: Displayed}" Text="Content" AutoHideDelay="3000" AddCloseButton="false" />

<bs:Button Text="Show / Hide with delay" Click="{staticCommand: Displayed = !Displayed}" />
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Toast.sample1
{
    public class ViewModel
    {
        public bool Displayed { get; set; } = true;
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

## Sample 5: Color and Font Color

The `Color` property allows to change the background color of toast.

The `FontColor` property allows to change the font color of texts in toast.

Basic Color which can be use as `Color` and `FontColor` can be found in [Bootstrap Color documentation](<https://getbootstrap.com/docs/5.2/utilities/colors/>)



```DOTHTML
<bs:Toast IsDisplayed="{value: true}" Text="Content" HeaderText="Header Primary" Color="Secondary" FontColor="Primary" />

```

