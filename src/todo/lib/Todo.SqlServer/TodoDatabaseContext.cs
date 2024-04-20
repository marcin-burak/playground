using Microsoft.EntityFrameworkCore;
using Todo.SqlServer.Entities;

namespace Todo.SqlServer;

public sealed class TodoDatabaseContext(DbContextOptions<TodoDatabaseContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }

    public DbSet<TodoList> TodoList { get; set; }

    public DbSet<TodoListItem> TodoListItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDatabaseContext).Assembly);
    }
}
