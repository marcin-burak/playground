using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Todo.SqlServer.Entities;

public sealed class TodoList
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;



    public IList<TodoListItem> Items { get; set; } = [];



    public Guid CreatedById { get; set; }

    public User CreatedBy { get; set; } = null!;
}

public sealed class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.HasKey(todoList => todoList.Id).IsClustered(false);
    }
}