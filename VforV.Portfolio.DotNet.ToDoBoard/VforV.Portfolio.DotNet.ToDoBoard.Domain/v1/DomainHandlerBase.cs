using AutoMapper;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Domain.Model.Common;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1;

public abstract class DomainHandlerBase
{
    protected readonly IEntityDbContext _dbContext;
    protected readonly IMapper _mapper;
    protected readonly ILogger _logger;

    protected DomainHandlerBase(
        IEntityDbContext dbContext,
        IMapper mapper,
        ILogger logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected void LogGetEntityAttempt<TEntity>(Guid identifier) where TEntity : class, IEntity
    {
        _logger.LogInformation($"Retrieving {typeof(TEntity)} (Identifier={identifier})");
    }

    protected void LogGetEntityFound<TEntity>(Guid identifier) where TEntity : class, IEntity
    {
        _logger.LogInformation($"Retrieved {typeof(TEntity)} successfully (Identifier={identifier})");
    }

    protected void LogGetEntityNotFound<TEntity>(Guid identifier) where TEntity : class, IEntity
    {
        _logger.LogInformation($"{typeof(TEntity)} not found (Identifier={identifier})");
    }

    protected void LogDomainDebug<TDomain>(TDomain domain) where TDomain : IDomain
    {
        _logger.LogDebug($"{typeof(TDomain)}: {domain}");
    }

    protected void LogEntityDebug<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        _logger.LogDebug($"{typeof(TEntity)}: {entity}");
    }
}