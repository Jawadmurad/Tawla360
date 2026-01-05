using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Application.DiscountUseCases.Dtos;

public record class CreateDiscountDto
{
    [Translatable]
    public string Name { get; set; }
    public decimal Value { get; set; }
    public AmountType AmountType { get; set; }
    public decimal? MaxDiscountLimit { get; set; }
}
