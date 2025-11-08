using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Enums;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Settings;

public class Discount:BaseBranchEntity,ITranslatedEntity<DiscountTranslation>
{
    public decimal Value { get; set; }
    public AmountType Type { get; set; }
    public ICollection<DiscountTranslation> Translations { get; set; }
}
