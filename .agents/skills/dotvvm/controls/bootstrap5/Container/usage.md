# <dot:Container>
Renders a Bootstrap container component.

<https://getbootstrap.com/docs/5.2/layout/containers/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Type`|([ContainerResponsiveBreakpoints](../_enums/DotVVM.Bootstrap5.Controls.ContainerResponsiveBreakpoints.md))|Gets or sets the type of the container. Fluid type utilizes the available horizontal space. Small, Medium, Large, XLarge, XXLarge types utilize the available space according to corresponding Bootstrap screen size.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Normal vs Fluid Container

The `Type` property specifies the behavior of the `Container` for wide pages.

There can by `Small`, `Medium`, `Large`, `XLarge`, `XXLarge` types, which set size by windows size and `Fluid`  type always utilizes the available horizontal space. To see specific windows sizes check [Bootstrap Container documentation](https://getbootstrap.com/docs/5.2/layout/containers/#how-they-work) for more details.

```DOTHTML
<bs:Container Type="Fluid">
  <p>
    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam quis nulla. Aenean vel massa quis mauris vehicula lacinia. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Aliquam erat volutpat. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. In rutrum. Maecenas sollicitudin. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
  </p>
</bs:Container>

<bs:Container Type="Small">
  <p>
    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam quis nulla. Aenean vel massa quis mauris vehicula lacinia. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Aliquam erat volutpat. Fusce dui leo, imperdiet in, aliquam sit amet, feugiat eu, orci. In rutrum. Maecenas sollicitudin. Mauris suscipit, ligula sit amet pharetra semper, nibh ante cursus purus, vel sagittis velit mauris vel metus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
  </p>
</bs:Container>
```

## Sample 2: Inner Elements

Container can contains any other element.


```DOTHTML
    <h4>Container with TextBox</h4>
    <bs:Container>
        <bs:TextBox Text="Some text"/>
    </bs:Container>

    <h24>Container with h2</h24>
    <bs:Container>
        <h2>Container with h2</h2>
    </bs:Container>

    <h4>Container with Spinner</h4>
    <bs:Container>
        <bs:Spinner></bs:Spinner>
    </bs:Container>

    <h4>Container with Progress</h4>
    <bs:Container>
        <bs:ProgressBar Value="100">
            100% completed...
        </bs:ProgressBar>
    </bs:Container>

    <h4>Container with Badge</h4>
    <bs:Container>
        <bs:Badge Text="100" ID="badge-text" />
    </bs:Container>
```

