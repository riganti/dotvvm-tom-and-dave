# <bs:Collapsible>
A Bootstrap collapse element.

<https://getbootstrap.com/docs/4.3/components/collapse/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsCollapsed`|Boolean|Gets or sets whether the content is collapsed or not.|attribute, bindable|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Collapsible

Put the collapsible content inside the control.

The `IsCollapsed` property specifies whether the content is collapsed or expanded. The easiest way to expand or collapse is to use a link or button and switch the property using [Static Command Binding](~/pages/concepts/respond-to-user-actions/static-commands).



```DOTHTML
<dot:LinkButton Click="{staticCommand: IsCollapsed = !IsCollapsed}" Text="Expand or collapse" />

<bs:Collapsible IsCollapsed="{value: IsCollapsed}">
  Collapsible content
</bs:Collapsible>
```

```CSHARP
public class ViewModel
{
    public bool IsCollapsed { get; set; } = true;

}

```

