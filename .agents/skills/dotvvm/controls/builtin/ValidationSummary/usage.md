# <dot:ValidationSummary>
Displays all validation errors in a list.

Look at the [Validation tutorial](~/pages/concepts/validation/overview) to see how the validation works.

## Rendered output
This control renders the HTML unordered list.

```DOTHTML
<ul data-bind="foreach: ...">
  <li data-bind="..."></li>
</ul>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HideWhenValid`|Boolean|Gets or sets whether this control is hidden if there are no validation messages|attribute, static value, bindable|False|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeErrorsFromChildren`|Boolean|Gets or sets whether the errors from child objects in the viewmodel will be displayed too.|attribute, static value|False|
|`IncludeErrorsFromTarget`|Boolean|Gets or sets whether the errors from the TargetProperty object will be displayed too.|attribute, static value|True|
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic ValidationSummary

The `ValidationSummary` will display all validation errors in the validation context.

```DOTHTML
<dot:TextBox Text="{value: Text}" />

<dot:ValidationSummary />

<dot:Button Text="SEND" Click="{command: Send()}" />
```

```CSHARP
using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationSummary.sample1
{
    public class ViewModel
    {
        [Required]
        public string Text { get; set; }

        public void Send()
        {
            // process data
        }
    }
}
```

## Sample 2: Validation errors from child objects

By default, the `ValidationSummary` control displays errors that comes directly from the `Validation.Target` object's properties. 
If the validation target contains another child objects, the validation errors from those objects are not displayed.
This is because of performance reasons.

However, using the `IncludeErrorsFromChildren` property, you can tell the control to display validation errors event from the 
child objects. Just be careful because there will be a performance penalty if you use this feature on large and complicated viewmodels.

```DOTHTML
<dot:TextBox Text="{value: ChildObject.Text}" />

<dot:ValidationSummary IncludeErrorsFromChildren="true" />

<dot:Button Text="SEND" Click="{command: Send()}" />
```

```CSHARP
using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationSummary.sample2
{
    public class ViewModel
    {
        public ChildViewModel ChildObject { get; set; } = new ChildViewModel();

        public void Send()
        {
            // process data
        }
    }

    public class ChildViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}
```

## Sample 3: Validation errors from the `Validation.Target`

The `ValidationSummary` control also displays validation errors attached directly to the `Validation.Target` object. This is useful for errors which do not belong to a particular property (for example, incorrect username or password). 

You can disable the behavior by setting the `IncludeErrorsFromTarget` property to `false`.

> The sample below creates a server-side validation error using the [IValidatableObject](~/pages/concepts/validation/overview) interface.

> The default value of the `IncludeErrorsFromTarget` property was changed in DotVVM 4.0 - previously, it was `false`. In DotVVM 4.0, we've decided to change this to `true` as it is a more reasonable default value.

```DOTHTML
<dot:TextBox Text="{value: ChildObject.Text1}" />
<dot:TextBox Text="{value: ChildObject.Text2}" />

<dot:ValidationSummary 
    Validation.Target="{value: ChildObject}"/>

<dot:Button Text="SEND" Click="{command: Send()}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.builtin.ValidationSummary.sample3
{
    public class ViewModel
    {
        public ChildViewModel ChildObject { get; set; } = new ChildViewModel();

        public void Send()
        {
            // process data
        }
    }

    public class ChildViewModel : IValidatableObject
    {
        [Required]
        public string Text1 { get; set; }

        [Required]
        public string Text2 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Text1 != Text2)
            {
                yield return new ValidationResult("This ChildViewModel is not valid.");
            }
        }
    }
}
```

