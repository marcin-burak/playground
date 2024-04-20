using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Common;

namespace Todo.SqlServer;

public static class DependencyInjection
{
    public static IServiceCollection AddSqlServerConfiguration(this IServiceCollection services, IConfiguration configuration) => services
        .AddOptionsByConvention<SqlServerOptions>()
        .AddSqlServer<TodoDatabaseContext>(configuration.TryGetOptionsByConvention<SqlServerOptions>()?.ConnectionString)
        .AddScoped<SqlServerInitialization>();
}
