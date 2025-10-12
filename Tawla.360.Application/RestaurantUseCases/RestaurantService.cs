using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RestaurantUseCases.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RestaurantUseCases;

public class RestaurantService : HasIdGenericService<Restaurant, CreateRestaurantDto, UpdateRestaurantDto, ListRestaurantDto, RestaurantDto, LiteRestaurantDto>, IRestaurantService
{

    public RestaurantService(IHasIdRepository<Restaurant> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
