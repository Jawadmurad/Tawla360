using MediatR;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.CategoryUseCases.Queries;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Shared;

namespace Tawla._360.Application.CategoryUseCases.Handler.QueryHandler;

public class GetCategoryPagedQueryHandler : IRequestHandler<GetCategoryPagedQuery, PagingResult<CategoryListDto>>
{
    private readonly ICategoryService _categoryService;
    public GetCategoryPagedQueryHandler(ICategoryService categoryService)
    {
        _categoryService=categoryService;
    }
    public Task<PagingResult<CategoryListDto>> Handle(GetCategoryPagedQuery request, CancellationToken cancellationToken)
    {
        return _categoryService.GetPagedAsync(request.Query,c=>c.ParentCategory);
    }
}
