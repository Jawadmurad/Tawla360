using System;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Repositories;

namespace Tawla._360.Application.Static;

public static class DefaultLanguageProvider
{
    private static Dictionary<Guid, string> _restaurantLanguages = new();
    private static readonly object _lock = new();

    public static void Initialize(IRepository<Restaurant> repository)
    {
        lock (_lock)
        {
            if (_restaurantLanguages.Count > 0) return;
            _restaurantLanguages = repository.Select(c => new { c.Id, c.InsertionDefaultLanguage }).GetAwaiter().GetResult().ToDictionary(c => c.Id, c => c.InsertionDefaultLanguage);
        }
    }

    public static string Get(Guid restaurantId)
    {
        if (_restaurantLanguages.TryGetValue(restaurantId, out var lang))
            return lang.Trim();
        return "en"; // fallback
    }
    public static void AddOrUpdate(Guid restaurantId, string language)
    {
        lock (_lock)
        {
            _restaurantLanguages[restaurantId] = language ?? "en";
        }
    }

    public static void Remove(Guid restaurantId)
    {
        lock (_lock)
        {
            _restaurantLanguages.Remove(restaurantId);
        }
    }

}
