namespace Tawla._360.Application.RoleUseCases.Dto;

public record class CreateRoleDto
{
    public string Name { get; set; }
    public string[] Permissions { get; set; }
}
