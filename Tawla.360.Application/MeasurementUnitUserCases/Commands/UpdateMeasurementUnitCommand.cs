using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;

namespace Tawla._360.Application.MeasurementUnitUserCases.Commands;

public record class UpdateMeasurementUnitCommand(UpdateMeasurementUnitDto UpdateDto):INotification;
