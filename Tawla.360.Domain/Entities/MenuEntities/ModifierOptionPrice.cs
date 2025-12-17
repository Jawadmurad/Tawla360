using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class ModifierOptionPrice : BaseBranchEntity
{
    public decimal PriceChange { get; set; }
    public Guid ModifierOptionId { get; set; }
    [ForeignKey(nameof(ModifierOptionId))]
    public ModifierOption ModifierOption { get; set; }
}
