# <t:ButtonGroup>
Renders multiple Tailwind `Button` controls as a connected group. You can place buttons manually or generate them from `DataSource` with the `Item*` mappings.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|IValueBinding<IEnumerable<Object>>|Gets or sets the collection used to generate buttons when data-binding is used.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`ItemEnabled`|Boolean|Gets or sets whether each generated button is enabled.|attribute, static value, bindable|True|
|`ItemIcon`|([HeroIcon](../_enums/DotVVM.Controls.Tailwind.Controls.HeroIcon.md))|Gets or sets the icon displayed in each generated button when DataSource is used.|attribute, static value, bindable||
|`ItemIconPosition`|([IconPosition](../_enums/DotVVM.Controls.Tailwind.Controls.IconPosition.md))|Gets or sets whether the icon is rendered before or after the generated button text.|attribute, static value, bindable|Start|
|`ItemIsSubmitButton`|Boolean|Gets or sets whether each generated button is rendered as a submit button.|attribute, static value|False|
|`Items`|List<Button>|Gets or sets the buttons rendered inside the group.|inner element, static value, default property||
|`ItemSize`|([ControlSize](../_enums/DotVVM.Controls.Tailwind.ControlSize.md))|Gets or sets the size applied to each generated button.|attribute, static value, bindable|Default|
|`ItemTemplate`|ITemplate|Gets or sets the template of generated buttons when DataSource is used.|inner element, static value||
|`ItemText`|String|Gets or sets the text of generated buttons when DataSource is used.|attribute, static value, bindable||
|`ItemType`|([ButtonType](../_enums/DotVVM.Controls.Tailwind.Controls.ButtonType.md))|Gets or sets the visual style applied to each generated button.|attribute, static value, bindable|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`ItemClick`|ICommandBinding|Gets or sets the command executed when a generated button is clicked.|

## Sample 2: Basic Hardcoded Button Group

Demonstrates a simple button group with three basic buttons placed directly inside the ButtonGroup control.



```DOTHTML
<div class="flex gap-2">
    <t:ButtonGroup>
        <t:Button Type="Default" Text="Left" />
        <t:Button Type="Default" Text="Center" />
        <t:Button Type="Default" Text="Right" />
    </t:ButtonGroup>
</div>


```

## Sample 3: Mixed Button Types with Icons

Shows a button group with different button types (Primary, Warning, Danger) and HeroIcons assigned to each button.



```DOTHTML
<div class="flex gap-2">
    <t:ButtonGroup>
        <t:Button Type="Primary" Text="Save" Icon="Check" />
        <t:Button Type="Warning" Text="Edit" Icon="PencilSquare" />
        <t:Button Type="Danger" Text="Delete" Icon="Trash" />
    </t:ButtonGroup>
</div>


```

## Sample 4: DataSource with Click Commands

Demonstrates button group generation from a DataSource collection, with ItemClick command that tracks which button was clicked.



```DOTHTML
<div class="flex flex-col gap-4 items-start">
    <t:ButtonGroup DataSource="{value: Actions}" ItemText="{value: _this}" ItemClick="{command: _parent.ItemClicked(_this)}" />
    <p class="text-sm">Last clicked: <strong>{{value: LastClicked}}</strong></p>
</div>


```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;

public class ViewModel : DotvvmViewModelBase
{
    public List<string> Actions { get; set; } = new() { "Copy", "Cut", "Paste" };
    
    public string LastClicked { get; set; } = "(none)";
    
    public void ItemClicked(string item)
    {
        LastClicked = $"{item} clicked at {DateTime.Now:HH:mm:ss}";
    }
}


```

