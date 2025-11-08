using MediatR;
using Tawla._360.Application.DiscountUseCases.Dtos;
using Tawla._360.Application.DiscountUseCases.Queries;
using Tawla._360.Application.DisCountUseCases;
using Tawla._360.Shared;

namespace Tawla._360.Application.DiscountUseCases.Handlers.QueriesHandlers;

internal class GetDiscountPagedQueryHandler : IRequestHandler<GetDiscountPagedQuery, PagingResult<DiscountListDot>>
{
    private readonly IDiscountService _discountService;
    public GetDiscountPagedQueryHandler(IDiscountService discountService)
    {
        _discountService = discountService;
    }
    public Task<PagingResult<DiscountListDot>> Handle(GetDiscountPagedQuery request, CancellationToken cancellationToken)
    {
        return _discountService.GetPagedAsync(request.Query);
    }
}
