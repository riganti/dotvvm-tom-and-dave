# <bs:CardGroup>
Groups multiple [Cards](~/controls/bootstrap4/Card).

<https://getbootstrap.com/docs/4.3/components/card/#card-groups>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Items`|List<Card>|Gets or sets a collection of cards rendered inside CardGroup.|inner element, static value, default property||
|`Type`|([CardGroupType](../_enums/DotVVM.Framework.Controls.Bootstrap4.CardGroupType.md))|Gets or sets the Type of CardGroup.|attribute, static value|Group|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Card Group Types

Use `Type` property to switch between different layouts of cards.

Possible values are:
* *Group* - Cards are rendered right next to each other and have equal size.
* *Deck* - Set of equal sized cards that are not attached to each other.
* *Columns* - Cards are organized into columns. Cards with different sizes are supported and will form mosaic-like pattern.


```DOTHTML
<bs:CardGroup Type="Columns">
    <bs:Card HeaderText="Tempor lorem"
             Text="Kasd dolor diam"
             FooterText="Et" />
    <bs:Card HeaderText="No"
             Text="But congealed but wassailers reverie objects by of would known thou bower night from to deadly harold of had a"
             FooterText="Sed id" />
    <bs:Card HeaderText="Labore lorem et"
             Text="Had mirthful resolved"
             FooterText="Amet ipsum takimata gubergren stet illum" />
    <bs:Card HeaderText="Eos vel"
             Text="Bower to there sad below hight virtues weary the on"
             FooterText="Dolores tincidunt" />
    <bs:Card HeaderText="Laoreet sea dolores"
             Text="Sorrow one loved he fathers scarce childe him basked seek say had is hight wasmen ear of things found sooth it maidens for of and"
             FooterText="Lorem odio feugiat" />
    <bs:Card HeaderText="Nonummy nonumy consectetuer lorem"
             Text="Text"
             FooterText="Diam sed" />
    <bs:Card HeaderText="Clita diam"
             Text="Might the and and forgot is festal would control hall to sad"
             FooterText="Kasd duo" />
</bs:CardGroup>
```

