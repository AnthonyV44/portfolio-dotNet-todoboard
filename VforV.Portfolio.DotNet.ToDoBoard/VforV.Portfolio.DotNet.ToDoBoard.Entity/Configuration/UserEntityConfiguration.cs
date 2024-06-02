using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VforV.Portfolio.DotNet.ToDoBoard.Entity.Model;

namespace VforV.Portfolio.DotNet.ToDoBoard.Entity.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Constants.Db.Tables.User);

        builder.HasIndex(i => i.Identifier).IsUnique();
        builder.HasIndex(i => i.EmailAddress).IsUnique();
        builder.HasIndex(i => new { i.FirstName, i.LastName }).IsUnique();
    }
}