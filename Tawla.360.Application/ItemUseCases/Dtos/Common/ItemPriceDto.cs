namespace Tawla._360.Application.ItemUseCases.Dtos.Common;

public record class ItemPriceDto
{
    public Guid BranchId { get; set; }
    public decimal Price { get; set; }
}
