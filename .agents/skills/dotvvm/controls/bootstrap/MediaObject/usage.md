# <bs:MediaObject>
Renders Bootstrap Media Object.

<https://getbootstrap.com/docs/3.3/components/#media>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AlternateText`|String|Gets or sets the alternate text of the image.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the content inside the Media object. Use this property if you don't need the default template.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Description`|String|Gets or sets the description text in the default content template.             Do not use this property in combination with the ContentTemplate property.|attribute, static value, bindable||
|`HeaderText`|String|Gets or sets the header text in the default content template.             Do not use this property in combination with the ContentTemplate property.|attribute, static value, bindable||
|`Height`|String|Gets or sets the height of the image.|attribute, static value, bindable||
|`HorizontalAlignment`|([MediaPositionHorizontal](../_enums/DotVVM.Framework.Controls.Bootstrap.MediaPositionHorizontal.md))|Gets or sets the horizontal alignment of the image.|attribute, static value|Left|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageTemplate`|ITemplate|Gets or sets custom content instead of image.|inner element, static value||
|`ImageUrl`|String|Gets or sets the URL of the image.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`NavigateUrl`|String|Gets or sets the URL of the hyperlink.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the name of the route which will be used to generate the URL.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL.|attribute, static value, bindable||
|`VerticalAlignment`|([MediaPositionVertical](../_enums/DotVVM.Framework.Controls.Bootstrap.MediaPositionVertical.md))|Gets or sets the vertical alignment of the image.|attribute, static value|Middle|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String|Gets or sets the width of the image.|attribute, static value, bindable||

## Sample 1: Basic Media Object

The `MediaObject` control has the `HeaderText` and `Description` properties which specify the header text and description of the media object. 

The `ImageUrl` and `AlternateText` property sets the URL and the `alt` text of the image.





```DOTHTML
<bs:MediaObject ImageUrl="~/Images/person.png" 
  HeaderText="Basic Image" 
  Description="Simple Description" />


```

## Sample 2: Media Object Templates

The `MediaObject` control supports templating for media content and body. 

You can use the `ImageTemplate` property to define any content for the media section.

Also, instead of `HeaderText` and `Description`, you can use the `ContentTemplate` to specify your own content.


```DOTHTML
<bs:MediaObject>
  <ImageTemplate>
    <iframe width="300" height="180" src="https://www.youtube.com/embed/fJ9rUzIMcZQ" frameborder="0" allowfullscreen=""></iframe>
  </ImageTemplate>
  <ContentTemplate>
    <h1>Header</h1>
    <p>Description defined in content template.</p>
  </ContentTemplate>
</bs:MediaObject>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Media.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Description { get; set; }= "This is media description.";
        public string HeaderText { get; set; } = "This is media header.";

    }
}
```

## Sample 3: MediaList and Nested MediaObjects

By default, the `MediaObject` renders the `<div>` element, so you can use it independently.

However, if you place the `MediaObject` in the [MediaList](~/controls/bootstrap/MediaList) control, it will be automatically detect this and render as `<li>` element.

The `MediaObject` controls can be nested.

```DOTHTML
<bs:MediaList>

    <bs:MediaObject ImageUrl="~/Images/person.png" VerticalAlignment="Top" AlternateText="TEST">

        <ContentTemplate>
            <h4>Media object in list</h4>
            <p>Description in template</p>

            <bs:MediaObject ImageUrl="~/Images/person.png" VerticalAlignment="Top" AlternateText="TEST">
                <ContentTemplate>
                    <h4>Child</h4>
                    <p>Description of a child</p>

                    <bs:MediaObject HeaderText="Nested Media Object" Description="Simple description" VerticalAlignment="Top">
                        <ImageTemplate>
                            <iframe width="300" height="180" src="https://www.youtube.com/embed/fJ9rUzIMcZQ" frameborder="0" allowfullscreen=""></iframe>
                        </ImageTemplate>
                    </bs:MediaObject>

                </ContentTemplate>

            </bs:MediaObject>
        </ContentTemplate>

    </bs:MediaObject>

    <bs:MediaObject ImageUrl="~/Images/person.png" VerticalAlignment="Top" AlternateText="TEST" />

</bs:MediaList>
```

