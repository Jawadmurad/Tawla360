using MediatR;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;

namespace Tawla._360.Application.ItemUseCases.Command;

public record class UpdateItemCommand(UpdateItemWithImageDto UpdateItem):INotification;

