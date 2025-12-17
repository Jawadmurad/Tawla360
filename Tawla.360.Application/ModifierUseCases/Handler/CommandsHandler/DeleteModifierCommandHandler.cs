using System;
using MediatR;
using Tawla._360.Application.ModifierUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ModifierUseCases.Handler.CommandsHandler;

public class DeleteModifierCommandHandler : INotificationHandler<DeleteModifierCommand>
{
    private readonly IModifierService _modifierService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteModifierCommandHandler(IModifierService modifierService,IUnitOfWork unitOfWork)
    {
        _modifierService = modifierService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteModifierCommand notification, CancellationToken cancellationToken)
    {
        await _modifierService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
