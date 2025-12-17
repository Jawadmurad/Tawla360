using Tawla._360.Application.ItemUseCases.Dtos.Common;

namespace Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

public record CreateItemDto:AbstractCreateItem
{
    
    public string ImagePath { get; set; }
}
