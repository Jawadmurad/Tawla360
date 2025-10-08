namespace Tawla._360.Application.AuthUseCases.Dtos;

public record class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

}
