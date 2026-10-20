# <bs:Thumbnail>
Renders the Bootstrap Thumbnail over an [Image](~/controls/bootstrap/Image) which can have caption.

<https://getbootstrap.com/docs/3.3/components/#thumbnails>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AlternateText`|String|Gets or sets the alternate text.|attribute, static value, bindable||
|`CaptionTemplate`|ITemplate|Gets or sets the caption template.|inner element, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Height`|String|Gets or sets the height of the image.|attribute, static value, bindable|100%|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrl`|String|Gets or sets the URL of the image.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`NavigateUrl`|String|Gets or sets the hyperlink URL.|attribute, static value, bindable||
|`Title`|String|Gets or sets the image title.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String|Gets or sets the width of the image.|attribute, static value, bindable|100%|

## Sample 1: Thumbnail

The `Thumbnail` control has the same properties of the displayed image as the [Image](~/controls/bootstrap/Image) control.  

Additionally, it has the `NavigateUrl` property which specifies the URL where the hyperlink navigates to.

The `CaptionTemplate` property of the `Thumbnail` control allows to customize the caption of the thumbnail.

```DOTHTML
<bs:Thumbnail ImageUrl="~/Images/LA.jpg" Title="Simple Thumbnail" Alt="Image">
  <CaptionTemplate >
    <h1>This is image caption.</h1>
    <p>You can put here description of the Image.</p>
  </CaptionTemplate>
</bs:Thumbnail>
```

