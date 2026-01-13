using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;

namespace Tawla._360.Application.MeasurementUnitUserCases.Commands;

public record class CreateMeasurementUnitCommand(CreateMeasurementUnitDto CreateMeasurementUnit):INotification;
