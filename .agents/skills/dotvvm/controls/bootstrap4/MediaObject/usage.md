# <bs:MediaObject>
Renders Bootstrap Media Object.

<https://getbootstrap.com/docs/4.3/components/media-object/>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AlternateText`|String|Gets or sets the alternate text of the image.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the content inside the Media object. Use this property if you don't want the default template.|inner element, static value||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Description`|String|Gets or sets the description text in the default content template.             Do not use this property in combination with the ContentTemplate property.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets whether this image link is enabled.|attribute, static value, bindable|True|
|`HeaderText`|String|Gets or sets the header text in the default content template.             Do not use this property in combination with the ContentTemplate property.|attribute, static value, bindable||
|`Height`|String|Gets or sets the height of the image.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageType`|([ImageType](../_enums/DotVVM.Framework.Controls.Bootstrap4.ImageType.md))|Gets or sets the type of the image - e.g. rounded, circle, responsive etc.|attribute, static value|Default|
|`ImageUrl`|String|Gets or sets the URL of the image.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`MediaTemplate`|ITemplate|Gets or sets a template for a custom content to be used instead of the image.|inner element, static value||
|`NavigateUrl`|String|Gets or sets the URL of the hyperlink.|attribute, static value, bindable||
|`NestedItems`|List<MediaObject>|Gets or sets nested Media objects.|inner element, static value||
|`Position`|([MediaHorizontalPosition](../_enums/DotVVM.Framework.Controls.Bootstrap4.MediaHorizontalPosition.md))|Gets or sets whether the image is on the left or the right side.|attribute, static value|Left|
|`RouteName`|String|Gets or sets the name of the route which will be used to generate the URL.|attribute, static value||
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL.|attribute, static value, bindable||
|`VerticalAlignment`|([VerticalAlignment](../_enums/DotVVM.Framework.Controls.Bootstrap4.VerticalAlignment.md))|Gets or sets the vertical alignment of the image.|attribute, static value|None|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`Width`|String|Gets or sets the width of the image.|attribute, static value, bindable||

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the image is clicked.|

## Sample 1: Basic MediaObject

The `MediaObject` control has the `HeaderText` and `Description` properties which specify the header text and description of the media object. 

The `ImageUrl` and `AlternateText` property sets the URL and the `alt` text of the image.





```DOTHTML
<bs:MediaObject ImageUrl="~/Images/person.png" 
                HeaderText="Basic Image" 
                Description="Simple Description" />


```

## Sample 2: Media Object Templates

The `MediaObject` control supports templating for media content and body. 

You can use the `MediaTemplate` property to define any content for the media section.

Also, instead of `HeaderText` and `Description`, you can use the `ContentTemplate` to specify your own content.


```DOTHTML
<bs:MediaObject>
  <MediaTemplate>
    <iframe width="300" height="180" src="https://www.youtube.com/embed/fJ9rUzIMcZQ" frameborder="0" allowfullscreen=""></iframe>
  </MediaTemplate>
  <ContentTemplate>
    <h1>Header</h1>
    <p>Description defined in content template.</p>
  </ContentTemplate>
</bs:MediaObject>
```

## Sample 3: Nested MediaObjects

You can nest `MediaObject` controls to create hierarchies. 

Use `ContentTemplate` to provide the title and description of the media, and use `MediaObject` control inside this template.



```DOTHTML
<bs:MediaList>

    <bs:MediaObject ImageUrl="~/Images/person.png" VerticalAlignment="Start" AlternateText="TEST">
        <ContentTemplate>
            <h4>Media object in list</h4>
            <p>Description in template</p>

            <bs:MediaObject ImageUrl="~/Images/person.png" VerticalAlignment="Start" AlternateText="TEST">
                <ContentTemplate>
                    <h4>Child</h4>
                    <p>Description of a child</p>

                    <bs:MediaObject HeaderText="Nested Media Object" Description="Simple description" VerticalAlignment="Start">
                        <MediaTemplate>
                            <iframe width="300" height="180" src="https://www.youtube.com/embed/fJ9rUzIMcZQ" frameborder="0" allowfullscreen=""></iframe>
                        </MediaTemplate>
                    </bs:MediaObject>

                </ContentTemplate>
            </bs:MediaObject>

        </ContentTemplate>
    </bs:MediaObject>

    <bs:MediaObject ImageUrl="~/Images/person.png" VerticalAlignment="Start" AlternateText="TEST" />

</bs:MediaList>
```

## Sample 4: MediaObject Alignment

The `Position` property specifies whether the image is on the left or on the right side.

You can use the `VerticalAlignment` property to specify the vertical alignment of the image within the row.

```DOTHTML
<bs:MediaObject ImageUrl="~/Images/person.png" 
                HeaderText="Basic Image" 
                Description="Simple Description"
                VerticalAlignment="End"
                Position="Right" />


```

