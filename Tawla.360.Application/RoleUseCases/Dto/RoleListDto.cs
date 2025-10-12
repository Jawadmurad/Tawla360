using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.RoleUseCases.Dto;

public record class RoleListDto:IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
