using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.SqlServer.Entities;

public sealed class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string FistName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;



    public IList<TodoList> Lists { get; set; } = [];
}

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id).IsClustered(false);
    }
}