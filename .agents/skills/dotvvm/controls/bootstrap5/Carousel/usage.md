# <dot:Carousel>
Renders a Bootstrap carousel widget.

<https://getbootstrap.com/docs/5.2/components/carousel/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ActiveItemIndex`|Int32|Gets or sets the index of the active slide.|attribute, static value|0|
|`Animation`|([CarouselAnimationType](../_enums/DotVVM.Bootstrap5.Controls.CarouselAnimationType.md))|Gets or sets which animation will be used.|attribute, static value|Slide|
|`Autoplay`|([CarouselAutoplay](../_enums/DotVVM.Bootstrap5.Controls.CarouselAutoplay.md))|Gets or sets the autoplay settings. Autoplay could be enabled after load, enabled after first interaction or disabled completely.|attribute, static value, bindable|OnLoad|
|`AutoSlideInterval`|Int32?|Gets or sets the interval (in miliseconds) between changing slides.|attribute, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CycleItems`|Boolean|Gets or sets whether the carousel should cycle through images continuously or stop after the slideshow is finished.|attribute, static value|True|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`DisableTouchSwiping`|Boolean|Gets or sets whether swiping by touch is enabled.|attribute, static value|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemCaption`|String|Gets or sets the caption plain text for carousel item when DataSource is set.|attribute, static value, bindable||
|`ItemCaptionTemplate`|ITemplate|Gets or sets the caption template for carousel item when DataSource is set.|inner element, static value||
|`ItemContent`|List<DotvvmControl>|Gets or sets the carousel item content when DataSource is set.|inner element, static value||
|`ItemDelay`|Int32?|Gets or sets the time delay (in seconds) for carousel item when DataSource is set.|attribute, static value||
|`ItemImageAlternateText`|String|Gets or sets the image alternate text for carousel item when DataSource is set.|attribute, static value, bindable||
|`ItemImageUrl`|String|Gets or sets the image URL for carousel item when DataSource is set.|attribute, static value, bindable||
|`ItemIsActive`|Boolean|Gets or sets whether the carousel item is active when DataSource is set.|attribute, static value, bindable||
|`Items`|List<ICarouselItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`LeftControlTemplate`|ITemplate|Gets or sets the template for the "move left" control.|inner element, static value||
|`PauseOnHover`|Boolean|Gets or sets whether changing of items shall be paused on hover.|attribute, static value|True|
|`RenderIndicators`|Boolean|Gets or sets whether the dots indicating the active slide will be rendered.|attribute, static value|True|
|`RenderSideControls`|Boolean|Gets or sets whether navigation controls will be rendered.|attribute, static value|True|
|`RightControlTemplate`|ITemplate|Gets or sets the template for the "move right" control.|inner element, static value||
|`Theme`|([CarouselTheme](../_enums/DotVVM.Bootstrap5.Controls.CarouselTheme.md))|Gets or sets the carousel theme.|attribute, static value, bindable|Light|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Carousel

Carousel images have to be placed inside the `Items` or `DataSource` property. Items is a control default property so you can place the `<bs:CarouselItem>` elements directly
inside the `<bs:Carousel>` control. Each image is defined using the `CarouselItem` control.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel>
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/LA.jpg" />
        </bs:CarouselItem>
    
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/NY.jpg" />
        </bs:CarouselItem>
    
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/Miami.jpg" />
        </bs:CarouselItem>
    </bs:Carousel>

</div>
```

## Sample 2: Carousel Settings

The `Carousel` control has the following properties:

* The `Animation` property specifies which transitions between slides should be used - `Fade` or `Slide`.

* The `AutoSlideInterval` property sets the interval of automatic transitions in seconds. If this property is not set, the user has to switch the slides manually.

* The `AutoPlay` property specifies when do the automatic transitions happen - `OnLoad`, `Disabled` or `OnFirstInteraction`.

* The `RenderSideControls` property specifies whether the left and right controls which switch the slides will be rendered.

* The `RenderIndicators` property specifies whether the bottom active slide indicators should be rendered.

* The `PauseOnHover` property indicates whether the animation should be paused when the mouse cursor is over the carousel.

* The `CycleItems` property specifies whether the animation should continue when it reaches the last slide.

* The `ActiveItemIndex` property specifies which image will be displayed first.

* The `DisableTouchSwipping` property specifies whether Carousel slides on touchscreen devices can be transitioned by swipping left/right. 

* The `IsDark` property specifies whether DarkMode is used.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel RenderSideControls="false" RenderIndicators="true" 
                 Animation="Fade" AutoSlideInterval="3" 
                 PauseOnHover="false" CycleItems="false"
                 ActiveItemIndex="0" AutoPlay="OnFirstInteraction">
                 
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/LA.jpg" />
        </bs:CarouselItem>
        
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/NY.jpg" />
        </bs:CarouselItem>
        
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/Miami.jpg" />
        </bs:CarouselItem>
    </bs:Carousel>

</div>
```

