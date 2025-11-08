using System.Linq.Expressions;
using AutoMapper;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.CategoryUseCases;

public class CategoryService : HasRestaurantService<Category, CreateCategoryDto, UpdateCategoryDto, CategoryListDto, CategoryDto, LiteCategoryDto>,ICategoryService
{
    public CategoryService(IHasIdRepository<Category> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
        
    }
}
