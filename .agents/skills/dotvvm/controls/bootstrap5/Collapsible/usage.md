# <dot:Collapsible>
A Bootstrap collapse element.

<https://getbootstrap.com/docs/5.2/components/collapse/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<DotvvmControl>|Gets or sets the content inside the collapsible element.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IsExpanded`|IValueBinding<Boolean>|Gets or sets whether the content is collapsed or not.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Collapsible

Put the collapsible content inside the control.

The `IsExpanded` property specifies whether the content is collapsed or expanded. The easiest way to expand or collapse is to use a link or button and switch the property using [Static Command Binding](~/pages/concepts/respond-to-user-actions/static-commands).



```DOTHTML
<dot:LinkButton Click="{staticCommand: IsExpanded = !IsExpanded}" Text="Expand or collapse" />

<bs:Collapsible IsExpanded="{value: IsExpanded}">
  Collapsible content
</bs:Collapsible>
```

```CSHARP
public class ViewModel
{
    public bool IsExpanded { get; set; }

}

```

