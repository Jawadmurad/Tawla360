using MediatR;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;

namespace Tawla._360.Application.ItemUseCases.Command;

public record class CreateItemCommand(CreateItemWithImageDto CreateItem):INotification;
