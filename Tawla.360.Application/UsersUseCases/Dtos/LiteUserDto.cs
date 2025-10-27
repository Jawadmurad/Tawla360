namespace Tawla._360.Application.UsersUseCases.Dtos;

public record class LiteUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
}
