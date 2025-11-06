using Tawla._360.Domain.Enums;

namespace Tawla._360.Application.TaxesCases.Dtos;

public record CreateTaxDto
{
    public string Name { get; set;  }
    public TaxType Type { get; set; }
    public decimal Amount { get; set; } 
    public bool IsVat { get; set; }
}
