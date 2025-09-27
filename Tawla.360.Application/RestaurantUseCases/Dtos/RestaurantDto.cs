using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.RestaurantUseCases.Dtos;

public record class RestaurantDto : IHasId
{
    public Guid Id { get; set;}
}
