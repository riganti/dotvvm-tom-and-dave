# <bp:ImageCrop>
A control which lets the user to make basic edits (like cropping, resizing or rotating) with a specified image.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AspectRatio`|String||attribute, static value||
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ForcedCropHeight`|Int32?||attribute, static value||
|`ForcedCropRadius`|Int32?||attribute, static value||
|`ForcedCropWidth`|Int32?||attribute, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`ImageUrl`|String||attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`Operations`|ImageOperations||attribute, bindable||
|`ResetIcon`|IconBase||inner element, static value, bindable||
|`RotateLeftIcon`|IconBase||inner element, static value, bindable||
|`RotateRightIcon`|IconBase||inner element, static value, bindable||
|`SelectOnlyImage`|Boolean||attribute, static value|True|
|`SwitchToCroppingIcon`|IconBase||inner element, static value, bindable||
|`SwitchToMovingIcon`|IconBase||inner element, static value, bindable||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|
|`ZoomInIcon`|IconBase||inner element, static value, bindable||
|`ZoomOutIcon`|IconBase||inner element, static value, bindable||

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `ImageUrl` property specifies the URL of the image that is being edited.

The `Operations` property must be bound to a property of type `ImageOperations` in the viewmodel. This object contains the following properties:

* `Resize` represents the scale ratio of the image.

* `Rotate` represents represents the rotation angle.

* `Crop` represents a rectangular area (with `Left`, `Top`, `Width` and `Height` properties) the crop settings.

* `Round` represents the radius of the rounded corners.

You can use the `DefaultImageFactory` class to load the image, apply the `ImageOperations` to it and save the result image.

```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}" />

<p>Left: {{value: ImageOperations.Crop.Left}}px</p>
<p>Top: {{value: ImageOperations.Crop.Top}}px</p>
<p>Width: {{value: ImageOperations.Crop.Width}}px</p>
<p>Height: {{value: ImageOperations.Crop.Height}}px</p>
<p>Rotate: {{value: ImageOperations.Rotate}}°</p>
<p>Resize: {{value: ImageOperations.Resize}}px</p>

<bp:Button Text="Save"
           Click="{command: Save()}" />
<br />
<br />

<p>Result: <a href="{value: Result}">{{value: Result}}</a></p>
<img src="{value: Result}" />
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Utils;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "../images/imagecrop.webp";
        public string Result { get; set; }
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();

        public void Save()
        {
            Result = $"/App_Images/{SecureGuidGenerator.GenerateGuid()}.png";

            using (var factory = new DefaultImageFactory())
            {
                factory
                    .Load(GetPhysicalPath(ImagePath))
                    .Apply(ImageOperations)
                    .Save(GetPhysicalPath(Result));
            }
        }

        private string GetPhysicalPath(string url)
        {
            return Context.Configuration.ApplicationPhysicalPath + url.Substring(1).Replace("/", "\\");
        }
    }
}

```

## Sample 2: Aspect Ratio

The ratio between the width and height of the cropped area can be set using the `AspectRatio` property. 
The value of the property is `string` and the control expects two numbers separated by a colon, e.g. `1:1`, `4:3`, `16:9` etc.


```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}"
              AspectRatio="1:1" />
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "../images/imagecrop.webp";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();
    }
}

```

## Sample 3: Forced Crop Radius

To make the border radius fixed, the `ForcedCropRadius` property can be used. It expects a value between `0` and `50`. 

`0` means no border radius. `50` means maximum border radius. The value is in percent, so the border radius of `50%` can be used to make a circle.


```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}"
              ForcedCropRadius="50" />
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;


namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "../images/imagecrop.webp";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();
    }
}

```

## Sample 4: Forced Crop Area

The crop area dimensions can be fixed using the `ForcedCropWidth` and `ForcedCropHeight` properties.

```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}"
              ForcedCropWidth="150"
              ForcedCropHeight="150" />
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "../images/imagecrop.webp";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();
    }
}

```

## Sample 5: Changed Event

When the user changes any parameter of the image, the `Changed` event can be used to call a command in the viewmodel.

```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}"
              Changed="{command: Changed()}" />

<p>Change count: {{value: ChangeCount}}</p>
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample5
{
    public class ViewModel : DotvvmViewModelBase
    {
        public int ChangeCount { get; set; }
        public string ImagePath { get; set; } = "../images/imagecrop.webp";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();

        public void Changed()
        {
            ChangeCount++;
        }
    }
}

```

## Sample 6: Predefined Operations

If you set the `ImageOperations` parameters from the viewmodel, you can specify default values for the control.


```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}" />
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample6
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "../images/imagecrop.webp";

        public ImageOperations ImageOperations { get; set; } = new ImageOperations {
            Crop = new CropRectangle {
                Left = 150,
                Top = 150,
                Width = 100,
                Height = 100
            },
            Resize = 400,
            Rotate = 45,
            Round = 50
        };
    }
}

```

## Sample 7: Custom Icons

To customize the look of toolbar icons in the control, you can use the following inner elements:

* `SwitchToMovingIcon` allows to customize the switch mode icon. The default value is `Move`.

* `SwitchToCroppingIcon` allows to customize the switch mode icon. The default value is `Crop`.

* `ResetIcon` allows to customize the reset icon. The default value is `Reset`.

* `RotateLeftIcon` allows to customize the rotate left icon. The default value is `RotateLeft`.

* `RotateRightIcon` allows to customize the rotate right icon. The default value is `RotateRight`.

* `ZoomInIcon` allows to customize the zoom in icon. The default value is `ZoomIn`.

* `ZoomOutIcon` allows to customize the zoom out icon. The default value is `ZoomOut`.

See the [Icon](~/controls/businesspack/Icon) documentation to find about using other icon packs.

```DOTHTML
<bp:ImageCrop ImageUrl="{value: ImagePath}"
              Operations="{value: ImageOperations}">
    <SwitchToMovingIcon>
        <bp:Icon Icon="Move"></bp:Icon>
    </SwitchToMovingIcon>
    <SwitchToCroppingIcon>
        <bp:Icon Icon="Crop"></bp:Icon>
    </SwitchToCroppingIcon>
    <ResetIcon>
        <bp:Icon Icon="Reset"></bp:Icon>
    </ResetIcon>
    <RotateLeftIcon>
        <bp:Icon Icon="RotateLeft"></bp:Icon>
    </RotateLeftIcon>
    <RotateRightIcon>
        <bp:Icon Icon="RotateRight"></bp:Icon>
    </RotateRightIcon>
    <ZoomInIcon>
        <bp:Icon Icon="ZoomIn"></bp:Icon>
    </ZoomInIcon>
    <ZoomOutIcon>
        <bp:Icon Icon="ZoomOut"></bp:Icon>
    </ZoomOutIcon>
</bp:ImageCrop>
```

```CSHARP
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.ImageCrop.sample7
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string ImagePath { get; set; } = "../images/imagecrop.webp";
        public ImageOperations ImageOperations { get; set; } = new ImageOperations();
    }
}

```

