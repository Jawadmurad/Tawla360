using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using LinqKit;
using Tawla._360.Application.Attributes;
using Tawla._360.Application.Common.Dtos.QueryRequestDtos;
using Tawla._360.Application.Common.Extensions;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Domain.Entities.Base;
using Tawla._360.Domain.Interfaces.Entities;
using Tawla._360.Domain.Repositories;
using Tawla._360.Shared;

namespace Tawla._360.Application.Services;

public class GenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite> : IGenericService<TEntity, TCreate, TUpdate, TList, TDetails, TLite>
    where TEntity : class, new()
    where TCreate : class
    where TUpdate : class
    where TList : class
    where TDetails : class
    where TLite : class, new()
{
    protected readonly IHttpContextAccessorService _httpContextAccessorService;
    protected readonly IRepository<TEntity> _repository;
    protected readonly IMapper _mapper;
    protected ExpressionStarter<TEntity> serviceFilter;
    public GenericService(IRepository<TEntity> repository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService)
    {
        this.serviceFilter = PredicateBuilder.New<TEntity>(true);
        _repository = repository;
        _mapper = mapper;
        _httpContextAccessorService = httpContextAccessorService;
    }

    public virtual async Task<IReadOnlyList<TList>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsNoTrackingAsync();
        return _mapper.Map<IReadOnlyList<TList>>(entities);
    }

    public virtual Task<IReadOnlyList<TLite>> GetLiteAsync(Expression<Func<TEntity, bool>> filter = null)
    {

        var projection = GenerateProjectionExpression<TEntity, TLite>(_httpContextAccessorService.GetAcceptedLanguage());
        return _repository.Select(projection, AndServiceFilter(filter));
    }
    public Task<IReadOnlyList<DDT>> Select<DDT>(Expression<Func<TEntity, DDT>> projection, Expression<Func<TEntity, bool>> filter = null) where DDT : class, new()
    {
        return _repository.Select(projection, AndServiceFilter(filter));
    }
    public virtual async Task<TDetails> CreateAsync(TCreate createDto)
    {
        var entity = _mapper.Map<TEntity>(createDto);
        await CreateAsync(entity);
        return _mapper.Map<TDetails>(entity);
    }
    public virtual async Task CreateRange(IEnumerable<TCreate> dtos)
    {
        var entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
        await _repository.AddRangeAsync(entities);
    }
    protected virtual async Task CreateAsync(TEntity entity)
    {
        await _repository.AddAsync(entity);
    }
    public async Task<PagingResult<TList>> GetPagedAsync(QueryRequestDto query, params Expression<Func<TEntity, object>>[] includes)
    {
        var lang = _httpContextAccessorService.GetAcceptedLanguage();
        var filter = query?.FilterGroup?.BuildFilter<TEntity>(lang) ?? null;
        var orderBy = query?.Sort?.BuildSorting<TEntity>(_httpContextAccessorService.GetAcceptedLanguage()) ?? null;
        var pagedResult = await _repository.GetPagedAsync(query.Paging.PageNumber, query.Paging.PageSize, AndServiceFilter(filter), orderBy,includes);
        var mappedItems = _mapper.Map<List<TList>>(pagedResult.Data);
        return new PagingResult<TList>()
        {
            Data = mappedItems,
            Count = pagedResult.Count
        };
    }
    public virtual async Task<PagingResult<TList>> GetPagedAsync(QueryRequestDto query)
    {
        var lang = _httpContextAccessorService.GetAcceptedLanguage();
        var filter = query?.FilterGroup?.BuildFilter<TEntity>(lang) ?? null;
        var orderBy = query?.Sort?.BuildSorting<TEntity>(_httpContextAccessorService.GetAcceptedLanguage()) ?? null;
        var pagedResult = await _repository.GetPagedAsync(query.Paging.PageNumber, query.Paging.PageSize, AndServiceFilter(filter), orderBy);
        var mappedItems = _mapper.Map<List<TList>>(pagedResult.Data);
        return new PagingResult<TList>()
        {
            Data = mappedItems,
            Count = pagedResult.Count
        };
    }
    public async Task<PagingResult<TList>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null)
    {
        var pagedResult = await _repository.GetPagedAsync(pageNumber, pageSize, AndServiceFilter(filter));
        var mappedItems = _mapper.Map<List<TList>>(pagedResult.Data);
        return new PagingResult<TList>()
        {
            Data = mappedItems,
            Count = pagedResult.Count
        };
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        => _repository.AnyAsync(AndServiceFilter(filter));

    public Task<TKey> MaxAsync<TKey>(Expression<Func<TEntity, TKey>> selector, Expression<Func<TEntity, bool>> filter = null)
        => _repository.MaxAsync(selector, AndServiceFilter(filter));

    public Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> sumSelector, Expression<Func<TEntity, bool>> filter = null)
        => _repository.SumAsync(sumSelector, AndServiceFilter(filter));

    public Task<List<TValue>> GroupByAsync<TKey, TValue>(Expression<Func<TEntity, TKey>> groupBySelector, Expression<Func<IGrouping<TKey, TEntity>, TValue>> projection, Expression<Func<TEntity, bool>> filter = null)
        => _repository.GroupByAsync(groupBySelector, projection, AndServiceFilter(filter));

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        => _repository.CountAsync(AndServiceFilter(filter));

    public async Task<TDetails> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
    {
        var entity = await _repository.FirstOrDefaultAsync(AndServiceFilter(filter), includes);
        return _mapper.Map<TDetails>(entity);
    }

    public async Task<TDetails> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, string includes = null)
    {
        var entity = await _repository.FirstOrDefaultAsync(AndServiceFilter(filter), includes);
        return _mapper.Map<TDetails>(entity);
    }
    protected static Expression<Func<TEntity, TLite>> GenerateProjectionExpression<TEntity, TLite>(string languageCode)
    where TEntity : class
    where TLite : class, new()
    {
        var parameter = Expression.Parameter(typeof(TEntity), "e");
        var bindings = new List<MemberBinding>();

        // Check if entity implements ITranslatedEntity<>
        var isTranslatedEntity = typeof(TEntity).GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ITranslatedEntity<>));

        foreach (var destProp in typeof(TLite).GetProperties().Where(p => p.CanWrite))
        {
            Expression valueExpression = null;

            // Direct property mapping (non-translated)
            var sourceProp = typeof(TEntity).GetProperty(destProp.Name);
            if (sourceProp != null)
            {
                valueExpression = Expression.Property(parameter, sourceProp);
            }
            else if (isTranslatedEntity)
            {
                // Only handle [Translatable] properties
                var attr = destProp.GetCustomAttribute<TranslatableAttribute>();
                if (attr != null)
                {
                    var translationsProp = Expression.Property(parameter, "Translations");
                    var tParam = Expression.Parameter(typeof(EntityTranslation), "t");

                    // --- 1. Filter by property name ---
                    var propertyNameCondition = Expression.Equal(
                        Expression.Property(tParam, nameof(EntityTranslation.PropertyName)),
                        Expression.Constant(destProp.Name)
                    );

                    var whereLambda = Expression.Lambda<Func<EntityTranslation, bool>>(propertyNameCondition, tParam);

                    var whereCall = Expression.Call(
                        typeof(Enumerable),
                        nameof(Enumerable.Where),
                        new[] { typeof(EntityTranslation) },
                        translationsProp,
                        whereLambda
                    );

                    // --- 2. OrderBy: prioritize requested language first ---
                    var langEquals = Expression.Equal(
                        Expression.Property(tParam, nameof(EntityTranslation.LanguageCode)),
                        Expression.Constant(languageCode)
                    );

                    var conditional = Expression.Condition(
                        langEquals,
                        Expression.Constant(0),   // current language = top priority
                        Expression.Constant(1)    // others come after
                    );

                    var orderByLambda = Expression.Lambda<Func<EntityTranslation, int>>(conditional, tParam);

                    var orderByCall = Expression.Call(
                        typeof(Enumerable),
                        nameof(Enumerable.OrderBy),
                        new[] { typeof(EntityTranslation), typeof(int) },
                        whereCall,
                        orderByLambda
                    );

                    // --- 3. Select(t => t.Value) ---
                    var selectLambda = Expression.Lambda<Func<EntityTranslation, string>>(
                        Expression.Property(tParam, nameof(EntityTranslation.Value)),
                        tParam
                    );

                    var selectCall = Expression.Call(
                        typeof(Enumerable),
                        nameof(Enumerable.Select),
                        new[] { typeof(EntityTranslation), typeof(string) },
                        orderByCall,
                        selectLambda
                    );

                    // --- 4. Take first available translation ---
                    var firstOrDefaultCall = Expression.Call(
                        typeof(Enumerable),
                        nameof(Enumerable.FirstOrDefault),
                        new[] { typeof(string) },
                        selectCall
                    );

                    valueExpression = firstOrDefaultCall;
                }
            }

            if (valueExpression != null)
            {
                bindings.Add(Expression.Bind(destProp, valueExpression));
            }
        }

        var body = Expression.MemberInit(Expression.New(typeof(TLite)), bindings);
        return Expression.Lambda<Func<TEntity, TLite>>(body, parameter);
    }



    public virtual void Update(TUpdate updateDto)
    {
        var entity = _mapper.Map<TEntity>(updateDto);
        _repository.Update(entity);
    }
    private ExpressionStarter<TEntity> AndServiceFilter(Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter == null)
            return serviceFilter;
        return serviceFilter.And(filter);
    }


}