# <bs:Badge>
Renders a Bootstrap badge component.

<https://getbootstrap.com/docs/4.3/components/badge/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets whether this item is enabled.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`NavigateUrl`|String|Gets or sets of the navigate URL of the link.|attribute, static value, bindable||
|`RouteName`|String|Gets or sets the name of the route for the item hyperlink.|attribute, static value||
|`Text`|String|Gets or sets the text inside the badge.|attribute, static value, bindable||
|`Type`|([BootstrapColor](../_enums/DotVVM.Framework.Controls.Bootstrap4.BootstrapColor.md))|Gets or sets of the type of the badge.|attribute, static value, bindable|Primary|
|`UrlSuffix`|String|Gets or sets the suffix that will be appended to the generated URL.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`VisualStyle`|([BadgeVisualStyle](../_enums/DotVVM.Framework.Controls.Bootstrap4.BadgeVisualStyle.md))|Gets or sets whether the badge is rendered as a classic badge or as a pill.|attribute, static value|Default|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|Command|Gets or sets the command that will be triggered when the button is clicked.|

## Sample 1: Basic Badge

Place the contents of the `Badge` inside the control, or use the `Text` property.

The `Type` property specifies the color category of the badge.

You can use the `VisualStyle` to specify, whether the badge should have a normal shape, or whether it should be rendered as a pill.

```DOTHTML
<bs:Badge Text="100"/>

<bs:Badge>
  <h1>9000+</h1>
</bs:Badge>

<bs:Badge Type="Primary" VisualStyle="Pill" />

```

## Sample 2: Badge in a Button

If you need to use the `Badge` inside the button, don't forget to set the `ButtonTagName` to `Button`.

Otherwise, the button would be rendered as `<input type="button">` which supports only a text values.

```DOTHTML
<bs:Button Click="{command: Increment()}" ButtonTagName="button">
  Number of clicks: <bs:Badge Text="{value: Clicks}"/>
</bs:Button>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public int Clicks { get; set; } = 0;

    public void Increment()
    {
        Clicks++;
    }
}

```

## Sample 3: Badge as Link or Button

The `Badge` control can work as a button or a link.

* You may set `NavigateUrl` to make the badge to link to a specific URL.
* The `Click` event can be used to invoke a command in the viewmodel.
* You may also use `RouteName`, `Param-*`, `Query-*` and `UrlSuffix` properties to build a link from a route table. See [RouteLink](~/controls/builtin/RouteLink) for details.



```DOTHTML
<bs:Badge Text="NavigateUrl" 
            NavigateUrl="https://google.com" />

<bs:Badge Text="{value: Clicks + ' clicks'}" 
            Click="{command: Increment()}" />

<bs:Badge Text="Route" 
            RouteName="Badge_sample3" 
            Param-Id="1"
            Query-Page="10"
            UrlSuffix="#table" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public int Clicks { get; set; } = 0;

    public void Increment()
    {
        Clicks++;
    }
}

```

