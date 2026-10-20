# <dot:CloseButton>
Renders a close button used in [Alers](~/controls/bootstrap5/Alert), [ModalDialog](~/controls/bootstrap5/ModalDialog) and others. 

<https://getbootstrap.com/docs/5.2/components/modal/>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`CloseButtonLabel`|String|Gets or sets the text displayed for the screen readers.|attribute, static value|Close|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Click`|ICommandBinding|Gets or sets the command that will be triggered when the close button is clicked. The `IsDisplayed` property can be set to `false` to close the ModalDialog or Alert control.|

## Sample 1: Close button 

`Close button` control can be used while using custom header templates.

```DOTHTML
<bs:ModalDialog ScrollableContent="true" IsDisplayed="{value: Displayed}">
  <Content>
      <span>
          Dolore at lorem option no duis est magna erat diam lorem sadipscing eos ea minim justo nonumy dolores tempor vulputate erat amet molestie dolor et dolores at no ipsum at
          eirmod et ut aliquyam sed in rebum dolor et vero sit feugiat et eirmod ullamcorper et invidunt et vero in accusam vulputate amet nulla</span>
  </Content>
  <FooterTemplate>
      <bs:CloseButton data-ui="close-btn-dismissed" Click="{staticCommand: Displayed = false}" />
  </FooterTemplate>
</bs:ModalDialog>
```

```CSHARP
public class ViewModel
{
    public bool Displayed { get; set; } = true;

}

```

