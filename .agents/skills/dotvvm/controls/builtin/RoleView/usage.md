# <dot:RoleView>
Allows to display different content to users that are member of a specific role.

## Rendered output
The control renders the contents of the `IsMemberTemplate` or `IsNotMemberTemplate` property. Optionally you can enable wrapper tag rendering using
the `RenderWrapperTag` property. The tag name can be changed using the `WrapperTagName` property.

```DOTHTML
<div>
    <!-- Contents of the IsMemberTemplate or IsNotMemberTemplate -->
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`HideForAnonymousUsers`|Boolean|Gets or sets whether the control will be hidden completely to anonymous users. If set to false,             the IsNotMemberTemplate will be rendered to anonymous users.|attribute, static value|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsMemberTemplate`|ITemplate|Gets or sets the content displayed to the users which are in one or more roles specified by the Roles property.|inner element, static value, default property||
|`IsNotMemberTemplate`|ITemplate|Gets or sets the content displayed to the users which are not in any of the roles specified by the Roles property.|inner element, static value||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|False|
|`Roles`|String[]|Gets or sets a comma-separated list of roles. The user must be a member of one or more of these roles.|attribute, static value||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: RoleView

The `Roles` property contains a comma-separated list of roles. 

The `IsMemberTemplate` defines the content displayed to the users who are member of at least one of the role in the `Roles` property.

The `IsNotMemberTemplate` defines the content displayed to other users.

By default, the control is hidden completely to the users who are not authenticated. If you want to display the `IsNotMemberTemplate`
even to the anonymous users, set the `HideForAnonymousUsers` property to `false`.

```DOTHTML
<dot:RoleView Roles="admin,moderator,tester" HideForAnonymousUsers="false">
  <IsMemberTemplate>
    I am a member.
  </IsMemberTemplate>
  <IsNotMemberTemplate>
    I am not a member.
  </IsNotMemberTemplate>
</dot:RoleView>
```

