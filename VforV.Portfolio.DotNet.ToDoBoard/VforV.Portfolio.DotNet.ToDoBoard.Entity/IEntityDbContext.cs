using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity;

public interface IEntityDbContext : IDisposable
{
    DbSet<Board> Boards { get; }
    DbSet<TaskItem> TaskItems { get; }

    DbSet<Priority> Priorities { get; }
    DbSet<Tag> Tags { get; }

    DbSet<User> Users { get; }

    EntityEntry Entry(object entity);
    DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;

    ChangeTracker ChangeTracker { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}