namespace Tawla._360.Application.ModifierGroupUserCase.Dtos;

public record class ModifierOptionPriceDto
{
    public Guid Id { get; set; }
    public Guid BranchId { get; set; }
    public decimal PriceChange { get; set; }

}
