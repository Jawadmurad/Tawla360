using MediatR;
using Tawla._360.Application.RestaurantUseCases.Dtos;

namespace Tawla._360.Application.RestaurantUseCases.Queries;

public record class GetAllRestaurantLiteQuery():IRequest<IReadOnlyList<LiteRestaurantDto>>;
