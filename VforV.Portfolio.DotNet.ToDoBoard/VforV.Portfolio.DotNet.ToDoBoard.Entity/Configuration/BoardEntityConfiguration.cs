using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Configuration;

public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.ToTable(Constants.Db.Tables.Board);

        builder.HasIndex(i => i.Identifier).IsUnique();
        builder.HasIndex(i => new { i.Title, i.OwnerId }).IsUnique();

        builder
            .HasOne(i => i.Owner)
            .WithMany(i => i.OwnedBoards)
            .HasForeignKey(i => i.OwnerId)
            .IsRequired();
    }
}