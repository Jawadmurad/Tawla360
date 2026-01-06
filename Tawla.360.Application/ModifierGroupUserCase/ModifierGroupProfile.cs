using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.ItemUseCases.Dtos.CreateItemDtos;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ModifierGroupUserCase;

public class ModifierGroupProfile:TranslatedEntityProfile<ModifierGroup,ModifierGroupTranslation,CreateModifierGroupDto,UpdateModifierGroupDto,ModifierGroupListDto,ModifierGroupDto,ModifierGroup>
{
    public ModifierGroupProfile()
    {
        CreateMap<CreateItemModifierGroupDto,CreateModifierGroupDto>();
        CreateMap<CreateModifierGroupDto,ModifierGroup>()
        .ForMember(x=>x.Options,opt=>opt.Ignore());
        CreateMap<ModifierOption,ModifierOptionDto>();
        CreateMap<ModifierOptionPrice,ModifierOptionPriceDto>();
    }
}
