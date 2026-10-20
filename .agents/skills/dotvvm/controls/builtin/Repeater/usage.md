# <dot:Repeater>
Repeats a template for each item in the `DataSource` collection.

## Rendered output
You can define, what tag the *Repeater* renders, using the `WrapperTagName`. The default is **div**:

```DOTHTML
<dot:Repeater DataSource="{value: Items}">
    <ItemTemplate>
        <p>{{value: Name}}</p>
    </ItemTemplate>
</dot:Repeater>

<!-- Client rendering mode -->
<div data-bind="template: { name: "hashOfTheTemplateContent", data = ...}">
</div>
<template id="hashOfTheTemplateContent">
    <p><span data-bind="..."></span></p>
</template>

<!-- Server rendering mode -->
<div>
    <p>Jim Hacker</p>
    <p>Humphrey Appleby</p>
    <p>Bernard Woolley</p>
</div>
```
> The `ItemTemplate` is default element property and so the `<ItemTemplate>` element **can be omitted** if it's the only one inside the Repeater control.

Using the `RenderWrapperTag` you can turn off the wrapper tag. The Knockout comments will then be used 
in the [client rendering mode](~/pages/concepts/server-side-rendering):
```DOTHTML
<!-- ko foreach: ... -->
<p><span data-bind="..."></span></p>
<!-- /ko -->
```

Be careful. Knockout comment bindings don't work well if they are directly in the `<table>` element. Put the Repeater inside the `<tbody>` element and it will work.

> From DotVVM 4.0, the `Repeater` control renders the `<template>` element by default instead of rendering the template inside the wrapper tag. If you want to fall back to the previous behavior, set the `RenderAsNamedTemplate` property to `false`.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSource`|Object|Gets or sets the source collection or a GridViewDataSet that contains data in the control.|attribute, bindable||
|`EmptyDataTemplate`|ITemplate|Gets or sets the template which will be displayed when the DataSource is empty.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`ItemTemplate`|ITemplate|Gets or sets the template for each Repeater item.|inner element, static value, default property||
|`RenderAsNamedTemplate`|Boolean|Gets or sets if the repeater should use inline template (the default, traditional way of doing things) or if it should use Knockout's named template (with the template in <script> tag).|attribute, static value|True|
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|True|
|`SeparatorTemplate`|ITemplate|Gets or sets the template containing the elements that separate items.|inner element, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: Basic Repeater

The `DataSource` points to an *IEnumerable* or a *GridViewDataSet* object.

Inside the `ItemTemplate`, you can use **_this** to access the current data item.

```DOTHTML
<dot:Repeater DataSource="{value: Items}">
  <ItemTemplate>
    {{value: _this}}<br />
  </ItemTemplate>
</dot:Repeater>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Items { get; set; } = { "First", "Second", "Third" };

    }
}
```

## Sample 2: Wrapper Tag Customization

If you don't want to render `<div>`, just change the `WrapperTagName` property to something else.
Or, set the `RenderWrapperTag` property to *false* if you don't want to render any wrapper tag.

```DOTHTML
<dot:Repeater DataSource="{value: Items}" WrapperTagName="ul">
    <ItemTemplate>
        <li>{{value: _this}}</li>
    </ItemTemplate>
</dot:Repeater>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string[] Items { get; set; } = { "First", "Second", "Third" };

    }
}
```

## Sample 3: Real World Sample

A simple task list.

```DOTHTML
@viewModel DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample3.ViewModel, DotvvmWeb

<p>
    Create a new task: 
    <dot:TextBox Text="{value: NewTaskTitle}" /> 
    <dot:Button Text="Add" Click="{command: AddTask()}" />
</p>

<dot:Repeater DataSource="{value: Tasks}" WrapperTagName="table">
    <ItemTemplate>
        <tr>
            <td>{{value: Title}}</td>
            <td>{{value: Completed ? ("Finished: " + CompletionDate) : "Not yet"}}</td>
            <td>
                <dot:LinkButton Text="Done" 
                                Click="{command: CompleteTask()}" 
                                Visible="{value: !Completed}" />
            </td>
        </tr>
    </ItemTemplate>
</dot:Repeater>
```

```CSHARP
using System;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.Repeater.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public List<MyTask> Tasks { get; set; } = new List<MyTask>();

        public string NewTaskTitle { get; set; }

        public ViewModel()
        {
            Tasks.Add(new MyTask("Install the DotVVM VS Extension"));
            Tasks.Add(new MyTask("Create the first project"));
            Tasks.Add(new MyTask("Build your first app"));
            Tasks.Add(new MyTask("Buy Professional Edition of DotVVM VS Extension"));
        }

        public void AddTask()
        {
            Tasks.Add(new MyTask(NewTaskTitle));
            NewTaskTitle = null;
        }

    }

    public class MyTask
    {
        public string Title { get; set; }

        public bool Completed { get; set; } = false;

        public string CompletionDate { get; set; }

        public MyTask(string title)
        {
            Title = title;
        }

        public MyTask()
        {

        }

        public void CompleteTask()
        {
            Completed = true;
            CompletionDate = DateTime.Now.ToString();
        }
    }
}
```

