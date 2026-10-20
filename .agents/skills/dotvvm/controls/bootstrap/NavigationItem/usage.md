# <bs:NavigationItem>
This control is used as a list item inside the [NavigationBar](~/controls/bootstrap/NavigationBar) control.

<https://getbootstrap.com/docs/3.3/components/#nav>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
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

## Sample 1: Basic Usage

The `NavigationItem` control has the `NavigateUrl` property which specifies target URL, or the `Click` property which invokes a command on the viewmodel.

The `Text` property defines the contents of the item. Alternatively, you can also place the contents inside the control.

The `IsSelected` and `IsDisabled` properties define whether the control gets the active or disabled CSS classes.

```DOTHTML
<bs:NavigationBar Type="Pills">
    <bs:NavigationItem NavigateUrl="https://www.google.com/" 
                            Text="Google" 
                            IsSelected="true" />

    <bs:NavigationItem Click="{command: Increment()}" Text="{value: Likes + ' likes'}" />

    <bs:NavigationItem NavigateUrl="http://www.w3schools.com/html/" 
                            Text="W3 Schools" 
                            IsDisabled="true" />
</bs:NavigationBar>
```

```CSHARP
using System.Collections.Generic;
using System.Linq;

namespace Dotvvm.Samples.NavigationItem.sample1
{
    public class ViewModel
    {

        public int Likes { get; set; }

        public void Increment()
        {
            Likes++;
        }            
    }
}
```

