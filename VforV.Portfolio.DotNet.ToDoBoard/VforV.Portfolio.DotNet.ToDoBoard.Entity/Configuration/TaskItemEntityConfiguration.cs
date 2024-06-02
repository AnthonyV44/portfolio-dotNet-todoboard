using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Configuration;

public class TaskItemEntityConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable(Constants.Db.Tables.TaskItem);

        builder.HasIndex(i => i.Identifier).IsUnique();
        builder.HasIndex(i => new { i.Title, i.BoardId, i.OwnerId }).IsUnique();

        builder
            .HasOne(i => i.Owner)
            .WithMany(i => i.OwnedTaskItems)
            .HasForeignKey(i => i.OwnerId)
            .IsRequired();

        builder
            .HasOne(i => i.AssignedTo)
            .WithMany(i => i.AssignedTaskItems)
            .HasForeignKey(i => i.AssignedToId)
            .IsRequired(false);
    }
}