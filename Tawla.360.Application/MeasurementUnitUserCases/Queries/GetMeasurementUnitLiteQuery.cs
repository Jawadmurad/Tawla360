using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;

namespace Tawla._360.Application.MeasurementUnitUserCases.Queries;

public record class GetMeasurementUnitLiteQuery:IRequest<IReadOnlyList<MeasurementUnitLiteDto>>;
