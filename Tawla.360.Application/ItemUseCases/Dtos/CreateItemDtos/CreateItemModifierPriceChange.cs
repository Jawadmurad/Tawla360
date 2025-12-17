namespace Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

public record class CreateItemModifierPriceChange
{
    public Guid BranchId { get; set; }
    public decimal PriceChange { get; set; }
}
