using System.Linq.Expressions;
using AutoMapper;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RoleUseCases.Dto;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.UsersEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RoleUseCases;

public class RoleService : HasIdGenericService<ApplicationRole, CreateRoleDto, UpdateRoleDto, RoleListDto, RoleDto, LiteRoleDto>, IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    public RoleService(IHasIdRepository<ApplicationRole> repository, IMapper mapper, RoleManager<ApplicationRole> roleManager, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper,httpContextAccessorService)
    {
        _roleManager = roleManager;
    }
    public override async Task<RoleDto> CreateAsync(CreateRoleDto createDto)
    {
        var role = _mapper.Map<ApplicationRole>(createDto);
        await _roleManager.CreateAsync(role);
        return _mapper.Map<RoleDto>(role);
    }
    public override Task<IReadOnlyList<LiteRoleDto>> GetLiteAsync(Expression<Func<ApplicationRole, bool>> filter = null)
    {
        var predicate = PredicateBuilder.New<ApplicationRole>(c => c.RestaurantId == _httpContextAccessorService.GetRestaurantId());
        if (filter != null)
        {
            predicate = predicate.And(filter);
        }
        return base.GetLiteAsync(predicate);
    }
}
