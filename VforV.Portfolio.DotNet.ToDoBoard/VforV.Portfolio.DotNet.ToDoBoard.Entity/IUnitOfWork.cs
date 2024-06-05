namespace VforV.Portfolio.DotNet.ToDoBoard.Entity;

public interface IUnitOfWork<TDbContext>
    where TDbContext : class, IEntityDbContext
{
    Task CompleteAsync();

    Task CompleteAsync(CancellationToken cancellationToken);
}