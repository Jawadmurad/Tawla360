using Tawla._360.Application.ItemUseCases.Dtos.Common;

namespace Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;

public record class UpdateItemDto : AbstractUpdateItem
{
    public string ImagePath { get; set; }
}
