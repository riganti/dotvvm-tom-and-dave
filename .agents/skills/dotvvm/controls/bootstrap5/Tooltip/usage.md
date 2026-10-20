# <dot:Tooltip>
Adds the Bootstrap Tooltip to an element or control.

<https://getbootstrap.com/docs/5.2/components/tooltips>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowHtml`|Boolean|Gets or sets the whether the tooltip can contain HTML in text.|attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|DotvvmControl|Gets or sets the element for which the tooltip is displayed.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Delay`|Int32|Gets or sets number of miliseconds to delay the showing and hiding the tooltip.|attribute, static value|0|
|`DisableHtmlSanitization`|Boolean|Gets or sets whether the inner HTML should be sanitized.|attribute, static value|False|
|`EnableAnimation`|Boolean|Gets or sets whether the tooltip should use the fade animation.|attribute, static value|True|
|`Enabled`|IValueBinding<Boolean>|Gets or sets whether the tooltip is active or not.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Placement`|([TooltipPlacement](../_enums/DotVVM.Bootstrap5.Controls.TooltipPlacement.md))|Gets or sets the side on which the tooltip is placed.|attribute, static value|Bottom|
|`Text`|String|Gets or sets the tooltip text.|attribute, static value, bindable||
|`Trigger`|Trigger[]|Gets or sets the event which triggers the tooltip to show.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the wrapper tag name for tooltip.|attribute, static value|span|

## Sample 1: Basic Tooltip

The control has the `Text` property which specifies the text displayed in the tooltip.

You can use the `Tooltip` control to wrap links, buttons, or any HTML block elements.

```DOTHTML
<bs:Tooltip Text="This element has simple tooltip">
  <a href="#">Link 1</a>
</bs:Tooltip>
```

## Sample 1: Tooltip Placement

The `Tooltip` control has also the `Placement` property. Use this property to specify on which side the overlay appears.

The `Placement` property can be set to `Top`, `Bottom`, `Left`, `Right` and `Auto`. 

```DOTHTML
<bs:Tooltip Placement="Left" Text="This element has simple tooltip">
  <a href="#">Link 1</a>
</bs:Tooltip>

<bs:Tooltip Placement="Right" Text="This element has simple tooltip">
  <a href="#">Link 2</a>
</bs:Tooltip>

<bs:Tooltip Placement="Bottom" Text="This element has simple tooltip">
  <a href="#">Link 3</a>
</bs:Tooltip>

<bs:Tooltip Placement="Top" Text="This element has simple tooltip">
  <a href="#">Link 4</a>
</bs:Tooltip>
```

## Sample 3: Tooltip Animation, Delay and Container

The `Tooltip` control uses CSS fade transition by default. It is possible to disable it using the `EnableAnimation` property.

The `Delay` property is used to delay showing and hiding of the popover (value represents number of seconds).

The `Container` property specifies the selector for an element in which the tooltip is created. It allows to position the popover in the flow of the document 
near the triggering element which will prevent the tooltip from floating away from the triggering element during a window resize.

```DOTHTML
<bs:Tooltip Text="Title" EnableAnimation="false">
    <bs:Button Text="Text" Type="Danger" />
</bs:Tooltip>

<bs:Tooltip Text="Title" Delay="1">
    <bs:Button Text="Text" Type="Info" />
</bs:Tooltip>

<bs:Tooltip Text="Title" Container="body">
    <bs:Button Text="Text" Type="Primary" />
</bs:Tooltip>
```

## Sample 4: Allowing HTML in Text

If you want to allow HTML in the `Text` property, you must turn it on explicitly using the `AllowHtml` property.

> If you allow HTML in tooltips, make sure the HTML is safe to display. See [Cross-site scripting](https://en.wikipedia.org/wiki/Cross-site_scripting) for more information.


```DOTHTML
<bs:Tooltip Text="{value: TitleHtml}" 
            AllowHtml="true">
    <bs:Button Text="Text" Type="Success" />
</bs:Tooltip>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Tooltip.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string TitleHtml { get; set; } = "<h3>Title with html</h3>";
    }
}
```

## Sample 5: HTML sanitization

All HTML passed into `Tooltip` by default goes through Bootstraps HTML sanitizer.
HTML sanitizer filters out all non whitelisted tags and attributes.  
[List of allowed tags and attributes.](https://getbootstrap.com/docs/4.3/getting-started/javascript/#sanitizer)  

To disable HTML sanitization you must set `DisableHtmlSanitization` to true.

>Without sanitization you could have be vulnerable to XSS attacks.

```DOTHTML
<bs:Tooltip Text="{value: TitleHtml}" 
            AllowHtml="true"
            AllowHtmlSanitization="false" >
    <bs:Button Text="Text" Type="Success" />
</bs:Tooltip>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string TitleHtml { get; set; } = "<h3 style='color: forestgreen;' >Title with html</h3>";
}
```

