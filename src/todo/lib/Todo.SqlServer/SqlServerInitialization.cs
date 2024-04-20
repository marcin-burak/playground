using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.SqlServer;

public sealed class SqlServerInitialization(TodoDatabaseContext context)
{
    private readonly TodoDatabaseContext _context = context;

    public async Task Init(CancellationToken cancellationToken)
    {
        await _context.Database.MigrateAsync(cancellationToken);
    }

    public static async Task Initialize(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var sqlServerInitialization = scope.ServiceProvider.GetRequiredService<SqlServerInitialization>();
        await sqlServerInitialization.Init(cancellationToken);
    }
}
