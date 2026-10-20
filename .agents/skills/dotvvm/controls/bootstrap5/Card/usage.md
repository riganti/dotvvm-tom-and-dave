# <dot:Card>
Renders the Bootstrap card with flexible content options. The card can contain one of more content items:

* [CardBody](~/controls/bootstrap5/CardBody) for text content.
* [CardImage](~/controls/bootstrap5/CardImage) for image or other media content.
* [CardListGroup](~/controls/bootstrap5/CardListGroup) for lists of items.

<https://getbootstrap.com/docs/5.2/components/card>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`BorderColor`|([BootstrapColor](../_enums/DotVVM.Bootstrap5.BootstrapColor.md))|Gets or sets the card border color.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`Color`|([CardColor](../_enums/DotVVM.Bootstrap5.Controls.CardColor.md))|Gets or sets the card color. Both the background and text color css classes are set.|attribute, static value, bindable||
|`Content`|List<ICardItem>|Gets or sets a custom template for the card content. Cannot be combined with a `Text` property.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets a custom template for card footer. Cannot be combined with a `FooterText` property.|inner element, static value||
|`FooterText`|String|Gets or sets a plain text for card footer. Cannot be combined with a `FooterTemplate` property.|attribute, static value, bindable||
|`HeaderTemplate`|ITemplate|Gets or sets a custom template for card header. Cannot be combined with a `HeaderText` property.|inner element, static value||
|`HeaderText`|String|Gets or sets a plain text for card header. Cannot be combined with a `HeaderTemplate` property.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`SubtitleText`|String|Gets or sets the control subtitle text. H6 tag is used.|attribute, static value, bindable||
|`Text`|String|Gets or sets a plain text for card content. Cannot be combined with any custom content inside the card.|attribute, static value, bindable||
|`TitleText`|String|Gets or sets the control title text. H5 tag is used.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Card

The contents of the card are just placed inside the control element.

You can use `HeaderText` or `HeaderTemplate`, and `FooterText` or `FooterTemplate` properties to specify contents of the card header and footer bar.

Use `SubtitleText` or `SubtitleTemplate` properties to specify subtitle of the card.

To provide a text content, use `Text` property or [CardBody](~/controls/bootstrap5/CardBody) control. 

```DOTHTML
<bs:Card FooterText="Card Footer">
  <HeaderTemplate>
    <h1>Header</h1>
  </HeaderTemplate>

  <bs:CardBody Text="Body of the card" />
</bs:Card>

<bs:Card HeaderText="Header" TitleText="Title"
         SubtitleText="Subtitle" Text="Text" 
         FooterText="Footer" />

<bs:Card HeaderText="{value: HeaderText}" TitleText="{value: TitleText}" SubtitleText="{value: SubtitleText}" Text="{value: Text}" FooterText="{value: FooterText}" />
```

## Sample 2: Card with images and lists

The card can contain images or lists. Use any combination of [CardBody](~/controls/bootstrap5/CardBody), [CardImage](~/controls/bootstrap5/CardImage) and [CardListGroup](~/controls/bootstrap5/CardListGroup) controls.

```DOTHTML
<bs:Card>
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
  
  <bs:CardListGroup DataSource="{value: Texts}" ItemText="{value: _this}" />

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

## Sample 3: Card colors 

The card component can use different backgrounds and border colors with `Color` and `BorderColor` properties.

```DOTHTML
<bs:Card Color="Danger" BorderColor="Warning">
  <bs:CardBody TitleText="Title" Text="Text" />
</bs:Card>
<bs:Card Color="Light" BorderColor="Dark">
  <bs:CardBody TitleText="Title" Text="Text" />
</bs:Card>
<bs:Card Color="Success" BorderColor="Light">
  <bs:CardBody TitleText="Title" Text="Text" />
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

