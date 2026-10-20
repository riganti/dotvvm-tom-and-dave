# <bs:Popover>
Adds a Bootstrap Popover functionality to a control.

<https://getbootstrap.com/docs/3.3/javascript/#popovers>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowHtmlInTitleAndContent`|Boolean|Gets or sets value indicating whether to insert HTML into popover.              When false jQuery's text method will be used to insert content into the DOM.|attribute, static value|False|
|`AutoPlacement`|Boolean|Gets or sets value indicating whether additional auto-placement should be used with specified position placement.|attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Container`|String|Gets or sets the selector for an element in which the popover is created.              It allows to position the popover in the flow of the document near the triggering element which will prevent the popover from              floating away from the triggering element during a window resize.|attribute, static value||
|`Content`|String|Gets or sets the contents of the popover.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Delay`|Int32|Gets or sets number of milliseconds to delay the showing and hiding the popover.|attribute, static value|0|
|`EnableAnimation`|Boolean|Gets or sets value indicating whether the popover should use the fade animation.|attribute, static value|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Placement`|([PopoverPlacement](../_enums/DotVVM.Framework.Controls.Bootstrap.PopoverPlacement.md))|Gets or sets the side on which the popover is placed.|attribute, static value|Right|
|`PopoverTemplate`|ITemplate|Gets or sets HTML template for creating popover.|inner element, static value||
|`Title`|String|Gets or sets the title of the popover.|attribute, static value, bindable||
|`Trigger`|([PopoverTrigger](../_enums/DotVVM.Framework.Controls.Bootstrap.PopoverTrigger.md))|Gets or sets the event which triggers the popover to show.|attribute, static value|Click|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Popover

The `Popover` control has the `Title` and `Content` properties that define the title and the contents of the popover dialog respectively.

You can also use `Popover` on any HTML elements with `display: block` CSS settings.

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

When the `AutoPlacement` property is set to *true*, it will dynamically reorient the popover. 
For example, if the `Placement` property is set to *Left*, the popover will display to the left when possible, otherwise it will display on the right.

```DOTHTML
<bs:Popover Title="Title" Content="Content text" Placement="Left" AutoPlacement="true">
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

The values are:

* Click
* Focus
* Hover


```DOTHTML
<bs:Popover Title="Title" Content="Content text" Trigger="Click">
    <bs:Button Text="Click" Type="Default" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Trigger="Focus">
    <bs:Button Text="Focus" Type="Primary" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Trigger="Hover">
    <bs:Button Text="Hover" Type="Warning" />
</bs:Popover>
```

## Sample 4: Popover Animation, Delay and Container

The `Popover` control uses by default a CSS fade transition. It is possible to disable it using the `EnableAnimation` property.

The `Delay` property is used to delay showing and hiding of the popover (value represents number of milliseconds).

The `Container` property specifies the selector for an element in which the popover is created. It allows to position the popover in the flow of the document 
near the triggering element which will prevent the popover from floating away from the triggering element during a window resize.


```DOTHTML
<bs:Popover Title="Title" Content="Content text" EnableAnimation="false">
    <bs:Button Text="Text" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Delay="500">
    <bs:Button Text="Text" Type="Info" />
</bs:Popover>

<bs:Popover Title="Title" Content="Content text" Container="body">
    <bs:Button Text="Text" Type="Default" />
</bs:Popover>
```

## Sample 5: Allowing HTML in Title and Content

The `Title` and `Content` properties can also contain HTML. You can allow HTML in these properties using the `AllowHtmlInTitleAndContent` property.


```DOTHTML
<bs:Popover Title="{value: TitleHtml}" Content="{value: ContentHtml}" AllowHtmlInTitleAndContent="true">
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

```DOTHTML
<bs:Popover Title="Title" Content="Content text">
    <PopoverTemplate>
        <div class="popover" role="tooltip">
            <div class="arrow"></div>
            <div class="popover-title" style="color: orchid; font-weight: bold; font-size: larger;"></div>
            <div class="popover-content" style="color: forestgreen;"></div>
        </div>
    </PopoverTemplate>
    <bs:Button Text="Text" Type="Default" />
</bs:Popover>
```

