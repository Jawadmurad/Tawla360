using System;
using AutoMapper;
using Tawla._360.Application.Attributes;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.Static;
using Tawla._360.Domain.Entities.Base;

namespace Tawla._360.Application.Common.CommonMapperProfile;

public class TranslationValueResolver<TCreate, TEntity, TTranslation> 
    : IValueResolver<TCreate, TEntity, ICollection<TTranslation>> 
    where TTranslation : EntityTranslation, new()
{
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    private readonly string lang;

    public TranslationValueResolver(IHttpContextAccessorService httpContextAccessorService)
    {
        _httpContextAccessorService = httpContextAccessorService;
        var resId = _httpContextAccessorService.GetRestaurantId().Value;
        lang = DefaultLanguageProvider.Get(resId);
    }

    public ICollection<TTranslation> Resolve(
        TCreate source, 
        TEntity destination, 
        ICollection<TTranslation> destMember, 
        ResolutionContext context)
    {
        
        var translations = new List<TTranslation>();

        // Get all properties of the source DTO marked with [Translatable]
        var translatableProps = typeof(TCreate).GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(TranslatableAttribute)))
            .ToList();

        foreach (var prop in translatableProps)
        {
            var value = prop.GetValue(source)?.ToString();

            var translation = new TTranslation
            {
                PropertyName = prop.Name,
                Value = value,
                LanguageCode = lang
            };

            translations.Add(translation);
        }

        return translations;
    }
}

