using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.RoleUseCases.Dto;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Application.RoleUseCases;

public class RoleProfile:MappingProfile<ApplicationRole,CreateRoleDto,UpdateRoleDto,RoleListDto,RoleDto,LiteRoleDto>
{

}
