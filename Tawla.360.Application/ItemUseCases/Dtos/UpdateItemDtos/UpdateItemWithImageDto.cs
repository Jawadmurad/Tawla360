using Microsoft.AspNetCore.Http;
using Tawla._360.Application.ItemUseCases.Dtos.Common;

namespace Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;

public record class UpdateItemWithImageDto : AbstractUpdateItem
{
    public IFormFile Image { get; set; }
    /// <summary>
    /// Indicates whether the existing image should be deleted.
    /// If <see cref="Image"/> is <c>null</c> and this value is <c>true</c>,
    /// the previously stored image will be removed.
    /// </summary>
    public bool DeleteExistingImage { get; set; }
}
