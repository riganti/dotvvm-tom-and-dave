# <bs:Accordion>
Wraps a group of [AccordionItem](~/controls/bootstrap4/AccordionItem) controls to create an accordion-like behavior.
When you expand one of the items inside, the others will collapse. Only one item can be expanded at the same time.

<https://getbootstrap.com/docs/4.3/components/collapse/#accordion-example>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`ExpandedItemIndex`|Int32|Gets or sets the index of the item which is currently expanded.|attribute, static value, bindable|-1|
|`FooterTextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the footer text of the item.|attribute, bindable||
|`HeaderTextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the header text of the item.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Items`|List<IAccordionItem>|Gets or sets a collection of items that is used when no DataSource is set.|inner element, static value, default property||
|`ItemsContent`|List<ICardItem>|Gets or sets the content for accordion items bound from DataSource.|inner element, static value||
|`ItemsFooterTemplate`|ITemplate|Gets or sets the footer template for accordion items bound from DataSource.|inner element, static value||
|`ItemsHeaderTemplate`|ITemplate|Gets or sets the content for accordion items bound from DataSource.|inner element, static value||
|`SubtitleTextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the subtitle text of the item.|attribute, bindable||
|`TextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the text of the item.|attribute, bindable||
|`TitleTextBinding`|IValueBinding|Gets or sets the value binding that points to a property which will be used as the title text of the item.|attribute, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Accordion

To use this control, just place several `AccordionItem` controls inside the `Accordion` control. The `AccordionItem` inherits from [Card](~/controls/bootstrap4/Card) and can specify the `IsExpanded` property to indicate whether the item is expanded or not.
  
In the most common scenario, you need the first panel to be expanded while the others are collapsed.


```DOTHTML
<bs:Accordion>
  
  <bs:AccordionItem HeaderText="Card 1"
                    TitleText="Card 1"
                    Text="This is first accordion item." 
                    IsExpanded="true" />

  <bs:AccordionItem HeaderText="Card 2"
                    TitleText="Card 3"
                    Text="This is second accordion item." />

  <bs:AccordionItem HeaderText="Card 3"
                    TitleText="Card 3"
                    Text="This is third accordion item." />
  
</bs:Accordion>
```

## Sample 2: Data-binding the Accordion

The `ExpandedItemIndex` property specifies the index of the accordion item which is selected.

The `DataSource` property can be used to generate the items from an `IEnumerable` in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `TextBinding` specifies the property of the collection elements to be used as the content of the accordion item.
* `HeaderTextBinding` specifies the text in the accordion item header.
* `FooterTextBinding` specifies the text in the accordion item footer.

```DOTHTML
<bs:Accordion ExpandedItemIndex="{value: Index}" 
              DataSource="{value: Panels}" 
              TextBinding="{value: Text}" 
              HeaderTextBinding="{value: Text}" />

<p>Expanded panel index: {{value: Index}}</p>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Accordion.sample2
{
    public class ViewModel
    {
        public int Index { get; set; } = 1;

        public PanelData[] Panels { get; set; } =
        {
            new PanelData("Text 1"),
            new PanelData("Text 2"),
            new PanelData("Text 3")
        };
    }

    public class PanelData
    {
        public string Text { get; set; }

        public PanelData()
        {
        }

        public PanelData(string text)
        {
            Text = text;
        }
    }
}
```

