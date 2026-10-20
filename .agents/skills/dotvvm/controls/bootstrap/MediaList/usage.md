# <bs:MediaList>
Renders Bootstrap Media List. Use the [MediaObject](~/controls/bootstrap/MediaObject) controls inside.

<https://getbootstrap.com/docs/3.3/components/#media>


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AlternateTextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as alternate text to image of the item.|attribute, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`DescriptionBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as description text of the item.|attribute, bindable||
|`HeaderTextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as header text of the item.|attribute, bindable||
|`HeightBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as image height of the item.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the url to image of the item.|attribute, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Items`|List<IListItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`NavigateUrlBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as url to which it will be navigated when clicked on image of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WidthBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as image width of the item.|attribute, bindable||

## Sample 1: MediaList

If you want to render a list of [MediaObject](~/controls/bootstrap/MediaObject)s, use this control and place the media objects inside.


```DOTHTML
<bs:MediaList>

    <bs:MediaObject ImageUrl="https://i3.ytimg.com/vi/m0gjBDswmsA/maxresdefault.jpg"
                    AlternateText="TEST" 
                    HeaderText="DotVVM Minutes #1: Using Bootstrap 4 in a DotVVM app" 
                    Description="Simple Description" 
                    Width="240px" />

    <bs:MediaObject ImageUrl="https://i3.ytimg.com/vi/anXu-v6-roE/maxresdefault.jpg"
                    AlternateText="TEST" 
                    HeaderText="DotVVM Minutes #2: Calling Azure Functions from DotVVM" 
                    Description="Simple Description" 
                    Width="240px" />

</bs:MediaList>
```

## Sample 2: Media List with Data Source

Items inside the `MediaList` control can be also generated from a collection bound to the `DataSource` property.

You can specify which properties of objects in the collection will be used to configure the generated items with following properties:

+ `ImageUrlBinding`
+ `AlternateTextBinding`
+ `NavigateUrlBinding`
+ `WidthBinding`
+ `HeightBinding`
+ `HeaderTextBinding`
+ `DescriptionBinding`

```DOTHTML
<bs:MediaList DataSource="{value: Medias}" 
              ImageUrlBinding="{value: ImageUrl}"
              AlternateTextBinding="{value: AltText}" 
              NavigateUrlBinding="{value: NavigateUrl}"
              HeaderTextBinding="{value: Header}" 
              DescriptionBinding="{value: Description}"
              WidthBinding="{value: Width}" 
              HeightBinding="{value: Height}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<MediaItem> Medias { get; set; } = new List<MediaItem>()
    {
        new MediaItem()
        {
            ImageUrl = "/Images/1.png",
            AltText = "google alt",
            NavigateUrl = "https://www.google.cz/",
            Header = "Google",
            Description = "This is description for Google",
            Width = "100",
            Height = "200"
        },
        new MediaItem()
        {
            ImageUrl = "/Images/2.png",
            AltText = "w3schools alt",
            NavigateUrl = "http://www.w3schools.com/",
            Header = "W3Schools",
            Description = "This is description for W3Schools",
            Width = "300",
            Height = "200"
        },
        new MediaItem()
        {
            ImageUrl = "/Images/3.png",
            AltText = "bootstrap alt",
            NavigateUrl = "http://getbootstrap.com/",
            Header = "Bootstrap",
            Description = "This is description for Bootstrap",
            Width = "200",
            Height = "100"
        }
    };
}

public class MediaItem
{
    public string ImageUrl { get; set; }
    public string AltText { get; set; }
    public string NavigateUrl { get; set; }
    public string Header { get; set; }
    public string Description { get; set; }
    public string Width { get; set; }
    public string Height { get; set; }
}

```

