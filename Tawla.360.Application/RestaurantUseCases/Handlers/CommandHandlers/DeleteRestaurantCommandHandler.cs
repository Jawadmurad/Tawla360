using System;
using MediatR;
using Tawla._360.Application.RestaurantUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RestaurantUseCases.Handlers.CommandHandlers;

internal class DeleteRestaurantCommandHandler : INotificationHandler<DeleteRestaurantCommand>
{
    private readonly IRestaurantService _restaurantService;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteRestaurantCommandHandler(IRestaurantService restaurantService, IUnitOfWork unitOfWork)
    {
        _restaurantService = restaurantService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteRestaurantCommand notification, CancellationToken cancellationToken)
    {
        //TODO add the required validation before deletion.
        await _restaurantService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();

    }
}
