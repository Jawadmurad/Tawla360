using System;
using MediatR;
using Tawla._360.Application.TableUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TableUseCases.Handlers.CommandsHandler;

public class DeleteTableCommandHandler : INotificationHandler<DeleteTableCommand>
{
    private readonly ITableService _tableService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTableCommandHandler(ITableService tableService, IUnitOfWork unitOfWork)
    {
        _tableService = tableService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteTableCommand notification, CancellationToken cancellationToken)
    {
        await _tableService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
