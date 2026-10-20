# <dot:FileUpload>
Allows the user to upload one or multiple files asynchronously.

## Processing uploaded files

The `FileUpload` control requires a property of type `UploadedFilesCollection` in the viewmodel. 

See [Upload files](~/pages/concepts/upload-and-download-files/upload-files) for more info about processing the uploaded files.


## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowedFileTypes`|String|Gets or sets the types of files that the server accepts. It must be a comma-separated list of unique content type             specifiers (e.g. ".jpg,image/png,audio/*"). All file types are allowed by default.|attribute, static value||
|`AllowMultipleFiles`|Boolean|Gets or sets whether the user can select multiple files at once. It is enabled by default.|attribute, static value|True|
|`Capture`|String|Gets or sets the .             It specifies that, optionally, a new file should be captured, and which device should be used to capture that new media of a type defined by the AllowedFileTypes property.             Allowed values are "user" and "environment" to select if front-facing or rear-facing camera/microphone should be used.|attribute, static value||
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`MaxFileSize`|Int32?|Gets or sets the maximum size of files in megabytes (MB). The size is not limited by default.             When file exceeding the limit is uploaded, the Error property is set to "Uploaded file is too large."|attribute, static value||
|`NumberOfFilesIndicatorText`|String|Gets or sets the text on the indicator showing number of files. The default value is "{0} files". The number of files             will be substituted for the "{0}" placeholder.|attribute, static value, bindable|{0} files|
|`SuccessMessageText`|String|Gets or sets the text that appears when all files are uploaded successfully.|attribute, static value, bindable|The files were uploaded successfully.|
|`UploadButtonText`|String|Gets or sets the text on the upload button. The default value is "Upload".|attribute, static value, bindable|Upload|
|`UploadedFiles`|UploadedFilesCollection|Gets or sets a collection of uploaded files.|attribute, bindable||
|`UploadErrorMessageText`|String|Gets or sets the text that appears when there is an error during the upload.|attribute, static value, bindable|Error occurred.|
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`UploadCompleted`|Command|Gets or sets a command that is triggered when the upload is complete.|

## Sample 1: Basic FileUpload control

The *FileUpload* control has the `UploadedFiles` property (of type **UploadedFilesCollection**). Each file will get a unique ID which is stored in this collection.

The `AllowMultipleFiles` property specifies whether the user can select multiple files in the file browser window.

```DOTHTML
<dot:FileUpload UploadedFiles="{value: Files}" AllowMultipleFiles="true" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.builtin.FileUpload.sample1
{
    public class ViewModel
    {
        public UploadedFilesCollection Files { get; set; }


        public ViewModel()
        {
            Files = new UploadedFilesCollection();
        }
        
    }
}
```

## Sample 2: UploadCompleted Event

The `UploadCompleted` event is fired automatically when file is uploaded.

```DOTHTML
<dot:FileUpload UploadedFiles="{value: Files}" AllowMultipleFiles="true" 
                UploadCompleted="{command: ProcessFile()}" />

{{value: Message}}
```

```CSHARP
using System.Collections.Generic;
using DotVVM.Framework.Controls;

namespace DotvvmWeb.Views.Docs.Controls.builtin.FileUpload.sample2
{
    public class ViewModel
    {
        public UploadedFilesCollection Files { get; set; }

        public string Message { get; set; }

        public ViewModel()
        {
            Files = new UploadedFilesCollection();
        }

        public void ProcessFile()
        {
            // do what you have to do with the uploaded files
            Message = "ProcessFile() was called.";
        }
    }
}
```

## Sample 3: Processing the Files

You can use the `Files.IsBusy` property to determine whether the upload is still in progress or not.

```DOTHTML
<dot:FileUpload UploadedFiles="{value: Files}" 
                AllowMultipleFiles="true" />
<p>
  <dot:Button Text="Save Files" 
              Click="{command: Process()}"
              Enabled="{value: !Files.IsBusy}" />
</p>
```

```CSHARP
using System.IO;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Core.Storage;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.builtin.FileUpload.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        private IUploadedFileStorage storage;
        
        public UploadedFilesCollection Files { get; set; }


        public ViewModel(IUploadedFileStorage storage)
        {
            // use dependency injection to request IUploadedFileStorage
            this.storage = storage;
            
            Files = new UploadedFilesCollection();
        }


        public async Task Process()
        {
            var uploadPath = GetUploadPath();

            // save all files to disk
            foreach (var file in Files.Files)
            {
                var targetPath = Path.Combine(uploadPath, file.FileId + ".bin");
                await storage.SaveAsAsync(file.FileId, targetPath);
                await storage.DeleteFileAsync(file.FileId);
            }

            // clear the uploaded files collection so the user can continue with other files
            Files.Clear();
        }

        private string GetUploadPath()
        {
            var uploadPath = Path.Combine(Context.Configuration.ApplicationPhysicalPath, "MyFiles");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            return uploadPath;
        }
    }
}
```

