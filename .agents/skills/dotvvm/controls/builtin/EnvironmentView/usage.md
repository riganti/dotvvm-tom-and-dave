# <dot:EnvironmentView>
Allows to render content when an application is running on a specific environment (eg. Development, Production). We use an `IEnvironmentNameProvider`
service to get the name of the current environment. The default implementation behaves differently on OWIN and on ASP.NET Core.

- **On ASP.NET Core:** We simply use the [IHostingEnvironment.EnvironmentName](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.hostingenvironmentextensions?view=dotnet-plat-ext-5.0)
property to get the name.
- **On OWIN:** We use a value stored in the environment dictionary under the `host.AppMode` key. If you host your application on `System.Web` 
the value is automatically set to `Development` when debugging is enabled in Web.config.

In both cases the default environment name is `Production`. You may override this behavior by implementing your own `IEnvironmentNameProvider`.

## Rendered output
The control renders the contents of the `IsEnvironmentTemplate` or `IsNotEnvironmentTemplate` property. Optionally you can enable wrapper tag rendering using
the `RenderWrapperTag` property. The tag name can be changed using the `WrapperTagName` property. 

```DOTHTML
<div>
    <!-- Contents of the IsEnvironmentTemplate or IsNotEnvironmentTemplate -->
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Environments`|String[]|Gets or sets a comma-separated list of hosting environments (e.g. Development, Production).|attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`IsEnvironmentTemplate`|ITemplate|Gets or sets the content rendered when the application is running in one of the specified environments.|inner element, static value, default property||
|`IsNotEnvironmentTemplate`|ITemplate|Gets or sets the content rendered when the application is not running in any of the specified environments.|inner element, static value||
|`RenderWrapperTag`|Boolean|Gets or sets whether the control should render a wrapper element.|attribute, static value|False|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`WrapperTagName`|String|Gets or sets the name of the tag that wraps the Repeater.|attribute, static value|div|

## Sample 1: EnvironmentView

The `Environments` property contains a comma-separated list of environment names. 

The `IsEnvironmentTemplate` defines the content rendered when the application is running on one of the specified `Environments`.

The `IsNotEnvironmentTemplate` defines the content rendered on other environments.

```DOTHTML
<dot:EnvironmentView Environments="Production,Development">
    Production or Development environment.
</dot:EnvironmentView>

<dot:EnvironmentView Environments="Staging">
    <IsEnvironmentTemplate>
        Staging environment.
    </IsEnvironmentTemplate>
    <IsNotEnvironmentTemplate>
        Other environment.
    </IsNotEnvironmentTemplate>
</dot:EnvironmentView>
```

