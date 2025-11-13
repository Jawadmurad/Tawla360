using System;
using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Shared;

namespace Tawla._360.Application.DiscountUseCases.Queries;

public record GetDiscountPagedQuery(QueryRequestDto Query):IRequest<PagingResult<DiscountListDot>>;
