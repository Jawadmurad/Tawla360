using System;
using MediatR;
using Tawla._360.Application.RoleUseCases.Dto;
using Tawla._360.Application.RoleUseCases.Queries;

namespace Tawla._360.Application.RoleUseCases.Handlers.QueryHandlers;

public class GetAllRoleLiteQueryHandler : IRequestHandler<GetAllRoleLiteQuery, IReadOnlyList<LiteRoleDto>>
{
    private readonly IRoleService _roleService;
    public GetAllRoleLiteQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public Task<IReadOnlyList<LiteRoleDto>> Handle(GetAllRoleLiteQuery request, CancellationToken cancellationToken)
    {
        return _roleService.GetLiteAsync();
    }
}
