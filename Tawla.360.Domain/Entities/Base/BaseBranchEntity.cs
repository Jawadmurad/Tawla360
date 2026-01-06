using System.ComponentModel.DataAnnotations.Schema;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Domain.Entities.Base;

public class BaseBranchEntity : BaseIdEntity, IHasBranch
{
    public Guid BranchId { get; set; }
    [ForeignKey(nameof(BranchId))]
    public Branch Branch { get; set; }
}
