using System;
using AutoMapper;
using Tawla._360.Application.Attributes;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.Common.CommonMapperProfile;

public class TranslationToValueResolver<TEntity, TTranslation, TList>
    : IMappingAction<TEntity, TList>
    where TEntity : class, ITranslatedEntity<TTranslation>
    where TTranslation : EntityTranslation
{
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    private readonly string _lang;

    public TranslationToValueResolver(IHttpContextAccessorService httpContextAccessorService)
    {
        _httpContextAccessorService = httpContextAccessorService;
        _lang = _httpContextAccessorService.GetAcceptedLanguage();
    }

    public void Process(TEntity source, TList destination, ResolutionContext context)
    {
        var translatableProps = typeof(TList).GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(TranslatableAttribute)))
            .ToList();

        foreach (var prop in translatableProps)
        {
            var translation = source.Translations?
                .FirstOrDefault(t => t.PropertyName == prop.Name && t.LanguageCode == _lang);
            translation ??= source.Translations?
                   .FirstOrDefault(t => t.PropertyName == prop.Name);
            if (translation != null)
                prop.SetValue(destination, translation.Value);

        }
    }
}
