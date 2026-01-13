using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;
using Tawla._360.Application.MeasurementUnitUserCases.Queries;

namespace Tawla._360.Application.MeasurementUnitUserCases.Handlers.QueryHandlers;

public class GetMeasurementUnitLiteQueryHandler : IRequestHandler<GetMeasurementUnitLiteQuery, IReadOnlyList<MeasurementUnitLiteDto>>
{
    private readonly IMeasurementUnitService _measurementUnitService;

    public GetMeasurementUnitLiteQueryHandler(IMeasurementUnitService measurementUnitService)
    {
        _measurementUnitService = measurementUnitService;
    }

    public Task<IReadOnlyList<MeasurementUnitLiteDto>> Handle(GetMeasurementUnitLiteQuery request, CancellationToken cancellationToken)
    {
        return _measurementUnitService.GetLiteAsync();
    }
}
