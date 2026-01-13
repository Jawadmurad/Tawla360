using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.MeasurementUnitUserCases.Handlers.CommandHandlers;

public record class CreateMeasurementUnitCommandHandler : INotificationHandler<CreateMeasurementUnitCommand>
{
    private readonly IMeasurementUnitService _measurementUnitService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateMeasurementUnitCommandHandler(IMeasurementUnitService measurementUnitService ,IUnitOfWork unitOfWork)
    {
        _measurementUnitService = measurementUnitService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateMeasurementUnitCommand notification, CancellationToken cancellationToken)
    {
        await _measurementUnitService.CreateAsync(notification.CreateMeasurementUnit);
        await _unitOfWork.SaveChangesAsync();
    }
}
