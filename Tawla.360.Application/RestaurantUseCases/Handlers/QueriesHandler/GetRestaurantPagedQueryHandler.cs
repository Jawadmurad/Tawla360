using MediatR;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Application.RestaurantUseCases.Queries;
using Tawla._360.Shared;

namespace Tawla._360.Application.RestaurantUseCases.Handlers.QueriesHandler;

public class GetRestaurantPagedQueryHandler : IRequestHandler<GetRestaurantPagedQuery, PagingResult<ListRestaurantDto>>
{
    private readonly IRestaurantService _restaurantService;
    public GetRestaurantPagedQueryHandler(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    public Task<PagingResult<ListRestaurantDto>> Handle(GetRestaurantPagedQuery request, CancellationToken cancellationToken)
    {
        return _restaurantService.GetPagedAsync(request.Query);
    }
}
