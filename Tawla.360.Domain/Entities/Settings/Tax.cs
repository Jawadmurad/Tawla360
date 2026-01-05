using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Settings;

public class Tax : BaseBranchEntity,ITranslatedEntity<TaxTranslation>
{
    public AmountType Type { get; set; }
    public decimal Amount { get; set; } 
    public bool IsVat { get; set; }
    public ICollection<TaxTranslation> Translations { get; set; }
}
