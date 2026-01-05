using Tawla._360.Application.Attributes;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.TaxesCases.Dtos;

public record class TaxLiteDto:IHasId
{
    public Guid Id {get;set;}
    [Translatable]
    public string Name { get; set; }
    public decimal Value { get; set; }
}
