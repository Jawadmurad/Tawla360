using Microsoft.AspNetCore.Http;

namespace Tawla._360.Application.Services;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(IFormFile file, string entityName);
}
