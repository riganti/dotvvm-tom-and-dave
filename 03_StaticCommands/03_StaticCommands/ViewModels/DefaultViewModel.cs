using System.Collections.Generic;
using System.Threading.Tasks;
using StaticCommands.Model;
using StaticCommands.Services;

namespace StaticCommands.ViewModels;

public class DefaultViewModel(FileService fileService) : MasterPageViewModel
{

    public required List<FileModel> Items { get; set; }

	public List<FileModel>? FilteredItems { get; set; }

	public string? SearchText { get; set; }

	public string? FileContents { get; set; }

	public bool IsModalVisible { get; set; }

	public string? NewFileName { get; set; }

	public override Task PreRender()
	{
		if (!Context.IsPostBack)
		{
			Items = fileService.GetFiles();
		}

		return base.PreRender();
	}

	public void LoadFile(FileModel file)
	{
		FileContents = fileService.LoadFile(file);
	}

	public void OpenModal()
	{
		IsModalVisible = true;
		NewFileName = null;
	}

	public void CloseModal()
	{
		IsModalVisible = false;
		NewFileName = null;
	}

	public void CreateFile()
	{
		fileService.CreateFile(NewFileName!);
		Items = fileService.GetFiles();
		FilteredItems = null;
		CloseModal();
	}

}