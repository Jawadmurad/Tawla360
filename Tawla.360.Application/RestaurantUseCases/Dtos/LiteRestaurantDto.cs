using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.RestaurantUseCases.Dtos;

public record class LiteRestaurantDto:IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}
