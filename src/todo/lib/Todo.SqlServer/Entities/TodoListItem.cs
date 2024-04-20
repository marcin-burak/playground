using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.SqlServer.Entities;

public sealed class TodoListItem
{
    public Guid Id { get; set; }

    public string Content { get; set; } = string.Empty;



    public Guid ListId { get; set; }

    public TodoList List { get; set; } = null!;
}

public sealed class TodoListItemConfiguration : IEntityTypeConfiguration<TodoListItem>
{
    public void Configure(EntityTypeBuilder<TodoListItem> builder)
    {
        builder.HasKey(todoListItem => todoListItem.Id).IsClustered(false);
    }
}