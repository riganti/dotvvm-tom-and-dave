# <auto:BulmaForm>
Generates a form for the object in the current [binding context](~/pages/concepts/data-binding/binding-context) based on [DotVVM Auto UI model metadata](~/pages/concepts/auto-ui/metadata).

This control renders HTML and CSS compatible with [Bulma](https://bulma.io/). Even if you don't use this CSS framework, the control may be useful to you as it generates a clean hierarchy of `div` elements marked with easily styleable CSS classes.

There are also other versions of this control which produce HTML and CSS classes expected by popular CSS frameworks: 

* [BulmaForm](./BulmaForm) for [Bootstrap 5](https://getbootstrap.com/) 

* [Form](./Form) - table-based form layout without any CSS framework

## Rendered output
```DOTHTML
<div class="field is-horizontal">
  <div class="field-label is-normal autoui-required">
    <label for="Name__input" class="label">Person or company name</label>
  </div>
  <div class="field-body">
    <div class="field">
      <div class="control">
        <input type="text" required class="input" id="Name__input" ... />
      </div>
      <span class="help is-danger" ...>Validation message</span>
    </div>
  </div>
</div>
<div class="field is-horizontal">
  <div class="field-label is-normal"></div>
  <div class="field-body">
    <div class="field">
      <div class="control">
        <label class="checkbox" id="IsCompany__input" ...>
          <input type="checkbox" data-bind="dotvvm-CheckState: IsCompany" />
          <span>Is company</span>
        </label>
      </div>
      <span class="help is-danger" ...>Validation message</span>
    </div>
  </div>
</div>
```

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ExcludeProperties`|String[]|The specified properties will not be included in this form.|attribute, static value|System.String[]|
|`GroupName`|String|Gets or sets the group of fields that should be rendered. If not set, fields from all groups will be rendered.|attribute, static value, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`IncludeProperties`|String[]|Only the specified properties will be included in this form. Using ViewName, GroupName or ExcludedProperties at the same time as IncludedProperties does not make sense. The properties will be listed in the exact order defined in this property.|attribute, static value||
|`ViewName`|String|Gets or sets the view name (e.g. Insert, Edit, ReadOnly). Some fields may have different metadata for each view.|attribute, static value, bindable||
|`WrapWithCheckboxClass`|Boolean|Indicates that when the AutoEditor control is used inside BulmaForm, it should be wrapped in a div with a 'checkbox' CSS class. This attached property is intended to be used when implementing custom FormEditorProviders.|attribute, static value, bindable|False|
|`WrapWithInputClass`|Boolean|Indicates that when the AutoEditor control is used inside BulmaForm, it should be wrapped in a div with an 'input' CSS class. This attached property is intended to be used when implementing custom FormEditorProviders.|attribute, static value, bindable|False|
|`WrapWithRadioClass`|Boolean|Indicates that when the AutoEditor control is used inside BulmaForm, it should be wrapped in a div with a 'radio' CSS class. This attached property is intended to be used when implementing custom FormEditorProviders.|attribute, static value, bindable|False|
|`WrapWithSelectClass`|Boolean|Indicates that when the AutoEditor control is used inside BulmaForm, it should be wrapped in a div with a 'select' CSS class. This attached property is intended to be used when implementing custom FormEditorProviders.|attribute, static value, bindable|False|
|`WrapWithTextareaClass`|Boolean|Indicates that when the AutoEditor control is used inside BulmaForm, it should be wrapped in a div with a 'textarea' CSS class. This attached property is intended to be used when implementing custom FormEditorProviders.|attribute, static value, bindable|False|

## Sample 1: Basic Form

The `DataContext` property set on the form or its closest ancestor defines the object for which the form will be auto-generated.

The [model metadata](~/pages/concepts/auto-ui/metadata) or conventions set in [Auto UI configuration](~/pages/concepts/auto-ui/overview) are used to determine how the editing control for each property will be generated.

```DOTHTML
<auto:BulmaForm DataContext="{value: Customer}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public CustomerModel Customer { get; set; } = new();
}

public class CustomerModel 
{
    [Display(Name = "Person or company name")]
    public string Name { get; set; }

    [Display(Name = "Is company")]
    public bool IsCompany { get; set; }
}

```

## Sample 2: Groups of properties

To create more complex layouts or generate editors just for some properties, you can use the `GroupName` property to tell the control which group of properties shall be considered.

The property can be assigned to a specific group using the `Display` attribute:

```CSHARP
[Display(..., GroupName = "basic")]
public string FirstName { get; set; }
```

```DOTHTML
<div class="two-columns">
    <div>
        <auto:BulmaForm DataContext="{value: Customer}" GroupName="BasicInfo" />
    </div>
    <div>
        <auto:BulmaForm DataContext="{value: Customer}" GroupName="ContactInfo" />
    </div>
</div>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public CustomerModel Customer { get; set; } = new();
}

public class CustomerModel 
{
    [Display(Name = "Person or company name", GroupName = "BasicInfo")]
    public string Name { get; set; }

    [Display(Name = "Is company", GroupName = "BasicInfo")]
    public bool IsCompany { get; set; }


    [Display(Name = "E-mail address", GroupName = "ContactInfo")]
    public string Email { get; set; }

    [Display(Name = "Phone number", GroupName = "ContactInfo")]
    public string Phone { get; set; } 
}

