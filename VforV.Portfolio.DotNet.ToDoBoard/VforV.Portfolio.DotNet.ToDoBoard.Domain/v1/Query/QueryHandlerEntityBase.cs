using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Query;

public abstract class QueryHandlerEntityBase<TEntity> : QueryHandlerBase where TEntity : class, IEntity
{
    protected QueryHandlerEntityBase(IEntityDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger)
    {
    }

    protected async Task<TEntity?> GetAsync<T>(Guid identifier, CancellationToken cancellationToken)
        where T : class, TEntity, IEntityIdentifier
    {
        return await _dbContext
            .Set<T>()
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.Identifier == identifier, cancellationToken);
    }

    protected async Task<List<TEntity>> GetAsync(CancellationToken cancellationToken)
    {
        return await _dbContext
            .Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    protected async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _dbContext
            .Set<TEntity>()
            .Where(predicate)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    protected void LogGetEntityAttempt(Guid identifier)
    {
        _logger.LogInformation($"Retrieving {typeof(TEntity)} (Identifier={identifier})");
    }

    protected void LogGetEntityFound(Guid identifier)
    {
        _logger.LogInformation($"Retrieved {typeof(TEntity)} successfully (Identifier={identifier})");
    }

    protected void LogGetEntityNotFound(Guid identifier)
    {
        _logger.LogInformation($"{typeof(TEntity)} not found (Identifier={identifier})");
    }

    protected void LogEntityDebug(TEntity entity)
    {
        _logger.LogDebug($"{typeof(TEntity)}: {entity}");
    }
}