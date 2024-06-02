using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Configuration;

public class PriorityEntityConfiguration : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        builder.ToTable(Constants.Db.Tables.Priority);

        builder.HasIndex(i => i.Title).IsUnique();
        builder.HasIndex(i => i.Value).IsUnique();
        builder.HasIndex(i => i.Identifier).IsUnique();
    }
}