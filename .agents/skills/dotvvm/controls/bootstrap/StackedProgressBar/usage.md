# <bs:StackedProgressBar>
Renders the Bootstrap Stacked Progress Bar widget. Use the [ProgressBar](~/controls/bootstrap/ProgressBar) controls inside.

<https://getbootstrap.com/docs/3.3/components/#progress>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Stacked Progress Bar

Placing [ProgressBar](~/controls/bootstrap/ProgressBar) controls inside the control creates `StackedProgressBar`.

```DOTHTML
<bs:StackedProgressBar>
  <bs:ProgressBar Color="Success" Value="25" />
  <bs:ProgressBar Color="Info" Value="25" />
  <bs:ProgressBar Color="Warning" Value="11" />
  <bs:ProgressBar Color="Danger" Value="14" />
</bs:StackedProgressBar>
```

