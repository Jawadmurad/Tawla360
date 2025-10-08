using System;
using MediatR;
using Tawla._360.Application.RoleUseCases.Command;

namespace Tawla._360.Application.RoleUseCases.Handlers.CommandHandlers;

public class UpdateRoleCommandHandler : INotificationHandler<UpdateRoleCommand>
{
    public Task Handle(UpdateRoleCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
