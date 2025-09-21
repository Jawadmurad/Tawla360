namespace Tawla._360.Application.RestaurantUseCases.Dtos;

public record class CreateRestaurantDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MainBranchLocation { get; set; }
}
