using System;
using System.Linq.Expressions;
using LinqKit;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.Common.Enums;

namespace Tawla._360.Application.Common.Extensions;

public static class QueryBuilder
{
    public static Expression<Func<T, bool>> BuildFilter<T>(this FilterGroup filterGroup)
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
            var filterExpression = filter.BuildFilterExpression<T>();
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
            var subgroupPredicate = BuildFilter<T>(subgroup);
            predicate = filterGroup.LogicalOperator.ToLower() switch
            {
                LogicalOperator.AND => predicate.And(subgroupPredicate),
                LogicalOperator.OR => predicate.Or(subgroupPredicate),
                _ => predicate
            };
        }

        return predicate;
    }

    private static Expression<Func<T, bool>> BuildFilterExpression<T>(this Filter filter)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, filter.FieldName.ToPascalCase());
        var constant = Expression.Constant(Convert.ChangeType(filter.FilterValue,
            property.Type));

        Expression body = filter.FilterType.ToLower() switch
        {
            ExpressionOperator.EQ => Expression.Equal(property, constant),
            ExpressionOperator.NEQ => Expression.NotEqual(property, constant),
            ExpressionOperator.GT => Expression.GreaterThan(property, constant),
            ExpressionOperator.GTE => Expression.GreaterThanOrEqual(property, constant),
            ExpressionOperator.LT => Expression.LessThan(property, constant),
            ExpressionOperator.LTE => Expression.LessThanOrEqual(property, constant),

            ExpressionOperator.CONTAINS => Expression.Call(
                property,
                nameof(string.Contains),
                Type.EmptyTypes,
                Expression.Constant(filter.FilterValue.ToString(), typeof(string))
            ),

            ExpressionOperator.STARTSWITH => Expression.Call(
                property,
                nameof(string.StartsWith),
                Type.EmptyTypes,
                Expression.Constant(filter.FilterValue.ToString(), typeof(string))
            ),

            ExpressionOperator.ENDSWITH => Expression.Call(
                property,
                nameof(string.EndsWith),
                Type.EmptyTypes,
                Expression.Constant(filter.FilterValue.ToString(), typeof(string))
            ),

            _ => throw new ArgumentException($"Unknown filter type: {filter.FilterType}")
        };

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    public static Func<IQueryable<T>, IOrderedQueryable<T>> BuildSorting<T>(this IEnumerable<SortModel> sortModels)
    {
        return query =>
        {
            IOrderedQueryable<T> orderedQuery = null!;
            bool first = true;

            foreach (var sort in sortModels)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Property(parameter, sort.Field.ToPascalCase());
                var lambda = Expression.Lambda(property, parameter);

                string methodName = first
                    ? (sort.SortDirection == SortDirection.Ascending ? "OrderBy" : "OrderByDescending")
                    : (sort.SortDirection == SortDirection.Ascending ? "ThenBy" : "ThenByDescending");

                query = (IQueryable<T>)typeof(Queryable).GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), property.Type)
                    .Invoke(null, new object[] { query, lambda })!;

                orderedQuery = (IOrderedQueryable<T>)query;
                first = false;
            }

            return orderedQuery ?? (IOrderedQueryable<T>)query;
        };
    }
}
