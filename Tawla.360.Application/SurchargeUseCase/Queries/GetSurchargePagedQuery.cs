using System;
using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.SurchargeUseCase.Dto;
using Tawla._360.Shared;

namespace Tawla._360.Application.SurchargeUseCase.Queries;

public record GetSurchargePagedQuery(QueryRequestDto Query):IRequest<PagingResult<SurchargeListDto>>;
