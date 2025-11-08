using MediatR;
using Tawla._360.Application.DiscountUseCases.Command;
using Tawla._360.Application.DisCountUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.DiscountUseCases.Handlers.CommandsHandlers;

public class UpdateDiscountCommandHandler : INotificationHandler<UpdateDiscountCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDiscountService _discountService;
    public UpdateDiscountCommandHandler(IUnitOfWork unitOfWork,IDiscountService discountService)
    {
        _unitOfWork = unitOfWork;
        _discountService = discountService;
    }
    public Task Handle(UpdateDiscountCommand notification, CancellationToken cancellationToken)
    {
        _discountService.Update(notification.UpdateDiscount);
        return _unitOfWork.SaveChangesAsync();
    }
}
