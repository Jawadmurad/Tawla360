using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class Modifier : BaseIdEntity, ITranslatedEntity<ModifierTranslation>
{
    public ICollection<ModifierTranslation> Translations { get; set; }
}   
