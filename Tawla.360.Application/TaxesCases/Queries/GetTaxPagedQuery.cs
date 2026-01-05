using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.TaxesCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.TaxesCases.Queries;

public record class GetTaxPagedQuery(QueryRequestDto Query):IRequest<PagingResult<TaxListDto>>;