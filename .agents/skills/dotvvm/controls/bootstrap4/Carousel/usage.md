# <bs:Carousel>
Renders a Bootstrap carousel widget.

<https://getbootstrap.com/docs/4.3/components/carousel/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Animation`|([CarouselAnimationType](../_enums/DotVVM.Framework.Controls.Bootstrap4.CarouselAnimationType.md))|Gets or sets which animation will be used. Allows to set animation to None.|attribute, static value|Slide|
|`AutoSlideInterval`|Double?|Gets or sets interval (in seconds) between changing slides.|attribute, static value||
|`CaptionBinding`|IValueBinding|Gets or sets the caption template for carousel items bound from DataSource.|attribute, bindable||
|`CaptionTemplate`|ITemplate|Gets or sets the caption template for carousel items bound from DataSource.|inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CycleItems`|Boolean|Gets or sets whether the carousel should cycle continuously or have hard stops.|attribute, static value, bindable|True|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageAlternateTextBinding`|IValueBinding|Gets or sets a value binding that points to a property that contains the Alternate Text of the image.|attribute, bindable||
|`ImageUrlBinding`|IValueBinding|Gets or sets a value binding that points to a property that contains the URL of the image.|attribute, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsActiveBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is active or not.|attribute, bindable||
|`Items`|List<ICarouselItem>|Gets or sets the individual slides inside the control.|inner element, static value, default property||
|`LeftControlTemplate`|ITemplate|Gets or sets the template for the "move left" control.|inner element, static value||
|`PauseOnHover`|Boolean|Gets or sets whether changing of items shall be paused on hover.|attribute, static value, bindable|True|
|`RenderIndicators`|Boolean|Gets or sets whether the dots indicating active slide will be rendered.|attribute, static value|True|
|`RenderSideControls`|Boolean|Gets or sets whether navigation controls will be rendered.|attribute, static value|True|
|`RightControlTemplate`|ITemplate|Gets or sets the template for the "move right" control.|inner element, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Carousel

Carousel images have to be placed inside the `Items` property. It is a control default property so you can place the `<bs:CarouselItem>` elements directly
inside the `<bs:Carousel>` control. Each image is defined using the `CarouselItem` control.

The `CarouselItem` has the `IsActive` that specifies which image will be displayed first.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel>
        <bs:CarouselItem IsActive="true">
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

* The `Animation` property specifies which transitions between slides should be used - `Slide`, `Fade` or `None`.

* The `AutoSlideInterval` property sets the interval of automatic transitions in seconds. If this property is not set, the user has to switch the slides manually.

* The `RenderSideControls` property specifies whether the left and right controls which switch the slides will be rendered.

* The `RenderIndicators` property specifies whether the bottom active slide indicators should be rendered.

* The `PauseOnHover` property indicates whether the animation should be paused when the mouse cursor is over the carousel.

* The `CycleItems` property specifies whether the animation should continue when it reaches the last slide.


```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel RenderSideControls="false" RenderIndicators="true" 
                 Animation="Fade" AutoSlideInterval="3" 
                 PauseOnHover="false" CycleItems="false">
                 
        <bs:CarouselItem IsActive="true">
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

The `RightControlTemplate` and `LeftControlTemplate` you can specify your own buttons which will used instead the default ones.

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

## Sample 4: Captions

The `Caption` or the `CaptionTemplate` properties can be used to set description of the image.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel>
    
        <bs:CarouselItem>
            <CaptionTemplate>
                <h1>Los Angeles</h1>
                <p>On of the most beautiful cities on the west coast.</p>
            </CaptionTemplate>
            
            <bs:Image ImageUrl="~/Images/LA.jpg" />
        </bs:CarouselItem>
        
        <bs:CarouselItem Caption="{value: Caption}">
            <bs:Image ImageUrl="~/Images/NY.jpg" />
        </bs:CarouselItem>
        
    </bs:Carousel>

</div>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Carousel.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Caption { get; set; } = "New York";
    }
}
```

## Sample 5: Carousel Data-binding

The `Carousel` slides can also be loaded from a collection in the viewmodel. Use the `DataSource` property to specify the source collection.

Then use the `ImageUrlBinding` to specify which property of the collection item will be used as the URL of the image. 

Similarly, the `CaptionBinding` specifies which property will be the slide caption. Alternatively, you can use `CaptionTemplate` property to define a custom template for slide captions.

Finally the `IsActiveBinding` specifies which of the slides will be displayed first.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel DataSource="{value: Images}" 
                ImageUrlBinding="{value: Url}" 
                CaptionBinding="{value: Caption}"
                IsActiveBinding="{value: IsActive}" />

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

