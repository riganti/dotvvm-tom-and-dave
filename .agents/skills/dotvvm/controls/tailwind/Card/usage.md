# <t:Card>
Renders a styled card with optional header, image, footer, semantic variant, and linked-card behavior. Use `Orientation`, `Type`, and `NavigateUrl` to switch between the main presentation modes.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Main content template rendered inside the card body.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Footer template rendered at the bottom of the card body.|inner element, static value||
|`HeaderTemplate`|ITemplate|Gets or sets the custom content rendered in the card header.|inner element, static value||
|`HeaderText`|String|Gets or sets the text displayed in the card header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageAlt`|String|Alternative text for the card image.|attribute, static value, bindable||
|`ImageUrl`|String|Optional image URL rendered at the top of the card.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`NavigateUrl`|String|Optional URL that turns the whole card into a link.|attribute, static value, bindable||
|`NewTab`|Boolean|When true, opens  in a new tab.|attribute, static value, bindable|False|
|`Orientation`|([Orientation](../_enums/DotVVM.Controls.Tailwind.Orientation.md))|Determines whether the card uses vertical or horizontal layout.|attribute, static value, bindable|Vertical|
|`Type`|([TailwindColor](../_enums/DotVVM.Controls.Tailwind.TailwindColor.md))|Semantic card styling variant.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Card

Shows a basic card with header, content, and a footer action.


```DOTHTML
<div class="max-w-sm">
    <t:Card HeaderText="Card Title">
        <ContentTemplate>
            <p>This is the card content. It can contain any HTML or controls.</p>
        </ContentTemplate>
        <FooterTemplate>
            <a class="button button-primary" href="?card=basic">Action</a>
        </FooterTemplate>
    </t:Card>
</div>

```

## Sample 2: Multiple Cards

Shows a responsive grid with multiple cards.



```DOTHTML
<div class="grid gap-4" style="grid-template-columns: repeat(auto-fill, minmax(260px, 1fr));">
    <t:Card HeaderText="Card 1">
        <ContentTemplate>
            <p>First card content.</p>
        </ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Card 2">
        <ContentTemplate>
            <p>Second card content.</p>
        </ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Card 3">
        <ContentTemplate>
            <p>Third card content.</p>
        </ContentTemplate>
    </t:Card>
</div>


```

## Sample 3: Card with Image

Demonstrates `ImageUrl` and `ImageAlt` using both static values and bindings.



```DOTHTML
<div class="grid gap-4" style="grid-template-columns: repeat(auto-fill, minmax(260px, 1fr));">
    <t:Card HeaderText="Static Image" ImageUrl="https://picsum.photos/400/200" ImageAlt="Sample image">
        <ContentTemplate>
            <p>This card has a hard-coded image URL.</p>
        </ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Dynamic Image" ImageUrl="{value: DynamicImageUrl}" ImageAlt="{value: DynamicImageAlt}">
        <ContentTemplate>
            <p>This card binds ImageUrl and ImageAlt from the viewmodel.</p>
        </ContentTemplate>
    </t:Card>
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public string DynamicImageUrl { get; set; } = "https://picsum.photos/400/200?random=1";

    public string DynamicImageAlt { get; set; } = "Dynamic image";
}


```

## Sample 4: Horizontal Card

Shows the horizontal layout using `Orientation="Horizontal"`. The card still uses the same `Header*`, `ContentTemplate`, `FooterTemplate`, and image properties.


```DOTHTML
<div class="max-w-xl">
    <t:Card Orientation="Horizontal" ImageUrl="https://picsum.photos/200/300" ImageAlt="Sample horizontal image" HeaderText="Horizontal Card">
        <ContentTemplate>
            <p>Image on the left, content on the right side of the card.</p>
        </ContentTemplate>
        <FooterTemplate>
            <a class="button button-primary" href="?layout=horizontal">Learn more</a>
        </FooterTemplate>
    </t:Card>
</div>

```

## Sample 5: Colored Cards

Applies semantic variants using the current `Type` property.


```DOTHTML
<div class="grid gap-4" style="grid-template-columns: repeat(auto-fill, minmax(260px, 1fr));">
    <t:Card HeaderText="Primary" Type="Primary">
        <ContentTemplate><p>Primary color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Success" Type="Success">
        <ContentTemplate><p>Success color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Warning" Type="Warning">
        <ContentTemplate><p>Warning color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Danger" Type="Danger">
        <ContentTemplate><p>Danger color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Info" Type="Info">
        <ContentTemplate><p>Info color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Secondary" Type="Secondary">
        <ContentTemplate><p>Secondary color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Dark" Type="Dark">
        <ContentTemplate><p>Dark color card.</p></ContentTemplate>
    </t:Card>
    <t:Card HeaderText="Light" Type="Light">
        <ContentTemplate><p>Light color card.</p></ContentTemplate>
    </t:Card>
</div>

```

## Sample 6: Custom Header Template

Uses `HeaderTemplate` to render custom header content.



```DOTHTML
<div class="max-w-sm">
    <t:Card>
        <HeaderTemplate>
            <div class="flex items-center gap-2">
                <strong>Settings</strong>
                <t:Badge Text="New" Color="Primary" />
            </div>
        </HeaderTemplate>
        <ContentTemplate>
            <p>This card uses HeaderTemplate for custom header content.</p>
        </ContentTemplate>
    </t:Card>
</div>


```

## Sample 7: Card as Link

Uses `NavigateUrl` and `NewTab` so the whole card acts as a link. Avoid nesting `<a>` tags inside a linked card because the root element already renders as an anchor.


```DOTHTML
<div class="max-w-sm">
    <t:Card HeaderText="Linked Card" ImageUrl="https://picsum.photos/400/200" ImageAlt="Sample image" NavigateUrl="?card=linked" NewTab="true">
        <ContentTemplate>
            <p>This card uses NavigateUrl so the whole surface works as a link inside the sample app.</p>
        </ContentTemplate>
    </t:Card>
</div>

```

