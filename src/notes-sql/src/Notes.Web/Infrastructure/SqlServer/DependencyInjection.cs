using Notes.Web.Dependencies.EntityFramework;
using Notes.Web.Dependencies.Options;

namespace Notes.Web.Infrastructure.SqlServer;

internal static class DependencyInjection
{
    public static IServiceCollection AddSqlServerConfiguration(this IServiceCollection services, IConfiguration configuration) => services
        .AddOptionsByConvention<SqlServerOptions, SqlServerOptionsValidation>()
        .AddSqlServer<ApplicationContext>(configuration.TryGetOptions<SqlServerOptions>()?.ConnectionString);
}
