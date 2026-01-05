using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Application.SurchargeUseCase.Dto;

public record class CreateSurchargeDto
{
    [Translatable]
    public string Name { get; set; }
    public AmountType AmountType { get; set; }
    public decimal Amount { get; set; }
    public bool IsTaxable { get; set; }
}
