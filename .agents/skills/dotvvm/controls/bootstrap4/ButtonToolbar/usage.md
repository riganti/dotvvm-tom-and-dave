# <bs:ButtonToolbar>
Render a Bootstrap button toolbar which consists of one or more [ButtonGroup](~/controls/bootstrap4/ButtonGroup) or [InputGroup](~/controls/bootstrap4/InputGroup) controls.

<https://getbootstrap.com/docs/4.3/components/button-group/#button-toolbar>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Items`|List<IButtonToolbarItem>|Gets or sets the contents of the button toolbar.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: ButtonToolbar Usage

Place `ButtonGroup` or `InputGroup` controls inside the toolbar element.

The `HorizontalAlignment` property allows to specify the alignment for the toolbar content.

* `Start` aligns the items to the left.
* `Center` aligns the items to the middle.
* `End` aligns the items to the right.
* `Around` distributes the remaining space equally around every items.
* `Between` distributes the remaining space equally in the gaps between items.

```DOTHTML
<bs:ButtonToolbar>
  <bs:ButtonGroup>
    <bs:Button Text="Button 1" Type="Primary" />
    <bs:Button Text="Button 2" Type="Secondary" />
  </bs:ButtonGroup>
  <bs:InputGroup>
    <LeftTemplate>
      <bs:InputGroupLiteral Text="@" />
    </LeftTemplate>
    <ContentTemplate>
      <bs:InputGroupTextBox Text="" />
    </ContentTemplate>
  </bs:InputGroup>
</bs:ButtonToolbar>
```

