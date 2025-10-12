using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.DiscountUseCases.Dtos;

public record class UpdateDiscountDto : IHasId
{
    public Guid Id { get; set; }
}
