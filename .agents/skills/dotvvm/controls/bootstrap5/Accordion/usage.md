# <dot:Accordion>
Wraps a group of [AccordionItem](~/controls/bootstrap5/AccordionItem) controls to create an accordion-like behavior.
When you expand one of the items inside, the others will collapse. Only one item can be expanded at the same time.

<https://getbootstrap.com/docs/5.2/components/accordion/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets a data-source object from which the child controls will be generated.|attribute, bindable||
|`ExpandedItemIndex`|IValueBinding<Int32>|Gets or sets an index of expanded accordion item. If none of the accordion items are expanded, the index is set to -1.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemContentTemplate`|ITemplate|Gets or sets a custom template for accordion item content when DataSource is set.|inner element, static value||
|`ItemContentText`|String|Gets or sets a plain text for accordion item content when DataSource is set.|attribute, static value, bindable||
|`ItemHeaderTemplate`|ITemplate|Gets or sets a custom template for accordion item header when DataSource is set.|inner element, static value||
|`ItemHeaderText`|String|Gets or sets a plain text for accordion item header when DataSource is set.|attribute, static value, bindable||
|`Items`|List<IAccordionItem>|Gets or sets the items inside the control.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: ExpandedItemIndex 

To expand specific `AccordioItem` use property `ExpandedItemIndex` with index of chosen item. If index is set to -1 or number higher than number of items, than no item will be expanded.

```DOTHTML
<bs:Accordion ExpandedItemIndex="{value: 2}">
    <bs:AccordionItem HeaderText="Header1" ContentText="Text1"/>
    <bs:AccordionItem HeaderText="Header2" ContentText="Text2"/>
    <bs:AccordionItem HeaderText="Header3" ContentText="Text3"/>
</bs:Accordion>
<bs:Accordion ExpandedItemIndex="{value: Index}">
    <bs:AccordionItem HeaderText="Header1" ContentText="Text1"/>
    <bs:AccordionItem HeaderText="Header2" ContentText="Text2"/>
    <bs:AccordionItem HeaderText="Header3" ContentText="Text3"/>
</bs:Accordion>

<dot:Button Click="{staticCommand: Index = 0}" Text="Change Index to 0" />
<dot:Button Click="{staticCommand: Index = 3}" Text="Change Index to 3" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public int Index { get; set; } = 2;
}
```

## Sample 2: Data-binding the Accordion

The `ExpandedItemIndex` property specifies the index of the accordion item which is selected.

The `DataSource` property can be used to generate the items from an `IEnumerable` in the viewmodel.

Then you can use the following properties which tell the control what property of the collection item will be used:

* `ItemContentText` specifies the property of the collection elements to be used as the content of the accordion item.
* `ItemHeaderText` specifies the text in the accordion item header.

```DOTHTML
<bs:Accordion   DataSource="{value: Accordions}"
                ItemHeaderText="{value: Header}"
                ItemContentText="{value: Text}"
                ExpandedItemIndex="{value: IndexAdvanced}" />

<dot:Button Click="{command: AddItem()}" Text="Add" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public int IndexAdvanced { get; set; } = 1;
    public List<AccordionModel> Accordions { get; set; }
    public ViewModel()
    {
        Accordions = new List<AccordionModel>()
        {
            new AccordionModel()
            {
                Header = "Item 1",
                Text = "Text 1"
            },
            new AccordionModel()
            {
                Header = "Item 2",
                Text = "Text 2"
            }
        };
    }
    public void AddItem()
    {
        var itemNumber = Accordions.Count + 1;
        Accordions.Add(
            new AccordionModel()
            {
                Header = $"Item {itemNumber}",
                Text = $"Text  {itemNumber}"
            });
        IndexAdvanced = Accordions.Count - 1;
    }

    public class AccordionModel
    {
        public string Header { get; set; }
        public string Text { get; set; }
    }
}
```

