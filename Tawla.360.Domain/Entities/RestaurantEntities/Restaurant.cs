using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Domain.Entities.RestaurantEntities;

public class Restaurant : BaseNamedEntity
{
    public string Description { get; set; }
    public string Logo { get; set; }
    public int NumberOfBranches { get; set; }
    public TimeOnly CloseTime { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<Branch> Branches { get; set; }
    public string InsertionDefaultLanguage { get; set; }
}
