# <dot:TabItem>
Represents the tab item inside the Bootstrap [TabControl](~/controls/bootstrap5/TabControl).

<https://getbootstrap.com/docs/5.2/components/navs-tabs>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets a custom template for the tab content.|inner element, static value, default property||
|`ContentText`|String|Gets or sets a plain text for the tab content.|attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether the tab header is enabled or disabled.|attribute, static value, bindable|True|
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for the tab header.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for the tab header.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Selected`|Boolean|Gets or sets wether the tab is selected and its content is displayed.|attribute, static value, bindable||
|`UrlFragment`|String||attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: TabItem Control

Use the `<bs:TabItem>` controls inside the [TabControl](~/controls/bootstrap5/TabControl) control.

The header and content of each `TabItem` is defined using the `HeaderTemplate` and `ContentTemplate` properties.  

The `IsActive` property specifies whether the tab is currently selected or not.

The `Enabled` property specifies whether the tab can be selected.



```DOTHTML
<bs:TabControl>
  <bs:TabItem>
    <HeaderTemplate>Tab 1</HeaderTemplate>
      <p>First tab</p>
  </bs:TabItem>

  <bs:TabItem IsActive="true">
    <HeaderTemplate>Tab 2</HeaderTemplate>
      <p>Second tab</p>
  </bs:TabItem>

  <bs:TabItem Enabled="false">
    <HeaderTemplate>Tab 3</HeaderTemplate>
      <p>Third tab</p>
  </bs:TabItem>
</bs:TabControl>
```

