# <bs:Popover>
Adds a Bootstrap Popover functionality to a control.

<https://getbootstrap.com/docs/4.3/components/popovers/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowHtmlInTitleAndContent`|Boolean|Gets or sets value indicating whether to insert HTML into popover.             When false jQuery's text method will be used to insert content into the DOM.|attribute, static value|False|
|`AllowHtmlSanitization`|Boolean|Gets or sets whether the inner HTML is sanitized.             https://getbootstrap.com/docs/4.3/getting-started/javascript/#sanitizer|attribute, static value|True|
|`AutoCloseMonitoringDepth`|Int32|Gets or sets how many levels of ancestors would be monitored for element removal.             Setting this property can resolve that Tooltip | Popover would not close after its parent element was removed.             Setting this property to high number can have performance impact for some pages.|attribute, static value|2|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Container`|String|Gets or sets the selector for an element in which the popover is created.             It allows to position the popover in the flow of the document near the triggering element which will prevent the popover from             floating away from the triggering element during a window resize.|attribute, static value|body|
|`Content`|String|Gets or sets the contents of the popover.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Delay`|Double|Gets or sets number of seconds to delay the showing and hiding the popover.|attribute, static value|0|
|`EnableAnimation`|Boolean|Gets or sets value indicating whether the popover should use the fade animation.|attribute, static value|True|
|`Enabled`|Boolean|Gets or sets whether the popover is active or not.|attribute, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisplayed`|Boolean|Gets or sets whether the popover is actually displayed.|attribute, bindable|False|
|`Placement`|([PopoverPlacement](../_enums/DotVVM.Framework.Controls.Bootstrap4.PopoverPlacement.md))|Gets or sets the side on which the popover is placed.|attribute, static value|Right|
|`PopoverTemplate`|ITemplate|Gets or sets the HTML template for creating popover.                           The outermost wrapper element should have the .popover class.              The popover's title will be injected into the element with class popover-header.              The popover's content will be injected into the element with class popover-body.              The element with class arrow will become the popover's arrow.|inner element, static value||
|`Title`|String|Gets or sets the title of the popover.|attribute, static value, bindable||
|`Trigger`|([PopoverTrigger](../_enums/DotVVM.Framework.Controls.Bootstrap4.PopoverTrigger.md))|Gets or sets the event which triggers the popover to show.|attribute, static value|Click|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Popover

The `Popover` control has the `Title` and `Content` properties that define the title and the body of the popover.

You can use the `Popover` control to wrap links, buttons, or any HTML block elements.

```DOTHTML
<bs:Popover Title="Title text" Content="Content text">
    <a>Simplest link with Popover</a>
</bs:Popover>

<bs:Popover Title="Title text" Content="Content text">
    <div style="width: 220px">
        simple div
    </div>
</bs:Popover>
```

## Sample 2: Popover Placement

The `Popover` control has also the `Placement` property. Use this property to specify on which side the overlay appears.

The `Placement` property can be set to `Top`, `Bottom`, `Left`, `Right` and `Auto`. 


```DOTHTML
<bs:Popover Title="Title" Content="Content text" Placement="Auto">
    <bs:Button Text="Text" Type="Success" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Placement="Bottom">
    <bs:Button Text="Bottom" Type="Info" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Placement="Left">
    <bs:Button Text="Left" Type="Success" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Placement="Right">
    <bs:Button Text="Right" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Placement="Top">
    <bs:Button Text="Top" Type="Warning" />
</bs:Popover>
```

## Sample 3: Popover Triggers

The `Popover` control has the `Trigger` property which specifies on which event the overlay should appear.

The values are `Click`, `Focus` and `Hover`. 


```DOTHTML
<bs:Popover Title="Title" Content="Content text" Trigger="Click">
    <bs:Button Text="Click" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Trigger="Focus">
    <bs:Button Text="Focus" Type="Primary" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Trigger="Hover">
    <bs:Button Text="Hover" Type="Warning" />
