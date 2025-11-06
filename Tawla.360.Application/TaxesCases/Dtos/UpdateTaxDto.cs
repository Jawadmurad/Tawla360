using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.TaxesCases.Dtos;

public record class UpdateTaxDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TaxType Type { get; set; }
    public decimal Amount { get; set; } 
}
