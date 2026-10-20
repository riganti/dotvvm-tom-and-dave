# <bs:Jumbotron>
Renders the Bootstrap jumbotron widget.

<https://getbootstrap.com/docs/4.3/components/jumbotron/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsFluid`|Boolean|Gets or sets whether the jumbotron should take full width and render without rounded corners, or not.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Usage

The content placed inside the control will be styled as the Bootstrap jumbotron (gray box with rounded corners which enlarges the font sizes of the text inside it).

The `IsFluid` property can make the jumbotron take fill width and remove its rounded corners.

```DOTHTML
<bs:Jumbotron IsFluid="true">
  <h3>Important text</h3>
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam dictum at lorem et tristique. Ut tempor mattis pretium.</p>
  <p>Aenean sit amet enim urna. Donec id massa eu nulla bibendum ultricies non vitae augue. Etiam consequat venenatis urna, viverra egestas est congue ut. Cras dapibus, magna eget ultricies egestas, ipsum massa euismod lectus, quis luctus felis dui sodales sem. Donec quam lectus, tempor id dictum eu, placerat eleifend mi.</p>
</bs:Jumbotron>
```

