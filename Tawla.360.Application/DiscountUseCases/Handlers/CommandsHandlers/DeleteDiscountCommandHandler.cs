using System;
using MediatR;
using Tawla._360.Application.DiscountUseCases.Command;
using Tawla._360.Application.DisCountUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.DiscountUseCases.Handlers.CommandsHandlers;

public class DeleteDiscountCommandHandler : INotificationHandler<DeleteDiscountCommand>
{
    private readonly IDiscountService _discountService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteDiscountCommandHandler(IDiscountService discountService,IUnitOfWork unitOfWork)
    {
        _discountService = discountService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteDiscountCommand notification, CancellationToken cancellationToken)
    {
        await _discountService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
