using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.RestaurantUseCases.Queries;

public record class GetRestaurantPagedQuery(QueryRequestDto Query):IRequest<PagingResult<ListRestaurantDto>>;
