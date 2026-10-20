# <bs:Container>
Renders a Bootstrap container component.

<https://getbootstrap.com/docs/4.3/layout/overview/#containers>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([BootstrapContainerType](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapContainerType.md))|Gets or sets the type of the container - fluid or normal.|attribute, static value|Normal|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Normal vs Fluid Container

The `Type` property specifies the behavior of the `Container` for wide pages.

* `Normal` type limits the maximum page width. If the window is wider, the content is not resized beyond the maximum width and it is centered.
* `Fluid` type always utilizes the available horizontal space.

```DOTHTML
<bs:Container Type="Fluid">
  <p>
    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam quis nulla. Aenean vel massa quis mauris vehicula lacinia. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Aliquam erat volutpat. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. In rutrum. Maecenas sollicitudin. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
  </p>
</bs:Container>

```

