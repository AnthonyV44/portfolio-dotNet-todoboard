using Microsoft.EntityFrameworkCore;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Configuration;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model.Common;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity;

public class EntityDbContext : DbContext, IEntityDbContext
{
    public DbSet<Board> Boards => Set<Board>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    public DbSet<Priority> Priorities => Set<Priority>();
    public DbSet<Tag> Tags => Set<Tag>();

    public DbSet<User> Users => Set<User>();

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity => base.Set<TEntity>();

    public EntityDbContext()
        : base(new DbContextOptions<EntityDbContext>())
    {
    }

    public EntityDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await OnBeforeSavingAsync();

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseLazyLoadingProxies(false);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskItemEntityConfiguration).Assembly);
    }

    private Task OnBeforeSavingAsync()
    {
        var entityEntries = ChangeTracker.Entries();

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.Entity is IAudit)
            {
                var now = DateTime.UtcNow;
                switch (entityEntry.State)
                {
                    case EntityState.Modified:
                        // entityEntry.CurrentValues[Constants.Domain.Data.ModifiedOnDate] = now;

                        break;
                    case EntityState.Added:
                        // entityEntry.CurrentValues[Constants.Domain.Data.ModifiedOnDate] = now;
                        // entityEntry.CurrentValues[Constants.Domain.Data.CreatedOnDate] = now;

                        break;
                }
            }
        }

        return Task.CompletedTask;
    }
}