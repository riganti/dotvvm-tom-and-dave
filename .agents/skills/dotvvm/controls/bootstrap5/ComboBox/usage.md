# <dot:ComboBox>
Extends the builtin [ComboBox](~/controls/builtin/ComboBox) control to allow sizing.

<https://getbootstrap.com/docs/5.2/forms/select/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyItemText`|String|Text displayed when no value is selected.|attribute, static value, bindable||
|`Enabled`|Boolean|Gets or sets a value indicating whether the control is enabled and can be modified.|attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTextBinding`|IValueBinding<String>|The expression of DataSource item that will be displayed in the control.|attribute, bindable||
|`ItemTitleBinding`|IValueBinding|The expression of DataSource item that will be placed into html title attribute.|attribute, bindable||
|`ItemValueBinding`|IValueBinding|The expression of DataSource item that will be passed to the SelectedValue property when the item is selected.|attribute, bindable||
|`SelectedValue`|Object|Gets or sets the value of the selected item.|attribute, bindable||
|`SelectMenuSize`|Int32||attribute, static value, bindable|1|
|`Size`|([Size](../_enums/DotVVM.Bootstrap5.Controls.Size.md))|Gets or sets the size of the ComboBox.|attribute, static value|Default|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`SelectionChanged`|Command|Gets or sets the command that will be triggered when the selection is changed.|

## Sample 1: Basic Usage

To fill combobox vith values use property `DataSource` and then properties `ItemTextBinding`, `ItemValueBinding` and `ItemTitleBinding` which set text, value and title of combobox items.

To specify currently displayed item use property `SelectedValue` and set it to index of item.

```DOTHTML
<bs:ComboBox SelectedValue="{value: SelectedValue}" 
             DataSource="{value: ComboBoxDataSource}" 
             ItemTextBinding="{value: Text}" 
             ItemValueBinding="{value: Value}" 
             ItemTitleBinding="{value: Title}" />

Selected value: {{value:  SelectedValue}}

```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<ListItemModel> ComboBoxDataSource { get; set; } = new List<ListItemModel>
            {
                new ListItemModel()  { Value = 1, Text = "Too long text", Title = "Nice title",  },
                new ListItemModel()  { Value = 2, Text = "Text", Title = "Even nicer title" }
            };


    public int SelectedValue { get; set; }

    public class ListItemModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
```

## Sample 2: ComboBox Sizing

Use the `Size` property to set the size of the ComboBox.

```DOTHTML
    <h5>Default Size</h5>
    <bs:ComboBox SelectedValue="{value: SelectedValue}" 
                 DataSource="{value: ComboBoxDataSource}" 
                 ItemTextBinding="{value: Text}" 
                 ItemValueBinding="{value: Value}" 
                 Size="Default" />
    <h5>Large Size</h5>
    <bs:ComboBox SelectedValue="{value: SelectedValue}" 
                 DataSource="{value: ComboBoxDataSource}" 
                 ItemTextBinding="{value: Text}" 
                 ItemValueBinding="{value: Value}" 
                 Size="Large" />
    <h5>Small Size</h5>
    <bs:ComboBox SelectedValue="{value: SelectedValue}" 
                 DataSource="{value: ComboBoxDataSource}" 
                 ItemTextBinding="{value: Text}" 
                 ItemValueBinding="{value: Value}" 
                 Size="Small" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<ListItemModel> ComboBoxDataSource { get; set; } = new List<ListItemModel>
            {
                new ListItemModel()  { Value = 1, Text = "Too long text", Title = "Nice title",  },
                new ListItemModel()  { Value = 2, Text = "Text", Title = "Even nicer title" }
            };


    public int SelectedValue { get; set; }

    public class ListItemModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
```

## Sample 3: Empty Item Text

Use property `EmptyItemText` to specify shown text if no item is selected.

```DOTHTML
    <bs:ComboBox SelectedValue="{value: null}" 
                 DataSource="{value: ComboBoxDataSource}" 
                 ItemTextBinding="{value: Text}" 
                 ItemValueBinding="{value: Value}" 
                 EmptyItemText="Some Empty Item Text" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public List<ListItemModel> ComboBoxDataSource { get; set; } = new List<ListItemModel>
            {
                new ListItemModel()  { Value = 1, Text = "Too long text", Title = "Nice title",  },
                new ListItemModel()  { Value = 2, Text = "Text", Title = "Even nicer title" }
            };


    public int SelectedValue { get; set; }

    public class ListItemModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
```

