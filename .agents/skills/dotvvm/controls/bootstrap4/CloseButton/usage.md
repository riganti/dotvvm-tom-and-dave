# <bs:CloseButton>
Renders a close button for [ModalDialog](~/controls/bootstrap4/ModalDialog). 

<https://getbootstrap.com/docs/4.3/components/modal/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataDismiss`|String|Gets or sets the data-dismiss parameter of the control.|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Close button

`Close button` control can be used while using custom header templates.

```DOTHTML
<bs:ModalDialog IsDisplayed="{value: Displayed}">

  <HeaderTemplate>
    Dialog header
    <bs:CloseButton/>
  </HeaderTemplate>

  <ContentTemplate>
    This is the contents of the dialog.
  </ContentTemplate>
</bs:ModalDialog>
```

```CSHARP
public class ViewModel
{
    public bool Displayed { get; set; } = true;

}

```

