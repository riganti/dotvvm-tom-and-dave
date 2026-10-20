# <t:Form>
The Tailwind form controls include `Form`, `FormRow`, `FormField`, and the specialized `TextBoxFormField`, `ComboBoxFormField`, `CheckBoxFormField`, and `DateTimePickerFormField`. Use them to build labeled forms with consistent spacing and validation messages.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate|Gets or sets the template rendered inside the main form body.|inner element, static value, default property||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`FooterTemplate`|ITemplate|Gets or sets the template rendered in the form footer, typically for action buttons.|inner element, static value||
|`HeaderTemplate`|ITemplate|Gets or sets custom header content rendered above the form body. Cannot be combined with HeaderText.|inner element, static value||
|`HeaderText`|String|Gets or sets the plain-text heading rendered in the form header. Cannot be combined with HeaderTemplate.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Sample 1: Basic Form Layout

Use `Form` with `HeaderText`, `ContentTemplate`, and `FooterTemplate`. `FormRow` and `TextBoxFormField` help build simple two-column layouts.


```DOTHTML
<t:Form HeaderText="Customer details">
    <ContentTemplate>
        <t:FormRow>
            <t:TextBoxFormField LabelText="First name" Text="{value: FirstName}" Size="Half" />
            <t:TextBoxFormField LabelText="Last name" Text="{value: LastName}" Size="Half" />
        </t:FormRow>

        <t:TextBoxFormField LabelText="Email" Text="{value: Email}" />
    </ContentTemplate>
    <FooterTemplate>
        <t:Button Text="Save"
                  Type="Primary"
                  Click="{command: Save()}" />
    </FooterTemplate>
</t:Form>

<div Visible="{value: Saved}" class="mt-3">
    <t:Alert Type="Success" Text="Customer saved." />
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Form.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string FirstName { get; set; } = "Anna";

        public string LastName { get; set; } = "Novak";

        public string Email { get; set; } = "anna@example.com";

        public bool Saved { get; set; }

        public void Save()
        {
            Saved = true;
        }
    }
}

```

## Sample 2: All Supported Tailwind Form Field Types

This sample combines `TextBoxFormField`, `ComboBoxFormField`, `CheckBoxFormField`, `DateTimePickerFormField`, the generic `FormField`, and `FormRow` in one form.


```DOTHTML
<t:Form>
    <HeaderTemplate>
        <div class="flex items-center gap-2">
            <t:Icon Icon="User" class="w-5 h-5" />
            <span class="font-semibold">Travel preferences</span>
        </div>
    </HeaderTemplate>
    <ContentTemplate>
        <t:FormRow Wrap="false">
            <t:TextBoxFormField LabelText="Full name"
                                Text="{value: FullName}"
                                Size="Half"
                                InputSize="Large"
                                Changed="{command: IncrementChanges()}" />

            <t:ComboBoxFormField LabelText="Country"
                                 DataSource="{value: Countries}"
                                 SelectedValue="{value: SelectedCountry}"
                                 ItemTextBinding="{value: Name}"
                                 ItemValueBinding="{value: Code}"
                                 EmptyItemText="-- select country --"
                                 Size="Half"
                                 InputSize="Large"
                                 SelectionChanged="{command: IncrementChanges()}" />
        </t:FormRow>

        <t:DateTimePickerFormField LabelText="Arrival"
                                   SelectedValue="{value: Arrival}"
                                   Type="Date"
                                   Placeholder="Choose arrival date..."
                                   InputSize="Small" />

        <t:CheckBoxFormField Checked="{value: Subscribe}"
                             Changed="{command: IncrementChanges()}">
            <span>Send me product updates</span>
        </t:CheckBoxFormField>

        <t:FormField LabelText="Preferred contact" ValidatorProperty="{value: ContactMethod}">
            <div class="flex gap-4 flex-wrap">
                <t:RadioButton Text="Email" CheckedValue="email" CheckedItem="{value: ContactMethod}" GroupName="contact" />
                <t:RadioButton Text="Phone" CheckedValue="phone" CheckedItem="{value: ContactMethod}" GroupName="contact" />
                <t:RadioButton Text="Chat" CheckedValue="chat" CheckedItem="{value: ContactMethod}" GroupName="contact" />
            </div>
        </t:FormField>
    </ContentTemplate>
</t:Form>

<p class="mt-3">Changes: <strong>{{value: ChangeCount}}</strong></p>
<p>Country: <strong>{{value: SelectedCountry ?? "(none)"}}</strong></p>
<p>Contact method: <strong>{{value: ContactMethod}}</strong></p>

```

