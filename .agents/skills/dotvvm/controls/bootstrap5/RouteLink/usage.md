# <dot:RouteLink>
Extends the builtin [RouteLink](~/controls/builtin/RouteLink) control to allow using Bootstrap button CSS classes.

<https://getbootstrap.com/docs/5.2/components/buttons/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Culture`|String|Gets or sets the required culture of the page. This property is supported only when using localizable routes.|attribute, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the link is enabled and can be clicked on. Please note that the HTML hyperlinks don't support the disabled state, so setting this property to "false" will still produce the "click" event in JavaScript. If the link is disabled, DotVVM will not perform the navigation.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the name of the route in the route table.|attribute, static value||
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the button.|attribute, static value, bindable|Default|
|`Text`|String|Gets or sets the text of the hyperlink.|attribute, static value, bindable||
|`Type`|([ButtonType](../_enums/DotVVM.Bootstrap5.Controls.ButtonType.md))|Gets or sets the color of the button.|attribute, static value, bindable|Primary|
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL (e.g. query string or URL fragment).|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([ButtonVisualStyle](../_enums/DotVVM.Bootstrap5.Controls.ButtonVisualStyle.md))|Gets or sets whether the button has solid fill, or whether it is only an outline.|attribute, static value, bindable|SolidFill|

## Sample 1: RouteLink Sizing

Use the `Size` property to set the size of the link.

```DOTHTML
<bs:RouteLink RouteName="RouteLink_sample1" 
              Text="Button" />

<bs:RouteLink RouteName="RouteLink_sample1" 
              Text="Button" 
              Size="Large" />

<bs:RouteLink RouteName="RouteLink_sample1" 
              Text="Button" 
              Size="Small" />

```

## Sample 2: RouteLink Types

The `Type` property specifies the color of the link (using standard Bootstrap classes).  


```DOTHTML
<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Primary" 
              Type="Primary" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Secondary" 
              Type="Secondary" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Success" 
              Type="Success" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Danger" 
              Type="Danger" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Warning" 
              Type="Warning" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Info" 
              Type="Info" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Light" 
              Type="Light" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Dark" 
              Type="Dark" />

<bs:RouteLink RouteName="RouteLink_sample2" 
              Text="Link" 
              Type="Link" />
```

## Sample 3: RouteLink VisualStyle

The `VisualStyle` property allows to switch between button with solid fill and outline buttons.


```DOTHTML
<bs:RouteLink RouteName="RouteLink_sample3" 
                Text="Solid Fill" 
                Type="Primary" 
                VisualStyle="SolidFill" />

<bs:RouteLink RouteName="RouteLink_sample3" 
                Text="Outline" 
                Type="Primary" 
                VisualStyle="Outline" />
```

