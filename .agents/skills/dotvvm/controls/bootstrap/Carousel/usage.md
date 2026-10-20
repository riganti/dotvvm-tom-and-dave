# <bs:Carousel>
Renders a Bootstrap carousel widget.

<https://getbootstrap.com/docs/3.3/javascript/#carousel>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoSlideInterval`|Int32?|Gets or sets interval (in seconds) of changing slides.|attribute, static value||
|`CaptionBinding`|IValueBinding|Gets or sets a value binding that points to a property that contains the image caption.|attribute, bindable||
|`CaptionTemplateBinding`|IValueBinding|Gets or sets a value binding that points to a property that contains the image caption HTML.|attribute, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EnableAnimation`|Boolean|Gets or sets whether the transitions between the slides should be animated or not.|attribute, static value|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrlBinding`|IValueBinding|Gets or sets a value binding that points to a property that contains the URL of the image.|attribute, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsActiveBinding`|IValueBinding|Gets or sets a value binding that points to a property indicating whether the item is active or not.|attribute, bindable||
|`LeftControlTemplate`|ITemplate|Gets or sets the template for the "move left" control.|inner element, static value||
|`RenderIndicators`|Boolean|Gets or sets whether the dots indicating the current slide will be rendered.|attribute, static value|True|
|`RenderSideControls`|Boolean|Gets or sets whether the controls for changing the slides will be rendered.|attribute, static value|True|
|`RightControlTemplate`|ITemplate|Gets or sets the template for the "move right" button.|inner element, static value||
|`SlidesTemplate`|ITemplate|Gets or sets the template of the individual slides inside the control.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Carousel

Carousel images have to be placed inside the `SlidesTemplate` property. It is a control default property so you can place the `<bs:CarouselItem>` elements directly
inside the `<bs:Carousel>` control. Each image is defined using the `CarouselItem` control.

The `CarouselItem` has the `IsActive` that specifies which image will be displayed first.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel>
        <SlidesTemplate>
        
            <bs:CarouselItem IsActive="true">
                <bs:Image ImageUrl="~/Images/LA.jpg" />
            </bs:CarouselItem>
        
            <bs:CarouselItem>
                <bs:Image ImageUrl="~/Images/NY.jpg" />
            </bs:CarouselItem>
        
            <bs:CarouselItem>
                <bs:Image ImageUrl="~/Images/Miami.jpg" />
            </bs:CarouselItem>
    
        </SlidesTemplate>
    </bs:Carousel>

</div>
```

## Sample 2: Carousel Settings

The `Carousel` control has the following properties:

* The `RenderSideControls` property specifies whether the left and right controls which switch the slides will be rendered.

* The `EnableAnimation` property specifies whether the transitions between slides are animated or not.

* The `AutoSlideInterval` property sets the interval of automatic transitions in seconds. If this property is not set, the user has to switch the slides manually.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel RenderSideControls="false" EnableAnimation="false" AutoSlideInterval="3">
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
        <SlidesTemplate>
        
            <bs:CarouselItem IsActive="true">
                <bs:Image ImageUrl="~/Images/LA.jpg" />
            </bs:CarouselItem>
        
            <bs:CarouselItem>
                <bs:Image ImageUrl="~/Images/NY.jpg" />
            </bs:CarouselItem>
        
            <bs:CarouselItem>
                <bs:Image ImageUrl="~/Images/Miami.jpg" />
            </bs:CarouselItem>
        
        </SlidesTemplate>
    
        <RightControlTemplate>
            <span class="glyphicon glyphicon-hand-right" aria-hidden="true"></span>
        </RightControlTemplate>
    
        <LeftControlTemplate>
            <span class="glyphicon glyphicon-hand-left" aria-hidden="true"></span>
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

Similarly, the `CaptionBinding` property can specify which property will be the slide caption, and finally the `IsActiveBinding` specifies which of the slides will be displayed first.

```DOTHTML
<div style="height: 428px; width: 640px;">

    <bs:Carousel DataSource="{value: Images}" 
                 ImageUrlBinding="{value: URL}"
                 CaptionBinding="{value: Caption}"
                 IsActiveBinding="{value: Active}"/>

</div>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Carousel.sample5
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
            Active = active;
            URL = url;
            Caption = caption;
        }

        public string Caption { get; set; }
        public bool Active { get; set; }
        public string URL { get; set; }
    }
}
```

