namespace Tawla._360.Application.UsersUseCases.Dtos;

public record class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RoleName { get; set; }
    public Guid[] BranchesIds { get; set; }

}
