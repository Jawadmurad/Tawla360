using System;
using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.MeasurementUnitUserCases.Handlers.CommandHandlers;

public class DeleteMeasurementUnitCommandHandler : INotificationHandler<DeleteMeasurementUnitCommand>
{
    private readonly IMeasurementUnitService _measurementUnitService;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMeasurementUnitCommandHandler(IMeasurementUnitService measurementUnitService, IUnitOfWork unitOfWork)
    {
        _measurementUnitService = measurementUnitService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteMeasurementUnitCommand notification, CancellationToken cancellationToken)
    {
        await _measurementUnitService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
