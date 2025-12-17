using Microsoft.AspNetCore.Http;
using Tawla._360.Application.ItemUseCases.Dtos.Common;

namespace Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

public record CreateItemWithImageDto : AbstractCreateItem
{
    public IFormFile Image { get; set; }
}
