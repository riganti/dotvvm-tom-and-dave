# <dot:ButtonToolbar>
Render a Bootstrap button toolbar which consists of one or more [ButtonGroup](~/controls/bootstrap5/ButtonGroup) or [InputGroup](~/controls/bootstrap5/InputGroup) controls.

<https://getbootstrap.com/docs/5.2/components/button-group/#button-toolbar>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<IButtonToolbarItem>|Gets or sets the inner elements containing only ButtonGroup and InputGroup controls.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`JustifyContentAll`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for all screens.|attribute, static value, bindable||
|`JustifyContentLarge`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for a large screen.|attribute, static value, bindable||
|`JustifyContentMedium`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for a medium screen.|attribute, static value, bindable||
|`JustifyContentSmall`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for a small screen.|attribute, static value, bindable||
|`JustifyContentXLarge`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for a very large screen.|attribute, static value, bindable||
|`JustifyContentXXLarge`|([BootstrapJustifyContent](../_enums/DotVVM.Bootstrap5.BootstrapJustifyContent.md))|Gets or sets the flexbox utility CSS class for the largest screen.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: ButtonToolbar Usage

Place `ButtonGroup` or `InputGroup` controls inside the toolbar element.

The `JustifyContent` property group allows to specify the alignment for the toolbar content for different screen sizes.


```DOTHTML
<bs:ButtonToolbar JustifyContentAll="Evenly">
  <bs:ButtonGroup Size="Default">
      <bs:Button Text="1" Type="secondary" VisualStyle="Outline" />
      <bs:Button Text="2" Type="secondary" VisualStyle="Outline" />
      <bs:Button Text="3" Type="secondary" VisualStyle="Outline" />
      <bs:Button Text="4" Type="secondary" VisualStyle="Outline" />
  </bs:ButtonGroup>
  <bs:InputGroup>
      <bs:InputGroupLiteral Text="@" />
      <bs:TextBox Placeholder="Input group example" Text="" />
  </bs:InputGroup>
</bs:ButtonToolbar>
```

