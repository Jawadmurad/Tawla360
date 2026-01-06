using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class ModifierGroup : BaseIdEntity, ITranslatedEntity<ModifierGroupTranslation>
{
    public bool MultipleQuantity { get; set; }
    public decimal? MaxMultipleQuantity { get; set; }
    public int MinQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public ICollection<ModifierGroupTranslation> Translations {get;set;}
    public Guid ItemId { get; set; }
    public Item Item { get; set; }
    public List<ModifierOption> Options { get; set; }
}
