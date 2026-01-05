using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Settings;

public class Surcharge:BaseBranchEntity,ITranslatedEntity<SurchargeTranslation>
{
    public AmountType AmountType { get; set; }
    public decimal Amount { get; set; }
    public bool IsTaxable { get; set; }
    public ICollection<SurchargeTranslation> Translations {get;set;}
}
