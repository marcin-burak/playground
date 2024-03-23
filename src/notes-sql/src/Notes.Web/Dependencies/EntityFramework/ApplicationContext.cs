using Microsoft.EntityFrameworkCore;
using Notes.Web.Dependencies.EntityFramework.Entities;
using System.Reflection;

namespace Notes.Web.Dependencies.EntityFramework;

internal sealed class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Note> Note { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
