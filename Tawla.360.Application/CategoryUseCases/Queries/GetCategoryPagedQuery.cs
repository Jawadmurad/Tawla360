using MediatR;
using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.CategoryUseCases.Queries;

public record class GetCategoryPagedQuery(QueryRequestDto Query):IRequest<PagingResult<CategoryListDto>>;
