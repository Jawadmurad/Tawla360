using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Tawla._360.Application.ItemUseCases.Command;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Application.ModifierGroupUserCase;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Exceptions;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ItemUseCases.Handlers.CommandHandlers;

public class UpdateItemCommandHandler : INotificationHandler<UpdateItemCommand>
{
    private readonly IItemService _itemService;
    private readonly IModifierGroupService _modifierGroupService;
    private readonly IFileStorageService _fileStorageService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateItemCommandHandler(
    IItemService itemService,
    IModifierGroupService modifierGroupService,
    IFileStorageService fileStorageService,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    {
        _itemService = itemService;
        _modifierGroupService = modifierGroupService;
        _fileStorageService = fileStorageService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateItemCommand notification, CancellationToken cancellationToken)
    {
        var dto = notification.UpdateItem;

        // 1. Get Existing Item (Tracked) to check old image path
        var existingItem = await _itemService.FirstOrDefaultAsync(x => x.Id == dto.Id) ?? throw new NotFoundException(nameof(Item));
        // 2. Handle Image Logic
        string finalImagePath = existingItem.ImagePath;

        if (dto.DeleteExistingImage && !string.IsNullOrEmpty(existingItem.ImagePath))
        {
            await _fileStorageService.DeleteFileAsync(existingItem.ImagePath);
            finalImagePath = null;
        }

        if (dto.Image != null)
        {
            // If replacing, delete old one first
            if (!string.IsNullOrEmpty(finalImagePath))
                await _fileStorageService.DeleteFileAsync(finalImagePath);

            finalImagePath = await _fileStorageService.SaveFileAsync(dto.Image, nameof(Domain.Entities.MenuEntities.Item));
        }
        var updateDto = _mapper.Map<UpdateItemDto>(dto);
        updateDto.ImagePath = finalImagePath;
        _itemService.Update(updateDto);
        await _itemService.ReplacePricesAsync(updateDto.Id, dto.Prices);
        //await _modifierGroupService.SyncGroupsForItem(dto.Id, dto.ModifierGroups);
        await _unitOfWork.SaveChangesAsync();
    }
}
