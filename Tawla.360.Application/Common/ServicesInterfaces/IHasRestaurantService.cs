using System;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.Common.ServicesInterfaces;

public interface IHasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
:IHasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class,IHasRestaurant, new()
    where TCreate : class
    where TUpdate : class, IHasId
    where TList : class
    where TDetails : class
    where TLite : class
{

}
