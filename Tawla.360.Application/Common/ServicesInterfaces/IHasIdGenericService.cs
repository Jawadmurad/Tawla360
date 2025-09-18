using System;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.Common.ServicesInterfaces;

public interface IHasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : IGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, IHasId, new()
    where TCreate : class
    where TUpdate : class, IHasId
    where TList : class
    where TDetails : class
    where TLite : class
{
    Task Delete(Guid id);
}