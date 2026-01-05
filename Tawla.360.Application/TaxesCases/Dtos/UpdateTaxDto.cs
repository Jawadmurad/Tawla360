using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.TaxesCases.Dtos;

public record class UpdateTaxDto : IHasId
{
    public Guid Id { get; set; }
    [Translatable]
    public string Name { get; set; }
    public AmountType Type { get; set; }
    public decimal Amount { get; set; } 
}
