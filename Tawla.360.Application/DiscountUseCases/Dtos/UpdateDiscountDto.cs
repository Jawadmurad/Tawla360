using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.DiscountUseCases.Dtos;

public record class UpdateDiscountDto : IHasId
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }
    public decimal Value { get; set; }
    public AmountType AmountType { get; set; }
}
