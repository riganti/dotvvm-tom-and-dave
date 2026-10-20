# <bs:Card>
Renders the Bootstrap card with flexible content options. The card can contain one of more content items:

* [CardBody](~/controls/bootstrap4/CardBody) for text content.
* [CardImage](~/controls/bootstrap4/CardImage) for image or other media content.
* [CardListGroup](~/controls/bootstrap4/CardListGroup) for lists of items.

<https://getbootstrap.com/docs/4.3/components/card/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Content`|List<ICardItem>|Gets or sets the contents of the main section of the panel.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets the contents of the footer section of the panel.|inner element, static value||
|`FooterText`|String|Gets or sets footer text|attribute, static value, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets the contents of the header section of the panel.|inner element, static value||
|`HeaderText`|String|Gets or sets header text.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`SubtitleText`|String|Gets or sets subtitle of the card.|attribute, static value, bindable||
|`Text`|String|Gets or sets inner text of the card.|attribute, static value, bindable||
|`TitleText`|String|Gets or sets title of the card.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Card

The contents of the card are just placed inside the control element.

You can use `HeaderText` or `HeaderTemplate`, and `FooterText` or `FooterTemplate` properties to specify contents of the card header and footer bar.

To provide a text content, use [CardBody](~/controls/bootstrap4/CardBody) control. 

```DOTHTML
<bs:Card FooterText="Card Footer">
  <HeaderTemplate>
    <h1>Header</h1>
  </HeaderTemplate>

  <bs:CardBody Text="Body of the card" />
</bs:Card>
```

## Sample 2: Card with images and lists

The card can contain images or lists. Use any combination of [CardBody](~/controls/bootstrap4/CardBody), [CardImage](~/controls/bootstrap4/CardImage) and [CardListGroup](~/controls/bootstrap4/CardListGroup) controls.

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

