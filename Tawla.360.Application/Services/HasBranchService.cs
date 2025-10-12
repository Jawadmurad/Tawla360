using System;
using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Interfaces.Entities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.Services;

public class HasBranchService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : HasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>, IHasBranchService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, IHasBranch, new()
    where TCreate : class
    where TUpdate : class, IHasId   
    where TList : class
    where TDetails : class
    where TLite : class
{
    public HasBranchService(IHasIdRepository<TEntity> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
