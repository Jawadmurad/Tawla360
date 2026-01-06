using System;
using AutoMapper;
using MediatR;
using Tawla._360.Application.ItemUseCases.Command;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ModifierGroupUserCase;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ItemUseCases.Handlers.CommandHandlers;

public class CreateItemCommandHandler : INotificationHandler<CreateItemCommand>
{
    private readonly IItemService _itemService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IModifierGroupService _modifierGroupService;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;
    public CreateItemCommandHandler(IItemService itemService,IFileStorageService fileStorageService,IUnitOfWork unitOfWork,IMapper mapper,IModifierGroupService modifierGroupService)
    {
        _unitOfWork = unitOfWork;
        _itemService = itemService;
        _fileStorageService = fileStorageService;
        _mapper=mapper;
        _modifierGroupService=modifierGroupService;
    }
    public async Task Handle(CreateItemCommand notification, CancellationToken cancellationToken)
    {
        var imagePath = string.Empty;
        if (notification.CreateItem.Image != null)
            imagePath = await _fileStorageService.SaveFileAsync(notification.CreateItem.Image, nameof(Domain.Entities.MenuEntities.Item));
        var createItemDto = _mapper.Map<CreateItemDto>(notification.CreateItem);
        createItemDto.ImagePath = imagePath;
        var item =await _itemService.CreateAsync(createItemDto);
        var modifierGroups= createItemDto.ModifierGroups.Select(c=>_mapper.Map<CreateModifierGroupDto>(c)).ToList();
        modifierGroups.ForEach(x=>x.ItemId=item.Id);
        await _modifierGroupService.CreateRange(modifierGroups);
        await _unitOfWork.SaveChangesAsync();
    }
}
