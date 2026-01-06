using Tawla._360.Application.Attributes;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.ItemUseCases.Dtos.Common;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.ItemUseCases.Dtos;

public record class ItemDto : IHasId
{
    public Guid Id { get; set; }

    [Translatable]
    public string Name { get; set; }

    public string ImagePath { get; set; }
    public int? LowStockAlert { get; set; }
    public string[] Tags { get; set; }
    public LiteCategoryDto Category { get; set; }
    public List<ItemPriceDto> Prices { get; set; }
    public List<ModifierGroupDto> ModifierGroups { get; set; }
}
