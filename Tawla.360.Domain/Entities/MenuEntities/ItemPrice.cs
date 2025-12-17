using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.MenuEntities;

public class ItemPrice:BaseBranchEntity
{
    public Guid ItemId { get; set; }
    [ForeignKey(nameof(ItemId))]
    public Item Item { get; set; }
    public decimal Price { get; set; }
}
