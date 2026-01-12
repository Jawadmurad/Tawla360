using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.SupplierUseCases.Dto;
using Tawla._360.Shared;

namespace Tawla._360.Application.SupplierUseCases.Queries;

public record class GetSupplierPagedQuery(QueryRequestDto Query) : IRequest<PagingResult<SupplierDto>>;
