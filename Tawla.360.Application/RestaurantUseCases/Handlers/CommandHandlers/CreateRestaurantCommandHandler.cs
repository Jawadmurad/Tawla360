using MediatR;
using Tawla._360.Application.RestaurantUseCases.Commands;
using Tawla._360.Application.Services;
using Tawla._360.Application.UsersUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.RestaurantUseCases.Handlers.CommandHandlers;

internal class CreateRestaurantCommandHandler : INotificationHandler<CreateRestaurantCommand>
{
    private readonly IRestaurantService _restaurantService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileStorageService _fileStorageService;
    private readonly IUserService _userService;
    public CreateRestaurantCommandHandler(IRestaurantService restaurantService, IUnitOfWork unitOfWork, IFileStorageService fileStorageService, IUserService userService)
    {
        _restaurantService = restaurantService;
        _unitOfWork = unitOfWork;
        _fileStorageService = fileStorageService;
        _userService = userService;
    }
    public async Task Handle(CreateRestaurantCommand notification, CancellationToken cancellationToken)
    {
        var file = notification.CreateRestaurantWithAdminDto.Logo;
        var filePath = await _fileStorageService.SaveFileAsync(file, nameof(Domain.Entities.RestaurantEntities.Restaurant));
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var restaurant = await _restaurantService.CreateAsync(new()
            {
                Description = notification.CreateRestaurantWithAdminDto.Description,
                Logo = filePath,
                Name = notification.CreateRestaurantWithAdminDto.Name,
                MainBranchLocation = notification.CreateRestaurantWithAdminDto.MainBranchLocation,
            });
            await _userService.CreateRestaurantAdmin(notification.CreateRestaurantWithAdminDto.Admin, restaurant.Id);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception)
        {
            await _unitOfWork.Rollback();
            throw;
        }
    }
}
