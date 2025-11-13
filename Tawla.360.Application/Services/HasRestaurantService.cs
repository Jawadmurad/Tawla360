using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Interfaces.Entities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.Services;

public class HasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : HasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>, IHasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, IHasRestaurant, new()
    where TCreate : class
    where TUpdate : class, IHasId
    where TList : class
    where TDetails : class
    where TLite : class,new()
{
    public HasRestaurantService(IHasIdRepository<TEntity> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
        this.serviceFilter = PredicateBuilder.New<TEntity>(x => x.RestaurantId == _httpContextAccessorService.GetRestaurantId());
    }

    protected override Task CreateAsync(TEntity entity)
    {
        entity.RestaurantId = _httpContextAccessorService.GetRestaurantId().Value;
        return base.CreateAsync(entity);
    }
}
