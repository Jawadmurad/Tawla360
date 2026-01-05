using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.SurchargeUseCase.Dto;

public record class UpdateSurchargeDto : IHasId
{
    public Guid Id {get;set;}
    [Translatable]
    public string Name { get; set; }
    public AmountType AmountType { get; set; }
    public decimal Amount { get; set; }
    public bool IsTaxable { get; set; }
}
