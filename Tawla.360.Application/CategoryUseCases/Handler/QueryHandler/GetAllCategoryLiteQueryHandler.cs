using System;
using MediatR;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.CategoryUseCases.Queries;

namespace Tawla._360.Application.CategoryUseCases.Handler.QueryHandler;

public class GetAllCategoryLiteQueryHandler : IRequestHandler<GetAllCategoryLiteQuery, IReadOnlyList<LiteCategoryDto>>
{
    private readonly ICategoryService _categoryService;
    public GetAllCategoryLiteQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public Task<IReadOnlyList<LiteCategoryDto>> Handle(GetAllCategoryLiteQuery request, CancellationToken cancellationToken)
    {
        return _categoryService.GetLiteAsync();
    }
}
