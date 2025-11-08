    using MediatR;
using Tawla._360.Application.CategoryUseCases.Dto;

namespace Tawla._360.Application.CategoryUseCases.Queries;

public record class GetAllCategoryLiteQuery:IRequest<IReadOnlyList<LiteCategoryDto>>;
