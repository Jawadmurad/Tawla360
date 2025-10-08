using System;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RoleUseCases.Dto;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Application.RoleUseCases;

public interface IRoleService:IHasIdGenericService<ApplicationRole,CreateRoleDto,UpdateRoleDto,RoleListDto,RoleDto,LiteRoleDto>
{
}
