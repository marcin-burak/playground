using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notes.Web.Dependencies.EntityFramework;

namespace Notes.Web.Initialization;

internal sealed class Initialize(
    IOptions<InitializationOptions> options,
    ApplicationContext databaseContext)
{
    private readonly IOptions<InitializationOptions> _options = options;
    private readonly ApplicationContext _databaseContext = databaseContext;

    public async ValueTask TryInitialize(CancellationToken cancellationToken)
    {
        if (_options.Value.InitializeOnStartup is false)
        {
            return;
        }

        await _databaseContext.Database.MigrateAsync(cancellationToken);
    }

    public static async Task TryInitialize(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        using var dependencyInjectionScope = serviceProvider.CreateScope();
        var initialize = dependencyInjectionScope.ServiceProvider.GetRequiredService<Initialize>();

        await initialize.TryInitialize(cancellationToken);
    }
}
