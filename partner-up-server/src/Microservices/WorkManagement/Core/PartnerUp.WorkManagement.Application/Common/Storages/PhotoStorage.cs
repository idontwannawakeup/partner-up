﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Storages;

namespace PartnerUp.WorkManagement.Application.Common.Storages;

public class PhotoStorage : IPhotoStorage
{
    private readonly IWebHostEnvironment _environment;

    public PhotoStorage(IWebHostEnvironment environment) => _environment = environment;

    public async Task<string> SavePhotoAsync(IFormFile photo)
    {
        var photosFolderPath = TryCreatePhotosFolder();
        var fileExtension = Path.GetExtension(photo.FileName);
        var fileName = $"{DateTime.Now:yyyyMMddHHmmssffff}{fileExtension}";
        await using var fileStream = File.OpenWrite(Path.Combine(photosFolderPath, fileName));

        await photo.CopyToAsync(fileStream);
        await fileStream.FlushAsync();

        return fileName;
    }

    private string TryCreatePhotosFolder()
    {
        var photosFolderPath = Path.Combine(_environment.WebRootPath, "Public", "Photos");
        if (!Directory.Exists(photosFolderPath))
        {
            Directory.CreateDirectory(photosFolderPath);
        }

        return photosFolderPath;
    }
}
