# <dot:ClaimView>
Allows to display different content to users who have a specific claim.

## Rendered output
The control renders the contents of the `HasClaimTemplate` or `HasNotClaimTemplate` property. Optionally you can enable wrapper tag rendering using
the `RenderWrapperTag` property. The tag name can be changed using the `WrapperTagName` property.

```DOTHTML
<div>
    <!-- Contents of the HasClaimTemplate or HasNotClaimTemplate -->
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`Claim`|String|Gets or sets the type of claim the user must have.|attribute, static value, bindable||
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HasClaimTemplate`|ITemplate|Gets or sets the content displayed to the users who have the Claim with one or more of accepted values.|inner element, static value, default property||
|`HasNotClaimTemplate`|ITemplate|Gets or sets the content displayed to the users who don't have the Claim with any of accepted values.|inner element, static value||
|`HideForAnonymousUsers`|Boolean|Gets or sets whether the control will be hidden completely to anonymous users. If set to false,             the HasNotClaimTemplate will be rendered to anonymous users.|attribute, static value|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|False|
|`Values`|String[]|Gets or sets a comma-separated list of accepted values. If specified; the user must have the Claim             with one or more of the values. Otherwise; all values are accepted.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: ClaimView

The `Claim` property specifies the type of claim the user must have.

The `Values` property optionally contains a comma-separated list of accepted values. If it is missing, all values are accepted.

The `HasClaimTemplate` defines the content displayed to the users who have the `Claim` with at least one of accepted values.

The `HasNotClaimTemplate` defines the content displayed to other users.

By default, the control is hidden completely to the users who are not authenticated. If you want to display the `HasNotClaimTemplate`
even to the anonymous users, set the `HideForAnonymousUsers` property to `false`. 

```DOTHTML
<dot:ClaimView Claim="Permission" Values="CanAddUsers" HideForAnonymousUsers="false">
    <HasClaimTemplate>
        I can add new users.
    </HasClaimTemplate>
    <HasNotClaimTemplate>
        I can't add new users.
    </HasNotClaimTemplate>
</dot:ClaimView>
```

