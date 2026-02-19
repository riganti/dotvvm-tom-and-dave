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
		var contentPath = GetContentPath();
        return Directory.GetFiles(contentPath)
			.Select(f => new FileModel()
			{
				FileName = Path.GetFileName(f)
			})
			.ToList();
	}

    [AllowStaticCommand]
	public string LoadFile(FileModel file)
	{
		return File.ReadAllText(Path.Combine(GetContentPath(), Path.GetFileName(file.FileName)!));
	}

    public void CreateFile(string fileName)
	{
		var contentPath = Path.Combine(environment.ContentRootPath, "Content");
		if (!Directory.Exists(contentPath))
		{
			Directory.CreateDirectory(contentPath);
		}
		
		var filePath = Path.Combine(contentPath, Path.GetFileName(fileName));
		if (!File.Exists(filePath))
		{
			File.WriteAllText(filePath, string.Empty);
		}
	}

    private string GetContentPath()
    {
        return Path.Combine(environment.ContentRootPath, "Content");
    }
}