---
name: dotvvm-ui-prototyping
description: Creates a clickable UI prototype in a form of DotVVM application using Tailwind UI for DotVVM controls.
---

## General rules

* For UI, Use Tailwind UI for DotVVM controls. Their usage is documented in `dotvvm` skill.
* Define a folder `MockedData` with C# classes for providing mocked data so they can be reused accross pages. Define models as plain C# classes in the `Models` directory.
* The UI doesn't need to manipulate with data - it is expacted that the buttons will do nothing, only navigation between pages should happen.

## Start the project

To create a DotVVM app, use a dotnet new template located in `./template` folder.
If the repo doesn't contain the `src` dir, create it so the app is not in the repo root.

```
dotnet new install ./template
mkdir APP_DIR
cd APP_DIR
dotnet new dotvvm-ui-prototyping
```

* Pages should go in the `Pages` directory, making a directory for every page. Design a hierarchy of directories to group related pages, for example `Pages/Admin/Users/List` containing files named `AdminUsersList.dothtml` and `AdminUsersListViewModel.cs`. 
* Shell of the app (menu, footer, etc.) should be a master page `Pages/Layout.dotmaster` and `Pages/LayoutViewModel.cs`.
* Controls are defined in `Controls` directory, having a separate directory per control. More complex controls should have their own viewmodels.

## Main layout

Choose the main layout for the master page from these three ones:
* Sidebar menu
* Top menu
* Top menu with sidebar

If unclear which layout to choose, ask the user.

```dothtml
<t:AppLayout>
    <TopMenuTemplate>
      <t:TopMenu>...</t:TopMenu>
    </TopMenuTemplate>
    <SideMenuTemplate>
      <t:SideMenu>...</t:SideMenu>
    </SideMenuTemplate>
    <Content>
        <dot:ContentPlaceHolder ID="MainContent" />
    </Content>
</t:AppLayout> 
```

If the application required breadcrumbs, make a separate `<dot:ContentPlaceHolder ID="Navigation">` in the layout page and define `<dot:Content>` with `<t:Breadcrumbs>` control in the individual pages. If it makes sense, use this area for page title or potential back button as well.

## Page organization

* Each page should have a primary purpose. Limit the secondary purposes to a minimum. 
* If there are multiple purposes, move them to modal dialogs or separate pages.
* If there is a longer form, split it into sections.
* For more editable fields, consider using a wizard with multiple steps (`<t:ProcessTimeline>`), multi-tab layout (`<t:TabControl>`), or locked sections that can be edited separately. 
* Login and error pages should be the only ones not using the main layout.
* If the page needs a title, prepare the `Init` function in the viewmodel and set the title.

## Page layout

For most things, use `<t:StackLayout>` - it will maintain consistent spacing between elements. Use `<t:DockLayout>` to push some things to the start, some to the end, and use the rest to fill the remaining space. For grid layouts, we don't have a control yet - use `<div class="grid grid-cols-3 gap-4">`.

## Forms

Use `<t:Form>` and define fields (they handle labels and validation automatically):
* `<t:TextBoxFormField>` for text input or textarea
* `<t:CheckBoxFormField>` for checkbox input
* `<t:ComboBoxFormField>` for select input
* `<t:DateTimePickerFormField>` for date input
* `<t:FormField>` for any custom content

To fit multiple fields on the same row, wrap them in `<t:FormRow>`.
Limit the width for short values (`Size=Quarter|Half|ThreeQuarters`).

In viewmodels, make a model object for each form, and use validation attributes (e.g. `[Required]`).
Forms should use `DataContext="{value: Model}"` and `Validation.Target="{value: _this}"` to simplify bindings and validate only the model object.

## Dynamic sections

* `DataContext` will hide the section if its value is null - no need to combine with `IncludeInPage` or `Visible`. When set, it changes the binding context on other properties of the control.
* Inheritance in viewmodels is not supported - use this pattern and assume that only one property will be non-null:
    ```csharp
	public class AnimalModel 
	{
	    public DogModel? Dog { get; set; }
		public CatModel? Cat { get; set; }
	}
	```
* If you use `DataContext` on an element nested in template, you may run into runtime error "Passing templates to controls is not allowed" - wrap the element with `<dot:PlaceHolder>` to fix it.

## Buttons

* Use `IsSubmitButton=true` for buttons that save data. If they belong to the form, place them inside the `<t:Form>` or `<form>` so they respond to Enter key. 
* Use `Type=Primary|Secondary|Warning|Danger` to indicate the importance of the action.
* Use `Icon` for common actions.
* Non-saving buttons should use `Validation.Enabled=false`.
* Destructive actions should use `<PostBack.Handlers><t:ModalConfirmPostBackHandler Message="..." /></PostBack.Handlers>`.

## Modals

* When using modal dialogs (`<t:ModalDialog>`), extract them as a separate DotVVM markup control in the `Controls` directory. 
* Define a custom viewmodel for the modal dialog, and use it as a property of the page viewmodel.

## Notifications and alerts

* The layout page template already contains `<t:Notifications>` control. To show a toast notification in the screen corner, call `Notifications.Add(new NotificationData() { Text = "...", Type = NotificationType.Success|Info|Warning|Error })` in the viewmodel.
* To display an alert, use `<t:Alert>` control. These alerts stay in pages.

## Grids and tables

* Rather than using grid by default, consider these alternatives:
  * `<t:ListGroup>` for displaying a list of items (title, short descriptions, badges, and a single action).
  * `<dot:Repeater>` with `<t:Card>`.
* Use `<t:GridView>` for displaying tabular data with DotVVM `GridViewDataSet`. It supports sorting and paging. 
* The column with buttons can use `HeaderCssClass="column-shrink" CssClass="column-shrink"` to make it shrink to the size of the buttons.
* There should be `<EmptyDataTemplate>` defined for empty datasets, ideally with a call to action to create a new entry.
* Each table should have `<t:DataPager>` for paging.
* If there is just a few filter fields (e.g. search), place them above the grid. If there are many filter fields, use a modal dialog for filtering.

## Data presentation

* When displaying user, accompany it with `<t:Avatar>`.
* Use `<t:Badge>` for status indicators or tags.
* When displaying values and it is suitable, accompany them with `<t:Icon>`.
* To display images, use `<t:Card>` or `<t:Carousel>`.

## Navigation

* When using route parameters, use `[FromRoute("paramName")]` on viewmodel property to bind it (nullables are supported).
* To make links, prefer using `RouteName` and `Param-paramName` properties instead of composing `NavigateUrl` and `href` yourself. `RouteName` doesn't support value bindings.

## Final check

When you finish writing DotVVM pages and controls, build the project and visit https://PROJECT_URL/_dotvvm/diagnostics/compilation - it compiles all pages and prints all syntax errors and warnings.

After you finish, look if there is `AGENTS.md` - if not, make it based on what you know about the application right now.