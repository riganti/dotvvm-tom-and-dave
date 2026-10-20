# <dot:ListBox>
Renders the HTML listbox.

## Rendered output
The control renders the HTML select:

```DOTHTML
<select data-bind="..." size="4"></select>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemTitleBinding`|IValueBinding|The expression of DataSource item that will be placed into html title attribute.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`Size`|Int32|Gets or sets number of rows visible in this ListBox.|attribute, static value, bindable|10|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Basic ListBox

The ListBox control has property `DataSource` which expects an *IEnumerable*. Each object is treated as an item in the listbox.

The `SelectedValue` property will contain the selected value.

```DOTHTML
<dot:ListBox DataSource="{value: Fruits}" SelectedValue="{value: SelectedFruit}"/>

{{value: SelectedFruit}}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample1
{
    public class ViewModel
    {
        public string[] Fruits { get; set; } 
            = { "Apple", "Banana", "Orange" };

        public string SelectedFruit { get; set; }
    }
}
```

## Sample 2: ListBox Size

The ListBox control has the `Size` property which specifies how many lines will be visible without scrolling.

```DOTHTML
<dot:ListBox DataSource="{value: Fruits}" 
              SelectedValue="{value: SelectedFruit}" 
              Size="5" />

{{value: SelectedFruit}}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample2
{
    public class ViewModel
    {
        public string[] Fruits { get; set; } 
            = { "Apple", "Banana", "Orange", "Mandarin", "Pear", "Avocado" };

        public string SelectedFruit { get; set; }
    }
}
```

## Sample 3: ItemValueBinding and ItemTextBinding

Typically, the `DataSource` is not a collection of strings, but a collection of some complex objects. 

The `ItemValueBinding` property defines which property of the object will be passed to the `SelectedValue` property.

The `ItemTextBinding` property defines which property of the object will be displayed in the drop-down list.


```DOTHTML
<dot:ListBox DataSource="{value: Fruits}" 
             SelectedValue="{value: SelectedFruitId}" 
             ItemValueBinding="{value: Id}" 
             ItemTextBinding="{value: Name}" />

{{value: SelectedFruitId}}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample3
{
    public class ViewModel
    {
        public Fruit[] Fruits { get; set; } = 
        {
            new Fruit(0, "Apple"),
            new Fruit(1, "Banana"),
            new Fruit(2, "Orange")
        };

        public int SelectedFruitId { get; set; } = 1;
    }

    public class Fruit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Fruit(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
```

## Sample 4: SelectionChanged Event

The ListBox control also has the `SelectionChanged` event which is fired whenever the selection changes.


```DOTHTML
<dot:ListBox DataSource="{value: Fruits}" SelectedValue="{value: SelectedFruit}" 
             SelectionChanged="{command: IsItReallyFruit()}"/>

{{value: Message}}
```

```CSHARP
namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample4
{
    public class ViewModel
    {
        public string[] Fruits { get; set; } = { "Apple", "Banana", "IceCream", "Orange" };

        public string SelectedFruit { get; set; }

        public string Message { get; set; }

        public void IsItReallyFruit()
        {
            if (SelectedFruit == "IceCream")
            {
                Message = "Ice cream isn't a fruit!";
            }
            else
            {
                Message = "Yes, it's a fruit!";
            }
        }
    }
}
```

## Sample 5: ListBox Game

A simple trivia game - match inventors to inventions.

```DOTHTML
<h3>Match inventors and inventions</h3>

<dot:ListBox DataSource="{value: Inventors}"
             SelectedValue="{value: SelectedInventor}"
             ItemValueBinding="{value: Id}"
             ItemTextBinding="{value: Name}" />

<dot:ListBox DataSource="{value: Inventions}"
             SelectedValue="{value: SelectedInvention}" />

<dot:Button Text="Check Answers"
            Click="{command: CheckAnswer()}" />

<p>Points: {{value: Points}}</p>
```

```CSHARP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ListBox.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<Inventor> Inventors { get; set; } = new List<Inventor>()
        {
            new Inventor(0, "Thomas Edison", "Lightbulb"),
            new Inventor(1, "Alexander Graham Bell", "Telephone"),
            new Inventor(2, "Benjamin Franklin", "Electricity"),
            new Inventor(3, "Tim Berners Lee", "HTTP Protocol"),
            new Inventor(4, "Sir John Harrington", "Toilet"),
            new Inventor(5, "Emile Berliner", "Gramophone Record")
        };

        public int? SelectedInventor { get; set; } = null;

        public List<string> Inventions { get; set; }

        public string SelectedInvention { get; set; }

        public int Points { get; set; } = 0;

        public override Task Init()
        {
            // generate random order when the page is loaded the first time
            if (!Context.IsPostBack)
            {
                Inventions = Inventors
                    .OrderBy(i => Guid.NewGuid())
                    .Select(i => i.Invention)
                    .ToList();
            }

            return base.Init();
        }

        public void CheckAnswer()
        {
            var selectedInventor = Inventors.First(i => i.Id == SelectedInventor);
            if (selectedInventor.Invention == SelectedInvention)
            {
                Inventors.Remove(selectedInventor);
                Inventions.Remove(selectedInventor.Invention);

                SelectedInventor = null;
                SelectedInvention = null;

                Points++;
            }
            else
            {
                Points = Points - 2;
            }
        }
    }

    public class Inventor
    {
        public string Name { get; set; }

        public string Invention { get; set; }

        public int Id { get; set; }

        public Inventor()
        {

        }
        public Inventor(int id, string name, string invention)
        {
            Id = id;
            Name = name;
            Invention = invention;
        }
    }
}
```

