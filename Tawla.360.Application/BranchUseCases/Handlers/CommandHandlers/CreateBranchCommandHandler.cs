using System.Collections.ObjectModel;
using MediatR;
using Tawla._360.Application.BranchUseCases.Commands;
using Tawla._360.Application.RestaurantUseCases;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.BranchUseCases.Handlers.CommandHandlers;

public class CreateBranchCommandHandler : INotificationHandler<CreateBranchCommand>
{
    private readonly IBranchService _branchService;
    private readonly IRestaurantService _restaurantService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateBranchCommandHandler(IBranchService branchService, IUnitOfWork unitOfWork,IRestaurantService restaurantService)
    {
        _branchService = branchService;
        _unitOfWork = unitOfWork;
        _restaurantService = restaurantService;
    }
    public async Task Handle(CreateBranchCommand notification, CancellationToken cancellationToken)
    {
        var count = await _branchService.CountAsync();
        await _branchService.CreateAsync(notification.CreateBranch);
        await _unitOfWork.SaveChangesAsync();
    }
}
