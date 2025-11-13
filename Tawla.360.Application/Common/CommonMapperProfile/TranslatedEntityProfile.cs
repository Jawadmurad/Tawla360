using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.Common.CommonMapperProfile;

public abstract class TranslatedEntityProfile<TEntity, TTranslation, TCreate, TUpdate, TList, TDetails, TLite>
    : MappingProfile<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, ITranslatedEntity<TTranslation>, new()
    where TTranslation : EntityTranslation, new()
    where TCreate : new()
    where TUpdate : new()
    where TList : new()
    where TDetails : new()
    where TLite : new()
{
    protected TranslatedEntityProfile()
    {
        CreateMap<TCreate, TEntity>()
    .ForMember(c => c.Translations,
               opt => opt.MapFrom<TranslationValueResolver<TCreate, TEntity, TTranslation>>());

        CreateMap<TEntity, TList>()
         .AfterMap<TranslationToValueResolver<TEntity, TTranslation, TList>>();
    }
}
