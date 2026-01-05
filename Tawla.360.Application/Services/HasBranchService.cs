using AutoMapper;
using LinqKit;
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
    where TLite : class,new()
{
    public HasBranchService(IHasIdRepository<TEntity> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
        this.serviceFilter = PredicateBuilder.New<TEntity>(c => c.BranchId == _httpContextAccessorService.GetBranchId().Value);
    }
    public override async Task<TDetails> CreateAsync(TCreate createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        entity.BranchId = _httpContextAccessorService.GetBranchId().Value;
        await CreateAsync(entity);
        return _mapper.Map<TDetails>(entity);
    }
    // public override void Update(TUpdate updateDto)
    // {
    //     var entity = _mapper.Map<TEntity>(updateDto);
    //     entity.BranchId = _httpContextAccessorService.GetBranchId().Value;
    //     _repository.Update(entity);
    // }
}
