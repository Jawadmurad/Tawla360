using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Tawla._360.Application.Services;

namespace Tawla._360.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly string _basePath;

    public FileStorageService(IHostEnvironment env)
    {
        _basePath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads");
    }

    public async Task<string> SaveFileAsync(IFormFile file, string entityName)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty.");
        if (string.IsNullOrWhiteSpace(entityName))
            throw new ArgumentException("Entity name is required.");
        var entityFolder = Path.Combine(_basePath, entityName);
        if (!Directory.Exists(entityFolder))
        {
            Directory.CreateDirectory(entityFolder);
        }
        var fileExtension = Path.GetExtension(file.FileName);
        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";

        var filePath = Path.Combine(entityFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return Path.Combine("uploads", entityName, uniqueFileName).Replace("\\", "/");
    }
}
