using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain;

public static class DomainExceptionBuilder
{
    public static DomainException EntityNotFound<TEntity>(Guid identifier) where TEntity : IEntity
    {
        return new DomainException($"{typeof(TEntity)} not found (Identifier={identifier})");
    }

    public static DomainException EntityInvalid(string message)
    {
        return new DomainException(message);
    }
}