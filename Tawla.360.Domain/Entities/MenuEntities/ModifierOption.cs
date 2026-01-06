using System.ComponentModel.DataAnnotations.Schema;

namespace Tawla._360.Domain.Entities.MenuEntities;


public class ModifierOption
{
    public Guid Id { get; set; }
    public Guid ModifierGroupId { get; set; }
    public Guid ModifierId { get; set; }
    public int? DisplayOrder { get; set; }
    [ForeignKey(nameof(ModifierId))]
    public Modifier Modifier { get; set; }
    [ForeignKey(nameof(ModifierGroupId))]
    public ModifierGroup ModifierGroup { get; set; }
    public List<ModifierOptionPrice> ModifierOptionPrices { get; set; }
}
