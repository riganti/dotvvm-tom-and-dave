# <dot:Offcanvas>
Renders a Bootstrap offcanvas component.

<https://getbootstrap.com/docs/5.2/components/offcanvas/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Backdrop`|([OffcanvasBackdrop](../_enums/DotVVM.Bootstrap5.Controls.OffcanvasBackdrop.md))|Gets or sets a backdrop settings. Page content srolling can be enabled or disabled.|attribute, static value|Backdrop|
|`BodyTemplate`|ITemplate|Gets or sets the content inside the Offcanvas body.|inner element, static value||
|`BodyText`|String|Gets or sets a plain text inside the Offcanvas body.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the content inside the Offcanvas header.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text inside the Offcanvas header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsExpanded`|IValueBinding<Boolean>|A boolean binding that gets or sets whether the Offcanvas is expanded.|attribute, bindable||
|`Placement`|([OffcanvasPlacement](../_enums/DotVVM.Bootstrap5.Controls.OffcanvasPlacement.md))|Gets or sets the Offcanvas position.|attribute, static value|Left|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Placement

Offcanvas is a sidebar component that can be toggled to appear from the `Left`, `Right`, `Top`, or `Bottom` edge of the viewport by property `Placement`. 

Required property to work with Offcanvas is property `IsCollapsed`, which is `true` when offcanvas is hidden and `false` when is shown.

```DOTHTML

<bs:Offcanvas HeaderText="Header" BodyText="Body Text" IsCollapsed="{value: IsCollapsed}" Placement="Top" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool IsCollapsed { get; set; } = true;
}

```

## Sample 2: Offcanvas text

The header content of Offcanvas can be set by one of two ways: using the `HeaderText` property or using `HeaderTemplate`.  

The main content can be set using `Text` or `ContentTemplate`.  This property is required, so it must be set.

```DOTHTML

<bs:Offcanvas HeaderText="Sample Header" BodyText="This is body text of offcanvas component" IsCollapsed="{value: IsCollapsed}" />

<bs:Offcanvas HeaderText="{value: HeaderText}" BodyText="{value: BodyText}" IsCollapsed="{value: IsCollapsed2}" />

<bs:Offcanvas IsCollapsed="{value: IsCollapsed3}">
    <HeaderTemplate>
        <h2>Custom header</h2>
        <bs:Button Click="{staticCommand: IsCollapsed3 = !IsCollapsed3}" Text="Close" />
    </HeaderTemplate>
    <BodyTemplate>
        <bs:Button Click="{staticCommand: IsCollapsed3 = !IsCollapsed3}" Text="Another close button" />
        <p>Bustom body content</p>
    </BodyTemplate>
</bs:Offcanvas>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool IsCollapsed { get; set; } = true;
    public bool IsCollapsed2 { get; set; } = true;
    public bool IsCollapsed3 { get; set; } = true;
    public string BodyText { get; set; } = "Bindable Body Text";
    public string HeaderText { get; set; } = "Bindable Header Text";
}

```

## Sample 3: Scrolling

Scrolling the `body` element is disabled when an offcanvas and its backdrop are visible. Use the property `BackDrop` attribute to enable `body` scrolling.

- `BodyScrolling` to enable `body` scrolling 
- `BackDrop` to disable `body` scrolling with visible backdrop
- `BodyScrollingAndBackdrop` to enable `body` scrolling with visible backdrop

```DOTHTML

<bs:Offcanvas BackDrop="BodyScrolling" IsCollapsed="{value: Scrolling}" BodyText="Body Scrolling" HeaderText="BodyScrolling"/>
<bs:Offcanvas BackDrop="Backdrop" IsCollapsed="{value: Drop}" BodyText="Backdrop" HeaderText="With Backdrop"/>
<bs:Offcanvas BackDrop="BodyScrollingAndBackdrop" IsCollapsed="{value: Scrollingdrop}" BodyText="Body Scrooling and Backdrop" HeaderText="BodyScrolling and Backdrop"/>

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public bool Scrolling { get; set; } = true;
    public bool Drop { get; set; } = true;
    public bool Scrollingdrop { get; set; } = true;
}

```

