---
name: dotvvm-security
description: Rules for keeping DotVVM viewmodels secure.
---

* Look at all properties and child objects in the viewmodel:
    * Check that there are no sensitive information - secrets, password hashes, security codes, pin, connection strings. Passwords in viewmodels are only allowed on pages where the user enters them - login, password reset page...
    * Check if there are properties that may depend on user permissions (for example ID of some entity, ID of the current tenant or organization, or properties calculated from roles, e.g. `CanEdit`, `IsAdmin`, `AllowDelete`, `ShowEditButton`...). Make sure the user cannot change these values by rewriting URL or by changing the viewmodel in browser Dev Tools and make a postback. These properties may be protected by one of these options:
        * declare only a getter
        * have a private setter
        * use `[Bind(Direction.ServerToClient)]` or `[Bind(Direction.ServerToClientFirstRequest)]` attribute
        * be calculated every time in `Load` method (including on postbacks) before they are used in other viewmodel methods. 
        * be bound from query string or route (`[FromQuery]` or `[FromRoute]`, or retrieved with `Context.Query` or `Context.Parameters`)
        * be protected with `[Protect(ProtectMode.Sign)]` or `[Protect(ProtectMode.Encrypt)]`
        * their value is never used
        * their value is always validated before it is used
* Look at all methods called by static commands (`[AllowStaticCommand]`) and ensure their arguments that may depend on user permissions are correctly validated.
* If the user is supposed to edit viewmodel properties, check that there are proper validation attributes, or that the models implement `IValidatableObject`, or that validation is done explicitly in the viewmodel methods (`AddModelError` followed by `Context.FailOnInvalidModelState`).
* Look at places where the validation is disabled in the UI (`Validation.Enabled="false"`) or scoped to a smaller target (`Validation.Target`), and ensure it is necessary (it makes sense for delete or cancel actions, opening modal dialogs, recalculating values on changes).
* Where necessary, check that the access to pages is authorized using `await Context.Authorize(...)` in `Init`, or by using `[Authorize]` attribute.
* If `Context.Authorize` is used in `Init`, make sure it is awaited, and the method is not overriden without calling `base.Init`.
* If some parts of the UI are hidden because of permissions (`Visible` or `IncludeInPage`), ensure that the permissions are checked also on the places where these models are used.
* If `<dot:HtmlLiteral>` is used, look at the source of the value and investigate if there is a risk of XSS.
* If any value in the viewmodel may represent a filename or a file-system path, ensure that it is properly validated.
* When doing redirects to URLs in the viewmodel or passed as parameters (such as `returnUrl`), ensure `Context.RedirectToLocalUrl` is used to prevent the open redirect attack.