using System;
using Tawla._360.Application.Common.CommonMapperProfile;
using Tawla._360.Application.ModifierGroupUserCase.Dtos;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Application.ModifierUseCases;

public class ModifierProfile : TranslatedEntityProfile<Modifier, ModifierTranslation, CreateModifierDto, UpdateModifierDto, ModifierListDto, ModifierDto, ModifierLiteDto>
{
    
}
