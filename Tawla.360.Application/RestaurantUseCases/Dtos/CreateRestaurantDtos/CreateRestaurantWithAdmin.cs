using Microsoft.AspNetCore.Http;

namespace Tawla._360.Application.RestaurantUseCases.Dtos.CreateRestaurantDtos;

public record class CreateRestaurantWithAdmin
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile Logo { get; set; }
    public string MainBranchLocation { get; set; }
    public CreateRestaurantAdminDto Admin { get; set; }
    public string InsertionDefaultLanguage { get; set; }
    public int NumberOfBranches { get; set; }
}
