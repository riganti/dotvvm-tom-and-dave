# <dot:Popover>
Adds a Bootstrap Popover functionality to a control.

<https://getbootstrap.com/docs/5.2/components/popovers/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowHtmlInTitleAndContent`|Boolean|Gets or sets whether the title and body can contain HTML.|attribute, static value|False|
|`Body`|String|Gets or sets the popover body.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Container`|String|Gets or sets the selector for athen element in which the popover is created. It allows to position the popover in the flow of the document near the triggering element which will prevent the popover from floating away from the triggering element during a window resize.|attribute, static value||
|`Content`|DotvvmControl|Gets or sets the element for which the popover is displayed.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Delay`|Int32?|Gets or sets number of miliseconds to delay the showing and hiding the popover.|attribute, static value||
|`DisableHtmlSanitization`|Boolean|Gets or sets whether the inner HTML should be sanitized.|attribute, static value|False|
|`EnableAnimation`|Boolean|Gets or sets whether the popover should use the fade animation.|attribute, static value|True|
|`Enabled`|IValueBinding<Boolean>|Gets or sets whether the popover is active or not.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Placement`|([PopoverPlacement](../_enums/DotVVM.Bootstrap5.Controls.PopoverPlacement.md))|Gets or sets the side on which the popover is placed.|attribute, static value, bindable|Right|
|`Title`|String|Gets or sets the popover title.|attribute, static value, bindable||
|`Trigger`|Trigger[]|Gets or sets the event which triggers the popover to show.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Popover

The `Popover` control has the `Title` and `Content` properties that define the title and the body of the popover.

You can use the `Popover` control to wrap links, buttons, or any HTML block elements.

```DOTHTML
<bs:Popover Title="Title text" Body="Content text">
    <a>Simplest link with Popover</a>
</bs:Popover>

<bs:Popover Title="Title text" Body="Content text">
    <div style="width: 220px">
        simple div
    </div>
</bs:Popover>
```

## Sample 2: Popover Placement

The `Popover` control has also the `Placement` property. Use this property to specify on which side the overlay appears.

The `Placement` property can be set to `Top`, `Bottom`, `Left`, `Right` and `Auto`. 


```DOTHTML
<bs:Popover Title="Title" Body="Content text" Placement="Auto">
    <bs:Button Text="Text" Type="Success" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Placement="Bottom">
    <bs:Button Text="Bottom" Type="Info" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Placement="Left">
    <bs:Button Text="Left" Type="Success" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Placement="Right">
    <bs:Button Text="Right" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Placement="Top">
    <bs:Button Text="Top" Type="Warning" />
</bs:Popover>
```

## Sample 3: Popover Triggers

The `Popover` control has the `Trigger` property which specifies on which event the overlay should appear.

The values are `Click`, `Focus` and `Hover`. 


```DOTHTML
<bs:Popover Title="Title" Body="Content text" Trigger="Click">
    <bs:Button Text="Click" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Trigger="Focus">
    <bs:Button Text="Focus" Type="Primary" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Trigger="Hover">
    <bs:Button Text="Hover" Type="Warning" />
</bs:Popover>
```

## Sample 4: Popover Animation, Delay and Container

The `Popover` control uses CSS fade transition by default. It is possible to disable it using the `EnableAnimation` property.

The `Delay` property is used to delay showing and hiding of the popover (value represents number of seconds).

The `Container` property specifies the selector for an element in which the popover is created. It allows to position the popover in the flow of the document near the triggering element which will prevent the popover from floating away from the triggering element during a window resize.


```DOTHTML
<bs:Popover Title="Title" Body="Content text" EnableAnimation="false">
    <bs:Button Text="Text" Type="Danger" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Delay="1">
    <bs:Button Text="Text" Type="Info" />
</bs:Popover>

<bs:Popover Title="Title" Body="Content text" Container="body">
    <bs:Button Text="Text" Type="Secondary" />
</bs:Popover>
```

## Sample 5: Allowing HTML in Title and Content

If you want to allow HTML in `Title` and `Content` properties, you must turn it on explicitly using the `AllowHtmlInTitleAndContent` property.

> If you allow HTML in popovers, make sure the HTML is safe to display. See [Cross-site scripting](https://en.wikipedia.org/wiki/Cross-site_scripting) for more information.


```DOTHTML
<bs:Popover Title="{value: TitleHtml}" 
            Body="{value: ContentHtml}" 
            AllowHtmlInTitleAndContent="true">
    <bs:Button Text="Text" Type="Success" />
</bs:Popover>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public string TitleHtml { get; set; } = "<h3>Title with html</h3>";
    public string ContentHtml { get; set; } = "This <i>content</i> uses <b>html</b> <u>tags</u>";
}
```

