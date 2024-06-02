using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Configuration;

public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable(Constants.Db.Tables.Tag);

        builder.HasIndex(i => i.Title).IsUnique();
        builder.HasIndex(i => i.Identifier).IsUnique();
    }
}