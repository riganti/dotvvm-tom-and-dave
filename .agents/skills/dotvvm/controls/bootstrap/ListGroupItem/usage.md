# <bs:ListGroupItem>
This control is used as a list item inside the [ListGroup](~/controls/bootstrap/ListGroup) control.

The `ListGroupItem` derives from the [ListItem](~/controls/bootstrap/ListItem) and it adds several features to it specific for ListGroup.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Badge`|String|Gets or sets the text that appears in the badge. If the text is empty, no badge will be displayed.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([ContextualColor](../_enums/DotVVM.Framework.Controls.Bootstrap.ContextualColor.md))|Gets or sets the color of the list item. (Based on bootstrap list group styles.)|attribute, static value, bindable|Default|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsDisabled`|Boolean|Gets or sets whether this item is disabled.|attribute, static value, bindable|False|
|`IsSelected`|Boolean|Gets or sets whether this item is selected.|attribute, static value, bindable|False|
|`NavigateUrl`|String|Gets or sets the URL of the item hyperlink.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the name of the route for the item hyperlink.|attribute, static value||
|`Text`|String|Gets or sets the text of the item.|attribute, static value, bindable||
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Action|Gets or sets the command that will be triggered when the button is clicked.|

## Sample 1: Basic ListGroupItem

The `ListGroupItem` control contains `Text` property which displays text in the generated item. 

The URL for link items can be specified using bindable `NavigateUrl` property.

You can specify the color of the item with the `Color` property using Bootstrap styling for items (Success, Info, Warning, Danger).

Additionally, you can add a badge text to the right side of the list item, using bindable `Badge` property. 
If this property is empty, empty badge will not be displayed.

```DOTHTML
<bs:ListGroup>
  <bs:ListGroupItem Text="Item 1" Color="Info" NavigateUrl="https://www.dotvvm.com"/>
  <bs:ListGroupItem Text="Item 2" Color="Success" Badge="This is success ListGroupItem" />
  <bs:ListGroupItem Text="Item 3" Color="Warning" />
  <bs:ListGroupItem Text="Item 4" Color="Danger" />
  <bs:ListGroupItem Text="Item 5" Badge="This is badge" />
</bs:ListGroup>
```

## Sample 2: ListGroupItem - Item Types, Bindings & Other Properties

Similarly to Bootstrap each `ListGroupItem` can have different type. `ItemType` property specify what type of item will be generated.
Expected values are `Link` which generates "a" element, `Button` which generates "button" element. Default generated element is "li". 
 
Additionally the `ListGroupItem` control has the `IsDisabled` and `IsSelected` properties.

You can also use [GlyphIcon](~/controls/bootstrap/GlyphIcon) or any other kind of HTML content inside the control.

```DOTHTML
<bs:ListGroup ItemType="Button">
  <bs:ListGroupItem Text="Item 1" Color="Info" />
  <bs:ListGroupItem Text="Item 2" Color="Success" IsDisabled="true" />
  <bs:ListGroupItem Text="Item 3" Color="Warning" IsSelected="true" />
  <bs:ListGroupItem Text="Item 4" Color="Danger" />
</bs:ListGroup>

<bs:ListGroup ItemType="Link">
  <bs:ListGroupItem Text="Google Link" NavigateUrl="https://www.google.com/" Color="Success"/>
  <bs:ListGroupItem Text="DotVVM" NavigateUrl="{value: NavigateUrl}" />
</bs:ListGroup>

<bs:ListGroup>
  <bs:ListGroupItem Text="Item 1" Badge="Simple Badge" />
  <bs:ListGroupItem Color="Info">
    <bs:GlyphIcon Icon="Info_sign" /> info
  </bs:ListGroupItem>
  <bs:ListGroupItem Text="Item 3" Badge="{value: BadgeText}" />
  <bs:ListGroupItem IsDisabled="true">
    <bs:GlyphIcon Icon="Music" />
  </bs:ListGroupItem>
</bs:ListGroup>
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.ListGroupItem.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string BadgeText { get; set; } = "Bound Badge Text From View Model";

        public string NavigateUrl { get; set; } = "https://www.dotvvm.com";
    }
}
```