```CSHARP
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Form.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string FullName { get; set; } = "Thomas Smith";

        public List<Country> Countries { get; set; } =
        [
            new() { Code = "cz", Name = "Czech Republic" },
            new() { Code = "fr", Name = "France" },
            new() { Code = "uk", Name = "United Kingdom" }
        ];

        public string? SelectedCountry { get; set; } = "cz";

        public DateTime? Arrival { get; set; } = new DateTime(2026, 10, 5);

        public bool Subscribe { get; set; } = true;

        public string ContactMethod { get; set; } = "email";

        public int ChangeCount { get; set; }

        public void IncrementChanges()
        {
            ChangeCount++;
        }
    }

    public class Country
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}

```

## Sample 3: Validation, LabelTemplate, and Dynamic Enabled State

Use `ValidatorProperty` when the validation message should follow a specific binding. This sample also shows `LabelTemplate`, `Type="Password"`, and a dynamically enabled combo box.


```DOTHTML
<t:Form HeaderText="Validation sample">
    <ContentTemplate>
        <dot:ValidationSummary IncludeErrorsFromChildren="true" />

        <t:TextBoxFormField LabelText="User name"
                            Text="{value: UserName}"
                            ValidatorProperty="{value: UserName}" />

        <t:TextBoxFormField LabelText="Password"
                            Text="{value: Password}"
                            Type="Password" />

        <t:ComboBoxFormField LabelText="Role"
                             DataSource="{value: Roles}"
                             SelectedValue="{value: SelectedRole}"
                             ItemTextBinding="{value: Name}"
                             ItemValueBinding="{value: Id}"
                             EmptyItemText="-- select role --"
                             Enabled="{value: RoleEnabled}"
                             ValidatorProperty="{value: SelectedRole}" />

        <t:CheckBoxFormField Text="Enable role selection"
                             Checked="{value: RoleEnabled}" />

        <t:FormRow>
            <t:DateTimePickerFormField SelectedValue="{value: ReminderTime}"
                                       Type="Time"
                                       ValidatorProperty="{value: ReminderTime}"
                                       Size="Half">
                <LabelTemplate>
                    <span>Reminder time <strong>(required)</strong></span>
                </LabelTemplate>
            </t:DateTimePickerFormField>
        </t:FormRow>
    </ContentTemplate>
    <FooterTemplate>
        <t:Button Text="Submit"
                  Type="Primary"
                  Click="{command: Submit()}"
                  Validation.Target="{value: _root}" />
    </FooterTemplate>
</t:Form>

<div Visible="{value: Submitted}" class="mt-3">
    <t:Alert Type="Success" Text="The form has been submitted." />
</div>

```

```CSHARP
using DotVVM.Framework.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotvvmWeb.Views.Docs.Controls.tailwind.Form.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        public List<RoleOption> Roles { get; set; } =
        [
            new() { Id = "author", Name = "Author" },
            new() { Id = "editor", Name = "Editor" },
            new() { Id = "admin", Name = "Administrator" }
        ];

        [Required]
        public string SelectedRole { get; set; }

        public bool RoleEnabled { get; set; } = true;

        [Required]
        public System.DateTime? ReminderTime { get; set; }

        public bool Submitted { get; set; }

        public void Submit()
        {
            Submitted = true;
        }
    }

    public class RoleOption
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

```

