using MediatR;
using Tawla._360.Application.RoleUseCases.Dto;

namespace Tawla._360.Application.RoleUseCases.Queries;

public record class GetAllRoleLiteQuery:IRequest<IReadOnlyList<LiteRoleDto>>;
