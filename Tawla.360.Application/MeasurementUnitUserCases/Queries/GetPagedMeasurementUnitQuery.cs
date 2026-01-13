using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.MeasurementUnitUserCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.MeasurementUnitUserCases.Queries;

public record class GetPagedMeasurementUnitQuery(QueryRequestDto Query):IRequest<PagingResult<MeasurementUnitListDto>>;