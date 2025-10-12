using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Enums;

namespace Tawla._360.Domain.Entities.Settings;

public class BranchTax:BaseBranchEntity
{
    public Guid TaxId { get; set; }
    [ForeignKey(nameof(TaxId))]
    public Tax Tax { get; set; }
    public decimal Amount { get; set; }
    public TaxType Type { get; set; }
}
