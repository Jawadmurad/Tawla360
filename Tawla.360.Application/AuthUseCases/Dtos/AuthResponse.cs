using Tawla._360.Domain.Enums;

namespace Tawla._360.Application.AuthUseCases.Dtos;

public record class AuthResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public DateTime Expiration { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public UserType UserType { get; set; }
    public IEnumerable<string> Permissions { get; set; }
    public Guid? RestaurantId { get; set; }
    public string RestaurantName { get; set; }
}
