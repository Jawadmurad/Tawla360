using System;
using MediatR;
using Tawla._360.Application.ItemUseCases.Command;

namespace Tawla._360.Application.ItemUseCases.Handlers.CommandHandlers;

public class DeleteItemCommandHandler : INotificationHandler<DeleteItemCommand>
{
    public Task Handle(DeleteItemCommand notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
