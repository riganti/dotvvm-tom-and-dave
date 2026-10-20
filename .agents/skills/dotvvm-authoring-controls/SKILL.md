---
name: dotvvm-authoring-controls
description: Use when you need to build a custom DotVVM control
---

When implementing components, use one of these approaches:
* Composite control - great for pass-through "HTML helpers" - specify a bunch of properties and return a control tree representing what should be rendered. Good for universal components that may be used in other apps (buttons, icons, other UI elements).
* Markup control - a `.dotcontrol` file with markup, usually app or page-specific.

# Composite Controls

Composite control is a class based on this pattern:

```csharp
public class MyControl : CompositeControl
{
	public static DotvvmControl GetContents(
		HtmlCapability html, 	// this allows using arbitrary attributes on the control - pass it to the root control
		string title,		// can accept only hard-coded values, or resource binding
		ValueOrBinding<string>? description = null,   // accepts both value and binding
		[DefaultValue(SomeEnum.SomeValue)] IValueBinding<SomeEnum> someEnum = default,	// accepts only binding
		ICommandBinding? command = null		// works with commands
	) 
	{
		return new HtmlGenericControl("div", html)
			.AddCssClass(someEnum.Select(e => e.ToString()))
			.AppendChildren(
				new Literal()
					.SetProperty(l => l.Text, title),
				new HtmlGenericControl("div")
					.SetProperty(c => c.InnerText, description), // SetProperty is fine with null values, it will ignore them
				command != null 
					? new Button()
						.SetProperty(b => b.Click, command)
					: null		// null controls are fine ignored
			);
	}
}
```
																			  
* It can use dependency injection and override `Init`, `Load`, and `PreRender` - the `GetContents` method can be instance in such cases.
* `Select` method on `ValueOrBinding` can apply only projections that can be translated to JavaScript by DotVVM - see [../dotvvm/supported-expressions.md].
	
# Markup Controls

Markup control is a `.dotcontrol` file which uses DotHTML syntax. Use `dotvvm` skill for writing the actual markup.
* The main data of the control (the model object) should be passed through `@viewModel` directive (set `DataContext` on the place where you use the control). If the control needs no data, use `@viewModel object`.
* Declare additional properties using `@property bool ShowTitle` for settings or auxiliary data (text on a button, list of items for comboboxes etc.).
* Try to avoid using `@baseType` and putting logic in control code behind - it should be in the viewmodel. The control should not load its data, it should get them from the parent.
* Use `@noWrapperTag` or `@wrapperTag span` to decide what element will the control render.
* When the control is more complex or needs some logic, make a separate viewmodel for it, and inherit from `DotvvmViewModelBase` to be able to override `Init`, `Load`, `PreRender`. Then, use the viewmodel for the control.
