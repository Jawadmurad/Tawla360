using Tawla._360.Application.CategoryUseCases.Dto;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.ItemUseCases.Dtos;
using Tawla._360.Application.ItemUseCases.Dtos.Common;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ItemUseCases.Dtos.UpdateItemDtos;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ItemUseCases;

public class ItemProfile : TranslatedEntityProfile<Item, ItemTranslation, CreateItemDto, UpdateItemDto, ItemListDto, ItemDto, ItemListDto>
{
    public ItemProfile()
    {
        CreateMap<Item, ItemDto>()
        .ForMember(x => x.Category, opt => opt.MapFrom((src, dest, i, context) =>
        {
            return context.Mapper.Map<LiteCategoryDto>(src.Category);
        }))
        .AfterMap<TranslationToValueResolver<Item, ItemTranslation, ItemDto>>();
        CreateMap<ItemPrice, ItemPriceDto>();


        CreateMap<CreateItemDto, Item>()
        .ForMember(x => x.ModifierGroups, opt => opt.Ignore())
        // Handled manually via Service
        // Important: Handle Prices replacement or merging depending on your EF configuration. 
        // Often, for simple updates, we let EF handle the collection if configured, 
        // or we Ignore it here and handle it in the Service if we need "Replace" logic.
        // Assuming standard mapping for now:
        .ForMember(c => c.Translations,
               opt => opt.MapFrom<TranslationValueResolver<CreateItemDto, Item, ItemTranslation>>());
        CreateMap<ItemPriceDto, ItemPrice>();
        CreateMap<CreateItemWithImageDto, CreateItemDto>();





        CreateMap<UpdateItemDto, Item>()
    .ForMember(dest => dest.ModifierGroups, opt => opt.Ignore()) // Manual Sync
    .ForMember(dest => dest.Prices, opt => opt.Ignore())         // Manual Sync
    .ForMember(dest => dest.Translations,
        opt => opt.MapFrom<TranslationValueResolver<UpdateItemDto, Item, ItemTranslation>>());

        CreateMap<UpdateItemWithImageDto, UpdateItemDto>();

    }
}
