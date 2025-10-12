using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Exceptions;
using Tawla._360.Domain.Interfaces.Entities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.Services;

public class HasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : GenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>, IHasIdGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
where TEntity : class,IBaseIdEntity, new()
    where TCreate : class
    where TUpdate : class, IHasId
    where TList : class
    where TDetails : class
    where TLite : class
{
    protected readonly IHttpContextAccessorService _httpContextAccessorService;
    protected new readonly IHasIdRepository<TEntity> _repository;
    public HasIdGenericService(IHasIdRepository<TEntity> repository, IMapper mapper,IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper)
    {
        _repository = repository;
        _httpContextAccessorService = httpContextAccessorService;
    }
    protected override Task CreateAsync(TEntity entity)
    {
        entity.CreatedBy = _httpContextAccessorService.GetUserId()?.ToString();
        return base.CreateAsync(entity);
    }
    public  async Task Delete(Guid id)
    {

        var entity = await _repository.Find(id) ?? throw new NotFoundException(nameof(TEntity));
        _repository.Delete(entity);
    }
}
