# <t:DockLayout>
Arranges content into `StartContent`, flexible center `Content`, and `EndContent` sections with orientation and spacing options.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([ItemAlignment](../_enums/DotVVM.Controls.Tailwind.ItemAlignment.md))|Controls how items are aligned on the cross axis inside the layout.|attribute, static value, bindable|Default|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|ITemplate|Template rendered in the center section of the layout.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EndContent`|ITemplate|Template rendered in the end section of the layout.|inner element, static value||
|`Gap`|([GapSize](../_enums/DotVVM.Controls.Tailwind.GapSize.md))|Controls the spacing between the rendered sections.|attribute, static value, bindable|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Justify`|([JustifyContent](../_enums/DotVVM.Controls.Tailwind.JustifyContent.md))|Controls how the start, center, and end sections are distributed on the main axis.|attribute, static value, bindable|Default|
|`Orientation`|([Orientation](../_enums/DotVVM.Controls.Tailwind.Orientation.md))|Controls whether the sections are arranged horizontally or vertically.|attribute, static value, bindable|Horizontal|
|`StartContent`|ITemplate|Template rendered in the start section of the layout.|inner element, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Start, center, and end regions

Shows the three content regions. The second example omits `Content`, leaving a flexible spacer between the start and end sections.


```DOTHTML
<div class="space-y-4">
    <t:DockLayout>
        <StartContent>
            <div class="bg-gray-700 text-white p-2 rounded">Filters</div>
        </StartContent>
        <Content>
            <div class="bg-info-700 text-white p-2 rounded">Flexible center content</div>
        </Content>
        <EndContent>
            <div class="bg-gray-700 text-white p-2 rounded">Actions</div>
        </EndContent>
    </t:DockLayout>

    <t:DockLayout>
        <StartContent>
            <div class="bg-gray-700 text-white p-2 rounded">Previous</div>
        </StartContent>
        <EndContent>
            <div class="bg-gray-700 text-white p-2 rounded">Next</div>
        </EndContent>
    </t:DockLayout>
</div>

```

## Sample 2: Orientation, gap, and alignment

Uses `Orientation`, `Gap`, and `Alignment` to change how the three regions are arranged.


```DOTHTML
<div class="space-y-4">
    <t:DockLayout Gap="Large" Alignment="Center" class="h-20 bg-gray-100 p-2">
        <StartContent><div class="bg-gray-700 text-white p-2 rounded">Start</div></StartContent>
        <Content><div class="bg-info-700 text-white p-2 rounded">Centered items</div></Content>
        <EndContent><div class="bg-gray-700 text-white p-2 rounded">End</div></EndContent>
    </t:DockLayout>

    <t:DockLayout Orientation="Vertical" Gap="Small" Alignment="Stretch">
        <StartContent><div class="bg-gray-700 text-white p-3 rounded">Header</div></StartContent>
        <Content><div class="bg-info-700 text-white p-3 rounded">Body</div></Content>
        <EndContent><div class="bg-gray-700 text-white p-3 rounded">Footer</div></EndContent>
    </t:DockLayout>
</div>

```

## Sample 3: Justify content

Shows several `Justify` values. This property is most useful when you want to change how the docked regions share the available horizontal space.


```DOTHTML
<div class="space-y-3">
    <t:DockLayout Justify="Start" class="bg-gray-100 p-2">
        <StartContent><div class="bg-gray-700 text-white p-2 rounded">Start</div></StartContent>
        <Content><div class="bg-info-700 text-white p-2 rounded">Content</div></Content>
        <EndContent><div class="bg-gray-700 text-white p-2 rounded">End</div></EndContent>
    </t:DockLayout>

    <t:DockLayout Justify="Center" class="bg-gray-100 p-2">
        <StartContent><div class="bg-gray-700 text-white p-2 rounded">Start</div></StartContent>
        <Content><div class="bg-info-700 text-white p-2 rounded">Content</div></Content>
        <EndContent><div class="bg-gray-700 text-white p-2 rounded">End</div></EndContent>
    </t:DockLayout>

    <t:DockLayout Justify="SpaceBetween" class="bg-gray-100 p-2">
        <StartContent><div class="bg-gray-700 text-white p-2 rounded">Start</div></StartContent>
        <Content><div class="bg-info-700 text-white p-2 rounded">Content</div></Content>
        <EndContent><div class="bg-gray-700 text-white p-2 rounded">End</div></EndContent>
    </t:DockLayout>
</div>

```

