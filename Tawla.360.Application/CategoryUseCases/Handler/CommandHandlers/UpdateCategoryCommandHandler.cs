using MediatR;
using Tawla._360.Application.CategoryUseCases.Command;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.CategoryUseCases.Handler.CommandHandlers;

public class UpdateCategoryCommandHandler : INotificationHandler<UpdateCategoryCommand>
{
    private readonly ICategoryService _categoryService;
    private readonly IUnitOfWork _unitOfWork;
    public async Task Handle(UpdateCategoryCommand notification, CancellationToken cancellationToken)
    {
        _categoryService.Update(notification.UpdateCategoryDto);
        await _unitOfWork.SaveChangesAsync();
    }
}
