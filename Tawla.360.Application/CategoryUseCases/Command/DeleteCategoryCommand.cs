using MediatR;

namespace Tawla._360.Application.CategoryUseCases.Command;

public record class DeleteCategoryCommand(Guid Id):INotification;
