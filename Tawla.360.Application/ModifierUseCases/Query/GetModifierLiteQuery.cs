using MediatR;
using Tawla._360.Application.ModifierUseCases.Dto;

namespace Tawla._360.Application.ModifierUseCases.Query;

public record class GetModifierLiteQuery:IRequest<IReadOnlyList<ModifierLiteDto>>;
