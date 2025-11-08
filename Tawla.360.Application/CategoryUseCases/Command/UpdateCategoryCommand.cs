using MediatR;
using Tawla._360.Application.CategoryUseCases.Dto;

namespace Tawla._360.Application.CategoryUseCases.Command;

public record class UpdateCategoryCommand(UpdateCategoryDto UpdateCategoryDto):INotification;