```

## Sample 3: Explicit property listing

If you prefer explicit listing of the properties, you can use the `IncludeProperties` and `ExcludeProperties` properties to specify which properties shall be generated.

```DOTHTML
<div class="two-columns">
    <div>
        <auto:BulmaForm DataContext="{value: Customer}" IncludeProperties="Name,IsCompany" />
    </div>
    <div>
        <auto:BulmaForm DataContext="{value: Customer}" ExcludeProperties="Name,IsCompany" />
    </div>
</div>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public CustomerModel Customer { get; set; } = new();
}

public class CustomerModel 
{
    [Display(Name = "Person or company name")]
    public string Name { get; set; }

    [Display(Name = "Is company")]
    public bool IsCompany { get; set; }


    [Display(Name = "E-mail address")]
    public string Email { get; set; }

    [Display(Name = "Phone number")]
    public string Phone { get; set; } 
}

```

## Sample 4: Include properties based on view

Sometimes you want to reuse the same model object in multiple contexts, a.k.a. __"views"__.

You can decorate the properties with the `Visible` attribute to define in which views they shall appear.

```CSHARP
// will be shown only when ViewName == "List"
[Visible(ViewNames = "List")]
public string CountryName { get; set; }
 
// will be shown only when ViewName == "Insert" || ViewName == "Edit"
[Visible(ViewNames = "Insert | Edit")]
public int CountryId { get; set; }
 
// will be shown only when ViewName != "Insert" && ViewName != "Edit"
[Visible(ViewNames = "!Insert & !Edit")]
public int UserId { get; set; }
```

The `ViewName` property specifies the view name for the current context. That's why only the editor for the `CountryId` property is displayed in the sample.

```DOTHTML
<auto:BulmaForm DataContext="{value: Customer}" ViewName="Edit" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public CustomerModel Customer { get; set; } = new();
}

public class CustomerModel 
{
    [Visible(ViewNames = "List")]
    public string CountryName { get; set; }

    [Visible(ViewNames = "Insert | Edit")]
    public int CountryId { get; set; }
}

```

## Sample 5: Adding extra properties

You can include additional properties to those coming from the current [binding context](~/pages/concepts/data-binding/binding-context) by using the `Property-*` property group.

If a property with the same name is present in the current binding context, it will be overriden by this settings.

```DOTHTML
<auto:BulmaForm DataContext="{value: Customer}" 
                Property-AgreeWithConditions="{value: _root.AgreeWithConditions}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public CustomerModel Customer { get; set; } = new();

    public bool AgreeWithConditions { get; set; }
}

public class CustomerModel 
{
    [Display(Name = "Person or company name")]
    public string Name { get; set; }

    [Display(Name = "Is company")]
    public bool IsCompany { get; set; }
}

```

## Sample 6: Responding to changes and enabling properties

You can use the `Changed-*` and `Enabled-*` property groups to specify commands triggered when the user changes the value, and to specify whether the field is editable.

There is also `Visible-*` property group which guides the field visibility, and `Label-*` property group which can override property labels.

```DOTHTML
<auto:BulmaForm DataContext="{value: Customer}" 
                Enabled-CompanyNumber="{value: IsCompany}" 
                Changed-CompanyNumber="{command: _root.LookupCompanyAddress()}" 
                Visible-CountryName="{value: IsInternational}" 
                Label-Name="{value: IsCompany ? 'Company name' : 'Person name'}" />
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public CustomerModel Customer { get; set; } = new();

    public void LookupCompanyAddress() 
    {
        // TODO
    }
}

public class CustomerModel 
{
    public string Name { get; set; }

    [Display(Name = "Is company")]
    public bool IsCompany { get; set; }

    [Display(Name = "Company number")]
    public string CompanyNumber { get; set; }

    [Display(Name = "International customer")]
    public bool IsInternational { get; set; }

    [Display(Name = "Country")]
    public string CountryName { get; set; }
}

```

## Sample 7: Overriding generated templates

You can use the `EditorTemplate-*` property group to override the generated editor control with your own content.

If you need to override the entire form field (including the label element), use the `FieldTemplate-*` instead.

In our sample, we are providing file upload and image preview experience for the `ImageUrl`, and selection of values from a viewmodel collection for the `Type` property. 

> You can use the [Selector attribute](~/pages/concepts/auto-ui/selectors) to auto-generate selection controls.

```DOTHTML
<auto:BulmaForm DataContext="{value: Image}">
    <EditorTemplate-Type>
      <div class="select">
        <dot:ComboBox DataSource="{value: _root.Types}" 
                      SelectedValue="{value: Type}" />
      </div>
    </EditorTemplate-Type>
    <FieldTemplate-ImageUrl>
        <!-- Please note that you are responsible to render the structual elements produced by the BulmaForm control -->
        <div class="field is-horizontal">
            <div class="field-label is-normal"></div>
            <div class="field-body">
              <div class="field">
                <img src="{value: ImageUrl}" class="img-responsive" />

                <dot:FileUpload UploadedFiles="{value: _root.ImageUpload}" 
                                UploadCompleted="{command: _root.ProcessImage()}" 
                                class="form-control" />
              </div>
            </div>
          </div>
        <div>
    </FieldTemplate-ImageUrl>
</auto:BulmaForm>
```

```CSHARP
public class ViewModel : DotvvmViewModelBase
{
    public ImageModel Image { get; set; } = new();

    public UploadedFilesCollection ImageUpload { get; set; } = new();

    public string[] Types => new[] { "Small", "Large" };

    public void ProcessImage() 
    {
        // TODO
    }
}

public class ImageModel 
{
    public string ImageUrl { get; set; }

    public string Type { get; set; }
}

```

