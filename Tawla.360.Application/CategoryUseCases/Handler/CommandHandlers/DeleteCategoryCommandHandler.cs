using System;
using MediatR;
using Tawla._360.Application.CategoryUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.CategoryUseCases.CommandHandlers.Handler;

public class DeleteCategoryCommandHandler : INotificationHandler<DeleteCategoryCommand>
{
    private readonly ICategoryService _categoryService;
    private readonly IUnitOfWork _unitOfWork;
    public async Task Handle(DeleteCategoryCommand notification, CancellationToken cancellationToken)
    {
        await _categoryService.Delete(notification.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
