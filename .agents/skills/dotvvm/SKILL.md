---
name: dotvvm
description: How to write DotVVM pages and viewmodels and what components can use.
---

# Project structure

Every page in DotVVM has a view (`.dothtml`) and a viewmodel (`.cs`).

There are two conventions for the file locations:
* Each page has its own folder with both view and viewmodel, along with related CSS files, images, etc. For example, the `Home` page will have `Pages/Home/Home.dothtml` and `Pages/Home/HomeViewModel.cs` files
* Views are in a `Views` directory and viewmodels are in the `ViewModels` directory. For example, the `Home` page will have `Views/Landing/Home.dothtml` and `ViewModels/Landing/HomeViewModel.cs` files

Components have `.dotcontrol` extension and are usually placed in `Controls` or `Components` directory.

Pages usually reference a master page (`.dotmaster`). In this case, the page viewmodel must inherit from master page viewmodel. The page must contain `<dot:Content>` sections for every `<dot:ContentPlaceHolder>`/`<dot:SpaContentPlaceHolder>` in the master page.

All pages must be registered in `DotvvmStartup.cs` file, where you specify the route and optionally the parameters.

# View

Views use HTML syntax with several extensions:

## Directives

Directives are always on the top of the file and start with `@`.

Valid directives are:
* `@viewModel` (fully qualified name of the viewmodel class)
* `@masterPage` (project-relative path to the master page)
* `@import` (C# namespace to use in the bindings)
* `@service` (name and type of the service to inject into the viewmodel)
* `@js` (name of JS module registered in `DotvvmStartup.cs`)
* `@noWrapperTag` (in controls, to omit the wrapper tag)
* `@wrapperTag` (in controls, to specify the wrapper tag)
* `@property` (in controls, to define a property of the control without defining base class)

## Data-bindings

Data-bindings are used to connect the view with the viewmodel
* They are defined in attributes (in single curly braces) or inside text nodes (double curly braces, `hello {{value: Name}}!`)
* When used in attributes, the entire attribute must be a binding, for example, `<input value="{value: Name}" />`
* Do not escape double quotes with \ or &quot; inside DotVVM bindings - this syntax is valid: `<a href="{value: "a" + "b"}">`
* To get to parent binding contexts (when `DataSource` on `Repeater/GridView` or `DataContext` on any element is used), use `_parent`, or `_root` keywords. You can use `_index` to get the index of the current item in repeater
* To change binding context for an element, use `DataContext="{value: ChildObject}"`. When `ChildObject` is `null`, the element is removed from the page, so the bindings inside do not check for null
* Bindings never throw. `null` values are propagated in bindings, the `.` operator behaves like `?.`
* See the [operators and expressions supported in DotVVM bindings](./supported-expressions.md)

Valid types of bindings:
* `value` (two-way binding in the viewmodel, can be updated while page is loaded)
* `resource` (rendered into HTML, non-updatable)
* `command` (sends the entire viewmodel to the server and executes the method)
* `staticCommand` (calls a method on the server and uses the result to patch the viewmodel, can also do local-only operations)

## Controls
Custom tags with registered prefix (`dot` for built-in framework controls, `bs` for Bootstrap for DotVVM controls, `bp` for DotVVM Business Pack, `dc` for DotVVM Contrib, `cc` for custom components). They can have properties (attributes) and content (child elements).

These properties can be applied to DotVVM controls (those which render something) and HTML elements:
* Use `Visible` property to show or hide elements using CSS
* Use `IncludeInPage` to include or exclude elements from the DOM
* To override the default HTML tag for `Repeater`, use `WrapperTagName` property. To omit the wrapper tag, use `RenderWrapperTag="false"`
* To apply conditional CSS classes, use `class-someName="{value: boolExpression}"` instead of string join operations

To make a conditional section without rendering anything, use `<dot:PlaceHolder>`. It supports `IncludeInPage` and `DataContext` properties.

## Valid components and properties

Do not guess control names - look in these files for available controls and properties:

* [Bultin controls](./controls/builtin/controls.md) are available in every project
* [AutoUI controls](./controls/builtin-autoui/controls.md) are available when `DotVVM.AutoUI` is referenced
* [Bootstrap3 controls](./controls/bootstrap3/controls.md) are available when `DotVVM.Controls.Bootstrap` is referenced
* [Bootstrap4 controls](./controls/bootstrap4/controls.md) are available when `DotVVM.Controls.Bootstrap4` is referenced
* [Bootstrap5 controls](./controls/bootstrap5/controls.md) are available when `DotVVM.Controls.Bootstrap5` is referenced
* [BusinessPack controls](./controls/businesspack/controls.md) are available when `DotVVM.BusinessPack` is referenced
* [BusinessPack Messaging controls](./controls/builtin-messaging/controls.md) are available when `DotVVM.BusinessPack.Messaging` is referenced
* [Tailwind controls](./controls/tailwind/controls.md) are available when `DotVVM.Controls.Tailwind` is referenced

# ViewModels

* Viewmodels inherit from `DotvvmViewModelBase`
* Do not implement `INotifyPropertyChanged` interface
* All properties should contain default `get` and `set` accessors without bodies
* Properties that never change (for example, lists of items for ComboBox or similar pickers) can have `[Bind(Direction.ServerToClientFirstRequest)]` attribute
* If the page has several sections with different visibility or validation groups, make a separate model (just C# class) for each section and use it as property in main viewmodel
* More complex components should have their own viewmodels inheriting from `DotvvmViewModelBase`
* Use dependency injection to get services in the viewmodel

# Validation
* Use Data Annotation attributes for validation, or implement `IValidatableObject` interface. For business validation, use `this.AddModelError(vm => ..., "error message")` method in the viewmodel followed by `Context.FailOnInvalidModelState()`
* Validation happens automatically for command bindings. To disable it (for delete or cancel buttons), use `Validation.Enabled="false"` property on the button. To validate only a specific section, use `Validation.Target="{value: ChildObject}"` (works only for nested objects, not for collections or primitive types)

# Data access
* To load data, override `PreRender` method. To execute code only on the first page load, check `Context.IsPostBack` property. Methods called from commands occur before `PreRender`. For viewmodel init, use `Init`, or `Load` (occurs after loading the viewmodel sent by client)
* For `GridView`, use `GridViewDataSet` class which supports sorting and paging, and load data only when `dataSet.IsRefreshRequested`

# Securing viewmodels

The user can modify any viewmodel property with public setter. Use `dotvvm-security` skill to ensure the page is resillient for attacks.

# Authoring controls

If you need to build your own control, use `dotvvm-authoring-controls` skill.

# Compilation & validation

* If you only change DotHTML markup, you don't need to rebuild the project. DotVVM can recompile the page while the process is running
* If you modify viewmodels or other C# files, you need to rebuild the project
* To list errors or warnings in DotHTML markup files,
  * use `dotvvm lint` command in the project directory (for DotVVM 5.0 and newer; requires .NET global tool `DotVVM.CommandLine`; do not check if it is installed, just run it - if it fails, ask the user to install it)
  * or run the app and visit `/_dotvvm/diagnostics/compilation` to see the compilation errors or warnings on all pages.

# UI best practices

* Most application use global error handlers that will catch exceptions and display an error message. No need to try/catch everything in commands
* For destructive actions, use `<PostBack.Handlers>` collection with `<dot:ConfirmPostBackHandler Message="Do you really ..."? />` (or its equivalent from control libraries) to show confirmation before the action is taken