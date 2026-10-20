# <dot:AuthenticatedView>
Allows to display different content to users that are authenticated and users that are not.

## Rendered output
The control renders the contents of the `AuthenticatedTemplate` or `NotAuthenticatedTemplate` property. Optionally you can enable wrapper tag rendering using
the `RenderWrapperTag` property. The tag name can be changed using the `WrapperTagName` property.

```DOTHTML
<div>
    <!-- Contents of the AuthenticatedTemplate or NotAuthenticatedTemplate -->
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AuthenticatedTemplate`|ITemplate|Gets or sets the content displayed to the authenticated users.|inner element, static value, bindable, default property||
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`NotAuthenticatedTemplate`|ITemplate|Gets or sets the content displayed to the users that are not authenticated.|inner element, static value, bindable||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: AuthenticatedView

The `AuthenticatedTemplate` property defines the content for users who are authenticated. The `NotAuthenticatedTemplate` property defines the content for users who are not authenticated. 

You have to specify at least one of the templates.

```DOTHTML
<dot:AuthenticatedView>
  <AuthenticatedTemplate>
    I am authenticated.
  </AuthenticatedTemplate>
  <NotAuthenticatedTemplate>
    I am not authenticated.
  </NotAuthenticatedTemplate>
</dot:AuthenticatedView>
```

