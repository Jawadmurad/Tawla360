using MediatR;
using Tawla._360.Application.RoleUseCases.Dto;

namespace Tawla._360.Application.RoleUseCases.Command;

public record UpdateRoleCommand(UpdateRoleDto UpdateRole) : INotification;
