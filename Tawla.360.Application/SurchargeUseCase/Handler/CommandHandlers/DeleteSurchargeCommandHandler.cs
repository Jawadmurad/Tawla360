using MediatR;
using Tawla._360.Application.SurchargeUseCase.Command;

namespace Tawla._360.Application.SurchargeUseCase.CommandHandlers.Handler;

public class DeleteSurchargeCommandHandler : INotificationHandler<DeleteSurchargeCommand>
{
    private readonly ISurchargeService _surchargeService;
    public DeleteSurchargeCommandHandler(ISurchargeService surchargeService)
    {
        _surchargeService=surchargeService;
    }
    public Task Handle(DeleteSurchargeCommand notification, CancellationToken cancellationToken)
    {
        return _surchargeService.Delete(notification.Id);
    }
}
