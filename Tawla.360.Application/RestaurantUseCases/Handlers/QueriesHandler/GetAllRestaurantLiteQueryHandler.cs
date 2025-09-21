using MediatR;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Application.RestaurantUseCases.Queries;

namespace Tawla._360.Application.RestaurantUseCases.Handlers.QueriesHandler;

public class GetAllRestaurantLiteQueryHandler : IRequestHandler<GetAllRestaurantLiteQuery, IReadOnlyList<LiteRestaurantDto>>
{
    private readonly IRestaurantService _restaurantService;
    public GetAllRestaurantLiteQueryHandler(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    public Task<IReadOnlyList<LiteRestaurantDto>> Handle(GetAllRestaurantLiteQuery request, CancellationToken cancellationToken)
    {
        return _restaurantService.GetLiteAsync();
    }
}
