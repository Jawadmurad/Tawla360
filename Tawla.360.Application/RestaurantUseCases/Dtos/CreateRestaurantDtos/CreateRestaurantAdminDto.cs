namespace Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;

public record class CreateRestaurantAdminDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
}
