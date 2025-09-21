using MediatR;
using Tawla._360.Application.RestaurantUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RestaurantUseCases.Handlers.CommandHandlers;

internal class CreateRestaurantCommandHandler : INotificationHandler<CreateRestaurantCommand>
{
    private readonly IRestaurantService _restaurantService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateRestaurantCommandHandler(IRestaurantService restaurantService, IUnitOfWork unitOfWork)
    {
        _restaurantService = restaurantService;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateRestaurantCommand notification, CancellationToken cancellationToken)
    {
        await _restaurantService.CreateAsync(notification.CreateRestaurant);
        await _unitOfWork.SaveChangesAsync();
    }
}
