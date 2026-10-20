# <bs:CardBody>
Renders a text content inside the [Card](~/controls/bootstrap4/Card) control.

<https://getbootstrap.com/docs/4.3/components/card/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AddAppropriateCardClassesToContent`|Boolean|Gets or sets whether appropriate classes (card-text, card-link, ...) should be added to inner elements.             Can be used only when Content template is used.|attribute, static value, bindable|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the contents of the main section of the panel.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`SubtitleText`|String|Gets or sets subtitle of the card.|attribute, static value, bindable||
|`Text`|String|Gets or sets inner text of the card.|attribute, static value, bindable||
|`TitleText`|String|Gets or sets title of the card.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic CardBody

Use the `TitleText`, `SubtitleText` and `Text` properties to provide two levels of title and a text content for the card.

```DOTHTML
<bs:Card>
  <bs:CardBody 
      TitleText="Main title"
      SubtitleText="Secondary title"
      Text="Body of the card" />
</bs:Card>
```

## Sample 2: Templated CardBody

If you need to provide a custom content in the card body, place the content inside the control.

Bootstrap recommends the following CSS classes to be used in the card body templates:

* `h1`, ..., `h6` elements should have `card-title` or `card-subtitle` CSS classes.
* `p` and other text elements should have `card-text` CSS class.
* `a` elements should have `card-link` CSS class.

You can set `AddAppropriateCardClassesToContent` property to `true` which makes the control to add the CSS classes automatically based on the rules mentioned above. 


```DOTHTML
<bs:Card FooterText="Card Footer">
  <bs:CardImage ImageUrl="~/images/LA.jpg" ToolTip="Card Image">
    <bs:CardBody style="color:aliceblue;">
      <h1>Overlaid body</h1>
      <p>
          Another text
      </p>
      <p>Some buttons</p>
      <bs:Button Click="{command: DoSomething()}" Text="Button" Type="Danger" />
    </bs:CardBody>
  </bs:CardImage>
  
  <bs:CardListGroup DataSource="{value: Texts}" TextBinding="{value: _this}" />

</bs:Card>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{

    public string[] Texts { get; } = new[] { "red", "green", "blue" };

    public void DoSomething() 
    {

    }
}
```

