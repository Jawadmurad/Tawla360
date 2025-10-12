using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.RoleUseCases.Dto;

public record class UpdateRoleDto : IHasId
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string[] Permissions { get; set; }
}
