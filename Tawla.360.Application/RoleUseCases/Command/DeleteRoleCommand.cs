using MediatR;

namespace Tawla._360.Application.RoleUseCases.Command;

public record DeleteRoleCommand(Guid Id) : INotification;
