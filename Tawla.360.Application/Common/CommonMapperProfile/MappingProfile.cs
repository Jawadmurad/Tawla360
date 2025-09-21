using System;
using AutoMapper;

namespace Tawla._360.Application.Common.CommonMapperProfile;

public abstract class MappingProfile<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : Profile
{
    protected MappingProfile()
    {
        CreateMap<TCreate, TEntity>();
        CreateMap<TUpdate, TEntity>();
        CreateMap<TEntity, TList>();
        CreateMap<TEntity, TDetails>();
        CreateMap<TEntity, TLite>();
    }
}