## Sample 3: Side Controls

With `RightControlTemplate` and `LeftControlTemplate` you can specify your own buttons which will be used instead of the default ones.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel>
        <Items>
        
            <bs:CarouselItem IsActive="true">
                <bs:Image ImageUrl="~/Images/LA.jpg" />
            </bs:CarouselItem>
        
            <bs:CarouselItem>
                <bs:Image ImageUrl="~/Images/NY.jpg" />
            </bs:CarouselItem>
        
            <bs:CarouselItem>
                <bs:Image ImageUrl="~/Images/Miami.jpg" />
            </bs:CarouselItem>
        
        </Items>

        <RightControlTemplate>
            <span aria-hidden="true" style="color: white">&gt; Next</span>
        </RightControlTemplate>

        <LeftControlTemplate>
            <span aria-hidden="true" style="color: white">&lt; Previous</span>
        </LeftControlTemplate>

    </bs:Carousel>

</div>
```

## Sample 4: CarouselItem

The `CarouselItem` control has the following properties:

* The `Caption` or the `CaptionTemplate` properties can be used to set description of the image.

* The `ImageAlternateText` property specifies an alternate text for an area, if the image cannot be displayed.

* The `ImageUrl` to specifies which property of the collection item will be used as the URL of the image. 

* The `Delay` property which specifies the amount of time to delay between automatically cycling to the next item.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel>
        <bs:CarouselItem Caption="Los Angeles" ImageAlternateText="Los Angeles">
            <bs:Image ImageUrl="~/Images/LA.jpg" />
        </bs:CarouselItem>
        
        <bs:CarouselItem Delay="2000">
            <bs:Image ImageUrl="~/Images/NY.jpg"/>
            <CaptionTemplate>
                <h1>New York</h1>
            </CaptionTemplate>
        </bs:CarouselItem>
        
        <bs:CarouselItem>
            <bs:Image ImageUrl="~/Images/Miami.jpg" />
        </bs:CarouselItem>
    </bs:Carousel>

</div>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public ImageData[] Images { get; set; } = new[]
    {
        new ImageData("~/Images/LA.jpg", "Los Angeles"),
        new ImageData("~/Images/NY.jpg", "New York", true),
        new ImageData("~/Images/Miami.jpg", "Miami")
    };
}

public class ImageData
{
    public ImageData()
    {
    }

    public ImageData(string url, string caption, bool active = false)
    {
        IsActive = active;
        Url = url;
        Caption = caption;
    }

    public string Caption { get; set; }
    public bool IsActive { get; set; }
    public string Url { get; set; }
}
```

## Sample 5: Carousel DataSource

The `Carousel` slides can also be loaded from a collection in the viewmodel. Use the `DataSource` property to specify the source collection.

Then use the `ItemImageUrl` to specify which property of the collection item will be used as the URL of the image. 

Similarly, the `ItemCaption` specifies which property will be the slide caption. Alternatively, you can use `ItemCaptionTemplate` property to define a custom template for slide captions.

The `ItemImageAlternateText` to specify which property of the collection item will be used as ImageAlternateTex.

Finally, the `ItemDelay` to specify the property which will be used as the delay of the Image.

```DOTHTML
<div style="height: 428px; width: 640px;">
    <bs:Carousel DataSource="{value: Images}"
                 ItemImageUrl="{value: Url}" 
                 ItemCaption="{value: Caption}"
                 ItemIsActive="{value: IsActive}"
                 ItemDelay="1000" />
</div>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace Dotvvm.Samples.Carousel.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public ImageData[] Images { get; set; } = new[]
        {
            new ImageData("/Images/LA.jpg", "Los Angeles"),
            new ImageData("/Images/NY.jpg", "New York", true),
            new ImageData("/Images/Miami.jpg", "Miami")
        };
    }

    public class ImageData
    {
        public ImageData()
        {
        }

        public ImageData(string url, string caption, bool active = false)
        {
            IsActive = active;
            Url = url;
            Caption = caption;
        }

        public string Caption { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; set; }
    }

}
```

