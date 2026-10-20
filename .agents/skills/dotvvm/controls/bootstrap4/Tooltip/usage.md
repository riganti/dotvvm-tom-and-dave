# <bs:Tooltip>
Adds the Bootstrap Tooltip to an element or control.

<https://getbootstrap.com/docs/3.3/javascript/#tooltips>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowHtml`|Boolean|Gets or sets the whether tooltip allows HTML content in title.|attribute, static value|False|
|`AllowHtmlSanitization`|Boolean|Gets or sets whether the inner HTML (Tooltip Template) is sanitized.             https://getbootstrap.com/docs/4.3/getting-started/javascript/#sanitizer|attribute, static value|True|
|`AutoCloseMonitoringDepth`|Int32|Gets or sets how many levels of ancestors would be monitored for element removal.             Setting this property can resolve that Tooltip | Popover would not close after its parent element was removed.             Setting this property to high number can have performance impact for some pages.|attribute, static value|2|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Delay`|Double|Gets or sets the delay (in seconds) before the tooltip is shown or closed.|attribute, static value|0|
|`EnableAnimation`|Boolean|Gets or sets whether the tooltip should use fade animation.|attribute, static value|True|
|`Enabled`|Boolean|Gets or sets whether the tooltip is active.|attribute, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean|Gets or sets whether the tooltip is actually displayed.|attribute, bindable|False|
|`Placement`|([TooltipPlacement](../_enums/DotVVM.Framework.Controls.Bootstrap4.TooltipPlacement.md))|Gets or sets the placement of the tooltip.|attribute, static value|Auto|
|`Title`|String|Gets or sets the text of the tooltip.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Tooltip

The control has the `Title` property which specifies the text displayed in the tooltip.

You can use the `Tooltip` control to wrap links, buttons, or any HTML block elements.

```DOTHTML
<bs:Tooltip Title="This element has simple tooltip">
  <a href="#">Link 1</a>
</bs:Tooltip>
```

## Sample 1: Tooltip Placement

The `Tooltip` control has also the `Placement` property. Use this property to specify on which side the overlay appears.

The `Placement` property can be set to `Top`, `Bottom`, `Left`, `Right` and `Auto`. 

```DOTHTML
<bs:Tooltip Placement="Left" Title="This element has simple tooltip">
  <a href="#">Link 1</a>
</bs:Tooltip>

<bs:Tooltip Placement="Right" Title="This element has simple tooltip">
  <a href="#">Link 2</a>
</bs:Tooltip>

<bs:Tooltip Placement="Bottom" Title="This element has simple tooltip">
  <a href="#">Link 3</a>
</bs:Tooltip>

<bs:Tooltip Placement="Top" Title="This element has simple tooltip">
  <a href="#">Link 4</a>
</bs:Tooltip>
```

## Sample 3: Tooltip Animation, Delay and Container

The `Tooltip` control uses CSS fade transition by default. It is possible to disable it using the `EnableAnimation` property.

The `Delay` property is used to delay showing and hiding of the popover (value represents number of seconds).

The `Container` property specifies the selector for an element in which the tooltip is created. It allows to position the popover in the flow of the document 
near the triggering element which will prevent the tooltip from floating away from the triggering element during a window resize.


```DOTHTML
<bs:Tooltip Title="Title" EnableAnimation="false">
    <bs:Button Text="Text" Type="Danger" />
</bs:Tooltip>

<bs:Tooltip Title="Title" Delay="1">
    <bs:Button Text="Text" Type="Info" />
</bs:Tooltip>

<bs:Tooltip Title="Title" Container="body">
    <bs:Button Text="Text" Type="Primary" />
</bs:Tooltip>
```

## Sample 4: Allowing HTML in Title

If you want to allow HTML in the `Title` property, you must turn it on explicitly using the `AllowHtmlInTitleAndContent` property.

> If you allow HTML in tooltips, make sure the HTML is safe to display. See [Cross-site scripting](https://en.wikipedia.org/wiki/Cross-site_scripting) for more information.


```DOTHTML
<bs:Tooltip Title="{value: TitleHtml}" 
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

To disable HTML sanitization you must set `AllowHtmlSanitization` to false.

>Without sanitization you could have be vulnerable to XSS attacks.

```DOTHTML
<bs:Tooltip Title="{value: TitleHtml}" 
            AllowHtml="true"
            AllowHtmlSanitization="false" >
    <bs:Button Text="Text" Type="Success" />
</bs:Tooltip>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Tooltip.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string TitleHtml { get; set; } = "<h3 style='color: forestgreen;' >Title with html</h3>";
    }
}
```

## Sample 6: Monitoring of parent element removal

`AutoCloseMonitoringDepth` allows to set how many the ancestors would be monitored for removal. When element removal is detected than the tooltip is closed.  
When `AutoCloseMonitoringDepth` is set to 1 than removal of tooltip source element or removal of its parent element would be detected. When set to 2 than removal of parent of this parent element would also trigger tooltip close.

Setting `AutoCloseMonitoringDepth` to too high number might negatively affect performance on some pages.

```DOTHTML
<dot:Button Click="{command: DeleteItems()}" Text="Delete items" />

<dot:Repeater DataSource="{value: Tooltips}" RenderWrapperTag="true" >
    <ItemTemplate>
        <div>
            <div>
                <bs:Tooltip Title="{value: Title}" IsDisplayed="{value: true}" AutoCloseMonitoringDepth="3" >
                    <a href="#">Link</a>
                </bs:Tooltip>
            </div>
        </div>
    </ItemTemplate>
</dot:Repeater>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Tooltip.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Tooltip> Tooltips { get; set; } = new List<Tooltip>
                {
                    new Tooltip()
                    {
                        Title = "Tooltip 1"
                    },
                    new Tooltip()
                    {
                        Title = "Tooltip 2"
                    }
                };
        
        
        public void DeleteItems()
        {
            Tooltips.Clear();
        }
    }    
    public class Tooltip
    {
        public string Title { get; set; }
    }
}
```

