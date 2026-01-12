using MediatR;

namespace Tawla._360.Application.MeasurementUnitUserCases.Commands;

public record class DeleteMeasurementUnitCommand(Guid Id) : INotification;