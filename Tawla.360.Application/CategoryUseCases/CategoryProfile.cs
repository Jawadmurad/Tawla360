using System;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.CategoryUseCases;

public class CategoryProfile:TranslatedEntityProfile<Category,CategoryTranslation,CreateCategoryDto,UpdateCategoryDto,CategoryListDto,CategoryDto,LiteCategoryDto>
{
    public CategoryProfile()
    {
        CreateMap<Category,CategoryListDto>();
    }
}
