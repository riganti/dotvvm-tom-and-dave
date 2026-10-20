# <bp:FileUpload>
Allows the user to upload one or multiple files asynchronously.

### Upload Configuration

The upload works on the background and starts immediately when the user selects the files. To make file uploading work, 
you have to specify where the temporary files will be uploaded.

The recommended strategy is to store the uploaded files in your application directory or in the temp directory (if your app have the appropriate permissions).
To define this, you have to register the `UploadedFileStorage` in the `IDotvvmServiceConfigurator`.

```CSHARP
public void ConfigureServices(IDotvvmServiceCollection options)
{
    options.AddUploadedFileStorage("App_Data/Temp");
}
```

### Using the Control

Then, you need to bind the `FileUpload` control to an `UploadData` object. It holds references to the files 
the user has selected and uploaded.

The `UploadData` object also has a useful property `IsBusy` which indicates whether the file upload is still in progress. You can use it e.g. on the button's `Enabled` property to disallow the user to continue until the upload is finished.

### Retrieving the Stored Files

The `UploadData` object contains only unique IDs of uploaded files. To get the file contents, you have to retrieve it using the `IUploadedFileStorage` service.

```CSHARP
public class UploadViewModel 
{
  private readonly IUploadedFileStorage storage;

  public UploadViewModel(IUploadedFileStorage storage)
  {
    this.storage = storage;
  }

  public async Task ProcessFiles()
  {
    foreach (var file in UploadData.Files)
    {
      if (file.IsAllowed)
      {
        // get the stream of the uploaded file and do whatever you need to do
        var stream = storage.GetFile(file.FileId);

        // OR you can just move the file from the temporary storage somewhere else
        var targetPath = Path.Combine(uploadPath, file.FileId + ".bin");
        await storage.SaveAsAsync(file.FileId, targetPath);
        
        // it is a good idea to delete the file from the temporary storage 
        // it is not required, the file would be deleted automatically after the timeout set in the DotvvmStartup.cs
        await storage.DeleteFileAsync(file.FileId);
      }
    }
  }
}
```

The FileUpload control checks whether the file extension or MIME type matches the `AllowedFileTypes` definition, and that the file size does not exceed the `MaxFileSize`.
You can use the `IsFileTypeAllowed` and `IsMaxSizeExceeded` properties of the file in the `UploadData` object to find out why the file was not allowed.

However, please note that the validation is essentially only performed client-side and cannot be trusted for anything beyond displaying error messages.
Any user able to press F12 can modify all unencrypted view model properties, including those in `UploadedFilesCollection`.
Make sure to validate the file characteristics based on the data from `IUploadedFileStorage` when it is important.

&nbsp;


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowedFileTypeErrorText`|String||attribute, static value, bindable|The file {0} is not of an allowed type.|
|`AllowedFileTypes`|String||attribute, static value||
|`AllowMultipleFiles`|Boolean||attribute, static value|True|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`ContentTemplate`|ITemplate||inner element, static value, bindable, default property||
|`Data`|UploadData||attribute, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DeleteFileIcon`|IconBase||inner element, static value, bindable||
|`DragFilesHereText`|String||attribute, static value|or drag them here.|
|`DropTemplate`|ITemplate||inner element, static value||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`GenericErrorText`|String||attribute, static value|Upload has failed.|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`MaxFileSize`|Int32?||attribute, static value||
|`MaxFileSizeErrorText`|String||attribute, static value|The file {0} is larger than the maximum allowed size.|
|`UploadButtonText`|String||attribute, static value|Select files|
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`UploadCompleted`|Command||

## Sample 1: Basic Usage

The `FileUpload` control has the `Data` property (of type `UploadData`). Each file will get a unique ID when it is uploaded. This ID will be then stored in the `Files` collection.

The `AllowMultipleFiles` property specifies whether the user can select multiple files in the file browser window. It also enables directory upload in modern browsers.

```DOTHTML
<bp:FileUpload Data="{value: Upload}" 
               AllowMultipleFiles="true" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public UploadData Upload { get; set; } = new UploadData();
    }
}
```

## Sample 2: UploadCompleted Event

The `UploadCompleted` event is fired automatically when all files are uploaded.

```DOTHTML
<bp:FileUpload Data="{value: Upload}"
               UploadCompleted="{command: ProcessFile()}" />

{{value: Message}}
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Message { get; set; }

        public UploadData Upload { get; set; } = new UploadData();

        public void ProcessFile()
        {
            // do what you have to do with the uploaded files
            Message = "ProcessFile() was called.";
        }
    }
}
```

## Sample 3: Processing the Files

You can use the `Upload.IsBusy` property to determine whether the upload is still in progress or not.

```DOTHTML
<bp:FileUpload Data="{value: Upload}" />

<p>
  <bp:Button Text="Save Files" 
              Click="{command: Process()}"
              Enabled="{value: !Upload.IsBusy}" />
</p>
```

```CSHARP
using System.IO;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Core.Storage;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        private readonly IUploadedFileStorage fileStorage;

        public ViewModel(IUploadedFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public UploadData Upload { get; set; } = new UploadData();

        public async Task Process()
        {
            var folderPath = GetFolderPath();

            // save all files to disk
            foreach (var file in Upload.Files)
            {
                var filePath = Path.Combine(folderPath, file.FileId + ".bin");
                await fileStorage.SaveAsAsync(file.FileId, filePath);
                await fileStorage.DeleteFileAsync(file.FileId);
            }

            // clear the data so the user can continue with other files
            Upload.Clear();
        }

        private string GetFolderPath()
        {
            var folderPath = Path.Combine(Context.Configuration.ApplicationPhysicalPath, "MyFiles");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }
    }
}

```

## Sample 4: Drag & Drop Upload

The drag & drop upload is supported out-of-the-box. And if you need to customize its look and feel, you can use the `DropTemplate` property. It allows you to specify contents visible when user drags files over the `FileUpload` control.

The `DropTemplate` is by default rendered over all contents of the control. If you want to open an upload dialog after an element is clicked on, mark it with `bp-select-files` CSS class.

```DOTHTML
<bp:FileUpload Data="{value: Upload}">
    <DropTemplate>
        Drop files here!
    </DropTemplate>
    <!-- build a custom UI here -->
    <dot:Repeater DataSource="{value: Upload.Files}">
        <div>
            {{value: FileName}}
        </div>
    </dot:Repeater>
    <div>
        <bp:Button Text="Upload" Type="Primary" Click="{command: UploadFiles()}"/>
    </div>
</bp:FileUpload>
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.FileUpload.sample4
{
    public class ViewModel : DotvvmViewModelBase
    {
        public UploadData Upload { get; set; } = new UploadData();

        public void UploadFiles()
        {
            // Custom Event
        }
    }
}
```

