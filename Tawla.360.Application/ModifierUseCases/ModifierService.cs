using System;
using AutoMapper;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.ModifierUseCases.Dto;
using Tawla._360.Application.Services;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.ModifierUseCases;

public class ModifierService :  HasIdGenericService<Modifier, CreateModifierDto, UpdateModifierDto, ModifierListDto, ModifierDto, ModifierLiteDto>, IModifierService
{
    public ModifierService(IHasIdRepository<Modifier> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService) : base(repository, mapper, httpContextAccessorService)
    {
    }
}
