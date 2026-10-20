# <t:StackLayout>
Renders a flexbox stack that can switch orientation, wrapping, spacing, alignment, and justification.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Alignment`|([ItemAlignment](../_enums/DotVVM.Controls.Tailwind.ItemAlignment.md))|Controls how child controls are aligned on the cross axis.|attribute, static value, bindable|Default|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Child controls rendered inside the stack layout.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Gap`|([GapSize](../_enums/DotVVM.Controls.Tailwind.GapSize.md))|Controls the spacing between child controls.|attribute, static value, bindable|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Justify`|([JustifyContent](../_enums/DotVVM.Controls.Tailwind.JustifyContent.md))|Controls how child controls are distributed on the main axis.|attribute, static value, bindable|Default|
|`Orientation`|([Orientation](../_enums/DotVVM.Controls.Tailwind.Orientation.md))|Controls whether the children are arranged vertically or horizontally.|attribute, static value, bindable|Vertical|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Wrap`|Boolean|When true, items can wrap onto additional lines; when false, they stay on a single line.|attribute, static value|True|

## Sample 1: Orientation and wrapping

Shows vertical and horizontal stacks and demonstrates the `Wrap` property in a constrained width.


```DOTHTML
<div class="space-y-4">
    <t:StackLayout>
        <t:Button Type="Primary" Text="Overview" />
        <t:Button Type="Secondary" Text="Reports" />
        <t:Button Type="Success" Text="Settings" />
    </t:StackLayout>

    <div class="w-64 border rounded p-2">
        <t:StackLayout Orientation="Horizontal">
            <t:Button Type="Primary" Text="Alpha" />
            <t:Button Type="Secondary" Text="Beta" />
            <t:Button Type="Success" Text="Gamma" />
            <t:Button Type="Warning" Text="Delta" />
        </t:StackLayout>
    </div>

    <div class="w-64 border rounded p-2 overflow-x-auto">
        <t:StackLayout Orientation="Horizontal" Wrap="false">
            <t:Button Type="Primary" Text="No wrap" />
            <t:Button Type="Secondary" Text="Keeps items" />
            <t:Button Type="Success" Text="On one line" />
        </t:StackLayout>
    </div>
</div>

```

## Sample 2: Gap and alignment

Uses `Gap` and `Alignment` to control spacing and cross-axis positioning.


```DOTHTML
<div class="space-y-3">
    <t:StackLayout Orientation="Horizontal" Gap="Large" class="bg-gray-100 p-2">
        <t:Button Type="Primary" Text="Large" />
        <t:Button Type="Primary" Text="Gap" />
        <t:Button Type="Primary" Text="Example" />
    </t:StackLayout>

    <t:StackLayout Orientation="Horizontal" Alignment="Center" class="h-20 bg-gray-100 p-2">
        <t:Button Type="Success" Text="Center" />
        <t:Button Type="Secondary" Text="Aligned" />
    </t:StackLayout>

    <t:StackLayout Orientation="Horizontal" Alignment="Stretch" Gap="Small" class="h-20 bg-gray-100 p-2">
        <t:Button Type="Warning" Text="Stretch" class="h-full" />
        <t:Button Type="Danger" Text="Items" class="h-full" />
    </t:StackLayout>
</div>

```

## Sample 3: Justify content

Shows common `Justify` values for horizontal stacks.


```DOTHTML
<div class="space-y-3">
    <t:StackLayout Orientation="Horizontal" Justify="Start" class="bg-gray-100 p-2">
        <t:Button Type="Primary" Text="Start" />
        <t:Button Type="Secondary" Text="Layout" />
    </t:StackLayout>

    <t:StackLayout Orientation="Horizontal" Justify="Center" class="bg-gray-100 p-2">
        <t:Button Type="Primary" Text="Center" />
        <t:Button Type="Secondary" Text="Layout" />
    </t:StackLayout>

    <t:StackLayout Orientation="Horizontal" Justify="SpaceBetween" class="bg-gray-100 p-2">
        <t:Button Type="Primary" Text="Space" />
        <t:Button Type="Secondary" Text="Between" />
        <t:Button Type="Success" Text="Items" />
    </t:StackLayout>
    
    <t:StackLayout Orientation="Horizontal" Justify="SpaceEvenly" class="bg-gray-100 p-2">
        <t:Button Type="Primary" Text="Space" />
        <t:Button Type="Secondary" Text="Evenly" />
    </t:StackLayout>
</div>

```

