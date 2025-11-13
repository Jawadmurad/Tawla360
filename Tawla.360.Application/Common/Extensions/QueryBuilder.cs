using System;
using System.Linq.Expressions;
using LinqKit;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.Common.Enums;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;

namespace Tawla._360.Application.Common.Extensions;

public static class QueryBuilder
{
    public static Expression<Func<T, bool>> BuildFilter<T>(this FilterGroup filterGroup, string langCode="ar")
    {
        // Start with "true" predicate if AND, "false" if OR
        var predicate = filterGroup.LogicalOperator.ToLower() switch
        {
            LogicalOperator.AND => PredicateBuilder.New<T>(true),
            LogicalOperator.OR => PredicateBuilder.New<T>(false),
            _ => throw new ArgumentException($"Unsupported logical operator: {filterGroup.LogicalOperator}")
        };

        // Handle filters in the group
        foreach (var filter in filterGroup.Filters)
        {
            var filterExpression = filter.BuildFilterExpression<T>(langCode);
            if (filterExpression != null)
            {
                predicate = filterGroup.LogicalOperator.ToLower() switch
                {
                    LogicalOperator.AND => predicate.And(filterExpression),
                    LogicalOperator.OR => predicate.Or(filterExpression),
                    _ => predicate
                };
            }
        }

        // Handle subgroups recursively
        foreach (var subgroup in filterGroup.SubGroups)
        {
            var subgroupPredicate = BuildFilter<T>(subgroup, langCode);
            predicate = filterGroup.LogicalOperator.ToLower() switch
            {
                LogicalOperator.AND => predicate.And(subgroupPredicate),
                LogicalOperator.OR => predicate.Or(subgroupPredicate),
                _ => predicate
            };
        }

        return predicate;
    }
    private static Expression<Func<T, bool>> BuildFilterExpression<T>(this Filter filter, string langCode="ar")
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        // Check if the type implements ITranslatedEntity<>
        var translatedInterface = typeof(T)
            .GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITranslatedEntity<>));

        bool isTranslatableField = translatedInterface != null &&
                                   typeof(T).GetProperty(filter.FieldName.ToPascalCase()) == null; // no direct property

        if (isTranslatableField)
        {
            // Build expression like:
            // x.Translations.Any(t => 
            //     t.PropertyName == "Name" &&
            //     t.LanguageCode == lang &&
            //     t.Value.Contains("abc")
            // )

            var translationType = translatedInterface.GetGenericArguments()[0];
            var translationsProp = Expression.Property(parameter, "Translations");
            var tParam = Expression.Parameter(translationType, "t");

            var propertyNameExpr = Expression.Equal(
                Expression.Property(tParam, nameof(EntityTranslation.PropertyName)),
                Expression.Constant(filter.FieldName.ToPascalCase())
            );

            // language filter (get from thread context or DI, for example)
            var lang = langCode;
            var langExpr = Expression.Equal(
                Expression.Property(tParam, nameof(EntityTranslation.LanguageCode)),
                Expression.Constant(lang)
            );

            // build the Value comparison
            var valueProp = Expression.Property(tParam, nameof(EntityTranslation.Value));
            Expression valueCheck = filter.FilterType.ToLower() switch
            {
                ExpressionOperator.EQ => Expression.Equal(valueProp, Expression.Constant(filter.FilterValue)),
                ExpressionOperator.CONTAINS => Expression.Call(
                    valueProp,
                    nameof(string.Contains),
                    Type.EmptyTypes,
                    Expression.Constant(filter.FilterValue)
                ),
                ExpressionOperator.STARTSWITH => Expression.Call(
                    valueProp,
                    nameof(string.StartsWith),
                    Type.EmptyTypes,
                    Expression.Constant(filter.FilterValue)
                ),
                ExpressionOperator.ENDSWITH => Expression.Call(
                    valueProp,
                    nameof(string.EndsWith),
                    Type.EmptyTypes,
                    Expression.Constant(filter.FilterValue)
                ),
                _ => throw new ArgumentException($"Unsupported filter type: {filter.FilterType}")
            };

            var combined = Expression.AndAlso(Expression.AndAlso(propertyNameExpr, langExpr), valueCheck);

            var anyLambda = Expression.Lambda(combined, tParam);
            var anyMethod = typeof(Enumerable)
                .GetMethods()
                .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                .MakeGenericMethod(translationType);

            var anyCall = Expression.Call(anyMethod, translationsProp, anyLambda);

            return Expression.Lambda<Func<T, bool>>(anyCall, parameter);
        }
        else
        {
            // Normal (non-translatable) property handling
            var property = Expression.Property(parameter, filter.FieldName.ToPascalCase());
            var constant = Expression.Constant(Convert.ChangeType(filter.FilterValue, property.Type));

            Expression body = filter.FilterType.ToLower() switch
            {
                ExpressionOperator.EQ => Expression.Equal(property, constant),
                ExpressionOperator.NEQ => Expression.NotEqual(property, constant),
                ExpressionOperator.GT => Expression.GreaterThan(property, constant),
                ExpressionOperator.GTE => Expression.GreaterThanOrEqual(property, constant),
                ExpressionOperator.LT => Expression.LessThan(property, constant),
                ExpressionOperator.LTE => Expression.LessThanOrEqual(property, constant),

                ExpressionOperator.CONTAINS => Expression.Call(property, nameof(string.Contains),
                    Type.EmptyTypes, Expression.Constant(filter.FilterValue.ToString(), typeof(string))),

                ExpressionOperator.STARTSWITH => Expression.Call(property, nameof(string.StartsWith),
                    Type.EmptyTypes, Expression.Constant(filter.FilterValue.ToString(), typeof(string))),

                ExpressionOperator.ENDSWITH => Expression.Call(property, nameof(string.EndsWith),
                    Type.EmptyTypes, Expression.Constant(filter.FilterValue.ToString(), typeof(string))),

                _ => throw new ArgumentException($"Unknown filter type: {filter.FilterType}")
            };

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    // private static Expression<Func<T, bool>> BuildFilterExpression<T>(this Filter filter)
    // {
    //     var parameter = Expression.Parameter(typeof(T), "x");
    //     var property = Expression.Property(parameter, filter.FieldName.ToPascalCase());
    //     var constant = Expression.Constant(Convert.ChangeType(filter.FilterValue,
    //         property.Type));

    //     Expression body = filter.FilterType.ToLower() switch
    //     {
    //         ExpressionOperator.EQ => Expression.Equal(property, constant),
    //         ExpressionOperator.NEQ => Expression.NotEqual(property, constant),
    //         ExpressionOperator.GT => Expression.GreaterThan(property, constant),
    //         ExpressionOperator.GTE => Expression.GreaterThanOrEqual(property, constant),
    //         ExpressionOperator.LT => Expression.LessThan(property, constant),
    //         ExpressionOperator.LTE => Expression.LessThanOrEqual(property, constant),

    //         ExpressionOperator.CONTAINS => Expression.Call(
    //             property,
    //             nameof(string.Contains),
    //             Type.EmptyTypes,
    //             Expression.Constant(filter.FilterValue.ToString(), typeof(string))
    //         ),

    //         ExpressionOperator.STARTSWITH => Expression.Call(
    //             property,
    //             nameof(string.StartsWith),
    //             Type.EmptyTypes,
    //             Expression.Constant(filter.FilterValue.ToString(), typeof(string))
    //         ),

    //         ExpressionOperator.ENDSWITH => Expression.Call(
    //             property,
    //             nameof(string.EndsWith),
    //             Type.EmptyTypes,
    //             Expression.Constant(filter.FilterValue.ToString(), typeof(string))
    //         ),

    //         _ => throw new ArgumentException($"Unknown filter type: {filter.FilterType}")
    //     };

    //     return Expression.Lambda<Func<T, bool>>(body, parameter);
    // }

    public static Func<IQueryable<T>, IOrderedQueryable<T>> BuildSorting<T>(
    this IEnumerable<SortModel> sortModels,
    string langCode="ar")
    {
        return query =>
        {
            IOrderedQueryable<T> orderedQuery = null!;
            bool first = true;

            var translatedInterface = typeof(T)
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITranslatedEntity<>));

            Type translationType = translatedInterface?.GetGenericArguments()[0];

            foreach (var sort in sortModels)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                Expression keySelector;

                var entityProperty = typeof(T).GetProperty(sort.Field.ToPascalCase());

                if (entityProperty != null || translatedInterface == null)
                {
                    // ✅ Normal property
                    keySelector = Expression.Property(parameter, sort.Field.ToPascalCase());
                }
                else
                {
                    // ✅ Translatable field (exists in Translations)
                    var translationsProp = Expression.Property(parameter, "Translations");
                    var tParam = Expression.Parameter(translationType!, "t");

                    // Build predicate for translation match:
                    // t.PropertyName == "Name" && t.LanguageCode == langCode
                    var propertyMatch = Expression.Equal(
                        Expression.Property(tParam, nameof(EntityTranslation.PropertyName)),
                        Expression.Constant(sort.Field.ToPascalCase())
                    );
                    var langMatch = Expression.Equal(
                        Expression.Property(tParam, nameof(EntityTranslation.LanguageCode)),
                        Expression.Constant(langCode)
                    );

                    var predicate = Expression.AndAlso(propertyMatch, langMatch);
                    var predicateLambda = Expression.Lambda(predicate, tParam);

                    // Get the .Value property from the matching translation
                    var valueSelector = Expression.Lambda(
                        Expression.Property(tParam, nameof(EntityTranslation.Value)),
                        tParam
                    );

                    // Build:
                    // x.Translations
                    //   .Where(t => t.PropertyName == "Name" && t.LanguageCode == lang)
                    //   .Select(t => t.Value)
                    //   .FirstOrDefault()
                    var whereMethod = typeof(Enumerable)
                        .GetMethods()
                        .First(m => m.Name == nameof(Enumerable.Where) && m.GetParameters().Length == 2)
                        .MakeGenericMethod(translationType!);

                    var selectMethod = typeof(Enumerable)
                        .GetMethods()
                        .First(m => m.Name == nameof(Enumerable.Select) && m.GetParameters().Length == 2)
                        .MakeGenericMethod(translationType!, typeof(string));

                    var firstOrDefaultMethod = typeof(Enumerable)
                        .GetMethods()
                        .First(m => m.Name == nameof(Enumerable.FirstOrDefault) && m.GetParameters().Length == 1)
                        .MakeGenericMethod(typeof(string));

                    var whereCall = Expression.Call(whereMethod, translationsProp, predicateLambda);
                    var selectCall = Expression.Call(selectMethod, whereCall, valueSelector);
                    var firstOrDefaultCall = Expression.Call(firstOrDefaultMethod, selectCall);

                    keySelector = firstOrDefaultCall;
                }

                // Build OrderBy / ThenBy dynamically
                var lambda = Expression.Lambda(keySelector, parameter);
                string methodName = first
                    ? (sort.SortDirection == SortDirection.Ascending ? "OrderBy" : "OrderByDescending")
                    : (sort.SortDirection == SortDirection.Ascending ? "ThenBy" : "ThenByDescending");

                query = (IQueryable<T>)typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), lambda.Body.Type)
                    .Invoke(null, new object[] { query, lambda })!;

                orderedQuery = (IOrderedQueryable<T>)query;
                first = false;
            }

            return orderedQuery ?? (IOrderedQueryable<T>)query;
        };
    }

}
