using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ModifierGroupUserCase;

public class ModifierGroupService : HasIdGenericService<ModifierGroup, CreateModifierGroupDto, UpdateModifierGroupDto, ModifierGroupListDto, ModifierGroupListDto, ModifierGroupListDto>, IModifierGroupService
{
    public ModifierGroupService(IHasIdRepository<ModifierGroup> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
    public override Task CreateRange(IEnumerable<CreateModifierGroupDto> dtos)
    {
        var entities = new List<ModifierGroup>();

        foreach (var createDto in dtos)
        {
            // 1. Map the main entity
            var entity = _mapper.Map<ModifierGroup>(createDto);

            // 2. Prepare the list for Options
            entity.Options = new List<ModifierOption>();

            // 3. Logic for Existing Modifiers (Has ModifierId)
            var existsModifier = createDto.Options.Where(x => x.ModifierId.HasValue);
            entity.Options.AddRange(existsModifier.Select(x => new ModifierOption()
            {
                DisplayOrder = x.DisplayOrder,
                Id = Guid.NewGuid(),
                ModifierId = x.ModifierId.Value,
                ModifierOptionPrices = x.PriceChanges.Select(pc => new ModifierOptionPrice()
                {
                    BranchId = pc.BranchId,
                    PriceChange = pc.PriceChange
                }).ToList()
            }));

            // 4. Logic for New Modifiers (No ModifierId)
            var newModifier = createDto.Options.Where(x => !x.ModifierId.HasValue);
            entity.Options.AddRange(newModifier.Select(x => new ModifierOption()
            {
                DisplayOrder = x.DisplayOrder,
                Id = Guid.NewGuid(),
                Modifier = _mapper.Map<Modifier>(new CreateModifierDto()
                {
                    Name = x.Name
                }),
                ModifierOptionPrices = x.PriceChanges?.Select(pc => new ModifierOptionPrice()
                {
                    BranchId = pc.BranchId,
                    PriceChange = pc.PriceChange
                }).ToList()
            }));

            entities.Add(entity);

        }
        return _repository.AddRangeAsync(entities);
    }
    public override async Task<ModifierGroupListDto> CreateAsync(CreateModifierGroupDto createDto)
    {
        var entity = _mapper.Map<ModifierGroup>(createDto);
        var existsModifier = createDto.Options.Where(x => x.ModifierId.HasValue);
        entity.Options = new List<ModifierOption>();
        entity.Options.AddRange(existsModifier.Select(x => new ModifierOption()
        {
            DisplayOrder = x.DisplayOrder,
            Id = Guid.NewGuid(),
            ModifierId = x.ModifierId.Value,
            ModifierOptionPrices = x.PriceChanges.Select(x => new ModifierOptionPrice()
            {
                BranchId = x.BranchId,
                PriceChange = x.PriceChange
            }).ToList()
        }));
        var newModifier = createDto.Options.Where(x => !x.ModifierId.HasValue);
        entity.Options.AddRange(newModifier.Select(x => new ModifierOption()
        {
            DisplayOrder = x.DisplayOrder,
            Id = Guid.NewGuid(),
            Modifier = _mapper.Map<Modifier>(new CreateModifierDto()
            {
                Name = x.Name
            }),
            ModifierOptionPrices = x.PriceChanges.Select(x => new ModifierOptionPrice()
            {
                BranchId = x.BranchId,
                PriceChange = x.PriceChange
            }).ToList()

        }));
        await CreateAsync(entity);
        return _mapper.Map<ModifierGroupListDto>(entity);
    }



    public async Task SyncGroupsForItem(Guid itemId, List<UpdateItemModifierGroupDto> incomingGroups)
    {
        var existingGroups = await _repository.GetAllAsync(c=>c.ItemId==itemId,null,$"{nameof(ModifierGroup.Options)}.{nameof(ModifierOption.Modifier)}");
        if (incomingGroups == null || !incomingGroups.Any())
        {
            if (existingGroups.Any())
                _repository.DeleteRange(existingGroups);
            return;
        }

        var incomingGroupIds = incomingGroups
            .Where(x => x.Id.HasValue)
            .Select(x => x.Id.Value)
            .ToList();

        var groupsToDelete = existingGroups
            .Where(x => !incomingGroupIds.Contains(x.Id))
            .ToList();

        if (groupsToDelete.Any())
        {
            _repository.DeleteRange(groupsToDelete);
        }

        // -----------------------------------------------------------
        // B. Upsert Groups (Insert / Update)
        // -----------------------------------------------------------
        foreach (var groupDto in incomingGroups)
        {
            if (groupDto.Id.HasValue)
            {
                // === UPDATE EXISTING GROUP ===
                var existingGroup = existingGroups.FirstOrDefault(x => x.Id == groupDto.Id.Value);
                if (existingGroup != null)
                {
                    // 1. Map Scalars & Translations
                    // This triggers your TranslationValueResolver for the Group's Name
                    _mapper.Map(groupDto, existingGroup);

                    // 2. Sync Options
                    SyncOptions(existingGroup, groupDto.Options);
                }
            }
            else
            {
                // === INSERT NEW GROUP ===
                // 1. Map New Group (Triggers Translation Resolver)
                var newGroup = _mapper.Map<ModifierGroup>(groupDto);
                newGroup.ItemId = itemId;

                // 2. Build Options Manually
                // We do this manually to ensure correct Modifier creation/linking logic
                newGroup.Options = new List<ModifierOption>();
                if (groupDto.Options != null)
                {
                    foreach (var optDto in groupDto.Options)
                    {
                        newGroup.Options.Add(CreateNewOption(optDto));
                    }
                }

                await _repository.AddAsync(newGroup);
            }
        }
    }

    // ------------------------------------------------------------------
    // Helper: Sync Options
    // ------------------------------------------------------------------
    private void SyncOptions(ModifierGroup group, List<UpdateModifierGroupOptionDto> optionDtos)
    {
        if (optionDtos == null) optionDtos = new List<UpdateModifierGroupOptionDto>();

        var currentOptions = group.Options.ToList();
        var incomingOptionIds = optionDtos
            .Where(x => x.Id.HasValue)
            .Select(x => x.Id.Value)
            .ToList();

        // 1. Delete Removed Options
        // EF Core Cascade Delete will handle the DB delete when removed from collection
        var optionsToDelete = currentOptions
            .Where(o => !incomingOptionIds.Contains(o.Id))
            .ToList();

        foreach (var opt in optionsToDelete)
        {
            group.Options.Remove(opt);
        }

        // 2. Upsert Options
        foreach (var optDto in optionDtos)
        {
            if (optDto.Id.HasValue)
            {
                // -- Update Existing Option --
                var existingOpt = currentOptions.FirstOrDefault(o => o.Id == optDto.Id.Value);
                if (existingOpt != null)
                {
                    existingOpt.DisplayOrder = optDto.DisplayOrder;

                    // Handle Modifier Link vs Name Update
                    if (optDto.ModifierId.HasValue)
                    {
                        // Switching to a specific existing Modifier
                        if (existingOpt.ModifierId != optDto.ModifierId.Value)
                        {
                            existingOpt.ModifierId = optDto.ModifierId.Value;
                            // We do not update the Modifier entity itself, just the link
                        }
                    }

                    // Sync Prices
                    SyncOptionPrices(existingOpt, optDto.PriceChanges);
                }
            }
            else
            {
                // -- Insert New Option --
                var newOpt = CreateNewOption(optDto);
                group.Options.Add(newOpt);
            }
        }
    }

    // ------------------------------------------------------------------
    // Helper: Create New Option
    // ------------------------------------------------------------------
    private ModifierOption CreateNewOption(UpdateModifierGroupOptionDto dto)
    {
        var opt = new ModifierOption
        {
            Id = Guid.NewGuid(),
            DisplayOrder = dto.DisplayOrder,
            ModifierOptionPrices = dto.PriceChanges?.Select(pc => new ModifierOptionPrice
            {
                BranchId = pc.BranchId,
                PriceChange = pc.PriceChange
            }).ToList() ?? new List<ModifierOptionPrice>()
        };

        if (dto.ModifierId.HasValue)
        {
            // Case A: Link to an existing Modifier (e.g. "Cheese")
            opt.ModifierId = dto.ModifierId.Value;
        }
        else
        {
            // Case B: Create a brand new Modifier (e.g. "Special Sauce")
            // We use the Mapper to create the Modifier from the DTO.
            // We simulate a CreateModifierDto to trigger the TranslationValueResolver correctly.

            var createModifierDto = new CreateModifierDto { Name = dto.Name };
            opt.Modifier = _mapper.Map<Modifier>(createModifierDto);
        }

        return opt;
    }

    // ------------------------------------------------------------------
    // Helper: Sync Prices (Standard Branch Match)
    // ------------------------------------------------------------------
    private void SyncOptionPrices(ModifierOption option, List<CreateItemModifierPriceChange> priceChanges)
    {
        // Ensure collection is not null
        if (option.ModifierOptionPrices == null)
            option.ModifierOptionPrices = new List<ModifierOptionPrice>();

        var existingPrices = option.ModifierOptionPrices.ToList();

        if (priceChanges == null || !priceChanges.Any())
        {
            option.ModifierOptionPrices.Clear();
            return;
        }

        // Match by BranchId
        var incomingBranchIds = priceChanges.Select(p => p.BranchId).ToList();

        // 1. Delete
        var toRemove = existingPrices
            .Where(p => !incomingBranchIds.Contains(p.BranchId))
            .ToList();

        foreach (var item in toRemove)
            option.ModifierOptionPrices.Remove(item);

        // 2. Upsert
        foreach (var pc in priceChanges)
        {
            var existing = option.ModifierOptionPrices
                .FirstOrDefault(x => x.BranchId == pc.BranchId);

            if (existing != null)
            {
                existing.PriceChange = pc.PriceChange;
            }
            else
            {
                option.ModifierOptionPrices.Add(new ModifierOptionPrice
                {
                    BranchId = pc.BranchId,
                    PriceChange = pc.PriceChange
                });
            }
        }
    }
}
