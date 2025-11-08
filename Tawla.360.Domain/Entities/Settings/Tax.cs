using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Domain.Entities.Settings;

public class Tax : BaseRestaurantEntity
{
    public string Name { get; set; }
    public TaxType Type { get; set; }
    public decimal Amount { get; set; } 
    public bool IsVat { get; set; }
    public ICollection<BranchTax> BranchTaxes { get; set; }
}
