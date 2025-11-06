using MediatR;
using Tawla._360.Application.DiscountUseCases.Dtos;

namespace Tawla._360.Application.DiscountUseCases.Queries;

public record class GetAllDiscountLiteQuery:IRequest<IReadOnlyList<LiteDiscountDto>>;
