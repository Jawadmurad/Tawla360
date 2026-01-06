using Tawla._360.Application.Attributes;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

namespace Tawla._360.Application.ItemUseCases.Dtos.Common;

public abstract record  AbstractItemManipulation
{
    [Translatable]
    public string Name { get; set; }
    public int? LowStockAlert { get; set; }
    public string[] Tags { get; set; }
    public Guid CategoryId { get; set; }
    public List<ItemPriceDto> Prices { get; set; }
}
