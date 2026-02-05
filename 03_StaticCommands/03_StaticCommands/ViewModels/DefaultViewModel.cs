using System.Collections.Generic;
using System.Threading.Tasks;
using StaticCommands.Model;
using StaticCommands.Services;

namespace StaticCommands.ViewModels;

public class DefaultViewModel(FileService fileService) : MasterPageViewModel
{

	public List<FileModel> Items { get; set; }

	public List<FileModel>? FilteredItems { get; set; }

	public string? SearchText { get; set; }

	public string? FileContents { get; set; }

	

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

}