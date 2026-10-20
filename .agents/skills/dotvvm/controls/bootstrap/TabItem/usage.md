# <bs:TabItem>
Represents the tab item inside the Bootstrap [TabControl](~/controls/bootstrap/TabControl).

<https://getbootstrap.com/docs/3.3/javascript/#tabs>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the template for content of the tab item.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the template for header of the tab item.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsActive`|Boolean|Gets or sets whether the tab item is active.|attribute, static value, bindable|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: TabItem Control

Use the `<bs:TabItem>` controls inside the [TabControl](~/controls/bootstrap/TabControl) control.

The header and content of each `TabItem` is defined using the `HeaderTemplate` and `ContentTemplate` properties.  

The `IsActive` property specifies whether the tab is currently selected or not.



```DOTHTML
<bs:TabControl>
  <bs:TabItem>
    <HeaderTemplate>Tab 1</HeaderTemplate>
    <ContentTemplate>
      <p>First tab</p>
    </ContentTemplate>
  </bs:TabItem>

  <bs:TabItem IsActive="true" >
    <HeaderTemplate>Tab 2</HeaderTemplate>
    <ContentTemplate>
      <p>Second tab</p>
    </ContentTemplate>
  </bs:TabItem>
</bs:TabControl>
```

