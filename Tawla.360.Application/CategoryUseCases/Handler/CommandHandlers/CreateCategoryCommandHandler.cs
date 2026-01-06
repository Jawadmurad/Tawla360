using System;
using MediatR;
using Tawla._360.Application.CategoryUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.CategoryUseCases.CommandHandlers.Handler;

public class CreateCategoryCommandHandler : INotificationHandler<CreateCategoryCommand>
{
    private readonly ICategoryService _categoryService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCategoryCommandHandler(ICategoryService categoryService,IUnitOfWork unitOfWork)
    {
        _categoryService=categoryService;
        _unitOfWork=unitOfWork;
    }
    public async Task Handle(CreateCategoryCommand notification, CancellationToken cancellationToken)
    {
        await _categoryService.CreateAsync(notification.CreateCategory);
        await _unitOfWork.SaveChangesAsync();
    }
}
