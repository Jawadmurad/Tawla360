using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class ModifierGroupTemplate:BaseRestaurantEntity,ITranslatedEntity<ModifierGroupTemplateTranslation>
{
    public Guid[] ModifierGroupsIds { get; set; }
    public ICollection<ModifierGroupTemplateTranslation> Translations {get;set;}
}
