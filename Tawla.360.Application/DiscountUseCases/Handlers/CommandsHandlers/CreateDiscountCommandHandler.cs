using System;
using MediatR;
using Tawla._360.Application.DiscountUseCases.Command;
using Tawla._360.Application.DisCountUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.DiscountUseCases.Handlers.CommandsHandlers;

public class CreateDiscountCommandHandler : INotificationHandler<CreateDiscountCommand>
{
    private readonly IDiscountService _discountService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateDiscountCommandHandler(IDiscountService discountService,IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _discountService = discountService;
    }
    public async Task Handle(CreateDiscountCommand notification, CancellationToken cancellationToken)
    {
        await _discountService.CreateAsync(notification.CreateDiscount);
        await _unitOfWork.SaveChangesAsync();

    }
}
