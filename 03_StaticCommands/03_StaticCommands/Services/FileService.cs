using StaticCommands.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Hosting;

namespace StaticCommands.Services;

public class FileService(IWebHostEnvironment environment)
{
	public List<FileModel> GetFiles()
	{
		return Directory.GetFiles(environment.ContentRootPath)
			.Select(f => new FileModel()
			{
				FileName = Path.GetFileName(f)
			})
			.ToList();
	}

	[AllowStaticCommand]
	public string LoadFile(FileModel file)
	{
		return File.ReadAllText(Path.Combine(environment.ContentRootPath, Path.GetFileName(file.FileName)!));
	}
}