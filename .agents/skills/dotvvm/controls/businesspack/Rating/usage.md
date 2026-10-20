# <bp:Rating>
Displays several stars (or any other symbols) and lets the user any number of them.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowHalfPoints`|Boolean||attribute, static value, bindable|True|
|`AllowPreviewOnHover`|Boolean||attribute, static value, bindable|True|
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxValue`|Int32||attribute, static value, bindable|5|
|`PointIcon`|SvgIconBase||inner element, static value, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Value`|Double?||attribute, bindable||
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `Value` property represents a number of stars selected by the user.

The `MaxValue` specifies the number of stars to be displayed.


```DOTHTML
<bp:Rating Value="{value: Rating}"
           MaxValue="5" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Rating.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Rating { get; set; } = 4.5;
    }
}
```

## Sample 2: Configuration

The `AllowHalfPoints` allows to select half of a star to be able to get more precise rating. By default, the user can select only the entire star.

The `AllowPreviewOnHover` property can be used to disable the hover effect that indicates which stars will be selected on click.


```DOTHTML
<bp:Rating Value="{value: Rating}"
           MaxValue="5"
           AllowHalfPoints="false"
           AllowPreviewOnHover="false" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Rating.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Rating { get; set; } = 4;
    }
}
```

## Sample 3: Changed Event

The `Changed` property specifies a command in the viewmodel that is triggered whenever the user changes the rating.


```DOTHTML
<bp:Rating Value="{value: Rating}"
           MaxValue="5"
           Changed="{command: RatingChanged()}" />

<p>Rating has changed {{value: ChangeCount}} times.</p>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Rating.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Rating { get; set; } = 4.5;
        public int ChangeCount { get; set; }

        public void RatingChanged()
        {
            ChangeCount++;
        }
    }
}
```

## Sample 4: Custom Icons

The icon used by the control can be customized using the following inner elements:

* `PointIcon` represents an icon that user can select. The default is `Star` icon.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:Rating Value="{value: Rating}"
           MaxValue="5">
    <PointIcon>
        <bp:Icon Icon="Plus"></bp:Icon>
    </PointIcon>
</bp:Rating>
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.Rating.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public double Rating { get; set; } = 3.5;
    }
}
```

