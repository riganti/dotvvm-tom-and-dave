# <bs:Container>
Renders a Bootstrap container component.

<https://getbootstrap.com/docs/3.3/css/#grid>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`NumberOfColumns`|Int32|Gets or sets the number of columns in the Bootstrap column system. The default value is 12.             Change this property if you are using a customized version of Bootstrap with different number of columns.|attribute, static value|12|
|`Type`|([ContainerType](../_enums/DotVVM.Framework.Controls.Bootstrap.ContainerType.md))|Gets or sets the type of the container - fluid or normal.|attribute, static value|Normal|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Fluid Container

The Container has the `Type` property which specifies the behavior of the Container for large page sizes.

The `Normal` type limits the maximum page width. If the window is wider, the content is not resized beyond the maximum width and it is centered.

The `Fluid` type always utilizes the available horizontal space.

```DOTHTML
<bs:Container Type="Fluid">
  <p>
    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam quis nulla. Aenean vel massa quis mauris vehicula lacinia. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Aliquam erat volutpat. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. In rutrum. Maecenas sollicitudin. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
  </p>
</bs:Container>

```

## Sample 2: Custom Number of Columns

By default, the Bootstrap has 12 columns in the grid system. However, sometimes it may be wise to modify this value and customize Bootstrap
to have a different number of columns. Because some controls (e.g. [Form](~/controls/bootstrap/Form) have to know the number of columns 
in the grid system, use the `NumberOfColumns` property.


```DOTHTML
<bs:Container NumberOfColumns="50">
  <bs:Column SizeXS="20" SizeLG="17">
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam quis nulla. Aenean vel massa quis mauris vehicula lacinia. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Aliquam erat volutpat. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. In rutrum. Maecenas sollicitudin. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos.</p>
  </bs:Column>
  <bs:Column SizeXS="30" SizeLG="33">
    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam quis nulla. Aenean vel massa quis mauris vehicula lacinia. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Aliquam erat volutpat. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. In rutrum. Maecenas sollicitudin. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos.</p>
  </bs:Column>
</bs:Container>
```

