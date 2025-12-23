using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.RestaurantUseCases.Dtos;

public record class ListRestaurantDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public int NumberOfBranches { get; set; }
    public TimeOnly CloseTime { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
