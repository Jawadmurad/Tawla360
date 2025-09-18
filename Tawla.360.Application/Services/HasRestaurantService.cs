using System;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.Services;

public class HasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : IHasRestaurantService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, IHasRestaurant, new()
    where TCreate : class
    where TUpdate : class
    where TList : class
    where TDetails : class
    where TLite : class
{

}
