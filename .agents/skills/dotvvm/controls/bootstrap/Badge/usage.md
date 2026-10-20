# <bs:Badge>
Renders a Bootstrap badge component.

<https://getbootstrap.com/docs/3.3/components/#badges>

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Text`|String|Gets or sets the text inside the badge.|attribute, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Badge

Place the contents of the `Badge` inside the control, or use the `Text` property.

```DOTHTML
<bs:Badge Text="100"/>

<bs:Badge>
  <h1>9000+</h1>
</bs:Badge>

```

## Sample 2: Badge in a Button

If you need to use the `Badge` inside the button, don't forget to set the `ButtonTagName` to `Button`.

Otherwise, the button would be rendered as `<input type="text">` which supports only a plain text values.

```DOTHTML
<bs:Button Click="{command: Increment()}" ButtonTagName="button">
  Number of clicks: <bs:Badge Text="{value: Clicks}"/>
</bs:Button>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.Badge.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int Clicks { get; set; } = 0;

        public void Increment()
        {
            Clicks++;
        }
    }
}
```

