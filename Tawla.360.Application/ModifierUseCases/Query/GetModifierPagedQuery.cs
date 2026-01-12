using MediatR;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Shared;

namespace Tawla._360.Application.ModifierUseCases.Query;

public record class GetModifierPagedQuery(QueryRequestDto Query) : IRequest<PagingResult<ModifierListDto>>;
