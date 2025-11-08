using System;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.CategoryUseCases;

public class CategoryProfile:MappingProfile<Category,CreateCategoryDto,UpdateCategoryDto,CategoryListDto,CategoryDto,LiteCategoryDto>
{

}
