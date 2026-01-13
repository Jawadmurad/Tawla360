using System;
using MediatR;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;
using Tawla._360.Application.MeasurementUnitUserCases.Queries;
using Tawla._360.Shared;

namespace Tawla._360.Application.MeasurementUnitUserCases.Handlers.QueryHandlers;

public class GetPagedMeasurementUnitQueryHandler : IRequestHandler<GetPagedMeasurementUnitQuery, PagingResult<MeasurementUnitListDto>>
{
    private readonly IMeasurementUnitService _measurementUnitService;

    public GetPagedMeasurementUnitQueryHandler(IMeasurementUnitService measurementUnitService)
    {
        _measurementUnitService = measurementUnitService;
    }

    public Task<PagingResult<MeasurementUnitListDto>> Handle(GetPagedMeasurementUnitQuery request, CancellationToken cancellationToken)
    {
        return _measurementUnitService.GetPagedAsync(request.Query);
    }
}
