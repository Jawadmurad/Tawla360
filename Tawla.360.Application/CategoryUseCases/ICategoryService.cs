using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.CategoryUseCases;

public interface ICategoryService : IHasRestaurantService<Category, CreateCategoryDto, UpdateCategoryDto, CategoryListDto, CategoryDto, LiteCategoryDto>
{
    
}
