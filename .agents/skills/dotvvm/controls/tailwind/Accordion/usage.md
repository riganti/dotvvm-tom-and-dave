# <t:Accordion>
Renders collapsible sections using hard-coded `AccordionItem` children or a bound `DataSource`. Use `HeaderType`, `AllowMultiple`, and `IsExpanded` to control the presentation and expanded state.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowMultiple`|Boolean|When true, multiple accordion items can stay expanded at the same time.|attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the collection used to generate accordion items.|attribute, bindable||
|`HeaderType`|([AccordionHeaderType](../_enums/DotVVM.Controls.Tailwind.Controls.AccordionHeaderType.md))|Controls the visual style of accordion headers.|attribute, static value, bindable|Default|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemContentTemplate`|ITemplate|Gets or sets the expandable body content template for each generated accordion item.|inner element, static value||
|`ItemHeaderTemplate`|ITemplate|Gets or sets the custom header template rendered for each generated accordion item.|inner element, static value||
|`ItemHeaderText`|String|Gets or sets the header text displayed for each generated accordion item.|attribute, static value, bindable||
|`ItemIsExpanded`|Boolean|Gets or sets whether each generated accordion item is expanded.|attribute, static value, bindable|False|
|`Items`|List<AccordionItem>|Gets or sets the accordion items declared directly inside the control.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Accordion

Shows a simple accordion with three items and plain text headers.



```DOTHTML
<div class="max-w-xl">
    <t:Accordion>
        <t:AccordionItem HeaderText="What is DotVVM?">
            <ContentTemplate>
                <p>DotVVM is an MVVM framework for ASP.NET that lets you build rich web apps without writing JavaScript by hand.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="What is Tailwind CSS?">
            <ContentTemplate>
                <p>Tailwind CSS is a utility-first framework for quickly building custom interfaces in markup.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="Can I use them together?">
            <ContentTemplate>
                <p>Yes. This library combines DotVVM controls with Tailwind styling.</p>
            </ContentTemplate>
        </t:AccordionItem>
    </t:Accordion>
</div>


```

## Sample 2: Data-bound items

Binds the accordion to a collection with `DataSource`, `ItemHeaderText`, `ItemContentTemplate`, and `ItemIsExpanded`. This is the current API for generating accordion items from viewmodel data.


```DOTHTML
<t:Accordion DataSource="{value: FaqItems}" 
             ItemHeaderText="{value: Question}" 
             ItemIsExpanded="{value: IsInitiallyExpanded}">
    <ItemContentTemplate>
        <p>{{value: Answer}}</p>
    </ItemContentTemplate>
</t:Accordion>

```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public List<FaqItem> FaqItems { get; set; } = new()
    {
        new() { Question = "What is DotVVM?", Answer = "DotVVM is an MVVM framework for ASP.NET Core applications.", IsInitiallyExpanded = true },
        new() { Question = "Why use the Tailwind package?", Answer = "It provides ready-made Tailwind-styled controls for common UI patterns." },
        new() { Question = "Can items start opened?", Answer = "Yes. Bind ItemIsExpanded to a boolean property on each item." }
    };

    public class FaqItem
    {
        public string Question { get; set; } = "";
        public string Answer { get; set; } = "";
        public bool IsInitiallyExpanded { get; set; }
    }
}

```

## Sample 3: Allow Multiple

Sets `AllowMultiple="true"` so multiple items can stay open simultaneously.



```DOTHTML
<div class="max-w-xl">
    <t:Accordion AllowMultiple="true">
        <t:AccordionItem HeaderText="Section A" IsExpanded="true">
            <ContentTemplate>
                <p>Content for section A. Other sections can also be open at the same time.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="Section B" IsExpanded="true">
            <ContentTemplate>
                <p>Content for section B. Both A and B start expanded here.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="Section C">
            <ContentTemplate>
                <p>Content for section C.</p>
            </ContentTemplate>
        </t:AccordionItem>
    </t:Accordion>
</div>


```

## Sample 4: Numbered Headers

Enables header numbering with `HeaderType="Numbered"`.


```DOTHTML
<div class="max-w-xl">
    <t:Accordion HeaderType="Numbered">
        <t:AccordionItem HeaderText="First item">
            <ContentTemplate>
                <p>First item's body content.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="Second item">
            <ContentTemplate>
                <p>Second item's body content.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="Third item">
            <ContentTemplate>
                <p>Third item's body content.</p>
            </ContentTemplate>
        </t:AccordionItem>
    </t:Accordion>
</div>

```

## Sample 5: Bound IsExpanded

Binds `IsExpanded` to viewmodel properties and toggles them using commands.



```DOTHTML
<div class="max-w-xl">
    <t:Accordion AllowMultiple="true">
        <t:AccordionItem HeaderText="Bound to IsFirstOpen" IsExpanded="{value: IsFirstOpen}">
            <ContentTemplate>
                <p>Current state: <dot:Literal Text="{value: IsFirstOpen}" /></p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem HeaderText="Bound to IsSecondOpen" IsExpanded="{value: IsSecondOpen}">
            <ContentTemplate>
                <p>Current state: <dot:Literal Text="{value: IsSecondOpen}" /></p>
            </ContentTemplate>
        </t:AccordionItem>
    </t:Accordion>
</div>

<div class="flex gap-2 mt-3">
    <t:Button Type="Secondary" Text="Toggle First" Click="{command: IsFirstOpen = !IsFirstOpen}" />
    <t:Button Type="Secondary" Text="Toggle Second" Click="{command: IsSecondOpen = !IsSecondOpen}" />
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;

public class ViewModel : DotvvmViewModelBase
{
    public bool IsFirstOpen { get; set; } = true;

    public bool IsSecondOpen { get; set; } = false;
}


```

## Sample 6: Custom Header Template

Uses `HeaderTemplate` to render custom header content with other controls.



```DOTHTML
<div class="max-w-xl">
    <t:Accordion>
        <t:AccordionItem>
            <HeaderTemplate>
                <span class="flex items-center gap-2">
                    <span>⚙️</span>
                    <strong>Settings</strong>
                    <t:Badge Text="New" Color="Primary" />
                </span>
            </HeaderTemplate>
            <ContentTemplate>
                <p>Use HeaderTemplate for rich header content.</p>
            </ContentTemplate>
        </t:AccordionItem>
        <t:AccordionItem>
            <HeaderTemplate>
                <span class="flex items-center gap-2">
                    <span>📋</span>
                    <strong>Details</strong>
                </span>
            </HeaderTemplate>
            <ContentTemplate>
                <p>This item shows another custom header layout.</p>
            </ContentTemplate>
        </t:AccordionItem>
    </t:Accordion>
</div>


```

