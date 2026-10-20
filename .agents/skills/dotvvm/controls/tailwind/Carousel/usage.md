# <t:Carousel>
Displays a carousel from hard-coded slides or a bound `DataSource`. Use `HideNavigation`, `HideIndicators`, `HideTextOrContent`, `AutoCycleInterval`, and `UseAspectRatio` to adjust the current Tailwind carousel behavior.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AutoCycleInterval`|Int32|Gets or sets the autoplay interval in milliseconds. Set to 0 to disable autoplay.|attribute, static value|0|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the data source used to generate carousel items.|attribute, bindable||
|`HideIndicators`|Boolean|Gets or sets whether the indicator buttons below the carousel are hidden.|attribute, static value|False|
|`HideNavigation`|Boolean|Gets or sets whether the previous and next buttons are hidden.|attribute, static value|False|
|`HideTextOrContent`|Boolean|Gets or sets whether slide text or content is hidden.|attribute, static value|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemContent`|List<DotvvmControl>|Gets or sets the slide caption content when DataSource is used.|inner element, static value||
|`ItemImageUrl`|String|Gets or sets the background image URL for each generated slide.|attribute, static value, bindable||
|`Items`|List<CarouselItem>|Gets or sets the hardcoded carousel items.|inner element, static value, default property||
|`ItemText`|String|Gets or sets the slide caption text when DataSource is used.|attribute, static value, bindable||
|`UseAspectRatio`|String|Gets or sets the CSS aspect-ratio value applied to each slide.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic carousel

A basic `Carousel` with hard-coded `CarouselItem` children. The first slide uses the plain `Text` property, while the others use inner content for richer captions.


```DOTHTML
<t:Carousel>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1018/1200/800" Text="Scenic mountain at golden hour" />
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1025/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Wild Nature</h3>
        <p class="text-base text-white/80 line-clamp-1">A young bear cub exploring its natural forest habitat.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1037/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Misty Forest</h3>
        <p class="text-base text-white/80 line-clamp-1">Ancient trees wrapped in morning fog deep in the wilderness.</p>
    </t:CarouselItem>
</t:Carousel>

```

## Sample 2: Data-bound slides

Binds the carousel to a collection using `DataSource`, `ItemImageUrl`, and `ItemText`. This is the current API for generating slides from the viewmodel.


```DOTHTML
<t:Carousel DataSource="{value: Slides}"
            ItemImageUrl="{value: ImageUrl}"
            ItemText="{value: Title}" />

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public List<SlideData> Slides { get; set; } = new()
    {
        new() { Title = "Scenic mountain", ImageUrl = "https://picsum.photos/id/1018/1200/800" },
        new() { Title = "Wild nature", ImageUrl = "https://picsum.photos/id/1025/1200/800" },
        new() { Title = "Misty forest", ImageUrl = "https://picsum.photos/id/1037/1200/800" }
    };

    public class SlideData
    {
        public string Title { get; set; } = "";
        public string ImageUrl { get; set; } = "";
    }
}

```

## Sample 3: Custom aspect ratio

Sets `UseAspectRatio` to a CSS `aspect-ratio` value. The current API expects a string such as `4 / 3` or `16 / 9`, not a boolean flag.


```DOTHTML
<t:Carousel UseAspectRatio="4 / 3">
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1018/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Scenic Mountain</h3>
        <p class="text-base text-white/80 line-clamp-1">Breathtaking views from the Alpine peaks at golden hour.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1025/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Wild Nature</h3>
        <p class="text-base text-white/80 line-clamp-1">A young bear cub exploring its natural forest habitat.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1037/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Misty Forest</h3>
        <p class="text-base text-white/80 line-clamp-1">Ancient trees wrapped in morning fog deep in the wilderness.</p>
    </t:CarouselItem>
</t:Carousel>

```

## Sample 4: Hidden navigation UI

Hides both the previous/next buttons and the indicator dots using `HideNavigation="true"` and `HideIndicators="true"`.


```DOTHTML
<t:Carousel HideNavigation="true" HideIndicators="true">
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1018/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Scenic Mountain</h3>
        <p class="text-base text-white/80 line-clamp-1">Breathtaking views from the Alpine peaks at golden hour.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1025/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Wild Nature</h3>
        <p class="text-base text-white/80 line-clamp-1">A young bear cub exploring its natural forest habitat.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1037/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Misty Forest</h3>
        <p class="text-base text-white/80 line-clamp-1">Ancient trees wrapped in morning fog deep in the wilderness.</p>
    </t:CarouselItem>
</t:Carousel>

```

## Sample 5: No caption

Set `HideTextOrContent="true"` to suppress the caption overlay even when the slides define `Text` or inner content.


```DOTHTML
<t:Carousel HideTextOrContent="true">
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1018/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Scenic Mountain</h3>
        <p class="text-base text-white/80 line-clamp-1">Breathtaking views from the Alpine peaks at golden hour.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1025/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Wild Nature</h3>
        <p class="text-base text-white/80 line-clamp-1">A young bear cub exploring its natural forest habitat.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1037/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Misty Forest</h3>
        <p class="text-base text-white/80 line-clamp-1">Ancient trees wrapped in morning fog deep in the wilderness.</p>
    </t:CarouselItem>
</t:Carousel>

```

## Sample 6: Auto cycle

Set `AutoCycleInterval` to a positive number of milliseconds to auto-advance slides.



```DOTHTML
<t:Carousel AutoCycleInterval="3000">
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1018/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Scenic Mountain</h3>
        <p class="text-base text-white/80 line-clamp-1">Breathtaking views from the Alpine peaks at golden hour.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1025/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Wild Nature</h3>
        <p class="text-base text-white/80 line-clamp-1">A young bear cub exploring its natural forest habitat.</p>
    </t:CarouselItem>
    <t:CarouselItem ImageUrl="https://picsum.photos/id/1037/1200/800">
        <h3 class="text-xl font-semibold mb-1 line-clamp-1">Misty Forest</h3>
        <p class="text-base text-white/80 line-clamp-1">Ancient trees wrapped in morning fog deep in the wilderness.</p>
    </t:CarouselItem>
</t:Carousel>

```

