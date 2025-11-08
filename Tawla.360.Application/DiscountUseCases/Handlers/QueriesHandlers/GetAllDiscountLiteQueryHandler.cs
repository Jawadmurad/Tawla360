using MediatR;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Application.DiscountUseCases.Queries;
using Tawla._360.Application.DisCountUseCases;

namespace Tawla._360.Application.DiscountUseCases.Handlers.QueriesHandlers;

public class GetAllDiscountLiteQueryHandler : IRequestHandler<GetAllDiscountLiteQuery, IReadOnlyList<LiteDiscountDto>>
{
    private readonly IDiscountService _discountService;
    public GetAllDiscountLiteQueryHandler(IDiscountService discountService)
    {
        _discountService = discountService;
    }
    public Task<IReadOnlyList<LiteDiscountDto>> Handle(GetAllDiscountLiteQuery request, CancellationToken cancellationToken)
    {
        return _discountService.GetLiteAsync();
    }
}
