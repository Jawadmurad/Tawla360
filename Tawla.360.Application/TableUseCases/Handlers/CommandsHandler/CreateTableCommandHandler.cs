using MediatR;
using Tawla._360.Application.TableUseCases.Commands;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.TableUseCases.Handlers.CommandsHandler;

public class CreateTableCommandHandler : INotificationHandler<CreateTableCommand>
{
    private readonly ITableService _tableService;
    private readonly IUnitOfWork _unitOfWork;
    public CreateTableCommandHandler(ITableService tableService,IUnitOfWork unitOfWork)
    {
        _tableService=tableService;
        _unitOfWork= unitOfWork;
    }
    public async Task Handle(CreateTableCommand notification, CancellationToken cancellationToken)
    {
        await _tableService.CreateAsync(notification.CreateTable);
        await _unitOfWork.SaveChangesAsync();
        
    }
}
