using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Tawla._360.Application.Services;

namespace Tawla._360.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly string _basePath;    // Points to .../wwwroot/uploads
    private readonly string _wwwRootPath; // Points to .../wwwroot

    public FileStorageService(IHostEnvironment env)
    {
        // Store the web root path for resolving full paths later
        _wwwRootPath = Path.Combine(env.ContentRootPath, "wwwroot");

        // The base path for saving new files
        _basePath = Path.Combine(_wwwRootPath, "uploads");
    }

    public Task DeleteFileAsync(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Task.CompletedTask;
        }

        try
        {
            // 1. Normalize the path separators to match the current OS (Windows '\' vs Linux '/')
            var normalizedPath = path.Replace("/", Path.DirectorySeparatorChar.ToString())
                                     .Replace("\\", Path.DirectorySeparatorChar.ToString());

            // 2. Remove leading slashes if present to ensure Path.Combine works correctly
            if (normalizedPath.StartsWith(Path.DirectorySeparatorChar.ToString()))
            {
                normalizedPath = normalizedPath.Substring(1);
            }

            // 3. Construct the full physical path
            // e.g., combine "C:/App/wwwroot" with "uploads/Item/image.jpg"
            var fullPath = Path.Combine(_wwwRootPath, normalizedPath);

            // 4. Delete the file if it exists
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
        catch (Exception ex)
        {
            // Optional: Log the error.
            // We usually swallow the exception here because if the file doesn't exist 
            // or is locked, we don't want to rollback the entire database transaction 
            // just because a file cleanup failed.
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }

        return Task.CompletedTask;
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

        // Return the relative path consistent with how the web server serves static files
        return Path.Combine("uploads", entityName, uniqueFileName).Replace("\\", "/");
    }
}