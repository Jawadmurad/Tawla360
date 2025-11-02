using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.ItemUseCases.Dtos;

public record class UpdateItemDto : IHasId
{
    public Guid Id { get; set; }
}
