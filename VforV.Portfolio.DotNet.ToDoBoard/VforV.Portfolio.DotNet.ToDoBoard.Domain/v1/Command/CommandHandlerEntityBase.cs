using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using VforV.Portfolio.DotNet.ToDoBoard.Domain.Utility;
using VforV.Portfolio.DotNet.ToDoBoard.Entity;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.v1.Command;

public abstract class CommandHandlerEntityBase<TEntity> : CommandHandlerBase where TEntity : class, IEntity
{
    protected readonly IValidator<TEntity> _validator;

    protected CommandHandlerEntityBase(
        IEntityDbContext dbContext,
        IUnitOfWork<IEntityDbContext> unitOfWork,
        IMapper mapper,
        IValidator<TEntity> validator,
        ILogger logger)
        : base(dbContext, unitOfWork, mapper, logger)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    protected async Task ValidateAsync(
        TEntity entity,
        CancellationToken cancellationToken,
        bool isThrowingIfFailure = true)
    {
        var result = await _validator.ValidateAsync(entity, cancellationToken);
        if (result.IsValid)
            return;

        var errorPrefix = $"Validation failed for {typeof(TEntity)}.";
        var errorMessage = $"{errorPrefix} Errors: {string.Join(" | ", result.GetErrors())}";
        _logger.LogError(errorMessage);

        _logger.LogDebug($"{errorPrefix} Details: {string.Join(" | ", result.GetDebugErrors())}");

        if (!isThrowingIfFailure)
            return;

        throw DomainExceptionBuilder.EntityInvalid(errorMessage);
    }

    protected void LogCreateEntityAttempt()
    {
        _logger.LogInformation($"Attempting to create {typeof(TEntity)}");
    }

    protected void LogCreateEntitySuccess(TEntity entity)
    {
        var message = $"Created {typeof(TEntity)} successfully";

        if (entity is IEntityIdentifier entityIdentifier)
        {
            message += $" (Identifier={entityIdentifier.Identifier})";
        }

        _logger.LogInformation(message);
    }

    protected void LogUpdateEntityAttempt()
    {
        _logger.LogInformation($"Attempting to update {typeof(TEntity)}");
    }

    protected void LogUpdateEntitySuccess(TEntity entity)
    {
        var message = $"Updated {typeof(TEntity)} successfully";

        if (entity is IEntityIdentifier entityIdentifier)
        {
            message += $" (Identifier={entityIdentifier.Identifier})";
        }

        _logger.LogInformation(message);
    }

    protected void LogDeleteEntityAttempt(Guid? identifier)
    {
        var message = $"Attempting to delete {typeof(TEntity)}";

        if (identifier.HasValue)
        {
            message += $" (Identifier={identifier.Value})";
        }

        _logger.LogInformation(message);
    }

    protected void LogDeleteEntitySuccess(Guid? identifier)
    {
        var message = $"Deleted {typeof(TEntity)} successfully";

        if (identifier.HasValue)
        {
            message += $" (Identifier={identifier.Value})";
        }

        _logger.LogInformation(message);
    }
}