using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
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
    public override Task<IReadOnlyList<TLite>> GetLiteAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        var predicate = PredicateBuilder.New<TEntity>(c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
        if (filter != null)
        {
            predicate = predicate.And(filter);
        }
        return base.GetLiteAsync(predicate);
    }
    protected override Task CreateAsync(TEntity entity)
    {
        entity.RestaurantId = _httpContextAccessorService.GetRestaurantId().Value;
        return base.CreateAsync(entity);
    }
}
