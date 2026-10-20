# <dot:TemplateHost>
This control allows to host a template (an `ITemplate` object) and build its contents using this template.

> The control is not meant to be used in DotHTML markup - it helps the control developers to place template inside another controls at a later time.

```CSHARP
public class MyMenu : CompositeControl
{
    public static DotvvmControl GetContents(
        // please note that appropriate DataContextChange attributes need to be applied here as the template is used inside Repeater
        ITemplate itemTemplate,
        ...
    )
    {
        return new Repeater()
            ...
            .SetProperty(r => r.ItemTemplate, new DelegateTemplate(serviceProvider => 
                new HtmlGenericControl("li")
                    .AppendChildren(new TemplateHost(itemTemplate))
            ));
    }
}
```

## See also

* [Composite controls](~/pages/concepts/control-development/composite-controls)

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Template`|ITemplate|Gets or sets the template that will be rendered inside this control.|attribute, static value||