</bs:Popover>
```

## Sample 4: Popover Animation, Delay and Container

The `Popover` control uses CSS fade transition by default. It is possible to disable it using the `EnableAnimation` property.

The `Delay` property is used to delay showing and hiding of the popover (value represents number of seconds).

The `Container` property specifies the selector for an element in which the popover is created. It allows to position the popover in the flow of the document near the triggering element which will prevent the popover from floating away from the triggering element during a window resize.


```DOTHTML
<bs:Popover Title="Title" Content="Content text" EnableAnimation="false">
    <bs:Button Text="Text" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Delay="1">
    <bs:Button Text="Text" Type="Info" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Container="body">
    <bs:Button Text="Text" Type="Secondary" />
</bs:Popover>
```

## Sample 5: Allowing HTML in Title and Content

If you want to allow HTML in `Title` and `Content` properties, you must turn it on explicitly using the `AllowHtmlInTitleAndContent` property.

> If you allow HTML in popovers, make sure the HTML is safe to display. See [Cross-site scripting](https://en.wikipedia.org/wiki/Cross-site_scripting) for more information.


```DOTHTML
<bs:Popover Title="{value: TitleHtml}" 
            Content="{value: ContentHtml}" 
            AllowHtmlInTitleAndContent="true">
    <bs:Button Text="Text" Type="Success" />
</bs:Popover>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Popover.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string TitleHtml { get; set; } = "<h3>Title with html</h3>";
        public string ContentHtml { get; set; } = "This <i>content</i> uses <b>html</b> <u>tags</u>";
    }
}
```

## Sample 6: Popover Template

The `Popover` control can define custom look using the `PopoverTemplate` property.

The popover's title must be decorated with `popover-header` CSS class.

The popover's content must be decorated with `popover-body` CSS class.

Element marked with `arrow` CSS class will become the popover's arrow.

The outermost wrapper element should have the `popover` CSS class.

```DOTHTML
<bs:Popover Title="Title" Content="Content text">
    <PopoverTemplate>
        <div class="popover" role="tooltip">
            <div class="arrow"></div>
            <div class="popover-header"></div>
            <div class="popover-body"></div>
            <img src="~/images/favicon.png" />
        </div>
    </PopoverTemplate>
    <bs:Button Text="Text" Type="Primary" />
</bs:Popover>
```

## Sample 7: HTML sanitization

All HTML passed into `Popover` by default goes through Bootstrap HTML sanitizer. It filters out all non-whitelisted tags and attributes.  

[List of allowed tags and attributes](https://getbootstrap.com/docs/4.3/getting-started/javascript/#sanitizer)  

To disable HTML sanitization, set `AllowHtmlSanitization` to `false`.

> Make sure the template is safe and cannot enable anyone to make a XSS attack.

```DOTHTML
<bs:Popover Title="Title" Content="Content text" AllowHtmlSanitization="false" >
    <PopoverTemplate>
        <div class="popover" role="tooltip">
            <div class="arrow"></div>
            <div class="popover-header" style="color: orchid; font-weight: bold; font-size: larger;"></div>
            <div class="popover-body" style="color: forestgreen;"></div>
        </div>
    </PopoverTemplate>
    <bs:Button Text="Text" Type="Primary" />
</bs:Popover>
```

## Sample 8: Monitoring of parent element removal

`AutoCloseMonitoringDepth` allows to set how many the ancestors would be monitored for removal. When element removal is detected than the popover is closed.  
When `AutoCloseMonitoringDepth` is set to 1 than removal of popover source element or removal of its parent element would be detected. When set to 2 than removal of parent of this parent element would also trigger popover close.

Setting `AutoCloseMonitoringDepth` to too high number might negatively affect performance on some pages.

```DOTHTML
<dot:Button Click="{command: DeleteItems()}" Text="Delete items" />

<dot:Repeater DataSource="{value: Popovers}" RenderWrapperTag="true" >
    <ItemTemplate>
        <div>
            <div>
                <bs:Popover AutoCloseMonitoringDepth="3" Title="{value: Title}" Content="{value: Content}" IsDisplayed="{value: true}">
                    <bs:Button Text="Open tooltip">
                </bs:Popover>
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
        public List<Popover> Popovers { get; set; } = new List<Popover>
                {
                    new Popover()
                    {
                        Title = "Tooltip 1",
                        Content = "Content 1"
                    },
                    new Popover()
                    {
                        Title = "Tooltip 2",
                        Content = "Content 2"
                    }
                };
        
        
        public void DeleteItems()
        {
            Popovers.Clear();
        }
    }    
    public class Popover
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
```

