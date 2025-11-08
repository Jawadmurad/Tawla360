using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.DiscountUseCases.Dtos;

public record class UpdateDiscountDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public AmountType AmountType { get; set; }
}
