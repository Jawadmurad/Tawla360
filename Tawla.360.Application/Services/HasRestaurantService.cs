using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Interfaces.Entities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.Services;

public class HasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>(IHasIdRepository<TEntity> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : HasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>(repository, mapper, httpContextAccessorService), IHasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, IHasRestaurant, new()
    where TCreate : class
    where TUpdate : class, IHasId
    where TList : class
    where TDetails : class
    where TLite : class
{
    protected override Task CreateAsync(TEntity entity)
    {
        entity.RestaurantId = _httpContextAccessorService.GetRestaurantId().Value;
        return base.CreateAsync(entity);
    }
}
